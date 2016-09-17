using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodBank.Core.Dto.Product
{
    public class ProductCreateModel
    {
        public ProductCreateModel()
        {
            ProductTypes = new List<SelectListItem>();
        }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public Guid ProductTypeId { get; set; }

        public List<SelectListItem> ProductTypes { get; set; }
    }
}
