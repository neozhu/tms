namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md_waybill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Waybills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(nullable: false, maxLength: 10),
                        Status = c.String(maxLength: 10),
                        CustomerId = c.String(nullable: false, maxLength: 10),
                        CustomerName = c.String(maxLength: 128),
                        ProjectNo = c.String(maxLength: 32),
                        PickNo = c.String(maxLength: 32),
                        ShippedDate = c.DateTime(nullable: false),
                        Original = c.String(maxLength: 38),
                        Destination = c.String(maxLength: 38),
                        Remark = c.String(),
                        ProductNo = c.String(maxLength: 38),
                        LotNo = c.String(maxLength: 38),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Cube = c.Decimal(precision: 18, scale: 2),
                        SPrice = c.Decimal(precision: 18, scale: 2),
                        SAmount = c.Decimal(precision: 18, scale: 2),
                        CPrice = c.Decimal(precision: 18, scale: 2),
                        CAmount = c.Decimal(precision: 18, scale: 2),
                        Way = c.String(maxLength: 128),
                        Sales = c.String(maxLength: 32),
                        SalesGroup = c.String(maxLength: 32),
                        Remark1 = c.String(maxLength: 256),
                        Remark2 = c.String(maxLength: 256),
                        Flag = c.Boolean(nullable: false),
                        Driver = c.String(maxLength: 32),
                        Transport = c.String(maxLength: 32),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Waybills");
        }
    }
}
