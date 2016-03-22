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
        Task SetSupplierReference(Guid orderItemId, string supplierReference);
        Task UpdateStatus(Guid id, OrderItemStatus orderItemStatus);
        Task<OrderIndexModel> GetSupplierOrders(Guid id);
        Task<OrderIndexModel> GetSupplierBranchOrders(Guid id);
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
            //todo Get all listings and group by supplier Branch then place a order for each supplierBranch

            //Is there available amount
            //Is Past its useby date

            var id = Guid.NewGuid();

            var order = new Data.Model.Order();
            order.OrderId = id;
            order.BankOrderReference = model.BankOrderReference;
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

      

        public async Task SetSupplierReference(Guid orderItemId, string supplierReference)
        {
            var orderItem = await _appDbContext.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == orderItemId);
            if (orderItem != null)
            {
                orderItem.SupplierReference = supplierReference;
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

        public async Task<OrderIndexModel> GetSupplierOrders(Guid id)
        {

            //todo anonymous type it
            var model = new OrderIndexModel();

            var orders = _appDbContext.Orders.Where(o => o.SupplierBranch.SupplierId == id);
            foreach (var order in orders)
            {
                model.OrderIndexItemModels.Add(new OrderIndexItemModel()
                {
                    SupplierId = order.SupplierBranch.SupplierId,
                    SupplierBranchName = order.SupplierBranch.SupplierBranchName,
                    BankBranchId = order.BankBranchId,
                    BankCompanyName = order.BankBranch.BankCompany.BankCompanyName,
                    SupplierName = order.SupplierBranch.Supplier.SupplierName,
                    CreationDate = order.CreationDate,
                    OrderStatus = order.OrderStatus,
                    OrderId = order.OrderId,
                    BankOrderReference = order.BankOrderReference,
                    SupplierOrderReference = order.SupplierOrderReference,
                    BankBranchName = order.BankBranch.BankBranchName,
                    NumberOfItems = order.OrderItems.Count
                });
            }


            return model;
        }

        public async Task<OrderIndexModel> GetSupplierBranchOrders(Guid id)
        {
            //todo anonymous type it
            var model = new OrderIndexModel();

            var orders = _appDbContext.Orders.Where(o => o.SupplierBranchId == id);
            foreach (var order in await orders.ToListAsync())
            {
                model.OrderIndexItemModels.Add(new OrderIndexItemModel()
                {
                    SupplierId = order.SupplierBranch.SupplierId,
                    SupplierBranchName = order.SupplierBranch.SupplierBranchName,
                    BankBranchId = order.BankBranchId,
                    BankCompanyName = order.BankBranch.BankCompany.BankCompanyName,
                    SupplierName = order.SupplierBranch.Supplier.SupplierName,
                    CreationDate = order.CreationDate,
                    OrderStatus = order.OrderStatus,
                    OrderId = order.OrderId,
                    BankOrderReference = order.BankOrderReference,
                    SupplierOrderReference = order.SupplierOrderReference,
                    BankBranchName = order.BankBranch.BankBranchName,
                    NumberOfItems = order.OrderItems.Count
                });
            }


            return model;
        }
    }
}