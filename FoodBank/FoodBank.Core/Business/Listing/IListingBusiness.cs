using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using Aspose.Words;
using Aspose.Words.Drawing;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Dto.Basket;
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

        Task<ListingIndexModel> GetListingsByCompany(Guid id);
        Task<ListingIndexModel> GetListingsByCompanyBranch(Guid id);
       
        BasketAddModel GetAddBasketListing(Guid id);
    }

    public class ListingBusiness : IListingBusiness
    {
        private readonly IAppDbContext _appDbContext;


        public ListingBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(ListingCreateModel model)
        {
            var id = Guid.NewGuid();
            var listing = new Data.Model.Listing();
            listing.ListingId = id;
            
            listing.CompanyBranchId = model.CompanyBranchId;
            listing.Description = model.Description;
            listing.ListingName = model.ListingName;
            listing.CompanyReference = model.CompanyReference;
            listing.Quantity = model.Quantity;
            listing.UseByDate = model.UseByDate;
            listing.ListingStatus = ListingStatus.Open;
            listing.CreationDate = DateTime.UtcNow;
            listing.ProductId = model.ProductId;
            listing.ConditionType = model.ConditionType;
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
                listing.CompanyReference = model.CompanyReference;
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
            return await GetListings(null, null, "", null, ListingStatus.NotSet);
        }

        private async Task<ListingIndexModel> GetListings(Guid? companyId, Guid? companyBranchId, string postcode, int? distance, ListingStatus listingStatus)
        {
            var model = new ListingIndexModel();

            IQueryable<Data.Model.Listing> listings = _appDbContext.Listings;


            if (companyId != Guid.Empty)

            {
                if (companyId != null)
                listings = listings.Where(o => o.CompanyBranch.CompanyId == companyId.Value);
            }


            if (companyBranchId != Guid.Empty)
            {
                if (companyBranchId != null)
                listings = listings.Where(o => o.CompanyBranchId == companyBranchId.Value);
            }
            if (listingStatus != ListingStatus.NotSet)
                listings = listings.Where(o => o.ListingStatus == listingStatus);
            //todo workout the closest

            foreach (var listing in await listings.ToListAsync())
            {
                model.ListingIndexItemModels.Add(new ListingIndexItemModel()
                {
                    ListingId = listing.ListingId,
                    TotalQuantity = listing.Quantity,
                    QuantityAvailable = listing.Quantity - listing.OrderItems.Where(o => !(o.OrderItemStatus == OrderItemStatus.Confirmed || o.OrderItemStatus == OrderItemStatus.Completed)).Sum(o => o.Quantity),
                    ListingName = listing.Product.ProductName,
                    CompanyId = listing.CompanyBranch.CompanyId,
                    CompanyName = listing.CompanyBranch.Company.CompanyName,
                    BranchName = listing.CompanyBranch.CompanyBranchName,
                    CompanyReference = listing.CompanyReference
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
                model.CompanyReference = listing.CompanyReference;
                model.UseByDate = listing.UseByDate;
            }
            return model;
        }

        public async Task<ListingIndexModel> GetListingsByCompany(Guid id)
        {
            return await GetListings(id, null, "", null, ListingStatus.NotSet);
        }

        public async Task<ListingIndexModel> GetListingsByCompanyBranch(Guid id)
        {
            return await GetListings(null, id, "", null, ListingStatus.NotSet);
        }

        public BasketAddModel GetAddBasketListing(Guid id)
        {
            var model = new BasketAddModel();

            var listing = _appDbContext.Listings.FirstOrDefault(o => o.ListingId == id);
            if (listing != null)
            {
                model.ListingId = id;
                model.ProductName = listing.Product.ProductName;
            }
            return model;
        }
    }
}