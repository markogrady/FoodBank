using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodBank.Core.Seed
{
    public class SeedUser
    {

        public static void CreateUsers(IAppDbContext context)
        {
            CreateUser(context,SeedProp.UserAdmin1, "mark.ogrady+admin@questionset.com", "Mark", "O'Grady", "Password9!", "Admin", "https://trackthechain.blob.core.windows.net/siteresource/mark5.jpg");
            CreateUser(context, SeedProp.UserCompany1, SeedProp.CompanyEmail1, "Tom", "West", "Password9!", "Company", "https://lawdocs.blob.core.windows.net/avatar/avatar/image_8f974aa5-3cb3-4114-a780-ea46281cad1e.jpg");
            CreateUser(context, SeedProp.UserFoodBank1, SeedProp.FoodBankEmail1, "Julia", "Davis", "Password9!", "FoodBank", "https://trackthechain.blob.core.windows.net/siteresource/estate2.png");
            
            context.SaveChanges();
        }

        public static AppUser GetAppUser(IAppDbContext context, string email)
        {
            var manager = new ApplicationUserManager(new UserStore<AppUser, ApplicationRole, Guid, UserLogin, UserRole, UserClaim>((AppDbContext)context));
            return manager.FindByEmail(email);
        }


        private static AppUser CreateUser(IAppDbContext context,Guid userId, string email, string firstname, string lastname, string password, string role, string avatar)
        {

            var manager = new ApplicationUserManager(new UserStore<AppUser, ApplicationRole, Guid, UserLogin, UserRole, UserClaim>((AppDbContext)context));
            manager.UserValidator = new UserValidator<AppUser, Guid>(manager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false


            };
            var user1 = manager.FindByEmail(email);
            if (user1 == null)
            {
                var user = new AppUser()
                {
                    Id = userId,
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = firstname,
                    LastName = lastname,
                    AvatarUrl = avatar,
                    PhoneNumber = "+447879775840",
                    PhoneNumberConfirmed = true,
                    CreationDate = DateTime.UtcNow,
                };


                var result = manager.Create(user, password);


            }
            var user2 = manager.FindByEmail(email);
            var roleForUser = manager.GetRoles(user2.Id);
            if (!roleForUser.Contains(role))
            {
                manager.AddToRole(user2.Id, role);
            }
            context.SaveChanges();

            return user2;
        }

    }
}
