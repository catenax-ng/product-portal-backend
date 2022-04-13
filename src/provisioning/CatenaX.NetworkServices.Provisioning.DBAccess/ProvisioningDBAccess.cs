using System.Threading.Tasks;
using CatenaX.NetworkServices.Provisioning.ProvisioningEntities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CatenaX.NetworkServices.Provisioning.DBAccess

{
    public class ProvisioningDBAccess : IProvisioningDBAccess
    {
        private readonly ProvisioningDBContext _dbContext;

        public ProvisioningDBAccess(ProvisioningDBContext provisioningDBContext)
        {
            _dbContext = provisioningDBContext;
        }

        public async Task<int> GetNextClientSequenceAsync()
        {
            var nextSequence = _dbContext.ClientSequences.Add(new ClientSequence()).Entity;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return nextSequence.SequenceId;
        }

        public async Task<int> GetNextIdentityProviderSequenceAsync()
        {
            var nextSequence = _dbContext.IdentityProviderSequences.Add(new IdentityProviderSequence()).Entity;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return nextSequence.SequenceId;
        }

        public  Task<bool> SaveUserPasswordResetInfo(string userEntityId, DateTime passwordModifiedAt,int resetCount)
        {
            _dbContext.UserPasswordResets.Add(new UserPasswordReset {
                SharedUserEntityId = userEntityId,
                PasswordModifiedAt = passwordModifiedAt,
                ResetCount = resetCount,
            });
                _dbContext.SaveChangesAsync();
          return Task.FromResult(true);
        }

        public  Task<UserPasswordReset> GetUserPasswordResetInfo(string userId) 
        {
            var result = _dbContext.UserPasswordResets
                .Where(x=>x.SharedUserEntityId == userId)
                .Select(
                    userPasswordReset => new UserPasswordReset {
                       
                        PasswordModifiedAt = userPasswordReset.PasswordModifiedAt,
                        ResetCount = userPasswordReset.ResetCount,
                    })
                .FirstOrDefault();
              return Task.FromResult(result);
        }
        
          
        public  Task<bool> SetUserPassword(string userEntityId,int count)
        {
          var passwordReset =  _dbContext.UserPasswordResets.Find(userEntityId);
            passwordReset.ResetCount = count;
             _dbContext.SaveChangesAsync();
             return Task.FromResult(true);
        }
        
        public  Task<bool> SetUserPassword(string userEntityId,DateTime dateReset,int count)
        {
          var passwordReset =  _dbContext.UserPasswordResets.Find(userEntityId);
                
           passwordReset.PasswordModifiedAt = dateReset;
            passwordReset.ResetCount = count;
             _dbContext.SaveChangesAsync();
             return Task.FromResult(true);
        }
    }
}
