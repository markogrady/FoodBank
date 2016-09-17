using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class ProductTypeAttribute
    {
        public Guid ProductTypeAttributeId { get; set; }

        public bool IsRequired { get; set; }


        public Guid ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public Guid AttributeId { get; set; }
        public virtual Attribute Attribute { get; set; }

        public string DefaultValue { get; set; }
        public string Regex { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
}
