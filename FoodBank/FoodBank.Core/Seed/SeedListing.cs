using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Business.Listing;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Dto.Listing;

namespace FoodBank.Core.Seed
{
    public static class SeedListing
    {
        public static void SeedData(IAppDbContext context)
        {
            var listings = new List<Listing>();


            var listing1 = new Listing()
            {
                ProductId = SeedProp.ProductId1,
                ListingId = SeedProp.SeedListing1,
                CreationDate = DateTime.UtcNow,
                Description = "Doughnuts in packs of 10",
                CompanyReference = "DNR10",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Doughnuts",
                ListingStatus = ListingStatus.Open,
                Quantity = 50,
                UseByDate = DateTime.UtcNow.AddDays(10),
                Price = 30,
            };

            //listing1.OrderItems.Add(new OrderItem() { OrderItemStatus = OrderItemStatus.Requested, CreationDate = DateTime.UtcNow, OrderItemId = SeedProp.Listing1Claime1, Quantity = 10, BankReference = "rewrew" });
            listings.Add(listing1);


            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId2,

                ListingId = SeedProp.SeedListing2,
                CreationDate = DateTime.UtcNow,
                Description = "Pesticides",
                CompanyReference = "Pest23",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Pest2",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7),
                Price = 22.00m,

            });

            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId3,

                ListingId = SeedProp.SeedListing3,
                CreationDate = DateTime.UtcNow,
                Description = "Damaged Diesel",
                CompanyReference = "GRN1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Diesel",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(200),
                Price=34.90m
            });

            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId4,

                ListingId = SeedProp.SeedListing4,
                CreationDate = DateTime.UtcNow,
                Description = "Diesel Closed",
                CompanyReference = "Cff1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "diesel",
                ListingStatus = ListingStatus.Closed,
                Quantity = 0,
                Price = 30.00m,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId5,

                ListingId = SeedProp.SeedListing5,
                CreationDate = DateTime.UtcNow,
                Description = "Grains",
                CompanyReference = "GRN1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Grain1",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId6,

                ListingId = SeedProp.SeedListing6,
                CreationDate = DateTime.UtcNow,
                Description = "Grain",
                CompanyReference = "GRN14",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Grains",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId7,

                ListingId = SeedProp.SeedListing7,
                CreationDate = DateTime.UtcNow,
                Description = "Grains",
                CompanyReference = "GRN2",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Grains",
                ListingStatus = ListingStatus.Open,
                Quantity = 5,
                UseByDate = DateTime.UtcNow.AddDays(7),
                Price = 40.50m
            });

            foreach (var listing in listings)
            {
                var listingExist = context.Listings.Any(o => o.ListingId == listing.ListingId);
                if (!listingExist)
                {
                    context.Listings.Add(listing);
                }
            }
            context.SaveChanges();
        }
    }
}
