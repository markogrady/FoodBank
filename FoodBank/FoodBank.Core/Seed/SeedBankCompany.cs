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
    public static class SeedBankCompany
    {
        public static void SeedData(IAppDbContext context)
        {
            var bankCompanies = new List<BankCompany>();

            var bankCompany1 = new BankCompany()
            {
                BankCompanyId = SeedProp.SeedBank1,
                Address1 = "50 Regent Road",
                Address2 = "",
                Address3 = "",
                TownCity = "London",
                County = County.LND,
                ContactEmailAddress = "lee.sole@questionset.com",
                ContactName = "Lee Sole",
                ContactPhoneNumber = "0800 000 0000",
            };

            var bankBranch1 = new BankBranch() { BankBranchId = SeedProp.SeedBank1Branch1, BankBranchName = "Ipswich10", ContactName = "Sarah Fry", ContactPhoneNumber = "08080 0000 000" };
            var bankBranch2 = new BankBranch() { BankBranchId = SeedProp.SeedBank1Branch2, BankBranchName = "Peterborough", ContactName = "Mike Freed", ContactPhoneNumber = "08080 0000 000" };
            var bankBranch3 = new BankBranch() { BankBranchId = SeedProp.SeedBank1Branch3, BankBranchName = "London", ContactName = "Robert Smith", ContactPhoneNumber = "08080 0000 000" };
            var bankBranch4 = new BankBranch() { BankBranchId = SeedProp.SeedBank1Branch4, BankBranchName = "Cambridge", ContactName = "Victor Spenser", ContactPhoneNumber = "08080 0000 000" };
            var bankBranch5 = new BankBranch() { BankBranchId = SeedProp.SeedBank1Branch5, BankBranchName = "Manchester", ContactName = "Graham Bennit", ContactPhoneNumber = "08080 0000 000" };
            var bankBranch6 = new BankBranch() { BankBranchId = SeedProp.SeedBank1Branch6, BankBranchName = "Leeds", ContactName = "Adam Parker", ContactPhoneNumber = "08080 0000 000" };
            var bankBranch7 = new BankBranch() { BankBranchId = SeedProp.SeedBank1Branch7, BankBranchName = "Birmingham", ContactName = "Dean Piper", ContactPhoneNumber = "08080 0000 000" };
            bankCompany1.BankBranches.Add(bankBranch1);
            bankCompany1.BankBranches.Add(bankBranch2);
            bankCompany1.BankBranches.Add(bankBranch3);
            bankCompany1.BankBranches.Add(bankBranch4);
            bankCompany1.BankBranches.Add(bankBranch5);
            bankCompany1.BankBranches.Add(bankBranch6);
            bankCompany1.BankBranches.Add(bankBranch7);
            bankCompany1.BankBranches.Add(bankBranch1);
            bankCompanies.Add(bankCompany1);

            foreach (var bankCompany in bankCompanies)
            {
                var supplierExist = context.BankCompanies.Any(o => o.BankCompanyId == bankCompany.BankCompanyId);
                if (!supplierExist)
                {
                    context.BankCompanies.Add(bankCompany);
                }
            }
            context.SaveChanges();


            var bankUser = context.BankUsers.FirstOrDefault(o => o.BankCompanyId == SeedProp.SeedBank1 && o.BankUserId == SeedProp.UserFoodBank1);
            if (bankUser == null)
            {
                bankUser = new BankUser();
                bankUser.BankUserId = SeedProp.UserFoodBank1;
                bankUser.BankCompanyId = SeedProp.SeedBank1;
                bankUser.BankBranchId = SeedProp.SeedBank1Branch1;
                context.BankUsers.Add(bankUser);
                context.SaveChanges();
            }
        }
    }
}
