using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Words;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Dto.Supplier;
using FoodBank.Core.Seed;

namespace FoodBank.Core.Business.Supplier
{
    public interface ISupplierBusiness
    {
        Task<Guid> Create(SupplierCreateModel model);
        Task Update(SupplierEditModel model);
        Task<Guid> CreateBranch(SupplierBranchCreateModel model);
        Task UpdateBranch(SupplierBranchEditModel model);
        Task<SupplierIndexModel> GetSuppliers();
       
        Task<SupplierEditModel> GetSupplier(Guid id);

        Task<SupplierBranchIndexModel> GetSupplierBranches(Guid id);

        Task<SupplierBranchEditModel> GetSupplierBranch(Guid id);
    }

    public class SupplierBusiness : ISupplierBusiness
    {
        private readonly IAppDbContext _appDbContext;

        public SupplierBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(SupplierCreateModel model)
        {
            //todo Validation
            //DoesNameexists

            var id = Guid.NewGuid();
            var supplier1 = new Data.Model.Supplier()
            {
                SupplierId = id,
                SupplierName = model.SupplierName,
                Address1 = model.SupplierAddress1,
                Address2 = model.SupplierAddress2,
                Address3 = model.SupplierAddress3,
                TownCity = model.SupplierTownCity,
                County = model.SupplierCounty,
                ContactEmailAddress = model.SupplierTownCity,
                ContactName = model.SupplierContactName,
                ContactPhoneNumber = model.SupplierContactPhoneNumber,
            };

            supplier1.SupplierBranches.Add(
                new SupplierBranch()
                {
                    SupplierBranchId = Guid.NewGuid(),
                    SupplierBranchName = model.SupplierBranchName,
                    Address1 = model.SupplierBranchAddress1,
                    Address2 = model.SupplierBranchAddress2,
                    Address3 = model.SupplierBranchAddress3,
                    TownCity = model.SupplierBranchTownCity,
                    County = model.SupplierBranchCounty,
                    ContactEmailAddress = model.SupplierBranchTownCity,
                    ContactName = model.SupplierBranchContactName,
                    ContactPhoneNumber = model.SupplierBranchContactPhoneNumber,
                });

            _appDbContext.Suppliers.Add(supplier1);
            await _appDbContext.SaveChangesAsync();

            return id;
        }

        public async Task Update(SupplierEditModel model)
        {
            var supplier = await _appDbContext.Suppliers.FirstOrDefaultAsync(o => o.SupplierId == model.SupplierId);
            if (supplier != null)
            {
                supplier.SupplierName = model.SupplierName;
                supplier.Address1 = model.Address1;
                supplier.Address2 = model.Address2;
                supplier.Address3 = model.Address3;
                supplier.TownCity = model.TownCity;
                supplier.County = model.County;
                supplier.ContactEmailAddress = model.TownCity;
                supplier.ContactName = model.ContactName;
                supplier.ContactPhoneNumber = model.ContactPhoneNumber;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Guid> CreateBranch(SupplierBranchCreateModel model)
        {
            var id = Guid.NewGuid();
            var supplier = await _appDbContext.Suppliers.FirstOrDefaultAsync(o => o.SupplierId == model.SupplierId);

            supplier.SupplierBranches.Add(new SupplierBranch()
            {
                SupplierBranchId = id,
                SupplierBranchName = model.SupplierBranchName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Address3 = model.Address3,
                TownCity = model.TownCity,
                County = model.County,
                ContactEmailAddress = model.TownCity,
                ContactName = model.ContactName,
                ContactPhoneNumber = model.ContactPhoneNumber,
            });
            await _appDbContext.SaveChangesAsync();
            return id;
        }

        public async Task UpdateBranch(SupplierBranchEditModel model)
        {
            var supplierBranch = await _appDbContext.SupplierBranches.FirstOrDefaultAsync(o => o.SupplierBranchId == model.SupplierBranchId);
            if (supplierBranch != null)
            {
                supplierBranch.Address1 = model.Address1;
                supplierBranch.Address2 = model.Address2;
                supplierBranch.Address3 = model.Address3;
                supplierBranch.TownCity = model.TownCity;
                supplierBranch.County = model.County;
                supplierBranch.ContactEmailAddress = model.TownCity;
                supplierBranch.ContactName = model.ContactName;
                supplierBranch.ContactPhoneNumber = model.ContactPhoneNumber;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public Task<SupplierIndexModel> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public Task<SupplierEditModel> GetSupplier(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierBranchIndexModel> GetSupplierBranches(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierBranchEditModel> GetSupplierBranch(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}