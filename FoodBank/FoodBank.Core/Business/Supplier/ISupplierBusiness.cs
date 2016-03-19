using System;
using System.Threading.Tasks;
using Aspose.Words;
using FoodBank.Core.Dto.Supplier;

namespace FoodBank.Core.Business.Supplier
{
    public interface ISupplierBusiness
    {
        Task<Guid> Create(SupplierCreateModel model);
        Task Update(SupplierEditModel model);
        Task<Guid> CreateBranch(SupplierBranchCreateModel model);
        Task UpdateBranch(SupplierBranchEditModel model);


    }

    public class SupplierBusiness : ISupplierBusiness
    {
        public Task<Guid> Create(SupplierCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task Update(SupplierEditModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateBranch(SupplierBranchCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBranch(SupplierBranchEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}