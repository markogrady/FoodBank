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

        public AuthBankModel AuthBankModel { get; set; }
        


    }

    public class AuthBankModel
    {
        public Guid BankCompanyId { get; set; }
        public string BankCompanyName { get; set; }
        public Guid BankUserId { get; set; }
    }

}