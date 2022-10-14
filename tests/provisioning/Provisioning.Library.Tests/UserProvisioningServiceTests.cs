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

using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using FluentAssertions;
using Org.CatenaX.Ng.Portal.Backend.Framework.ErrorHandling;
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.DBAccess;
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.DBAccess.Repositories;
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.PortalEntities.Entities;
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.PortalEntities.Enums;
using Org.CatenaX.Ng.Portal.Backend.Provisioning.Library.Models;
using Org.CatenaX.Ng.Portal.Backend.Provisioning.Library.Service;
using FakeItEasy;
using Xunit;

namespace Org.CatenaX.Ng.Portal.Backend.Provisioning.Library.Tests;

public class UserProvisioningServiceTests
{
    private readonly IFixture _fixture;
    private readonly Random _random;
    private readonly int _numUsers;
    private readonly int _numRoles;
    private readonly int _indexInvalidUser;
    private readonly IProvisioningManager _provisioningManager;
    private readonly IPortalRepositories _portalRepositories;
    private readonly IUserRepository _userRepository;
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly CompanyNameIdpAliasData _companyNameIdpAliasData;
    private readonly CompanyNameIdpAliasData _companyNameIdpAliasDataSharedIdp;
    private readonly string _clientId;
    private readonly IEnumerable<(string Role, Guid Id)> _userRolesWithId;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public UserProvisioningServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoFakeItEasyCustomization { ConfigureMembers = true });
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _random = new Random();
        _numUsers = 2;
        _indexInvalidUser = 1;
        _numRoles = 5;

        _companyNameIdpAliasData = _fixture.Build<CompanyNameIdpAliasData>().With(x => x.IsSharedIdp, false).Create();
        _companyNameIdpAliasDataSharedIdp = _fixture.Build<CompanyNameIdpAliasData>().With(x => x.IsSharedIdp, true).Create();

        _clientId = _fixture.Create<string>();
        _cancellationTokenSource = new CancellationTokenSource();
        _userRolesWithId = _fixture.CreateMany<(string,Guid)>(_numRoles).ToList();

        _portalRepositories = A.Fake<IPortalRepositories>();
        _provisioningManager = A.Fake<IProvisioningManager>();
        _userRepository = A.Fake<IUserRepository>();
        _userRolesRepository = A.Fake<IUserRolesRepository>();

        SetupRepositories();
        SetupProvisioningManager();
    }

    [Fact]
    public async void TestFixtureSetup()
    {
        var sut = new UserProvisioningService(_provisioningManager,_portalRepositories);

        var userCreationInfoIdp = CreateUserCreationInfoIdp().ToAsyncEnumerable();
        
        var result = await sut.CreateOwnCompanyIdpUsersAsync(
            _companyNameIdpAliasData,
            _clientId,
            userCreationInfoIdp,
            _cancellationTokenSource.Token
        ).ToListAsync().ConfigureAwait(false);

        A.CallTo(() => _portalRepositories.GetInstance<IUserRepository>()).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _portalRepositories.GetInstance<IUserRolesRepository>()).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _provisioningManager.CreateCentralUserAsync(A<UserProfile>._, A<IEnumerable<(string,IEnumerable<string>)>>._)).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _provisioningManager.AddProviderUserLinkToCentralUserAsync(A<string>._, A<IdentityProviderLink>._)).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _provisioningManager.CreateSharedRealmUserAsync(A<string>._, A<UserProfile>._)).MustNotHaveHappened();
        A.CallTo(() => _userRepository.CreateIamUser(A<Guid>._, A<string>._)).MustHaveHappenedOnceOrMore();
    }

    [Fact]
    public async void TestSharedIdpFixtureSetup()
    {
        var sut = new UserProvisioningService(_provisioningManager,_portalRepositories);

        var userCreationInfoIdp = CreateUserCreationInfoIdp().ToAsyncEnumerable();
        
        var result = await sut.CreateOwnCompanyIdpUsersAsync(
            _companyNameIdpAliasDataSharedIdp,
            _clientId,
            userCreationInfoIdp,
            _cancellationTokenSource.Token
        ).ToListAsync().ConfigureAwait(false);

        A.CallTo(() => _portalRepositories.GetInstance<IUserRepository>()).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _portalRepositories.GetInstance<IUserRolesRepository>()).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _provisioningManager.CreateCentralUserAsync(A<UserProfile>._, A<IEnumerable<(string,IEnumerable<string>)>>._)).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _provisioningManager.AddProviderUserLinkToCentralUserAsync(A<string>._, A<IdentityProviderLink>._)).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _provisioningManager.CreateSharedRealmUserAsync(A<string>._, A<UserProfile>._)).MustHaveHappenedOnceOrMore();
        A.CallTo(() => _userRepository.CreateIamUser(A<Guid>._, A<string>._)).MustHaveHappenedOnceOrMore();
    }

    [Fact]
    public async void TestCreateUsersAllSuccess()
    {
        var sut = new UserProvisioningService(_provisioningManager,_portalRepositories);

        var userCreationInfoIdp = CreateUserCreationInfoIdp().ToList();
        
        var result = await sut.CreateOwnCompanyIdpUsersAsync(
            _companyNameIdpAliasData,
            _clientId,
            userCreationInfoIdp.ToAsyncEnumerable(),
            _cancellationTokenSource.Token
        ).ToListAsync().ConfigureAwait(false);

        result.Should().HaveCount(_numUsers);
        result.Select(r => r.UserName).Should().ContainInOrder(userCreationInfoIdp.Select(u => u.UserName));
        result.Should().AllSatisfy(r => r.Error.Should().BeNull());
    }

    [Fact]
    public async void TestCreateUsersInvalidRolesError()
    {
        var sut = new UserProvisioningService(_provisioningManager,_portalRepositories);

        var userWithInvalidRoles = _fixture.Create<UserCreationInfoIdp>();
        var userCreationInfoIdp = CreateUserCreationInfoIdp(
            () => userWithInvalidRoles).ToList();

        var result = await sut.CreateOwnCompanyIdpUsersAsync(
            _companyNameIdpAliasData,
            _clientId,
            userCreationInfoIdp.ToAsyncEnumerable(),
            _cancellationTokenSource.Token
        ).ToListAsync().ConfigureAwait(false);

        result.Should().HaveCount(_numUsers);
        result.Where((r,index) => index != _indexInvalidUser).Should().AllSatisfy(r => r.Error.Should().BeNull());

        var error = result.ElementAt(_indexInvalidUser).Error;
        error.Should().NotBeNull();
        error.Should().BeOfType(typeof(ControllerArgumentException));
        error!.Message.Should().Be($"invalid Roles: [{string.Join(", ",userWithInvalidRoles.Roles)}]");
    }

    [Fact]
    public async void TestCreateUsersRolesAssignmentError()
    {
        var sut = new UserProvisioningService(_provisioningManager,_portalRepositories);

        var userCreationInfoIdp = CreateUserCreationInfoIdp().ToList();

        var roles = userCreationInfoIdp.ElementAt(_indexInvalidUser).Roles;
        var assignedRoles = roles.Take(roles.Count()-1);
        var centralUserName = _companyNameIdpAliasData.IdpAlias + "." + userCreationInfoIdp.ElementAt(_indexInvalidUser).UserId;
        var iamUserId = _fixture.Create<string>();

        A.CallTo(() => _provisioningManager.CreateCentralUserAsync(A<UserProfile>.That.Matches(p => p.UserName ==  centralUserName), A<IEnumerable<(string,IEnumerable<string>)>>._))
            .Returns(iamUserId);

        A.CallTo(() => _provisioningManager.AssignClientRolesToCentralUserAsync(A<string>.That.IsEqualTo(iamUserId), A<IDictionary<string, IEnumerable<string>>>._))
            .ReturnsLazily((string _, IDictionary<string, IEnumerable<string>> clientRoles) => new [] { (_clientId, assignedRoles) }.ToDictionary(x => x._clientId, x => x.assignedRoles));

        var result = await sut.CreateOwnCompanyIdpUsersAsync(
            _companyNameIdpAliasData,
            _clientId,
            userCreationInfoIdp.ToAsyncEnumerable(),
            _cancellationTokenSource.Token
        ).ToListAsync().ConfigureAwait(false);

        result.Should().HaveCount(_numUsers);
        result.Where((r,index) => index != _indexInvalidUser).Should().AllSatisfy(r => r.Error.Should().BeNull());

        var error = result.ElementAt(_indexInvalidUser).Error;
        error.Should().NotBeNull();
        error.Should().BeOfType(typeof(ConflictException));
        error!.Message.Should().Be($"invalid role data, client: {_clientId}, [{String.Join(", ", roles.Except(assignedRoles))}] has not been assigned in keycloak");
    }

    private void SetupRepositories()
    {
        A.CallTo(() => _portalRepositories.GetInstance<IUserRepository>()).Returns(_userRepository);
        A.CallTo(() => _portalRepositories.GetInstance<IUserRolesRepository>()).Returns(_userRolesRepository);

        A.CallTo(() => _userRepository.CreateCompanyUser(A<string>._, A<string>._, A<string>._,  A<Guid>._, A<CompanyUserStatusId>._, A<Guid>._))
            .ReturnsLazily((string firstName, string lastName, string email, Guid companyId, CompanyUserStatusId companyUserStatusId, Guid lastEditorId) =>
                new CompanyUser(_fixture.Create<Guid>(), companyId, companyUserStatusId, DateTimeOffset.UtcNow, lastEditorId));

        A.CallTo(() => _userRepository.CreateIamUser(A<Guid>._, A<string>._))
            .ReturnsLazily((Guid companyUserId, string iamUserId) => new IamUser(iamUserId, companyUserId));

        A.CallTo(() => _userRolesRepository.GetUserRolesWithIdAsync(A<string>.Ignored)).Returns(_userRolesWithId.ToAsyncEnumerable());
    }

    private void SetupProvisioningManager()
    {
        A.CallTo(() => _provisioningManager.CreateCentralUserAsync(A<UserProfile>._, A<IEnumerable<(string,IEnumerable<string>)>>._))
            .ReturnsLazily(() => _fixture.Create<string>());

        A.CallTo(() => _provisioningManager.AssignClientRolesToCentralUserAsync(A<string>._, A<IDictionary<string, IEnumerable<string>>>._))
            .ReturnsLazily((string _, IDictionary<string, IEnumerable<string>> clientRoles) => clientRoles);
    }

    private IEnumerable<UserCreationInfoIdp> CreateUserCreationInfoIdp(Func<UserCreationInfoIdp>? createInvalidUser = null)
    {
        var indexUser = 0;
        while (indexUser < _numUsers)
        {
            yield return (indexUser == _indexInvalidUser && createInvalidUser != null)
                ? createInvalidUser()
                : _fixture.Build<UserCreationInfoIdp>().With(x => x.Roles, PickValidRoles().ToList()).Create();
            indexUser++;
        }
    }

    private IEnumerable<string> PickValidRoles()
    {
        var maxRoles = _userRolesWithId.Count();
        var numRoles = _random.Next(1,maxRoles);
        while(numRoles > 0)
        {
            yield return _userRolesWithId.ElementAt(_random.Next(maxRoles)).Role;
            numRoles--;
        }
    }
}
