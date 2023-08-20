namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md_maxlength1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Waybills", "OrderNo", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Waybills", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Waybills", "ProjectNo", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waybills", "PickNo", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waybills", "Original", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waybills", "Destination", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waybills", "ProductNo", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waybills", "LotNo", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waybills", "Sales", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waybills", "SalesGroup", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waybills", "SalesGroup", c => c.String(maxLength: 32));
            AlterColumn("dbo.Waybills", "Sales", c => c.String(maxLength: 32));
            AlterColumn("dbo.Waybills", "LotNo", c => c.String(maxLength: 38));
            AlterColumn("dbo.Waybills", "ProductNo", c => c.String(maxLength: 38));
            AlterColumn("dbo.Waybills", "Destination", c => c.String(maxLength: 38));
            AlterColumn("dbo.Waybills", "Original", c => c.String(maxLength: 38));
            AlterColumn("dbo.Waybills", "PickNo", c => c.String(maxLength: 32));
            AlterColumn("dbo.Waybills", "ProjectNo", c => c.String(maxLength: 32));
            AlterColumn("dbo.Waybills", "CustomerId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Waybills", "OrderNo", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
