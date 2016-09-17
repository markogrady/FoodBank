using System;
using System.Data.Entity;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Dto.Product;

namespace FoodBank.Core.Business.Product
{
    public interface IProductBusiness
    {
        Task<Guid> Create(ProductCreateModel model);
        Task Update(ProductEditModel model);
        Task<ProductEditModel> GetProduct(Guid id);
        Task<ProductIndexModel> GetProducts();
    }



    public class ProductBusiness : IProductBusiness
    {
        private IAppDbContext _appDbContext;

        public ProductBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(ProductCreateModel model)
        {
            var id = Guid.NewGuid();
            var product = new Data.Model.Product();
            product.ProductId = id;
            product.ProductName = model.ProductName;
            product.Description = model.Description;
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();

            return id;
        }

        public async Task Update(ProductEditModel model)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(o => o.ProductId == model.ProductId);
            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.Description = model.Description;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<ProductEditModel> GetProduct(Guid id)
        {
            var model = new ProductEditModel();
            var product = await _appDbContext.Products.FirstOrDefaultAsync(o => o.ProductId == id);
            if (product != null)
            {
                model.ProductId = id;
                model.ProductName = product.ProductName;
                model.Description = product.Description;
            }
            return model;
        }

        public async Task<ProductIndexModel> GetProducts()
        {
            var model = new ProductIndexModel();
            var products = await _appDbContext.Products.ToListAsync();
            foreach (var product in products)
            {
                model.ProductIndexItemModels.Add(new ProductIndexItemModel()
                {
                    Description = product.Description,
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductTypeName = product.ProductType.ProductTypeName
                
                });
            }
            return model;
        }
    }
}