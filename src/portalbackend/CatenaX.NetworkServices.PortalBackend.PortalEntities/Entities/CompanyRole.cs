using CatenaX.NetworkServices.PortalBackend.PortalEntities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CatenaX.NetworkServices.PortalBackend.PortalEntities.Entities;

public class CompanyRole
{
    private CompanyRole()
    {
        Label = null!;
        Companies = new HashSet<Company>();
        AgreementAssignedCompanyRoles = new HashSet<AgreementAssignedCompanyRole>();
        CompanyRoleDescriptions = new HashSet<CompanyRoleDescription>();
    }

    public CompanyRole(CompanyRoleId companyRoleId) : this()
    {
        Id = companyRoleId;
        Label = companyRoleId.ToString();
    }

    public CompanyRoleId Id { get; private set; }

    [MaxLength(255)]
    public string Label { get; set; }

    // Navigation properties
    public virtual ICollection<AgreementAssignedCompanyRole> AgreementAssignedCompanyRoles { get; private set; }
    public virtual ICollection<Company> Companies { get; private set; }
    public virtual ICollection<CompanyRoleDescription> CompanyRoleDescriptions { get; private set; }
}
