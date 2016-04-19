using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Dto.Listing;
using FoodBank.Core.Dto.Order;

namespace FoodBank.Core.Business.Order
{
    public interface IOrderBusiness
    {
        Task<Guid> Create(OrderCreateModel model);
        Task SetCompanyReference(Guid orderItemId, string customerItemReference);
        Task UpdateStatus(Guid id, OrderItemStatus orderItemStatus);
        Task<OrderIndexModel> GetCompanyOrders(Guid id);
        Task<OrderIndexModel> GetCompanyBranchOrders(Guid id);
        Task CreateOrdersFromBasket(OrderCreateFromBasketModel model);
        OrderEditModel GetOrderById(Guid id);
    }

    public class OrderBusiness : IOrderBusiness
    {
        private readonly IAppDbContext _appDbContext;

        public OrderBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(OrderCreateModel model)
        {
            //todo Get all listings and group by Company Branch then place a order for each CompanyBranch

            //Is there available amount
            //Is Past its useby date

            var id = Guid.NewGuid();

            var order = new Data.Model.Order();
            order.OrderId = id;
            order.SupplierId = model.SupplierBranchId;
            order.CustomerId = model.CustomerBranchId;
            order.CustomerOrderReference = model.CustomerOrderReference;
            order.OrderStatus = OrderStatus.Open;
            
            foreach (var item in model.OrderItems)
            {
                var orderItem = new OrderItem();
                orderItem.OrderItemId = Guid.NewGuid();
                orderItem.ListingId = item.ListingId;
                orderItem.Quantity = item.Quantity;
                orderItem.CustomerItemReference = item.CustomerItemReference;
                orderItem.OrderItemStatus = OrderItemStatus.Requested;
            }

           
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();
            return id;
        }

      

        public async Task SetCompanyReference(Guid orderItemId, string customerItemReference)
        {
            var orderItem = await _appDbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == orderItemId);
            if (orderItem != null)
            {
                orderItem.CustomerItemReference = customerItemReference;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStatus(Guid id, OrderItemStatus orderItemStatus)
        {
            var orderItem = await _appDbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == id);
            if (orderItem != null)
            {
                //Todo maybe some rules like if claim is cancelled to order amount to 0 but audit the change
                switch (orderItemStatus)
                {
                        //case OrderItemStatus.Cancelled:
                        //if (orderItem.OrderItemStatus == OrderItemStatus.Completed)
                        //{
                            
                        //}
                        //break;
                }

                orderItem.OrderItemStatus = orderItemStatus;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<OrderIndexModel> GetCompanyOrders(Guid id)
        {

            //todo anonymous type it
            var model = new OrderIndexModel();

            var orders = await _appDbContext.Orders.Where(o => o.Customer.CompanyId == id).ToListAsync();
            foreach (var order in orders)
            {
                model.OrderIndexItemModels.Add(new OrderIndexItemModel()
                {
                    CompanyId = order.Customer.CompanyId,
                    CompanyBranchName = order.Customer.CompanyBranchName,
                    CompanyName = order.Customer.Company.CompanyName,
                    CreationDate = order.CreationDate,
                    OrderStatus = order.OrderStatus,
                    OrderId = order.OrderId,
                     CompanyOrderReference = order.CustomerOrderReference,
                    NumberOfItems = order.OrderItems.Count
                });
            }


            return model;
        }

        public async Task<OrderIndexModel> GetCompanyBranchOrders(Guid id)
        {
            //todo anonymous type it
            var model = new OrderIndexModel();

            var orders = _appDbContext.Orders.Where(o => o.CustomerId == id);
            foreach (var order in await orders.ToListAsync())
            {
                model.OrderIndexItemModels.Add(new OrderIndexItemModel()
                {
                    CompanyId = order.Customer.CompanyId,
                    CompanyBranchName = order.Customer.CompanyBranchName,
                   CompanyName = order.Customer.Company.CompanyName,
                    CreationDate = order.CreationDate,
                    OrderStatus = order.OrderStatus,
                    OrderId = order.OrderId,
                    CompanyOrderReference = order.CustomerOrderReference,
                    NumberOfItems = order.OrderItems.Count
                });
            }


            return model;
        }

        public async Task CreateOrdersFromBasket(OrderCreateFromBasketModel model)
        {
            //Get the basket 
            var basket = await _appDbContext.Baskets.FirstOrDefaultAsync(o => o.BasketId == model.BasketId);
            if (basket != null)
            {
                //group listings by supplier branch
                var basketItemsByBranch = basket.BasketItems.GroupBy(
                    o => o.Listing.CompanyBranchId, 
                    (key,g) => new {
                   BranchId = key,
                   Items = g.ToList()
                });
                //place order for each branch
                foreach (var basketGroup in basketItemsByBranch)
                {
                    var order = new Data.Model.Order();
                    order.OrderId = Guid.NewGuid();
                    order.SupplierId = basketGroup.BranchId;
                    order.CustomerId = model.CustomerBranchId;
                    order.CustomerOrderReference = model.CustomerOrderReference;
                    order.OrderStatus = OrderStatus.Open;
                    order.CreationDate = DateTime.UtcNow;
                    foreach (var item in basketGroup.Items)
                    {
                        var orderItem = new OrderItem();
                        orderItem.OrderItemId = Guid.NewGuid();
                        orderItem.ListingId = item.ListingId;
                        orderItem.Quantity = item.Quantity;
                        orderItem.OrderItemStatus = OrderItemStatus.Requested;
                    }
                    _appDbContext.Orders.Add(order);
                }
                await _appDbContext.SaveChangesAsync();
            }
        }

        public OrderEditModel GetOrderById(Guid id)
        {
            var model = new OrderEditModel();
            var order = _appDbContext.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order != null)
            {
                model.OrderId = order.OrderId;
                model.SupplierId = order.SupplierId;
                model.CreationDate = order.CreationDate;
                model.CustomerOrderReference = order.CustomerOrderReference;
                model.OrderStatus = order.OrderStatus;

                model.SupplierBranchName = order.Supplier.CompanyBranchName;
                model.SupplierAddress1 = order.Supplier.Address1;
                model.SupplierAddress2 = order.Supplier.Address2;
                model.SupplierAddress3 = order.Supplier.Address3;
                model.SupplierTownCity = order.Supplier.TownCity;
                model.SupplierCounty = order.Supplier.County;
                model.SupplierPostCode = order.Supplier.PostCode;
                model.SupplierContactEmailAddress= order.Supplier.ContactEmailAddress;
                model.SupplierContactPhoneNumber= order.Supplier.ContactPhoneNumber;
                model.SupplierContactName= order.Supplier.ContactName;

                model.CustomerBranchName = order.Customer.CompanyBranchName;
                model.CustomerAddress1 = order.Customer.Address1;
                model.CustomerAddress2 = order.Customer.Address2;
                model.CustomerAddress3 = order.Customer.Address3;
                model.CustomerTownCity = order.Customer.TownCity;
                model.CustomerCounty = order.Customer.County;
                model.CustomerPostCode = order.Customer.PostCode;
                model.CustomerContactEmailAddress = order.Customer.ContactEmailAddress;
                model.CustomerContactPhoneNumber = order.Customer.ContactPhoneNumber;
                model.CustomerContactName = order.Customer.ContactName;


                foreach (var orderItem in order.OrderItems)
                {
                    model.OrderItems.Add(new OrderItemEditModel()
                    {
                        ProductId = orderItem.Listing.ProductId,
                        ProductName = orderItem.Listing.Product.ProductName,
                        OrderId = orderItem.OrderId,
                        OrderItemId = orderItem.OrderItemId,
                        OrderItemStatus = orderItem.OrderItemStatus,
                        ListingId = orderItem.ListingId,
                        CreationDate = orderItem.CreationDate,
                        Quantity = orderItem.Quantity,
                        CustomerItemReference = orderItem.CustomerItemReference,
                        ConditionType = orderItem.Listing.ConditionType,
                        CollectionDate = orderItem.CollectionDate,
                        SupplierItemReference = orderItem.SupplierItemReference,
                        UseByDate = orderItem.Listing.UseByDate

                    });
                }
            }
            return model;
        }
    }
}