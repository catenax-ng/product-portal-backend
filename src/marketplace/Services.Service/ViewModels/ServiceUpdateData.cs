using Offers.Library.Models;
using Org.CatenaX.Ng.Portal.Backend.PortalBackend.PortalEntities.Enums;

namespace Org.CatenaX.Ng.Portal.Backend.Services.Service.ViewModels;

public record ServiceUpdateRequestData(
    string Title,
    IEnumerable<LocalizedDescription> Descriptions,
    IEnumerable<ServiceTypeId> ServiceTypeIds,
    string Price,
    string ContactEmail,
    Guid SalesManager);