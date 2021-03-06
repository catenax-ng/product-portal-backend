using CatenaX.NetworkServices.PortalBackend.PortalEntities.Entities;

namespace CatenaX.NetworkServices.Registration.Service.Model;

public class CompanyApplicationUserData
{
    public CompanyApplicationUserData(CompanyApplication companyApplication)
    {
        CompanyApplication = companyApplication;
    }

    public CompanyApplication CompanyApplication { get; }
    public Guid CompanyUserId { get; set; }
    public string? Email { get; set; }
}
