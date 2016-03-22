using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class BankBranch
    {
        public BankBranch()
        {
            BankUsers = new List<BankUser>();
            OrderItems = new List<OrderItem>();
        }
        public Guid BankBranchId { get; set; }
        public string BankBranchName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string TownCity { get; set; }
        public County County { get; set; }
        public string PostCode { get; set; }

        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }

        public Guid BankCompanyId { get; set; }
        public virtual BankCompany BankCompany { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<BankUser> BankUsers { get; set; }

    }
}
