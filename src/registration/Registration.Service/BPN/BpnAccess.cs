/********************************************************************************
 * Copyright (c) 2021,2022 Microsoft and BMW Group AG
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

using Org.CatenaX.Ng.Portal.Backend.Registration.Service.BPN.Model;
using Org.CatenaX.Ng.Portal.Backend.Framework.ErrorHandling;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Org.CatenaX.Ng.Portal.Backend.Registration.Service.BPN
{
    public class BpnAccess : IBpnAccess
    {
        private readonly ILogger<BpnAccess> _logger;
        private readonly HttpClient _httpClient;

        public BpnAccess(IHttpClientFactory httpFactory, ILogger<BpnAccess> logger)
        {
            _httpClient = httpFactory.CreateClient("bpn");
            _logger = logger;
        }

        public async Task<List<FetchBusinessPartnerDto>> FetchBusinessPartner(string bpn, string token)
        {
            var response = new List<FetchBusinessPartnerDto>();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await _httpClient.GetAsync($"api/catena/business-partner/{bpn}");
            _logger.LogDebug("Responded with StatusCode: {StatusCode} and the following content {Content}", result.StatusCode, await result.Content.ReadAsStringAsync());
            if (result.IsSuccessStatusCode)
            {
                var body = JsonSerializer.Deserialize<FetchBusinessPartnerDto>(await result.Content.ReadAsStringAsync());
                response.Add(body);
            }
            else
            {
                throw new ServiceException($"Access to BPN Failed with Status Code {result.StatusCode}", result.StatusCode);
            }

            return response;
        }
    }
}