using System.Text.Json.Serialization;

namespace CatenaX.NetworkServices.Provisioning.Library.Models;

public class UserCreationInfo
{
    public UserCreationInfo(string? userName, string email, string? firstName, string? lastName, IEnumerable<string> roles, string? message)
    {
        this.userName = userName;
        this.eMail = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.Roles = roles;
        this.Message = message;
    }

    [JsonPropertyName("userName")]
    public string? userName { get; set; }

    [JsonPropertyName("email")]
    public string eMail { get; set; }

    [JsonPropertyName("firstName")]
    public string? firstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? lastName { get; set; }

    [JsonPropertyName("roles")]
    public IEnumerable<string> Roles { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
