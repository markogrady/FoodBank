using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;

namespace FoodBank.Core.Seed
{
    public static class SeedProductType
    {
        public static void SeedData(IAppDbContext context)
        {
            var list = GetProductType();
            foreach (var item in list)
            {
                var exists = context.ProductTypes.Any(o => o.ProductTypeId == item.ProductTypeId);
                if (!exists)
                {
                    context.ProductTypes.Add(item);
                }
                context.SaveChanges();
            }

        }

        public static List<ProductType> GetProductType()
        {
            var model = new List<ProductType>();
            model.Add(new ProductType() {ProductTypeId = SeedProp.ProductType1,ProductTypeName = "Chemical"});
            model.Add(new ProductType() {ProductTypeId = SeedProp.ProductType2,ProductTypeName = "Grains"});
            model.Add(new ProductType() {ProductTypeId = SeedProp.ProductType3,ProductTypeName = "Fuel"});


            return model;
        }
    }
}
