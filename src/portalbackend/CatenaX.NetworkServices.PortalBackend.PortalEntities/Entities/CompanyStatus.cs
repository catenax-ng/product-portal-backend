using CatenaX.NetworkServices.PortalBackend.PortalEntities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CatenaX.NetworkServices.PortalBackend.PortalEntities.Entities;

public class CompanyStatus
{
    private CompanyStatus()
    {
        Label = null!;
        Companies = new HashSet<Company>();
    }

    public CompanyStatus(CompanyStatusId companyStatusId) : this()
    {
        Id = companyStatusId;
        Label = companyStatusId.ToString();
    }

    public CompanyStatusId Id { get; private set; }

    [MaxLength(255)]
    public string Label { get; private set; }

    // Navigation properties
    public virtual ICollection<Company> Companies { get; private set; }
}
