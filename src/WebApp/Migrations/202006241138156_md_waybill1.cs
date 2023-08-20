namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md_waybill1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Waybills", "Cube", c => c.Decimal(precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waybills", "Cube", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
