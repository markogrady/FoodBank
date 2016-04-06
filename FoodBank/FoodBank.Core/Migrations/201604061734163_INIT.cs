namespace FoodBank.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false),
                        CompanyName = c.String(),
                        CompanyType = c.Int(nullable: false),
                        LogoUrl = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        TownCity = c.String(),
                        County = c.Int(nullable: false),
                        PostCode = c.String(),
                        ContactName = c.String(),
                        ContactPhoneNumber = c.String(),
                        ContactEmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyBranches",
                c => new
                    {
                        CompanyBranchId = c.Guid(nullable: false),
                        CompanyBranchName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        TownCity = c.String(),
                        County = c.Int(nullable: false),
                        PostCode = c.String(),
                        ContactName = c.String(),
                        ContactPhoneNumber = c.String(),
                        ContactEmailAddress = c.String(),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyBranchId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        SupplierOrderReference = c.String(),
                        CustomerOrderReference = c.String(),
                        SupplierId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.CompanyBranches", t => t.CustomerId)
                .ForeignKey("dbo.CompanyBranches", t => t.SupplierId)
                .Index(t => t.SupplierId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Guid(nullable: false),
                        SupplierItemReference = c.String(),
                        CustomerItemReference = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectionDate = c.DateTime(),
                        CreationDate = c.DateTime(nullable: false),
                        OrderItemStatus = c.Int(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        ListingId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Listings", t => t.ListingId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.ListingId);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingId = c.Guid(nullable: false),
                        CompanyReference = c.String(),
                        ListingName = c.String(),
                        Description = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UseByDate = c.DateTime(),
                        ListingStatus = c.Int(nullable: false),
                        ConditionType = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CompanyBranchId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ListingId)
                .ForeignKey("dbo.CompanyBranches", t => t.CompanyBranchId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.CompanyBranchId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ProductName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.CompanyUsers",
                c => new
                    {
                        CompanyUserId = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        CompanyBranchId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.CompanyUserId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.CompanyBranches", t => t.CompanyBranchId)
                .Index(t => t.CompanyUserId)
                .Index(t => t.CompanyId)
                .Index(t => t.CompanyBranchId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AvatarUrl = c.String(),
                        ChangePasswordOnFirstLogin = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionId = c.Guid(nullable: false),
                        Reference = c.String(),
                        LocationUrl = c.String(),
                        FileName = c.String(),
                        SubmissionStatus = c.Int(nullable: false),
                        JsonErrorPayload = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "SupplierId", "dbo.CompanyBranches");
            DropForeignKey("dbo.CompanyUsers", "CompanyBranchId", "dbo.CompanyBranches");
            DropForeignKey("dbo.CompanyUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyUsers", "CompanyUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompanyBranches", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.CompanyBranches");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Listings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.Listings", "CompanyBranchId", "dbo.CompanyBranches");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CompanyUsers", new[] { "CompanyBranchId" });
            DropIndex("dbo.CompanyUsers", new[] { "CompanyId" });
            DropIndex("dbo.CompanyUsers", new[] { "CompanyUserId" });
            DropIndex("dbo.Listings", new[] { "ProductId" });
            DropIndex("dbo.Listings", new[] { "CompanyBranchId" });
            DropIndex("dbo.OrderItems", new[] { "ListingId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "SupplierId" });
            DropIndex("dbo.CompanyBranches", new[] { "CompanyId" });
            DropTable("dbo.Submissions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CompanyUsers");
            DropTable("dbo.Products");
            DropTable("dbo.Listings");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.CompanyBranches");
            DropTable("dbo.Companies");
        }
    }
}