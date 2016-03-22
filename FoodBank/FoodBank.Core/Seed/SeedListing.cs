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
                ListingId = SeedProp.SeedListing1,
                CreationDate = DateTime.UtcNow,
                Description = "Doughnuts in packs of 10",
                SupplierReference = "DNR10",
                SupplierBranchId = SeedProp.SeedSupplier1Branch1,
                ListingName = "Doughnuts",
                ListingStatus = ListingStatus.Open,
                Quantity = 50,
                UseByDate = DateTime.UtcNow.AddDays(10)
            };

            //listing1.OrderItems.Add(new OrderItem() { OrderItemStatus = OrderItemStatus.Requested, CreationDate = DateTime.UtcNow, OrderItemId = SeedProp.Listing1Claime1, Quantity = 10, BankReference = "rewrew" });
            listings.Add(listing1);


            listings.Add(new Listing()
            {
                ListingId = SeedProp.SeedListing2,
                CreationDate = DateTime.UtcNow,
                Description = "Apples",
                SupplierReference = "App1",
                SupplierBranchId = SeedProp.SeedSupplier1Branch1,
                ListingName = "Apples",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });

            listings.Add(new Listing()
            {
                ListingId = SeedProp.SeedListing3,
                CreationDate = DateTime.UtcNow,
                Description = "CornFlakes Damaged Boxes",
                SupplierReference = "App1",
                SupplierBranchId = SeedProp.SeedSupplier1Branch1,
                ListingName = "Cornflakes",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(200)
            });

            listings.Add(new Listing()
            {
                ListingId = SeedProp.SeedListing4,
                CreationDate = DateTime.UtcNow,
                Description = "Coffee - Closed",
                SupplierReference = "Cff1",
                SupplierBranchId = SeedProp.SeedSupplier1Branch1,
                ListingName = "Coffee",
                ListingStatus = ListingStatus.Closed,
                Quantity = 0,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ListingId = SeedProp.SeedListing5,
                CreationDate = DateTime.UtcNow,
                Description = "Mars bars",
                SupplierReference = "Mbars1",
                SupplierBranchId = SeedProp.SeedSupplier1Branch1,
                ListingName = "Mars Bars",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ListingId = SeedProp.SeedListing6,
                CreationDate = DateTime.UtcNow,
                Description = "Bread",
                SupplierReference = "Bread1",
                SupplierBranchId = SeedProp.SeedSupplier1Branch1,
                ListingName = "Bread",
                ListingStatus = ListingStatus.Open,
                Quantity = 2000,
                UseByDate = DateTime.UtcNow.AddDays(7)
            });
            listings.Add(new Listing()
            {
                ListingId = SeedProp.SeedListing7,
                CreationDate = DateTime.UtcNow,
                Description = "Sausage Rolls",
                SupplierReference = "SR1",
                SupplierBranchId = SeedProp.SeedSupplier1Branch1,
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
