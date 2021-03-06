using CatenaX.NetworkServices.PortalBackend.PortalEntities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CatenaX.NetworkServices.PortalBackend.PortalEntities.Entities;

public class AppStatus
{
    private AppStatus()
    {
        Label = null!;
        Apps = new HashSet<App>();
    }

    public AppStatus(AppStatusId appStatusId) : this()
    {
        Id = appStatusId;
        Label = appStatusId.ToString();
    }

    public AppStatusId Id { get; private set; }

    [MaxLength(255)]
    public string Label { get; private set; }

    // Navigation properties
    public virtual ICollection<App> Apps { get; private set; }
}
