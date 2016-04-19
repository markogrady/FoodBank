﻿using System;
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
        Task<CompanyIndexModel> GetCompanies();
       
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
            var company1 = new Data.Model.Company()
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

            company1.CompanyBranches.Add(
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

            _appDbContext.Companies.Add(company1);
            await _appDbContext.SaveChangesAsync();

            return id;
        }

        public async Task Update(CompanyEditModel model)
        {
            var company = await _appDbContext.Companies.FirstOrDefaultAsync(o => o.CompanyId == model.CompanyId);
            if (company != null)
            {
                company.CompanyName = model.CompanyName;
                company.Address1 = model.Address1;
                company.Address2 = model.Address2;
                company.Address3 = model.Address3;
                company.TownCity = model.TownCity;
                company.County = model.County;
                company.ContactEmailAddress = model.TownCity;
                company.ContactName = model.ContactName;
                company.ContactPhoneNumber = model.ContactPhoneNumber;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Guid> CreateBranch(CompanyBranchCreateModel model)
        {
            var id = Guid.NewGuid();
            var company = await _appDbContext.Companies.FirstOrDefaultAsync(o => o.CompanyId == model.CompanyId);

            company.CompanyBranches.Add(new CompanyBranch()
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
            var companyBranch = await _appDbContext.CompanyBranches.FirstOrDefaultAsync(o => o.CompanyBranchId == model.CompanyBranchId);
            if (companyBranch != null)
            {
                companyBranch.Address1 = model.Address1;
                companyBranch.Address2 = model.Address2;
                companyBranch.Address3 = model.Address3;
                companyBranch.TownCity = model.TownCity;
                companyBranch.County = model.County;
                companyBranch.ContactEmailAddress = model.TownCity;
                companyBranch.ContactName = model.ContactName;
                companyBranch.ContactPhoneNumber = model.ContactPhoneNumber;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public Task<CompanyIndexModel> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyEditModel> GetCompany(Guid id)
        {


            var model = new CompanyEditModel();

            var company = await _appDbContext.Companies.FirstOrDefaultAsync(o => o.CompanyId == id);
            if (company != null)
            {

                model.CompanyId = company.CompanyId;
                model.CompanyName = company.CompanyName;
                model.ContactName = company.ContactName;
                model.Address1 = company.Address1;
                model.Address2 = company.Address2;
                model.Address3 = company.Address3;
                model.ContactEmailAddress = company.ContactEmailAddress;
                model.ContactPhoneNumber = company.ContactPhoneNumber;
                model.County = company.County;
                model.LogoUrl = company.LogoUrl;
                model.PostCode = company.PostCode;
                model.TownCity = company.TownCity;
                foreach (var companyBranch in company.CompanyBranches)
                {
                    model.CompanyBranchEditModels.Add(new CompanyBranchEditModel()
                    {
                        CompanyBranchId = companyBranch.CompanyBranchId,
                        ContactPhoneNumber = companyBranch.ContactPhoneNumber,
                        Address1 = companyBranch.Address1,
                        Address2 = companyBranch.Address2,
                        Address3 = companyBranch.Address3,
                        TownCity = companyBranch.TownCity,
                        CompanyBranchName = companyBranch.CompanyBranchName,
                        County = companyBranch.County,
                        ContactName = companyBranch.ContactName,
                        ContactEmailAddress = companyBranch.ContactEmailAddress,
                        PostCode = companyBranch.PostCode,
                    });
                }


            }

            return model;
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