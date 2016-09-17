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
                ProductName = "Pesticide 1",
                Description = "Contains 1.5% TR3799 metaldehyde. Excellent control of slugs and snails on all edible and non edible…",
                ProductTypeId = SeedProp.ProductType1
            };
            products.Add(product1);

            var product2 = new Product()
            {
                ProductId = SeedProp.ProductId2,
                ProductName = "Pesticide 2",
                Description = "Contains 2% TR4000 metaldehyde. Excellent control of slugs and snails on all edible and non edible…",
                ProductTypeId = SeedProp.ProductType1

            };
            products.Add(product2);

            var product3 = new Product()
            {
                ProductId = SeedProp.ProductId3,
                ProductName = "Diesel 1",
                Description = "Red diesel with additional power",
                ProductTypeId = SeedProp.ProductType3

            };
            products.Add(product3);

            var product4 = new Product()
            {
                ProductId = SeedProp.ProductId4,
                ProductName = "Diesel 2",
                Description = "Standard Diesel",
                ProductTypeId = SeedProp.ProductType3

            };
            products.Add(product4);

            var product5 = new Product()
            {
                ProductId = SeedProp.ProductId5,
                ProductName = "Grain 1",
                Description = "Top Quality Grain",
                ProductTypeId = SeedProp.ProductType2

            };
            products.Add(product5);

            var product6 = new Product()
            {
                ProductId = SeedProp.ProductId6,
                ProductName = "Grain 2",
                Description = "Fine Grain",
                ProductTypeId = SeedProp.ProductType2

            };
            products.Add(product6);

            var product7 = new Product()
            {
                ProductId = SeedProp.ProductId7,
                ProductName = "Grain 3",
                Description = "Strong Grain",
                ProductTypeId = SeedProp.ProductType2

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
