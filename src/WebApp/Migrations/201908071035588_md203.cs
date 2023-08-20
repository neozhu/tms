namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md203 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FreightRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ORIGINAL = c.String(nullable: false, maxLength: 50),
                        DESTINATION = c.String(nullable: false, maxLength: 50),
                        SHPTYPE = c.String(nullable: false, maxLength: 1),
                        CALTYPE = c.String(nullable: false, maxLength: 1),
                        CARLWT1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CARLWT2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MINAMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STATUS = c.Int(nullable: false),
                        DESCRIPTION = c.String(maxLength: 180),
                        LOTTABLE1 = c.String(maxLength: 50),
                        LOTTABLE2 = c.String(maxLength: 50),
                        LOTTABLE3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false, maxLength: 30),
                        GWT1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GWT2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ELEVATOR = c.Boolean(nullable: false),
                        PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MINAMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STATUS = c.Int(nullable: false),
                        DESCRIPTION = c.String(maxLength: 180),
                        LOTTABLE1 = c.String(maxLength: 50),
                        LOTTABLE2 = c.String(maxLength: 50),
                        LOTTABLE3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceRules");
            DropTable("dbo.FreightRules");
        }
    }
}
