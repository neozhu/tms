namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md211 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salesmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        CompanyName = c.String(maxLength: 80),
                        Title = c.String(maxLength: 20),
                        IsPushNotification = c.Boolean(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 50),
                        Notes = c.String(maxLength: 80),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "Salesman_IX");
            
            CreateTable(
                "dbo.StandardCosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ORIGINAL = c.String(nullable: false, maxLength: 50),
                        DESTINATION = c.String(nullable: false, maxLength: 50),
                        STDKM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarType = c.String(maxLength: 20),
                        STDLOADWEIGHT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STDOIL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STDCOST = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DESCRIPTION = c.String(maxLength: 180),
                        Notes = c.String(maxLength: 80),
                        LOTTABLE1 = c.String(maxLength: 50),
                        LOTTABLE2 = c.String(maxLength: 50),
                        LOTTABLE3 = c.Decimal(nullable: false, precision: 18, scale: 2),
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
            DropIndex("dbo.Salesmen", "Salesman_IX");
            DropTable("dbo.StandardCosts");
            DropTable("dbo.Salesmen");
        }
    }
}
