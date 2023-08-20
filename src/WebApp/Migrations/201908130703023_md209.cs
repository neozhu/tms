namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md209 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ORDERKEY = c.String(maxLength: 20),
                        SHIPORDERKEY = c.String(maxLength: 20),
                        STATUS = c.String(maxLength: 3),
                        DESCRIPTION = c.String(maxLength: 100),
                        REMARK = c.String(maxLength: 100),
                        TRANSACTIONDATETIME = c.DateTime(nullable: false),
                        USER = c.String(),
                        LONGITUDE = c.Decimal(nullable: false, precision: 18, scale: 8),
                        LATITUDE = c.Decimal(nullable: false, precision: 18, scale: 8),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StatusHistories");
        }
    }
}
