namespace Assesment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPassword",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Password = c.String(),
                        PasswordFormatId = c.Int(nullable: false),
                        PasswordSalt = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserGuid = c.Guid(nullable: false),
                        Username = c.String(maxLength: 1000),
                        Email = c.String(maxLength: 1000),
                        EmailToRevalidate = c.String(maxLength: 1000),
                        RequireReLogin = c.Boolean(nullable: false),
                        FailedLoginAttempts = c.Int(nullable: false),
                        CannotLoginUntilDateUtc = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        IsSystemAccount = c.Boolean(nullable: false),
                        SystemName = c.String(maxLength: 400),
                        LastIpAddress = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        LastLoginDateUtc = c.DateTime(),
                        LastActivityDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExternalAuthenticationRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Email = c.String(),
                        ExternalIdentifier = c.String(),
                        ExternalDisplayIdentifier = c.String(),
                        OAuthToken = c.String(),
                        OAuthAccessToken = c.String(),
                        ProviderSystemName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        IsSystemRole = c.Boolean(nullable: false),
                        SystemName = c.String(maxLength: 255),
                        EnablePasswordLifetime = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SystemName = c.String(nullable: false, maxLength: 255),
                        Category = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivityLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityLogTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        IpAddress = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityLogType", t => t.ActivityLogTypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ActivityLogTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ActivityLogType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemKeyword = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogLevelId = c.Int(nullable: false),
                        ShortMessage = c.String(nullable: false),
                        FullMessage = c.String(),
                        IpAddress = c.String(maxLength: 200),
                        UserId = c.Int(),
                        PageUrl = c.String(),
                        ReferrerUrl = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LanguageCulture = c.String(nullable: false, maxLength: 20),
                        UniqueSeoCode = c.String(maxLength: 2),
                        FlagImageFileName = c.String(maxLength: 50),
                        Rtl = c.Boolean(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                        DefaultCurrencyId = c.Int(nullable: false),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocaleStringResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        ResourceName = c.String(nullable: false, maxLength: 200),
                        ResourceValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.LocalizedProperty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        LocaleKeyGroup = c.String(nullable: false, maxLength: 400),
                        LocaleKey = c.String(nullable: false, maxLength: 400),
                        LocaleValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Value = c.String(nullable: false, maxLength: 2000),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenericAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        KeyGroup = c.String(nullable: false, maxLength: 400),
                        Key = c.String(nullable: false, maxLength: 400),
                        Value = c.String(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionRecord_Role_Mapping",
                c => new
                    {
                        PermissionRecord_Id = c.Int(nullable: false),
                        UserRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissionRecord_Id, t.UserRole_Id })
                .ForeignKey("dbo.PermissionRecord", t => t.PermissionRecord_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserRole", t => t.UserRole_Id, cascadeDelete: true)
                .Index(t => t.PermissionRecord_Id)
                .Index(t => t.UserRole_Id);
            
            CreateTable(
                "dbo.User_UserRole_Mapping",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        UserRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.UserRole_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserRole", t => t.UserRole_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.UserRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocalizedProperty", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.LocaleStringResource", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.Log", "UserId", "dbo.User");
            DropForeignKey("dbo.ActivityLog", "UserId", "dbo.User");
            DropForeignKey("dbo.ActivityLog", "ActivityLogTypeId", "dbo.ActivityLogType");
            DropForeignKey("dbo.UserPassword", "UserId", "dbo.User");
            DropForeignKey("dbo.User_UserRole_Mapping", "UserRole_Id", "dbo.UserRole");
            DropForeignKey("dbo.User_UserRole_Mapping", "User_Id", "dbo.User");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "UserRole_Id", "dbo.UserRole");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "PermissionRecord_Id", "dbo.PermissionRecord");
            DropForeignKey("dbo.ExternalAuthenticationRecord", "UserId", "dbo.User");
            DropIndex("dbo.User_UserRole_Mapping", new[] { "UserRole_Id" });
            DropIndex("dbo.User_UserRole_Mapping", new[] { "User_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "UserRole_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "PermissionRecord_Id" });
            DropIndex("dbo.LocalizedProperty", new[] { "LanguageId" });
            DropIndex("dbo.LocaleStringResource", new[] { "LanguageId" });
            DropIndex("dbo.Log", new[] { "UserId" });
            DropIndex("dbo.ActivityLog", new[] { "UserId" });
            DropIndex("dbo.ActivityLog", new[] { "ActivityLogTypeId" });
            DropIndex("dbo.ExternalAuthenticationRecord", new[] { "UserId" });
            DropIndex("dbo.UserPassword", new[] { "UserId" });
            DropTable("dbo.User_UserRole_Mapping");
            DropTable("dbo.PermissionRecord_Role_Mapping");
            DropTable("dbo.GenericAttribute");
            DropTable("dbo.Setting");
            DropTable("dbo.LocalizedProperty");
            DropTable("dbo.LocaleStringResource");
            DropTable("dbo.Language");
            DropTable("dbo.Log");
            DropTable("dbo.ActivityLogType");
            DropTable("dbo.ActivityLog");
            DropTable("dbo.PermissionRecord");
            DropTable("dbo.UserRole");
            DropTable("dbo.ExternalAuthenticationRecord");
            DropTable("dbo.User");
            DropTable("dbo.UserPassword");
        }
    }
}
