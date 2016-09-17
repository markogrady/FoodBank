using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;

namespace FoodBank.Core.Seed
{
    public static class SeedCategory
    {
        public static void SeedData(IAppDbContext context)
        {
            var list = GetCategory();
            foreach (var item in list)
            {
                var exists = context.ProductCategories.Any(o => o.ProductCategoryId == item.ProductCategoryId);
                if (!exists)
                {
                    context.ProductCategories.Add(item);
                }
                context.SaveChanges();
            }

        }

        public static List<ProductCategory> GetCategory()
        {
            var model = new List<ProductCategory>();
            model.Add(new ProductCategory() {ProductCategoryId = SeedProp.ProductCategory1,ProductCategoryName = "Chemical"});
            model.Add(new ProductCategory() {ProductCategoryId = SeedProp.ProductCategory2,ProductCategoryName = "Grain"});
            model.Add(new ProductCategory() {ProductCategoryId = SeedProp.ProductCategory3,ProductCategoryName = "Fuel"});

            return model;
        }
    }
}
