using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Supplier
{
    public class SupplierCreateModel
    {
        public string SupplierName { get; set; }
        public string LogoUrl { get; set; }
        public string SupplierAddress1 { get; set; }
        public string SupplierAddress2 { get; set; }
        public string SupplierAddress3 { get; set; }
        public string SupplierTownCity { get; set; }
        public County SupplierCounty { get; set; }
        public string SupplierPostCode { get; set; }
                      
        public string SupplierContactName { get; set; }
        public string SupplierContactPhoneNumber { get; set; }
        public string SupplierContactEmailAddress { get; set; }

        public string SupplierBranchAddress1 { get; set; }
        public string SupplierBranchAddress2 { get; set; }
        public string SupplierBranchAddress3 { get; set; }
        public string SupplierBranchTownCity { get; set; }
        public County SupplierBranchCounty { get; set; }
        public string SupplierBranchPostCode { get; set; }

        public string SupplierBranchContactName { get; set; }
        public string SupplierBranchContactPhoneNumber { get; set; }
        public string SupplierBranchContactEmailAddress { get; set; }
    }
}
