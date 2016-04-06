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

         public IDbSet<Product> Products { get; set; }

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<CompanyBranch>()
                    .HasMany<Order>(s => s.SellOrders)
                    .WithRequired(s => s.Supplier)
                    .HasForeignKey(s => s.SupplierId);


            modelBuilder.Entity<CompanyBranch>()
                    .HasMany<Order>(s => s.BuyOrders)
                    .WithRequired(s => s.Customer)
                    .HasForeignKey(s => s.CustomerId);
            base.OnModelCreating(modelBuilder);
        }
       
         public IDbSet<Listing> Listings { get; set; }
         public IDbSet<OrderItem> OrderItems { get; set; }
         public IDbSet<Company> Companies { get; set; }
         public IDbSet<CompanyBranch> CompanyBranches { get; set; }
         public IDbSet<CompanyUser> CompanyUsers { get; set; }
         public IDbSet<Order> Orders { get; set; }
         public IDbSet<Submission> Submissions { get; set; }
    }
}
