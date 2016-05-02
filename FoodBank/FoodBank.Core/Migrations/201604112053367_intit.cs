namespace FoodBank.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intit : DbMigration
    {
        public override void Up()
        {
         
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BasketItems", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.Listings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "SupplierId", "dbo.CompanyBranches");
            DropForeignKey("dbo.Listings", "CompanyBranchId", "dbo.CompanyBranches");
            DropForeignKey("dbo.CompanyUsers", "CompanyBranchId", "dbo.CompanyBranches");
            DropForeignKey("dbo.CompanyUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyUsers", "CompanyUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompanyBranches", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.CompanyBranches");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CompanyUsers", new[] { "CompanyBranchId" });
            DropIndex("dbo.CompanyUsers", new[] { "CompanyId" });
            DropIndex("dbo.CompanyUsers", new[] { "CompanyUserId" });
            DropIndex("dbo.OrderItems", new[] { "ListingId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "SupplierId" });
            DropIndex("dbo.CompanyBranches", new[] { "CompanyId" });
            DropIndex("dbo.Listings", new[] { "ProductId" });
            DropIndex("dbo.Listings", new[] { "CompanyBranchId" });
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropIndex("dbo.BasketItems", new[] { "ListingId" });
            DropTable("dbo.Submissions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CompanyUsers");
            DropTable("dbo.Companies");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.CompanyBranches");
            DropTable("dbo.Listings");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
