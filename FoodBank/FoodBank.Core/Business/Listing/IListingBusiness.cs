using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Dto.Listing;

namespace FoodBank.Core.Business.Listing
{
    public interface IListingBusiness
    {
        Task<Guid> Create(ListingCreateModel model);
        Task Update(ListingEditModel model);
        Task UpdateQuantity(Guid listingId, decimal quantity);
        Task UpdateStatus(Guid listingId, ListingStatus listingStatus);
        Task<ListingIndexModel> GetListings();
        Task<ListingEditModel> GetListing(Guid id);

    }

    public class ListingBusiness : IListingBusiness
    {
        private IAppDbContext _appDbContext;

        public ListingBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(ListingCreateModel model)
        {
            var id = Guid.NewGuid();
            var listing = new Data.Model.Listing();
            listing.ListingId = id;

            listing.SupplierBranchId = model.SupplierBranchId;
            listing.Description = model.Description;
            listing.ListingName = model.ListingName;
            listing.SupplierReference = model.SupplierReference;
            listing.Quantity = model.Quantity;
            listing.UseByDate = model.UseByDate;

            listing.ListingStatus = ListingStatus.Open;
            listing.CreationDate = DateTime.UtcNow;

            _appDbContext.Listings.Add(listing);
            await _appDbContext.SaveChangesAsync();
            return id;
        }

        public async Task Update(ListingEditModel model)
        {
            var listing = await _appDbContext.Listings.FirstOrDefaultAsync(o => o.ListingId == model.ListingId);
            if (listing != null)
            {
                listing.Description = model.Description;
                listing.SupplierReference = model.SupplierReference;
                listing.UseByDate = model.UseByDate;
                listing.ListingName = model.Description;

            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateQuantity(Guid listingId, decimal quantity)
        {
            var listing = await _appDbContext.Listings.FirstOrDefaultAsync(o => o.ListingId == listingId);
            if (listing != null)
            {
                listing.Quantity = quantity;
                if (listing.Quantity == 0)
                {
                    listing.ListingStatus = ListingStatus.Closed;
                    //todo if outstanding claims then contact them
                }
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStatus(Guid listingId, ListingStatus listingStatus)
        {
            var listing = await _appDbContext.Listings.FirstOrDefaultAsync(o => o.ListingId == listingId);
            if (listing != null)
            {
               
                    listing.ListingStatus = listingStatus;
                    //todo if outstanding claims then contact them
               
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<ListingIndexModel> GetListings()
        {
            var model = new ListingIndexModel();

            var listings = await _appDbContext.Listings.ToListAsync();
            foreach (var listing in listings)
            {
                model.ListingIndexItemModels.Add(new ListingIndexItemModel()
                {
                    ListingId = listing.ListingId,
                    TotalQuantity = listing.Quantity,
                    QuantityAvailable = listing.Quantity - listing.ListingClaims.Sum(o => o.Quantity),
                    ListingName = listing.ListingName,
                    SupplierId = listing.SupplierBranch.SupplierId,
                    SupplierName = listing.SupplierBranch.Supplier.SupplierName

                });
            }
            return model;
        }

        public async Task<ListingEditModel> GetListing(Guid id)
        {
           var model = new ListingEditModel();
            var listing = await _appDbContext.Listings.FirstOrDefaultAsync(o => o.ListingId == id);
            if (listing != null)
            {
                model.ListingId = listing.ListingId;
                model.CreationDate = listing.CreationDate;
                model.Description = listing.Description;
                model.ListingName = listing.ListingName;
                model.ListingStatus = listing.ListingStatus;
                model.Quantity = listing.Quantity;
                model.SupplierReference = listing.SupplierReference;
                model.UseByDate = listing.UseByDate;
            }
            return model;
        }
    }
}