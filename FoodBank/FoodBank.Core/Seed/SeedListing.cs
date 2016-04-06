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
                UseByDate = DateTime.UtcNow.AddDays(10)
            };

            //listing1.OrderItems.Add(new OrderItem() { OrderItemStatus = OrderItemStatus.Requested, CreationDate = DateTime.UtcNow, OrderItemId = SeedProp.Listing1Claime1, Quantity = 10, BankReference = "rewrew" });
            listings.Add(listing1);


            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId2,

                ListingId = SeedProp.SeedListing2,
                CreationDate = DateTime.UtcNow,
                Description = "Apples",
                CompanyReference = "App1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Apples",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });

            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId3,

                ListingId = SeedProp.SeedListing3,
                CreationDate = DateTime.UtcNow,
                Description = "CornFlakes Damaged Boxes",
                CompanyReference = "App1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Cornflakes",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(200)
            });

            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId4,

                ListingId = SeedProp.SeedListing4,
                CreationDate = DateTime.UtcNow,
                Description = "Coffee - Closed",
                CompanyReference = "Cff1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Coffee",
                ListingStatus = ListingStatus.Closed,
                Quantity = 0,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId5,

                ListingId = SeedProp.SeedListing5,
                CreationDate = DateTime.UtcNow,
                Description = "Mars bars",
                CompanyReference = "Mbars1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Mars Bars",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId6,

                ListingId = SeedProp.SeedListing6,
                CreationDate = DateTime.UtcNow,
                Description = "Bread",
                CompanyReference = "Bread1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Bread",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ProductId = SeedProp.ProductId7,

                ListingId = SeedProp.SeedListing7,
                CreationDate = DateTime.UtcNow,
                Description = "Sausage Rolls",
                CompanyReference = "SR1",
                CompanyBranchId = SeedProp.SeedCompany1Branch1,
                ListingName = "Sausage Rolls",
                ListingStatus = ListingStatus.Open,
                Quantity = 5,
                UseByDate = DateTime.UtcNow.AddDays(7)
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
