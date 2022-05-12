namespace CatenaX.NetworkServices.Provisioning.Library.Models
{
    public class RealmConfig
    {
        public bool? BruteForceDetected { get; set; }
        public string PasswordPolicy { get; set; }
        public int? MaxLoginFailure { get; set; }
    }
}