namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md1001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ORDERDETAILs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ORDERKEY = c.String(nullable: false, maxLength: 20),
                        LOTTABLE2 = c.String(maxLength: 50),
                        EXTERNORDERKEY = c.String(maxLength: 50),
                        ORDERLINENUMBER = c.String(nullable: false, maxLength: 6),
                        STATUS = c.String(maxLength: 3),
                        SUPPLIERCODE = c.String(maxLength: 20),
                        SUPPLIERNAME = c.String(maxLength: 80),
                        SKU = c.String(nullable: false, maxLength: 30),
                        SKUNAME = c.String(maxLength: 80),
                        ORIGINALQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SHIPPEDQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UMO = c.String(nullable: false, maxLength: 10),
                        PACKKEY = c.String(maxLength: 10),
                        CASECNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GROSSWGT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NETWGT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CUBE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COST1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COST2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NOTES = c.String(maxLength: 180),
                        REQUESTEDSHIPDATE = c.DateTime(),
                        DELIVERYDATE = c.DateTime(),
                        ACTUALSHIPDATE = c.DateTime(),
                        ACTUALDELIVERYDATE = c.DateTime(),
                        WHSEID = c.String(nullable: false, maxLength: 20),
                        STORERKEY = c.String(nullable: false, maxLength: 50),
                        LOTTABLE3 = c.String(maxLength: 50),
                        LOTTABLE1 = c.String(maxLength: 50),
                        EXTERNLINENO = c.String(maxLength: 20),
                        TYPE = c.String(maxLength: 10),
                        LOTTABLE4 = c.String(maxLength: 50),
                        LOTTABLE5 = c.String(maxLength: 50),
                        LOTTABLE6 = c.Decimal(precision: 18, scale: 2),
                        LOTTABLE7 = c.Decimal(precision: 18, scale: 2),
                        LOTTABLE8 = c.DateTime(),
                        LOTTABLE9 = c.DateTime(),
                        LOTTABLE10 = c.String(maxLength: 50),
                        ORDERID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ORDERs", t => t.ORDERID, cascadeDelete: true)
                .Index(t => new { t.ORDERKEY, t.ORDERLINENUMBER }, unique: true, name: "ORDERDETAIL_IX")
                .Index(t => t.ORDERID);
            
            CreateTable(
                "dbo.ORDERs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ORDERKEY = c.String(nullable: false, maxLength: 20),
                        WHSEID = c.String(nullable: false, maxLength: 20),
                        LOTTABLE2 = c.String(maxLength: 80),
                        EXTERNORDERKEY = c.String(maxLength: 50),
                        STATUS = c.String(nullable: false, maxLength: 3),
                        STORERKEY = c.String(nullable: false, maxLength: 50),
                        SUPPLIERCODE = c.String(maxLength: 20),
                        SUPPLIERNAME = c.String(maxLength: 80),
                        ORDERDATE = c.DateTime(nullable: false),
                        REQUESTEDSHIPDATE = c.DateTime(),
                        DELIVERYDATE = c.DateTime(),
                        TYPE = c.String(maxLength: 10),
                        CONSIGNEEKEY = c.String(maxLength: 30),
                        CONSIGNEENAME = c.String(maxLength: 80),
                        CONSIGNEEADDRESS = c.String(maxLength: 180),
                        CARRIERNAME = c.String(maxLength: 80),
                        DRIVERNAME = c.String(maxLength: 20),
                        CARRIERPHONE = c.String(maxLength: 20),
                        TRAILERNUMBER = c.String(maxLength: 80),
                        ACTUALSHIPDATE = c.DateTime(),
                        ACTUALDELIVERYDATE = c.DateTime(),
                        CLOSEDDATE = c.DateTime(),
                        TOTALQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TOTALSHIPPEDQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TOTALCASECNT = c.Decimal(precision: 18, scale: 2),
                        TOTALGROSSWGT = c.Decimal(precision: 18, scale: 2),
                        TOTALCUBE = c.Decimal(precision: 18, scale: 2),
                        NOTES = c.String(maxLength: 180),
                        LOTTABLE1 = c.String(maxLength: 50),
                        LOTTABLE3 = c.String(maxLength: 80),
                        LOTTABLE4 = c.String(maxLength: 60),
                        LOTTABLE5 = c.String(maxLength: 50),
                        LOTTABLE6 = c.Decimal(precision: 18, scale: 2),
                        LOTTABLE7 = c.Decimal(precision: 18, scale: 2),
                        LOTTABLE8 = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ORDERKEY, unique: true);
            
            CreateTable(
                "dbo.SUPPLIERs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SUPPLIERCODE = c.String(nullable: false, maxLength: 20),
                        SUPPLIERNAME = c.String(nullable: false, maxLength: 80),
                        ISDISABLED = c.Boolean(nullable: false),
                        ADDRESS1 = c.String(maxLength: 80),
                        ADDRESS2 = c.String(maxLength: 80),
                        CONTACT = c.String(maxLength: 20),
                        PHONENUMBER = c.String(maxLength: 20),
                        EMAIL = c.String(maxLength: 20),
                        NOTES = c.String(maxLength: 80),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.SUPPLIERCODE, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ORDERDETAILs", "ORDERID", "dbo.ORDERs");
            DropIndex("dbo.SUPPLIERs", new[] { "SUPPLIERCODE" });
            DropIndex("dbo.ORDERs", new[] { "ORDERKEY" });
            DropIndex("dbo.ORDERDETAILs", new[] { "ORDERID" });
            DropIndex("dbo.ORDERDETAILs", "ORDERDETAIL_IX");
            DropTable("dbo.SUPPLIERs");
            DropTable("dbo.ORDERs");
            DropTable("dbo.ORDERDETAILs");
        }
    }
}
