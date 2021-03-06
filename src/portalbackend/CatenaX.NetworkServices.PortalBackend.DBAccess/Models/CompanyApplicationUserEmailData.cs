using CatenaX.NetworkServices.PortalBackend.PortalEntities.Entities;

namespace CatenaX.NetworkServices.PortalBackend.DBAccess.Models;

public class CompanyApplicationUserEmailData
{
    public CompanyApplicationUserEmailData(CompanyApplication companyApplication)
    {
        CompanyApplication = companyApplication;
    }

    public CompanyApplication CompanyApplication { get; }
    public Guid CompanyUserId { get; set; }
    public string? Email { get; set; }
}
