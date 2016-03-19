using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class BankUser
    {
        [Key]
        [ForeignKey("AppUser")]
        public Guid BankUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        public Guid BankCompanyId { get; set; }
        public virtual BankCompany BankCompany { get; set; }
        public Guid BankBranchId { get; set; }
        public virtual BankBranch BankBranch{ get; set; }
    }
}
