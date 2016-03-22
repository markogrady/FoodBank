using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Data.Model;

namespace FoodBank.Core.Seed
{
    public static class SeedCompany
    {
        public static void SeedData(IAppDbContext context)
        {
            var Companys = new List<Company>();

           var Company1=  new Company()
            {
               CompanyName = "Tescways",
                Address1 = "10 Northgate Street",
                Address2 = "",
                Address3 = "",
                TownCity = "Bury St Edmunds",
                County = County.SFK,
                ContactEmailAddress = "mark.ogrady@questionset.com",
                ContactName = "Mark O'Grady",
                ContactPhoneNumber = "0800 000 0000",
                CompanyId = SeedProp.SeedCompany1,
            };

            var CompanyBranch1 = new CompanyBranch() {CompanyBranchId = SeedProp.SeedCompany1Branch1,CompanyBranchName = "Ipswich10",ContactName = "Mark Davis",ContactPhoneNumber = "08080 0000 000"};
            var CompanyBranch2 = new CompanyBranch() {CompanyBranchId = SeedProp.SeedCompany1Branch2, CompanyBranchName = "Peterborough",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var CompanyBranch3 = new CompanyBranch() {CompanyBranchId = SeedProp.SeedCompany1Branch3, CompanyBranchName = "London",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var CompanyBranch4 = new CompanyBranch() {CompanyBranchId = SeedProp.SeedCompany1Branch4, CompanyBranchName = "Cambridge",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var CompanyBranch5 = new CompanyBranch() {CompanyBranchId = SeedProp.SeedCompany1Branch5, CompanyBranchName = "Manchester",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var CompanyBranch6 = new CompanyBranch() {CompanyBranchId = SeedProp.SeedCompany1Branch6, CompanyBranchName = "Leeds",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var CompanyBranch7 = new CompanyBranch() {CompanyBranchId = SeedProp.SeedCompany1Branch7, CompanyBranchName = "Birmingham",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            Company1.CompanyBranches.Add(CompanyBranch1);
            Company1.CompanyBranches.Add(CompanyBranch2);
            Company1.CompanyBranches.Add(CompanyBranch3);
            Company1.CompanyBranches.Add(CompanyBranch4);
            Company1.CompanyBranches.Add(CompanyBranch5);
            Company1.CompanyBranches.Add(CompanyBranch6);
            Company1.CompanyBranches.Add(CompanyBranch7);
            Company1.CompanyBranches.Add(CompanyBranch1);
            Companys.Add(Company1);

            foreach (var Company in Companys)
            {
                var CompanyExist = context.Companies.Any(o => o.CompanyId == Company.CompanyId);
                if (!CompanyExist)
                {
                    context.Companies.Add(Company);
                }
            }
            context.SaveChanges();

            
            var CompanyUser = context.CompanyUsers.FirstOrDefault(o => o.CompanyId == SeedProp.SeedCompany1 && o.CompanyUserId == SeedProp.UserCompany1);
            if (CompanyUser == null)
            {
                CompanyUser = new CompanyUser();
                CompanyUser.CompanyUserId = SeedProp.UserCompany1;
                CompanyUser.CompanyId = SeedProp.SeedCompany1;
                CompanyUser.CompanyBranchId = SeedProp.SeedCompany1Branch1;
                context.CompanyUsers.Add(CompanyUser);
                context.SaveChanges();
            }
        
    }
    }
}
