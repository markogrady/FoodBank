using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class Attribute
    {
        public Attribute()
        {
            AttributeValues = new List<AttributeValue>();
            ProductTypeAttributes = new List<ProductTypeAttribute>();

        }

        public Guid AttributeId { get; set; }
        public string AttributeName { get; set; }
        public FieldType FieldType { get; set; }
        
        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
        public virtual ICollection<ProductTypeAttribute> ProductTypeAttributes { get; set; }
    }
}
