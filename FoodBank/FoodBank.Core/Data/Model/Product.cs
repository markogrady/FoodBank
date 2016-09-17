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
            ProductCategoryItems = new List<ProductCategoryItem>();
        }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }

        public virtual ICollection<ProductCategoryItem> ProductCategoryItems { get; set; }
        public Guid ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        //TODO Attributes

    }
}
