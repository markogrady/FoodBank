using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;

namespace FoodBank.Core.Seed
{
    public static class SeedAll
    {
        public static void SeedAllData(IAppDbContext context)
        {
            ((AppDbContext)context).Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' ");
            ((AppDbContext)context).Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'DELETE FROM ?' ");
            ((AppDbContext)context).Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'");




            SeedRole.CreateRoles(context);
            SeedUser.CreateUsers(context);
            SeedCompany.SeedData(context);
            SeedProduct.SeedData(context);
            SeedListing.SeedData(context);
        }
    }
}