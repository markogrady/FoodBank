using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Dto.Company
{
    public class CompanyCreateModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
       
        public bool IsTermsConfirmed { get; set; }


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
