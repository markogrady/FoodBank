using System;
using Microsoft.AspNet.Identity.EntityFramework;
using FoodBank.Core.Data.Model;

namespace FoodBank.Core.Data.Model
{
    public class ApplicationRole : IdentityRole<Guid, UserRole>
    {
        public ApplicationRole()
        {
            Id = Guid.NewGuid();
        }

        public ApplicationRole(string name) : this() { Name = name; }
    }

    public class UserRole : IdentityUserRole<Guid> { }
    public class UserClaim : IdentityUserClaim<Guid> { }
    public class UserLogin : IdentityUserLogin<Guid> { }
    public class AppUserStore : UserStore<AppUser, ApplicationRole, Guid, UserLogin, UserRole, UserClaim>
    {
        public AppUserStore(AppDbContext context)
            : base(context)
        {
        }
    }

}
