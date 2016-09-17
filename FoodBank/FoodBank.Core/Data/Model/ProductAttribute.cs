using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class ProductAttribute
    {
        public Guid ProductAttributeId { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid AttributeId { get; set; }

        public virtual Attribute Attribute { get; set; }

        public Guid? AttributeValueId { get; set; }
        public virtual AttributeValue AttributeValue { get; set; }
        public string Value { get; set; }

    }
}
