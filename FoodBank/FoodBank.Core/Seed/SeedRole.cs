using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodBank.Core.Seed
{
    public static class SeedRole
    {
        public static void CreateRoles(IAppDbContext context)
        {
            var roleManager = new RoleManager<ApplicationRole, Guid>(new RoleStore<ApplicationRole, Guid, UserRole>((AppDbContext)context));

            var adminRole = roleManager.FindByName("Admin");
            if (adminRole == null)
            {
                adminRole = new ApplicationRole("Admin");
                var roleResult = roleManager.Create(adminRole);
            }

            var CompanyRole = roleManager.FindByName("Company");
            if (CompanyRole == null)
            {
                CompanyRole = new ApplicationRole("Company");
                var roleResult = roleManager.Create(CompanyRole);
            }

          

    
        }
    }
}