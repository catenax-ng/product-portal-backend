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
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.PortalEntities.Entities;
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.PortalEntities.Enums;

namespace Org.CatenaX.Ng.Portal.Backend.PortalBackend.DBAccess.Repositories;

public interface IUserRolesRepository
{
    /// <summary>
    /// Add User Role for App Id
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    UserRole CreateAppUserRole(Guid appId, string role);

    /// <summary>
    /// Delete an existing User Role
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    UserRole DeleteUserRole(Guid roleId);

    /// <summary>
    /// Add User Role for App Description
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="languageCode"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    UserRoleDescription CreateAppUserRoleDescription(Guid roleId, string languageCode, string description);
    CompanyUserAssignedRole CreateCompanyUserAssignedRole(Guid companyUserId, Guid companyUserRoleId);
    CompanyUserAssignedRole DeleteCompanyUserAssignedRole(Guid companyUserId, Guid userRoleId);
    void DeleteCompanyUserAssignedRoles(IEnumerable<(Guid CompanyUserId, Guid UserRoleId)> companyUserAssignedRoleIds);
    IAsyncEnumerable<UserRoleData> GetUserRoleDataUntrackedAsync(IEnumerable<Guid> userRoleIds);
    IAsyncEnumerable<Guid> GetUserRoleIdsUntrackedAsync(IDictionary<string, IEnumerable<string>> clientRoles);
    IAsyncEnumerable<UserRoleData> GetUserRoleDataUntrackedAsync(IDictionary<string, IEnumerable<string>> clientRoles);
    IAsyncEnumerable<UserRoleData> GetOwnCompanyPortalUserRoleDataUntrackedAsync(string clientId, IEnumerable<string> roles, string iamUserId);
    IAsyncEnumerable<(Guid OfferId, Guid RoleId, string RoleText, string Description)> GetCoreOfferRolesAsync(string iamUserId, string languageShortName);
    IAsyncEnumerable<OfferRoleInfo> GetAppRolesAsync(Guid offerId, string iamUserid, string languageShortName);
    IAsyncEnumerable<string> GetClientRolesCompositeAsync(string keyCloakClientId);
    IAsyncEnumerable<UserRoleWithDescription> GetServiceAccountRolesAsync(string clientId,string? languageShortName = null);

    /// <summary>
    /// Gets all user role ids for the given offerId
    /// </summary>
    /// <param name="offerId">Id of the offer the roles are assigned to.</param>
    /// <returns>Returns a list of user role ids</returns>
    Task<List<string>> GetUserRolesForOfferIdAsync(Guid offerId);

    IAsyncEnumerable<UserRoleModificationData> GetAssignedAndMatchingAppRoles(Guid companyUserId, IEnumerable<string> userRoles, Guid offerId);
    IAsyncEnumerable<UserRoleModificationData> GetAssignedAndMatchingCoreOfferRoles(Guid companyUserId, IEnumerable<string> userRoles, Guid offerId);

    /// <summary>
    /// Get user name data by assinged roles
    /// </summary>
    /// <param name="iamUserId"></param>
    /// <param name="clientRoles"></param>
    /// <returns></returns>
    IAsyncEnumerable<CompanyUserNameData> GetUserDataByAssignedRoles(string iamUserId, IDictionary<string, IEnumerable<string>> clientRoles);
}
