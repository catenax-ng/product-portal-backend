using System.Threading.Tasks;
using CatenaX.NetworkServices.Provisioning.ProvisioningEntities;
using System;

namespace CatenaX.NetworkServices.Provisioning.DBAccess

{
    public interface IProvisioningDBAccess
    {
        Task<int> GetNextClientSequenceAsync();
        Task<int> GetNextIdentityProviderSequenceAsync();
        Task<bool> SaveUserPasswordResetInfo(string userEntityId, DateTime passwordModifiedAt,int resetCount);
        Task<UserPasswordReset> GetUserPasswordResetInfo(string userId);
        Task<bool> SetUserPassword(string userEntityId,int count);
        Task<bool> SetUserPassword(string userEntityId,DateTime dateReset,int count);
    }
}
