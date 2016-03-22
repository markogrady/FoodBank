using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Company
{
    public class CompanyCreateModel
    {
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyAddress3 { get; set; }
        public string CompanyTownCity { get; set; }
        public County CompanyCounty { get; set; }
        public string CompanyPostCode { get; set; }
                      
        public string CompanyContactName { get; set; }
        public string CompanyContactPhoneNumber { get; set; }
        public string CompanyContactEmailAddress { get; set; }

        public string CompanyBranchAddress1 { get; set; }
        public string CompanyBranchAddress2 { get; set; }
        public string CompanyBranchAddress3 { get; set; }
        public string CompanyBranchTownCity { get; set; }
        public County CompanyBranchCounty { get; set; }
        public string CompanyBranchPostCode { get; set; }

        public string CompanyBranchContactName { get; set; }
        public string CompanyBranchContactPhoneNumber { get; set; }
        public string CompanyBranchContactEmailAddress { get; set; }
        public string CompanyBranchName { get; set; }
    }
}
