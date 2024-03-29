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

using Org.CatenaX.Ng.Portal.Backend.PortalBackend.DBAccess.Models;
using Org.CatenaX.Ng.Portal.Backend.Provisioning.Library.Enums;
using System.Text.Json.Serialization;

namespace Org.CatenaX.Ng.Portal.Backend.Administration.Service.Models;

public class ServiceAccountDetails
{
    public ServiceAccountDetails(Guid serviceAccountId, string clientId, string name, string description, IamClientAuthMethod iamClientAuthMethod, IEnumerable<UserRoleData> userRoleDatas)
    {
        ServiceAccountId = serviceAccountId;
        ClientId = clientId;
        Name = name;
        Description = description;
        IamClientAuthMethod = iamClientAuthMethod;
        UserRoleDatas = userRoleDatas;
    }

    [JsonPropertyName("serviceAccountId")]
    public Guid ServiceAccountId { get; set; }

    [JsonPropertyName("clientId")]
    public string ClientId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("authenticationType")]
    public IamClientAuthMethod IamClientAuthMethod { get; set; }

    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    [JsonPropertyName("roles")]
    public IEnumerable<UserRoleData> UserRoleDatas { get; set; }
}
