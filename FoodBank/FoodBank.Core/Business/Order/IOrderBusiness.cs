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
        Task SetCompanyReference(Guid orderItemId, string CompanyReference);
        Task UpdateStatus(Guid id, OrderItemStatus orderItemStatus);
        Task<OrderIndexModel> GetCompanyOrders(Guid id);
        Task<OrderIndexModel> GetCompanyBranchOrders(Guid id);
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
            order.CompanyOrderReference = model.BankOrderReference;
            order.OrderStatus = OrderStatus.Open;
            
            foreach (var item in model.OrderItems)
            {
                var orderItem = new OrderItem();
                orderItem.OrderItemId = Guid.NewGuid();
                orderItem.ListingId = item.ListingId;
                orderItem.Quantity = item.Quantity;
                orderItem.BankReference = item.BankReference;
                orderItem.OrderItemStatus = OrderItemStatus.Requested;
            }

           
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();
            return id;
        }

      

        public async Task SetCompanyReference(Guid orderItemId, string CompanyReference)
        {
            var orderItem = await _appDbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == orderItemId);
            if (orderItem != null)
            {
                orderItem.CompanyReference = CompanyReference;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStatus(Guid id, OrderItemStatus orderItemStatus)
        {
            var orderItem = await _appDbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == id);
            if (orderItem != null)
            {
                //Todo maybe some rules like if claim is cancelled to order amount to 0 but audit the change


                orderItem.OrderItemStatus = orderItemStatus;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<OrderIndexModel> GetCompanyOrders(Guid id)
        {

            //todo anonymous type it
            var model = new OrderIndexModel();

            var orders = _appDbContext.Orders.Where(o => o.CompanyBranch.CompanyId == id);
            foreach (var order in orders)
            {
                model.OrderIndexItemModels.Add(new OrderIndexItemModel()
                {
                    CompanyId = order.CompanyBranch.CompanyId,
                    CompanyBranchName = order.CompanyBranch.CompanyBranchName,
                    CompanyName = order.CompanyBranch.Company.CompanyName,
                    CreationDate = order.CreationDate,
                    OrderStatus = order.OrderStatus,
                    OrderId = order.OrderId,
                     CompanyOrderReference = order.CompanyOrderReference,
                    NumberOfItems = order.OrderItems.Count
                });
            }


            return model;
        }

        public async Task<OrderIndexModel> GetCompanyBranchOrders(Guid id)
        {
            //todo anonymous type it
            var model = new OrderIndexModel();

            var orders = _appDbContext.Orders.Where(o => o.CompanyBranchId == id);
            foreach (var order in await orders.ToListAsync())
            {
                model.OrderIndexItemModels.Add(new OrderIndexItemModel()
                {
                    CompanyId = order.CompanyBranch.CompanyId,
                    CompanyBranchName = order.CompanyBranch.CompanyBranchName,
                   CompanyName = order.CompanyBranch.Company.CompanyName,
                    CreationDate = order.CreationDate,
                    OrderStatus = order.OrderStatus,
                    OrderId = order.OrderId,
                    CompanyOrderReference = order.CompanyOrderReference,
                    NumberOfItems = order.OrderItems.Count
                });
            }


            return model;
        }
    }
}