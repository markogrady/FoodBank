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

            var product1 = new Product()
            {
                ProductId = SeedProp.ProductId1,
                ProductName = "Hp Ketchup",
                Description = "Hp Ketchup",
            };
            products.Add(product1);

            var product2 = new Product()
            {
                ProductId = SeedProp.ProductId2,
                ProductName = "Apples",
                Description = "Apples",
            };
            products.Add(product2);

            var product3 = new Product()
            {
                ProductId = SeedProp.ProductId3,
                ProductName = "Cornflakes",
                Description = "Kellogs Cornflakes",
            };
            products.Add(product3);

            var product4 = new Product()
            {
                ProductId = SeedProp.ProductId4,
                ProductName = "Coffee",
                Description = "Coffee",
            };
            products.Add(product4);

            var product5 = new Product()
            {
                ProductId = SeedProp.ProductId5,
                ProductName = "Mars Bars",
                Description = "Mars Bars",
            };
            products.Add(product5);

            var product6 = new Product()
            {
                ProductId = SeedProp.ProductId6,
                ProductName = "Bread",
                Description = "Bread",
            };
            products.Add(product6);

            var product7 = new Product()
            {
                ProductId = SeedProp.ProductId7,
                ProductName = "Sausage Rolls",
                Description = "Sausage Rolls",
            };
            products.Add(product7);

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
