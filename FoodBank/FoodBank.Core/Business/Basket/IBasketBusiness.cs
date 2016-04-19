using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Dto.Basket;

namespace FoodBank.Core.Business.Basket
{
    public interface IBasketBusiness
    {
        BasketEditModel GetBasket(Guid id);
        void AddItem(BasketAddModel model);
        void SetQuantity(BasketSetQuanityModel model);
        void RemoveItem(Guid id);
    }

    public class BasketBusiness : IBasketBusiness
    {
        private IAppDbContext _appDbContext;

        public BasketBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public BasketEditModel GetBasket(Guid id)
        {
            var model = new BasketEditModel();
            var basket = _appDbContext.Baskets.FirstOrDefault(o => o.CompanyUserId == id);
            if (basket != null)
            {
                model.BasketId = basket.BasketId;
                foreach (var basketItem in basket.BasketItems)
                {
                model.BasketItemModels.Add(new BasketItemModel()
                {
                    BasketItemId = basketItem.BasketItemId,
                    ProductName = basketItem.Listing.Product.ProductName,
                    SupplierBranch = basketItem.Listing.CompanyBranch.CompanyBranchName,
                    Quantity = basketItem.Quantity
                });


                }

            }

            return model;
        }

        public void AddItem(BasketAddModel model)
        {
            var isNew = false;
            var basket = _appDbContext.Baskets.FirstOrDefault(o => o.CompanyUserId == model.CompanyUserId);
            if (basket == null)
            {
                isNew = true;
                basket = new Data.Model.Basket();
                basket.BasketId = Guid.NewGuid();
                basket.CreationDate = DateTime.UtcNow;
                basket.CompanyUserId = model.CompanyUserId;
            }

            var basketItem = basket.BasketItems.FirstOrDefault(o => o.ListingId == model.ListingId);
            if (basketItem == null)
            {
                basketItem = new BasketItem();
                basketItem.BasketItemId = Guid.NewGuid();
                basketItem.ListingId = model.ListingId;
                basketItem.Quantity = model.Quantity;
                basket.BasketItems.Add(basketItem);
            }
            else
            {
                basketItem.Quantity += model.Quantity;
            }

            if (isNew)
            {
                _appDbContext.Baskets.Add(basket);
            }
            _appDbContext.SaveChanges();
        }

        public void SetQuantity(BasketSetQuanityModel model)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}