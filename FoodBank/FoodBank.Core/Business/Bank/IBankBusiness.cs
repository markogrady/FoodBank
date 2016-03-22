using System;
using FoodBank.Core.Dto.Bank;

namespace FoodBank.Core.Business.Bank
{
    public interface IBankBusiness
    {
        BankIndexModel GetAllBanks();
        BankEditModel GetBank(Guid id);
    }

    public class BankBusiness : IBankBusiness
    {
        public BankIndexModel GetAllBanks()
        {
            throw new System.NotImplementedException();
        }

        public BankEditModel GetBank(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}