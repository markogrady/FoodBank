using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace FoodBank.Core.Helpers
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            const string accountSid = "AC3b29af3c1386d863bc858c2d5d49380b";
            const string authToken = "48c0c0a7c3bb750ca365bf7e331ab074";
            const string phoneNumber = "770-999-9875";

            //var twilioRestClient = new TwilioRestClient(accountSid, authToken);
            //twilioRestClient.SendMessage(phoneNumber, message.Destination, message.Body);

            return Task.FromResult(0);
        }
    }

    public class ApplicationUserManager : UserManager<AppUser, Guid>
    {
        public ApplicationUserManager(IUserStore<AppUser, Guid> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<AppDbContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<AppUser, ApplicationRole, Guid, UserLogin, UserRole, UserClaim>(appDbContext));

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser, Guid>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(6),
                };
            }
            appUserManager.UserValidator = new UserValidator<AppUser, Guid>(appUserManager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false


            };

            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,


            };

            appUserManager.UserLockoutEnabledByDefault = true;
            appUserManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            appUserManager.MaxFailedAccessAttemptsBeforeLockout = 8;
            return appUserManager;

        }


    }

    public class ApplicationSignInManager : SignInManager<AppUser, Guid>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser user)
        //{
        //    return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        //}

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class ApplicationRoleManager : RoleManager<ApplicationRole, Guid>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, Guid> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<ApplicationRole, Guid, UserRole>(context.Get<AppDbContext>()));

        }
    }

}
