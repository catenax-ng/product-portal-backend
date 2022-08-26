using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatenaX.NetworkServices.PortalBackend.PortalEntities.Auditing;

namespace CatenaX.NetworkServices.PortalBackend.PortalEntities.Entities;

public class UserRole : IAuditable
{
    protected UserRole()
    {
        UserRoleText = null!;
        CompanyUsers = new HashSet<CompanyUser>();
        CompanyServiceAccounts = new HashSet<CompanyServiceAccount>();
        UserRoleDescriptions = new HashSet<UserRoleDescription>();
    }

    public UserRole(Guid id, string userRoleText, Guid appId) : this()
    {
        Id = id;
        UserRoleText = userRoleText;
        AppId = appId;
    }

    public Guid Id { get; set; }

    [MaxLength(255)]
    [Column("user_role")]
    public string UserRoleText { get; set; }

    public Guid AppId { get; set; }
    
    /// <inheritdoc />
    public Guid? LastEditorId { get; set; }

    // Navigation properties
    public virtual App? App { get; set; }
    public virtual ICollection<CompanyUser> CompanyUsers { get; private set; }
    public virtual ICollection<CompanyServiceAccount> CompanyServiceAccounts { get; private set; }
    public virtual ICollection<UserRoleDescription> UserRoleDescriptions { get; private set; }
}
