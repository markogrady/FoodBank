using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace FoodBank.Core.Data.Model
{
    public class AppUser : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public bool ChangePasswordOnFirstLogin { get; set; }
        public DateTime CreationDate { get; set; }

        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser, Guid> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here

            return userIdentity;
        }

    }

}
