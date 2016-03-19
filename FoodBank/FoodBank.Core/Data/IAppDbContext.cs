using System.Data.Entity;
using System.Threading.Tasks;
using FoodBank.Core.Data.Model;
using Microsoft.AspNet.Identity.Owin;

namespace FoodBank.Core.Data
{
    public interface IAppDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        IDbSet<BankUser> BankUsers { get; set; }
        IDbSet<BankBranch> BankBranches { get; set; }
        IDbSet<BankCompany> BankCompanies { get; set; }
        IDbSet<Listing> Listings { get; set; }
        IDbSet<ListingClaim> ListingClaims { get; set; }
        IDbSet<Supplier> Suppliers { get; set; }
        IDbSet<SupplierBranch> SupplierBranches { get; set; }
        IDbSet<SupplierUser> SupplierUsers { get; set; }
    }
}