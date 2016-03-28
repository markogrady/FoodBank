using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;

namespace FoodBank.Core.Seed
{
    public static class SeedProduct
    {
        public static void SeedData(IAppDbContext context)
        {
            var products = new List<Product>();

            foreach (var product in products)
            {
                var existProduct = context.Products.Any(o => o.ProductId == product.ProductId);
                if (!existProduct)
                {
                    context.Products.Add(product);
                }
            }

            context.SaveChanges();
        }
    }
}
