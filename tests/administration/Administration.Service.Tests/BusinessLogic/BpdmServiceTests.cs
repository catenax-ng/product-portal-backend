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

using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Org.CatenaX.Ng.Portal.Backend.Framework.ErrorHandling;
using Org.CatenaX.Ng.Portal.Backend.Framework.Token;
using Org.CatenaX.Ng.Portal.Backend.Tests.Shared;
using Org.CatenaX.Ng.Portal.Backend.Administration.Service.BusinessLogic;
using Org.CatenaX.Ng.Portal.Backend.Administration.Service.Models;
using System.Net;
using Xunit;

namespace Org.CatenaX.Ng.Portal.Backend.Administration.Service.Tests.BusinessLogic;

public class BpdmServiceTests
{
    #region Initialization

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenService _tokenService;
    private readonly string _accessToken;
    private readonly IOptions<BpdmServiceSettings> _options;
    private readonly IFixture _fixture;

    public BpdmServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoFakeItEasyCustomization {ConfigureMembers = true});
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _accessToken = _fixture.Create<string>();
        _options = Options.Create(new BpdmServiceSettings
        {
            Password = "passWord",
            Scope = "test",
            Username = "user@name",
            BaseAdress = "https://base.address.com",
            ClientId = "CatenaX",
            ClientSecret = "pass@Secret",
            GrantType = "cred",
            KeyCloakTokenAdress = "https://key.cloak.com",
        });
        _httpClientFactory = A.Fake<IHttpClientFactory>();
        _tokenService = A.Fake<ITokenService>();
    }

    #endregion

    #region Trigger BpnDataPush

    [Fact]
    public async Task TriggerBpnDataPush_WithValidData_DoesNotThrowException()
    {
        // Arrange
        var data = _fixture.Create<BpdmTransferData>();
        SetupTokenService();
        var httpMessageHandlerMock =
            new HttpMessageHandlerMock(HttpStatusCode.OK);
        var httpClient = new HttpClient(httpMessageHandlerMock)
        {
            BaseAddress = new Uri("https://base.address.com")
        };
        A.CallTo(() => _httpClientFactory.CreateClient(nameof(BpdmService)))
            .Returns(httpClient);
        var sut = new BpdmService(_httpClientFactory, _tokenService, _options);
        
        // Act
        var result = await sut.TriggerBpnDataPush(data, CancellationToken.None).ConfigureAwait(false);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task TriggerBpnDataPush_WithInvalidData_ThrowsServiceException()
    {
        // Arrange
        var data = _fixture.Create<BpdmTransferData>();
        SetupTokenService();
        var httpMessageHandlerMock = new HttpMessageHandlerMock(HttpStatusCode.BadRequest);
        var httpClient = new HttpClient(httpMessageHandlerMock)
        {
            BaseAddress = new Uri("https://base.address.com")
        };
        A.CallTo(() => _httpClientFactory.CreateClient(nameof(BpdmService))).Returns(httpClient);
        var sut = new BpdmService(_httpClientFactory, _tokenService, _options);

        // Act
        async Task Act() => await sut.TriggerBpnDataPush(data, CancellationToken.None).ConfigureAwait(false);

        // Assert
        var ex = await Assert.ThrowsAsync<ServiceException>(Act);
        ex.Message.Should().Contain("Bpdm Service Call failed");
    }

    #endregion

    #region Setup
    
    private void SetupTokenService()
    {
        A.CallTo(() => _tokenService.GetTokenAsync(A<GetTokenSettings>._, A<CancellationToken>._)).Returns(_accessToken);
    }

    #endregion
}
