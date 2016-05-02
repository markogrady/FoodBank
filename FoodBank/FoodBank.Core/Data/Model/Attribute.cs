using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class Attribute
    {
        public Attribute()
        {
            AttributeValues = new List<AttributeValue>();
        }

        public Guid AttributeId { get; set; }
        public string AttributeName { get; set; }

        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
