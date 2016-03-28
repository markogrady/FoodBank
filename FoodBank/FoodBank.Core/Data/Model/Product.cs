using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Data.Model
{
    public class Product
    {
        public Product()
        {
            Listings= new List<Listing>();
        }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
