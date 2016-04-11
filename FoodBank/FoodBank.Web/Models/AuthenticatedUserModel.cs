using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Data.Model;

namespace FoodBank.Web.Models
{
    public class AuthenticatedUserModel
    {
        public Guid UserId { get; set; }
        public string Avatar { get; set; }
        public Guid CompanyFirmId { get; set; }
        public PartyType PartyType { get; set; }
        public AppUser AppUser { get; set; }

        
        public AuthCompanyModel AuthCompanyModel { get; set; }
    }

    public class AuthCompanyModel
    {
        public Guid CompanyId { get; set; }
        public Guid CompanyBranchId { get; set; }
        public string BranchName { get; set; }

        public string CompanyName { get; set; }
    }

  

}