namespace FoodBank.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankBranches",
                c => new
                    {
                        BankBranchId = c.Guid(nullable: false),
                        BankBranchName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        TownCity = c.String(),
                        County = c.Int(nullable: false),
                        PostCode = c.String(),
                        ContactName = c.String(),
                        ContactPhoneNumber = c.String(),
                        ContactEmailAddress = c.String(),
                        BankCompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BankBranchId)
                .ForeignKey("dbo.BankCompanies", t => t.BankCompanyId)
                .Index(t => t.BankCompanyId);
            
            CreateTable(
                "dbo.BankCompanies",
                c => new
                    {
                        BankCompanyId = c.Guid(nullable: false),
                        BankCompanyName = c.String(),
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
                .PrimaryKey(t => t.BankCompanyId);
            
            CreateTable(
                "dbo.BankUsers",
                c => new
                    {
                        BankUserId = c.Guid(nullable: false),
                        BankCompanyId = c.Guid(nullable: false),
                        BankBranchId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BankUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.BankUserId)
                .ForeignKey("dbo.BankBranches", t => t.BankBranchId)
                .ForeignKey("dbo.BankCompanies", t => t.BankCompanyId)
                .Index(t => t.BankUserId)
                .Index(t => t.BankCompanyId)
                .Index(t => t.BankBranchId);
            
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
                "dbo.ListingClaims",
                c => new
                    {
                        ListingClaimId = c.Guid(nullable: false),
                        Reference = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        ClaimStatus = c.Int(nullable: false),
                        BankBranchId = c.Guid(nullable: false),
                        ListingId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ListingClaimId)
                .ForeignKey("dbo.BankBranches", t => t.BankBranchId)
                .ForeignKey("dbo.Listings", t => t.ListingId)
                .Index(t => t.BankBranchId)
                .Index(t => t.ListingId);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingId = c.Guid(nullable: false),
                        SupplierReference = c.String(),
                        ListingName = c.String(),
                        Description = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UseByDate = c.DateTime(),
                        ListingStatus = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        SupplierBranchId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ListingId)
                .ForeignKey("dbo.SupplierBranches", t => t.SupplierBranchId)
                .Index(t => t.SupplierBranchId);
            
            CreateTable(
                "dbo.SupplierBranches",
                c => new
                    {
                        SupplierBranchId = c.Guid(nullable: false),
                        SupplierBranchName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        TownCity = c.String(),
                        County = c.Int(nullable: false),
                        PostCode = c.String(),
                        ContactName = c.String(),
                        ContactPhoneNumber = c.String(),
                        ContactEmailAddress = c.String(),
                        SupplierId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierBranchId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Guid(nullable: false),
                        SupplierName = c.String(),
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
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.SupplierUsers",
                c => new
                    {
                        SupplierUserId = c.Guid(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        SupplierBranchId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.SupplierUserId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .ForeignKey("dbo.SupplierBranches", t => t.SupplierBranchId)
                .Index(t => t.SupplierUserId)
                .Index(t => t.SupplierId)
                .Index(t => t.SupplierBranchId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SupplierUsers", "SupplierBranchId", "dbo.SupplierBranches");
            DropForeignKey("dbo.SupplierUsers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierUsers", "SupplierUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SupplierBranches", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Listings", "SupplierBranchId", "dbo.SupplierBranches");
            DropForeignKey("dbo.ListingClaims", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.ListingClaims", "BankBranchId", "dbo.BankBranches");
            DropForeignKey("dbo.BankUsers", "BankCompanyId", "dbo.BankCompanies");
            DropForeignKey("dbo.BankUsers", "BankBranchId", "dbo.BankBranches");
            DropForeignKey("dbo.BankUsers", "BankUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BankBranches", "BankCompanyId", "dbo.BankCompanies");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SupplierUsers", new[] { "SupplierBranchId" });
            DropIndex("dbo.SupplierUsers", new[] { "SupplierId" });
            DropIndex("dbo.SupplierUsers", new[] { "SupplierUserId" });
            DropIndex("dbo.SupplierBranches", new[] { "SupplierId" });
            DropIndex("dbo.Listings", new[] { "SupplierBranchId" });
            DropIndex("dbo.ListingClaims", new[] { "ListingId" });
            DropIndex("dbo.ListingClaims", new[] { "BankBranchId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BankUsers", new[] { "BankBranchId" });
            DropIndex("dbo.BankUsers", new[] { "BankCompanyId" });
            DropIndex("dbo.BankUsers", new[] { "BankUserId" });
            DropIndex("dbo.BankBranches", new[] { "BankCompanyId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SupplierUsers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierBranches");
            DropTable("dbo.Listings");
            DropTable("dbo.ListingClaims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BankUsers");
            DropTable("dbo.BankCompanies");
            DropTable("dbo.BankBranches");
        }
    }
}
