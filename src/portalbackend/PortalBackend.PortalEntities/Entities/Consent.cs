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

using Org.CatenaX.Ng.Portal.Backend.PortalBackend.PortalEntities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Org.CatenaX.Ng.Portal.Backend.PortalBackend.PortalEntities.Entities;

public class Consent
{
    private Consent()
    {
        ConsentAssignedOffers = new HashSet<ConsentAssignedOffer>();
        ConsentAssignedOfferSubscriptions = new HashSet<ConsentAssignedOfferSubscription>();
    }

    /// <summary>
    /// Please only use when attaching the Consent to the database
    /// </summary>
    /// <param name="id"></param>
    public Consent(Guid id) 
        :this()
    {
        Id = id;
    }

    public Consent(Guid id, Guid agreementId, Guid companyId, Guid companyUserId, ConsentStatusId consentStatusId, DateTimeOffset dateCreated)
        : this(id)
    {
        AgreementId = agreementId;
        CompanyId = companyId;
        CompanyUserId = companyUserId;
        ConsentStatusId = consentStatusId;
        DateCreated = dateCreated;
    }

    public Guid Id { get; private set; }

    public DateTimeOffset DateCreated { get; private set; }

    [MaxLength(255)]
    public string? Comment { get; set; }

    public ConsentStatusId ConsentStatusId { get; set; }

    [MaxLength(255)]
    public string? Target { get; set; }

    public Guid AgreementId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid? DocumentId { get; set; }
    public Guid CompanyUserId { get; private set; }

    // Navigation properties
    public virtual Agreement? Agreement { get; private set; }
    public virtual Company? Company { get; private set; }
    public virtual CompanyUser? CompanyUser { get; private set; }
    public virtual ConsentStatus? ConsentStatus { get; private set; }
    public virtual Document? Document { get; private set; }
    public virtual ICollection<ConsentAssignedOffer> ConsentAssignedOffers { get; private set; }
    public virtual ICollection<ConsentAssignedOfferSubscription> ConsentAssignedOfferSubscriptions { get; private set; }
}
