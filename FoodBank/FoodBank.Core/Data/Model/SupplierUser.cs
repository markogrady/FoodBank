using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class SupplierUser
    {
        [Key]
        [ForeignKey("AppUser")]
        public Guid SupplierUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        public Guid SupplierId   { get; set; }
        public virtual Supplier Supplier { get; set; }
        public Guid SupplierBranchId { get; set; }
        public virtual SupplierBranch SupplierBranch { get; set; }
    }
}
