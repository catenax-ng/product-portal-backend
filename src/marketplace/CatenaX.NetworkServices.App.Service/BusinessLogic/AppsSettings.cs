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

using CatenaX.NetworkServices.PortalBackend.PortalEntities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CatenaX.NetworkServices.App.Service.BusinessLogic;

/// <summary>
/// Config Settings for Apps
/// </summary>
public class AppsSettings
{
    /// <summary>
    /// Company Admin Roles
    /// </summary>
    /// <value></value>
    [Required]
    public IDictionary<string,IEnumerable<string>> CompanyAdminRoles { get; set; } = null!;

    /// <summary>
    /// Notification Type Id
    /// </summary>
    /// <value></value>
    [Required]
    public IEnumerable<NotificationTypeId> NotificationTypeIds { get; set; } = null!;
    
    /// <summary>
    /// Document Type Id
    /// </summary>
    /// <value></value>
    [Required]
    public IEnumerable<DocumentTypeId> DocumentTypeIds { get; set; } = null!;

    /// <summary>
    /// BasePortalAddress url required for subscription email 
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public string BasePortalAddress { get; init; } = null!;
}

/// <summary>
/// App Settings extension class.
/// </summary>
public static class AppsSettingsExtension
{
    /// <summary>
    /// configure apps settings using service collection interface
    /// </summary>
    public static IServiceCollection ConfigureAppsSettings(
        this IServiceCollection services,
        IConfigurationSection section)
    {
        services.AddOptions<AppsSettings>()
            .Bind(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return services;
    }
}
