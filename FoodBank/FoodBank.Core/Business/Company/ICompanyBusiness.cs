using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aspose.Words;
using FoodBank.Core.Data;
using FoodBank.Core.Data.Enum;
using FoodBank.Core.Data.Model;
using FoodBank.Core.Dto.Company;
using FoodBank.Core.Seed;

namespace FoodBank.Core.Business.Company
{
    public interface ICompanyBusiness
    {
        Task<Guid> Create(CompanyCreateModel model);
        Task Update(CompanyEditModel model);
        Task<Guid> CreateBranch(CompanyBranchCreateModel model);
        Task UpdateBranch(CompanyBranchEditModel model);
        Task<CompanyIndexModel> GetCompanys();
       
        Task<CompanyEditModel> GetCompany(Guid id);

        Task<CompanyBranchIndexModel> GetCompanyBranches(Guid id);

        Task<CompanyBranchEditModel> GetCompanyBranch(Guid id);
        Task AddCompanyUser(AppUser user, Guid companyId);
    }

    public class CompanyBusiness : ICompanyBusiness
    {
        private readonly IAppDbContext _appDbContext;

        public CompanyBusiness(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Create(CompanyCreateModel model)
        {
            //todo Validation
            //DoesNameexists

            var id = Guid.NewGuid();
            var Company1 = new Data.Model.Company()
            {
                CompanyId = id,
                CompanyName = model.CompanyName,
                Address1 = model.CompanyAddress1,
                Address2 = model.CompanyAddress2,
                Address3 = model.CompanyAddress3,
                TownCity = model.CompanyTownCity,
                County = model.CompanyCounty,
                ContactEmailAddress = model.CompanyTownCity,
                ContactName = model.CompanyContactName,
                ContactPhoneNumber = model.CompanyContactPhoneNumber,
            };

            Company1.CompanyBranches.Add(
                new CompanyBranch()
                {
                    CompanyBranchId = Guid.NewGuid(),
                    CompanyBranchName = model.CompanyBranchName,
                    Address1 = model.CompanyBranchAddress1,
                    Address2 = model.CompanyBranchAddress2,
                    Address3 = model.CompanyBranchAddress3,
                    TownCity = model.CompanyBranchTownCity,
                    County = model.CompanyBranchCounty,
                    ContactEmailAddress = model.CompanyBranchTownCity,
                    ContactName = model.CompanyBranchContactName,
                    ContactPhoneNumber = model.CompanyBranchContactPhoneNumber,
                });

            _appDbContext.Companies.Add(Company1);
            await _appDbContext.SaveChangesAsync();

            return id;
        }

        public async Task Update(CompanyEditModel model)
        {
            var Company = await _appDbContext.Companies.FirstOrDefaultAsync(o => o.CompanyId == model.CompanyId);
            if (Company != null)
            {
                Company.CompanyName = model.CompanyName;
                Company.Address1 = model.Address1;
                Company.Address2 = model.Address2;
                Company.Address3 = model.Address3;
                Company.TownCity = model.TownCity;
                Company.County = model.County;
                Company.ContactEmailAddress = model.TownCity;
                Company.ContactName = model.ContactName;
                Company.ContactPhoneNumber = model.ContactPhoneNumber;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Guid> CreateBranch(CompanyBranchCreateModel model)
        {
            var id = Guid.NewGuid();
            var Company = await _appDbContext.Companies.FirstOrDefaultAsync(o => o.CompanyId == model.CompanyId);

            Company.CompanyBranches.Add(new CompanyBranch()
            {
                CompanyBranchId = id,
                CompanyBranchName = model.CompanyBranchName,
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

        public async Task UpdateBranch(CompanyBranchEditModel model)
        {
            var CompanyBranch = await _appDbContext.CompanyBranches.FirstOrDefaultAsync(o => o.CompanyBranchId == model.CompanyBranchId);
            if (CompanyBranch != null)
            {
                CompanyBranch.Address1 = model.Address1;
                CompanyBranch.Address2 = model.Address2;
                CompanyBranch.Address3 = model.Address3;
                CompanyBranch.TownCity = model.TownCity;
                CompanyBranch.County = model.County;
                CompanyBranch.ContactEmailAddress = model.TownCity;
                CompanyBranch.ContactName = model.ContactName;
                CompanyBranch.ContactPhoneNumber = model.ContactPhoneNumber;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public Task<CompanyIndexModel> GetCompanys()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyEditModel> GetCompany(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyBranchIndexModel> GetCompanyBranches(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyBranchEditModel> GetCompanyBranch(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task AddCompanyUser(AppUser user, Guid companyId)
        {
            var companyBranch = await _appDbContext.CompanyBranches.FirstOrDefaultAsync(o => o.CompanyId == companyId);
            var companyUser = new CompanyUser();
            companyUser.CompanyId = companyId;
            companyUser.CompanyUserId = user.Id;
            companyUser.CompanyBranchId = companyBranch.CompanyBranchId;
            _appDbContext.CompanyUsers.Add(companyUser);
            await _appDbContext.SaveChangesAsync();
        }
    }
}