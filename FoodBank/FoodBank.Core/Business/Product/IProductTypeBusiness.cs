using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Dto.ProductType;

namespace FoodBank.Core.Business.Product
{
    public interface IProductTypeBusiness
    {
        Task<ProductTypeIndexModel> GetProductTypes();
        Task<ProductTypeEditModel> GetProductType(Guid id);
        Task CreateUpdateProductType(ProductTypeEditModel model);

        Task AddAttribute(Guid productTypeId, Guid attributeId);


    }

    public class ProductTypeBusiness : IProductTypeBusiness
    {
        private IAppDbContext _appDbContext;

        public ProductTypeBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProductTypeIndexModel> GetProductTypes()
        {
            var model = new ProductTypeIndexModel();
            var productTypes = await _appDbContext.ProductTypes.ToListAsync();
            foreach (var productType in productTypes)
            {
                model.ProductTypeIndexItemModels.Add(new ProductTypeIndexItemModel()
                {
                    ProductTypeId = productType.ProductTypeId,
                    ProductTypeName = productType.ProductTypeName
                });
            }
            return model;
        }

        public async Task<ProductTypeEditModel> GetProductType(Guid id)
        {
            var model = new ProductTypeEditModel();

            var productType = await _appDbContext.ProductTypes.FirstOrDefaultAsync(o => o.ProductTypeId == id);

            if (productType != null)
            {
                model.ProductTypeId = productType.ProductTypeId;
                model.ProductTypeName = productType.ProductTypeName;
                model.JsonSchema = productType.JsonSchema;

                foreach (var productTypeAttribute in productType.ProductTypeAttributes.ToList())
                {
                    model.ProductTypeAttributeEditModels.Add(new ProductTypeAttributeEditModel()
                    {
                        AttributeId = productTypeAttribute.AttributeId,
                        AttributeName = productTypeAttribute.Attribute.AttributeName
                    });
                }
            }

            return model;
        }

        public async Task CreateUpdateProductType(ProductTypeEditModel model)
        {
            var isNew = false;
            var productType = await _appDbContext.ProductTypes.FirstOrDefaultAsync(o => o.ProductTypeId == model.ProductTypeId);
            if (productType == null)
            {
                isNew = true;
                productType = new ProductType();
                productType.ProductTypeId = Guid.NewGuid();
            }

            productType.ProductTypeName = model.ProductTypeName;

            if (isNew)
                _appDbContext.ProductTypes.Add(productType);

            await _appDbContext.SaveChangesAsync();

        }

        public async Task AddAttribute(Guid productTypeId, Guid attributeId, bool isRequired)
        {
            var isNew = false;
            var productTypeAttribute = await _appDbContext.ProductTypeAttributes.FirstOrDefaultAsync(o => o.AttributeId == attributeId && o.ProductTypeId == productTypeId);
            if (productTypeAttribute == null)
            {
                isNew = true;
                productTypeAttribute = new ProductTypeAttribute();
                productTypeAttribute.ProductTypeAttributeId = Guid.NewGuid();
                productTypeAttribute.AttributeId = attributeId;
                productTypeAttribute.ProductTypeId = productTypeId;
            }

            productTypeAttribute.IsRequired = isRequired;
            if (isNew)
                _appDbContext.ProductTypeAttributes.Add(productTypeAttribute);


            await _appDbContext.SaveChangesAsync();
            await GenerateProductTypeSchema(productTypeId);

        }

        private async Task GenerateProductTypeSchema(Guid productTypeId)
        {
          var productType = await _appDbContext.ProductTypes.FirstOrDefaultAsync(o => o.ProductTypeId == productTypeId);
            if (productType != null)
            {
                var strBuilder = new StringBuilder();
                strBuilder.Append("{");
                strBuilder.Append("'title':'" + productType.ProductTypeName+ "',");
                strBuilder.Append("'type':'object',");
                if (productType.ProductTypeAttributes.Any())
                {
                    strBuilder.Append("'properties': {");
                    foreach (var productTypeAttribute in productType.ProductTypeAttributes.ToList())
                    {
                        strBuilder.Append("'" + productTypeAttribute.Attribute.AttributeName + "': {");
                        strBuilder.Append("'type':'" + productTypeAttribute.Attribute.FieldType + "'");

                        if (productTypeAttribute.MinValue.HasValue)
                            strBuilder.Append(",'minimum':'" + productTypeAttribute.MinValue.Value + "',");

                        strBuilder.Append("},");

                    }
                    strBuilder.Append("},");

                }
                if (productType.ProductTypeAttributes.Any(o => o.IsRequired))
                {
                    var requiredList = new List<string>();
                    strBuilder.Append("'required': [");
                    foreach (var field in productType.ProductTypeAttributes.Where(o => o.IsRequired))
                    {
                        requiredList.Add("'" + field.Attribute.AttributeName + "'");
                    }
                    strBuilder.Append(string.Join(",", requiredList));
                    strBuilder.Append("]");
                }
                strBuilder.Append("}");

               
                productType.JsonSchema = strBuilder.ToString(); 
               await _appDbContext.SaveChangesAsync();
            }


        }
    }
}