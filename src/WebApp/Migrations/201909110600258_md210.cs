namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md210 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseCodes", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.CodeItems", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.DataTableImportMappings", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.FreightRules", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.LocBases", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.MenuItems", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.ORDERs", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.RoleMenus", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceRules", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.SHIPORDERDETAILs", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.SHIPORDERs", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.StatusHistories", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.SUPPLIERs", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicle", "TenantId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "TenantId");
            DropColumn("dbo.SUPPLIERs", "TenantId");
            DropColumn("dbo.StatusHistories", "TenantId");
            DropColumn("dbo.SHIPORDERs", "TenantId");
            DropColumn("dbo.SHIPORDERDETAILs", "TenantId");
            DropColumn("dbo.ServiceRules", "TenantId");
            DropColumn("dbo.RoleMenus", "TenantId");
            DropColumn("dbo.ORDERs", "TenantId");
            DropColumn("dbo.ORDERDETAILs", "TenantId");
            DropColumn("dbo.Notifications", "TenantId");
            DropColumn("dbo.Messages", "TenantId");
            DropColumn("dbo.MenuItems", "TenantId");
            DropColumn("dbo.LocBases", "TenantId");
            DropColumn("dbo.FreightRules", "TenantId");
            DropColumn("dbo.DataTableImportMappings", "TenantId");
            DropColumn("dbo.Companies", "TenantId");
            DropColumn("dbo.CodeItems", "TenantId");
            DropColumn("dbo.BaseCodes", "TenantId");
        }
    }
}
