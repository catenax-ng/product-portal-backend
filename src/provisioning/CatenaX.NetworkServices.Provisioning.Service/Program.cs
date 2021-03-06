/********************************************************************************
 * Copyright (c) 2021,2022 BMW Group AG
 * Copyright (c) 2021,2022 Contributors to the CatenaX (ng) GitHub Organisation.
 *
 * See the NOTICE file(s) distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Apache License, Version 2.0 which is available at
 * https://www.apache.org/licenses/LICENSE-2.0.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 * SPDX-License-Identifier: Apache-2.0
 ********************************************************************************/

using CatenaX.NetworkServices.Framework.Cors;
using CatenaX.NetworkServices.Framework.ErrorHandling;
using CatenaX.NetworkServices.Framework.Swagger;
using CatenaX.NetworkServices.Keycloak.Authentication;
using CatenaX.NetworkServices.Keycloak.ErrorHandling;
using CatenaX.NetworkServices.Keycloak.Factory;
using CatenaX.NetworkServices.Keycloak.Factory.Utils;
using CatenaX.NetworkServices.Provisioning.DBAccess;
using CatenaX.NetworkServices.Provisioning.Library;
using CatenaX.NetworkServices.Provisioning.ProvisioningEntities;
using CatenaX.NetworkServices.Provisioning.Service.BusinessLogic;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;

using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

var VERSION = "v2";
var TAG = typeof(Program).Namespace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Kubernetes")
{
    var provider = new PhysicalFileProvider("/app/secrets");
    builder.Configuration.AddJsonFile(provider, "appsettings.json", optional: false, reloadOnChange: false);
}

builder.Services.AddCors(options => options.SetupCors(builder.Configuration));

builder.Services.AddControllers()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

builder.Services.AddSwaggerGen(c => SwaggerGenConfiguration.SetupSwaggerGen(c, VERSION, TAG));

builder.Services.AddAuthentication(x => {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options => {
                    builder.Configuration.Bind("JwtBearerOptions", options);
                    if (!options.RequireHttpsMetadata)
                    {
                        options.BackchannelHttpHandler = new HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                        };
                    }
                });

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddTransient<IClaimsTransformation, KeycloakClaimsTransformation>()
                .Configure<JwtBearerOptions>(options => builder.Configuration.Bind("JwtBearerOptions",options));

builder.Services.AddTransient<IIdentityProviderBusinessLogic,IdentityProviderBusinessLogic>()
                .AddTransient<IClientBusinessLogic,ClientBusinessLogic>()
                .AddTransient<IKeycloakFactory, KeycloakFactory>()
                .AddTransient<IProvisioningManager, ProvisioningManager>()
                .ConfigureKeycloakSettingsMap(builder.Configuration.GetSection("Keycloak"))
                .ConfigureProvisioningSettings(builder.Configuration.GetSection("Provisioning"));

builder.Services.AddTransient<IProvisioningDBAccess, ProvisioningDBAccess>();

builder.Services.AddDbContext<ProvisioningDBContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("ProvidioningDB")));


var app = builder.Build();

var debugEnabled = app.Configuration.GetValue<bool?>("DebugEnabled") != null && app.Configuration.GetValue<bool>("DebugEnabled");
if (debugEnabled)
{
    app.UseDeveloperExceptionPage();
    KeycloakUntrustedCertExceptionHandler.ConfigureExceptions(app.Configuration.GetSection("Keycloak"));
}
FlurlErrorHandler.ConfigureErrorHandler(app.Services.GetRequiredService<ILogger<Program>>(), debugEnabled);

if (app.Configuration.GetValue<bool?>("SwaggerEnabled") != null && app.Configuration.GetValue<bool>("SwaggerEnabled"))
{
    app.UseSwagger( c => c.RouteTemplate = "/api/provisioning/swagger/{documentName}/swagger.{json|yaml}");
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint(string.Format("/api/provisioning/swagger/{0}/swagger.json",VERSION), string.Format("{0} {1}",TAG,VERSION));
        c.RoutePrefix = "api/provisioning/swagger";
    });
}

app.UseRouting();

app.UseCors(CorsExtensions.AllowSpecificOrigins);

app.UseMiddleware<GeneralHttpErrorHandler>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
