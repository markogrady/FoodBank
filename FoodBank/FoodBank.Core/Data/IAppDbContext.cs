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

       IDbSet<Product> Products { get; set; }
            IDbSet<Listing> Listings { get; set; }
        IDbSet<OrderItem> OrderItems { get; set; }
        IDbSet<Company> Companies { get; set; }
        IDbSet<CompanyBranch> CompanyBranches { get; set; }
        IDbSet<CompanyUser> CompanyUsers { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<Submission> Submissions { get; set; }
    }
}