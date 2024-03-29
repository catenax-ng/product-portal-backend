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

using Org.CatenaX.Ng.Portal.Backend.Administration.Service.BusinessLogic;
using Org.CatenaX.Ng.Portal.Backend.Framework.ErrorHandling;
using Org.CatenaX.Ng.Portal.Backend.Keycloak.Authentication;
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.DBAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Org.CatenaX.Ng.Portal.Backend.Administration.Service.Controllers;

/// <summary>
/// Creates a new instance of <see cref="CompanyDataController"/>
/// </summary>
[ApiController]
[Route("api/administration/companydata")]
[Produces("application/json")]
[Consumes("application/json")]
public class CompanyDataController : ControllerBase
{
    private readonly ICompanyDataBusinessLogic _logic;

    /// <summary>
    /// Creates a new instance of <see cref="CompanyDataController"/>
    /// </summary>
    /// <param name="logic">The company data business logic</param>
    public CompanyDataController(ICompanyDataBusinessLogic logic)
    {
        _logic = logic;
    }

    /// <summary>
    /// Gets the company with its address
    /// </summary>
    /// <returns>the company with its address</returns>
    /// <remarks>Example: GET: api/administration/companydata/ownCompanyDetails</remarks>
    /// <response code="200">Returns the company with its address.</response>
    /// <response code="400">No company data was found.</response>
    [HttpGet]
    [Authorize(Roles = "view_company_data")]
    [Route("ownCompanyDetails")]
    [ProducesResponseType(typeof(CompanyWithAddress), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public Task<CompanyWithAddress> GetOwnCompanyDetailsAsync() =>
        this.WithIamUserId(iamUserId =>_logic.GetOwnCompanyDetailsAsync(iamUserId));
}
