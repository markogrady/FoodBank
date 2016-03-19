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
    public static class SeedSupplier
    {
        public static void SeedData(IAppDbContext context)
        {
            var suppliers = new List<Supplier>();

           var supplier1=  new Supplier()
            {
               SupplierName = "Tescways",
                Address1 = "10 Northgate Street",
                Address2 = "",
                Address3 = "",
                TownCity = "Bury St Edmunds",
                County = County.SFK,
                ContactEmailAddress = "mark.ogrady@questionset.com",
                ContactName = "Mark O'Grady",
                ContactPhoneNumber = "0800 000 0000",
                SupplierId = SeedProp.SeedSupplier1,
            };

            var supplierBranch1 = new SupplierBranch() {SupplierBranchId = SeedProp.SeedSupplier1Branch1,SupplierBranchName = "Ipswich10",ContactName = "Mark Davis",ContactPhoneNumber = "08080 0000 000"};
            var supplierBranch2 = new SupplierBranch() {SupplierBranchId = SeedProp.SeedSupplier1Branch2, SupplierBranchName = "Peterborough",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var supplierBranch3 = new SupplierBranch() {SupplierBranchId = SeedProp.SeedSupplier1Branch3, SupplierBranchName = "London",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var supplierBranch4 = new SupplierBranch() {SupplierBranchId = SeedProp.SeedSupplier1Branch4, SupplierBranchName = "Cambridge",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var supplierBranch5 = new SupplierBranch() {SupplierBranchId = SeedProp.SeedSupplier1Branch5, SupplierBranchName = "Manchester",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var supplierBranch6 = new SupplierBranch() {SupplierBranchId = SeedProp.SeedSupplier1Branch6, SupplierBranchName = "Leeds",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            var supplierBranch7 = new SupplierBranch() {SupplierBranchId = SeedProp.SeedSupplier1Branch7, SupplierBranchName = "Birmingham",ContactName = "Peter Willis",ContactPhoneNumber = "08080 0000 000"};
            supplier1.SupplierBranches.Add(supplierBranch1);
            supplier1.SupplierBranches.Add(supplierBranch2);
            supplier1.SupplierBranches.Add(supplierBranch3);
            supplier1.SupplierBranches.Add(supplierBranch4);
            supplier1.SupplierBranches.Add(supplierBranch5);
            supplier1.SupplierBranches.Add(supplierBranch6);
            supplier1.SupplierBranches.Add(supplierBranch7);
            supplier1.SupplierBranches.Add(supplierBranch1);
            suppliers.Add(supplier1);

            foreach (var supplier in suppliers)
            {
                var supplierExist = context.Suppliers.Any(o => o.SupplierId == supplier.SupplierId);
                if (!supplierExist)
                {
                    context.Suppliers.Add(supplier);
                }
            }
            context.SaveChanges();

            
            var supplierUser = context.SupplierUsers.FirstOrDefault(o => o.SupplierId == SeedProp.SeedSupplier1 && o.SupplierUserId == SeedProp.UserSupplier1);
            if (supplierUser == null)
            {
                supplierUser = new SupplierUser();
                supplierUser.SupplierUserId = SeedProp.UserSupplier1;
                supplierUser.SupplierId = SeedProp.SeedSupplier1;
                supplierUser.SupplierBranchId = SeedProp.SeedSupplier1Branch1;
                context.SupplierUsers.Add(supplierUser);
                context.SaveChanges();
            }
        
    }
    }
}
