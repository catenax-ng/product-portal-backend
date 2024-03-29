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

using Org.CatenaX.Ng.Portal.Backend.Framework.ErrorHandling;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Org.CatenaX.Ng.Portal.Backend.Keycloak.ErrorHandling;

public class FlurlErrorHandler
{
    public static void ConfigureErrorHandler(ILogger logger, bool debugEnabled)
    {
        FlurlHttp.Configure(settings => settings.OnError = (call) =>
        {
            var message = $"{call.HttpResponseMessage?.ReasonPhrase ?? "ReasonPhrase is null"}: {call.HttpRequestMessage.RequestUri}";

            if (debugEnabled)
            {
                var request = call.HttpRequestMessage == null ? "" : $"{call.HttpRequestMessage.Method} {call.HttpRequestMessage.RequestUri} HTTP/{call.HttpRequestMessage.Version}\n{call.HttpRequestMessage.Headers}\n";
                var requestBody = call.RequestBody == null ? "\n" : call.RequestBody.ToString() + "\n\n";
                var response = call.HttpResponseMessage == null ? "" : call.HttpResponseMessage.ReasonPhrase + "\n";
                var responseContent = call.HttpResponseMessage?.Content == null ? "" : call.HttpResponseMessage.Content.ReadAsStringAsync().Result + "\n";
                logger.LogError(call.Exception, request + requestBody + response + responseContent);
            }
            else
            {
                logger.LogError(call.Exception, message);
            }

            if (call.HttpResponseMessage != null)
            {
                switch (call.HttpResponseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new KeycloakEntityNotFoundException(message, call.Exception);

                    case HttpStatusCode.Conflict:
                        throw new KeycloakEntityConflictException(message, call.Exception);

                    case HttpStatusCode.BadRequest:
                        throw new ArgumentException(message, call.Exception);

                    default:
                        throw new ServiceException(message, call.Exception, call.HttpResponseMessage.StatusCode);
                }
            }
        });
    }
}
