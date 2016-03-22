using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodBank.Core.Data
{
     public class AppDbContext : IdentityDbContext<AppUser, ApplicationRole, Guid, UserLogin, UserRole, UserClaim>, IAppDbContext
    {
        static AppDbContext()
        {


        }

        public AppDbContext(DbConnection connection) : base(connection, true)
        {

        }

        public AppDbContext()
                : base("DefaultConnection")
        {
            // needs to be added  this.Configuration.LazyLoadingEnabled = false;
        }

        public static AppDbContext Create()
        {

            return new AppDbContext();
        }

        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {

            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
         public IDbSet<BankUser> BankUsers { get; set; }
         public IDbSet<BankBranch> BankBranches { get; set; }
         public IDbSet<BankCompany> BankCompanies { get; set; }
         public IDbSet<Listing> Listings { get; set; }
         public IDbSet<OrderItem> OrderItems { get; set; }
         public IDbSet<Supplier> Suppliers { get; set; }
         public IDbSet<SupplierBranch> SupplierBranches { get; set; }
         public IDbSet<SupplierUser> SupplierUsers { get; set; }
         public IDbSet<Order> Orders { get; set; }
    }
}
