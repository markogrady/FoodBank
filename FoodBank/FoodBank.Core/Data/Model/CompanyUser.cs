using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class CompanyUser
    {
        [Key]
        [ForeignKey("AppUser")]
        public Guid CompanyUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        public Guid CompanyId   { get; set; }
        public virtual Company Company { get; set; }
        public Guid CompanyBranchId { get; set; }
        public virtual CompanyBranch CompanyBranch { get; set; }
    }
}
