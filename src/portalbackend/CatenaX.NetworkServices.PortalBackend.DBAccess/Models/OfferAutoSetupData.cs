﻿/********************************************************************************
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

using System.Text.Json.Serialization;

namespace CatenaX.NetworkServices.PortalBackend.DBAccess.Models;

public record OfferAutoSetupData(
    [property: JsonPropertyName("customer")] CustomerData Customer, 
    [property: JsonPropertyName("properties")] PropertyData Properties);

public record CustomerData(
    [property: JsonPropertyName("organizationName")] string OrganizationName, 
    [property: JsonPropertyName("country")] string Country, 
    [property: JsonPropertyName("email")] string? Email);

public record PropertyData(
    [property: JsonPropertyName("bpnNumber")] string BpnNumber, 
    [property: JsonPropertyName("subscriptionId")] Guid SubscriptionId, 
    [property: JsonPropertyName("serviceId")] Guid ServiceId);