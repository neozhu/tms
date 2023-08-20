namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md207 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SHIPORDERDETAILs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SHIPORDERKEY = c.String(nullable: false, maxLength: 20),
                        EXTERNSHIPORDERKEY = c.String(maxLength: 50),
                        ORDERKEY = c.String(nullable: false, maxLength: 20),
                        LOTTABLE2 = c.String(maxLength: 50),
                        EXTERNORDERKEY = c.String(maxLength: 50),
                        ORDERLINENUMBER = c.String(nullable: false, maxLength: 6),
                        STATUS = c.String(maxLength: 3),
                        SUPPLIERCODE = c.String(maxLength: 20),
                        SUPPLIERNAME = c.String(maxLength: 80),
                        SKU = c.String(nullable: false, maxLength: 30),
                        SKUTYPE = c.String(nullable: false, maxLength: 10),
                        SKUNAME = c.String(maxLength: 80),
                        ORIGINALQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SHIPPEDQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UMO = c.String(nullable: false, maxLength: 10),
                        PACKKEY = c.String(maxLength: 10),
                        CASECNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GROSSWGT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NETWGT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CUBE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SALER = c.String(),
                        SALESORG = c.String(),
                        CHECKEDCOST1 = c.Boolean(nullable: false),
                        COST1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST2 = c.Boolean(nullable: false),
                        COST2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST3 = c.Boolean(nullable: false),
                        FLOOR = c.Int(nullable: false),
                        COST3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST4 = c.Boolean(nullable: false),
                        COST4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST5 = c.Boolean(nullable: false),
                        COST5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST6 = c.Boolean(nullable: false),
                        COST6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST7 = c.Boolean(nullable: false),
                        COST7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST8 = c.Boolean(nullable: false),
                        COST8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NOTES = c.String(maxLength: 180),
                        FLAG1 = c.Boolean(nullable: false),
                        FLAG2 = c.Boolean(nullable: false),
                        NOTES1 = c.String(maxLength: 180),
                        REQUESTEDSHIPDATE = c.DateTime(),
                        DELIVERYDATE = c.DateTime(),
                        ACTUALSHIPDATE = c.DateTime(),
                        ACTUALDELIVERYDATE = c.DateTime(),
                        WHSEID = c.String(nullable: false, maxLength: 20),
                        STORERKEY = c.String(nullable: false, maxLength: 50),
                        LOTTABLE3 = c.String(maxLength: 80),
                        CONSIGNEEADDRESS = c.String(maxLength: 180),
                        LOTTABLE1 = c.String(maxLength: 50),
                        EXTERNLINENO = c.String(maxLength: 20),
                        TYPE = c.String(maxLength: 10),
                        ORIGINAL = c.String(maxLength: 50),
                        DESTINATION = c.String(maxLength: 50),
                        SHPTYPE = c.String(nullable: false, maxLength: 1),
                        COMPANYCODE = c.String(maxLength: 20),
                        LOTTABLE4 = c.String(maxLength: 50),
                        LOTTABLE5 = c.String(maxLength: 50),
                        LOTTABLE6 = c.Decimal(precision: 18, scale: 2),
                        LOTTABLE7 = c.Decimal(precision: 18, scale: 2),
                        LOTTABLE8 = c.DateTime(),
                        LOTTABLE9 = c.DateTime(),
                        LOTTABLE10 = c.String(maxLength: 50),
                        SHIPORDERID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SHIPORDERs", t => t.SHIPORDERID, cascadeDelete: true)
                .Index(t => new { t.SHIPORDERKEY, t.ORDERKEY, t.ORDERLINENUMBER }, unique: true, name: "SHIPORDERDETAIL_IX")
                .Index(t => t.SHIPORDERID);
            
            CreateTable(
                "dbo.SHIPORDERs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SHIPORDERKEY = c.String(nullable: false, maxLength: 20),
                        EXTERNSHIPORDERKEY = c.String(maxLength: 50),
                        ORIGINAL = c.String(nullable: false, maxLength: 50),
                        DESTINATION = c.String(nullable: false, maxLength: 50),
                        STATUS = c.String(nullable: false, maxLength: 3),
                        PLATENUMBER = c.String(nullable: false, maxLength: 10),
                        DRIVERNAME = c.String(maxLength: 20),
                        DRIVERPHONE = c.String(maxLength: 20),
                        CARRIERCODE = c.String(maxLength: 20),
                        CARRIERNAME = c.String(maxLength: 80),
                        SHIPORDERDATE = c.DateTime(nullable: false),
                        REQUESTEDSHIPDATE = c.DateTime(),
                        DELIVERYDATE = c.DateTime(),
                        TYPE = c.String(maxLength: 3),
                        SHIPPERKEY = c.String(maxLength: 30),
                        SHIPPERNAME = c.String(maxLength: 80),
                        SHIPPERADDRESS = c.String(maxLength: 180),
                        CONSIGNEEKEY = c.String(maxLength: 30),
                        CONSIGNEENAME = c.String(maxLength: 80),
                        CONSIGNEEADDRESS = c.String(maxLength: 180),
                        NOTES = c.String(maxLength: 180),
                        ACTUALSHIPDATE = c.DateTime(),
                        ACTUALDELIVERYDATE = c.DateTime(),
                        CLOSEDDATE = c.DateTime(),
                        TOTALQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TOTALSHIPPEDQTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TOTALCASECNT = c.Decimal(precision: 18, scale: 2),
                        TOTALGROSSWGT = c.Decimal(precision: 18, scale: 2),
                        TOTALCUBE = c.Decimal(precision: 18, scale: 2),
                        STDKM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KM1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KM2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ACTKM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STDOIL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OIL1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OIL2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ACTOIL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STDLOADWEIGHT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STDLOADVOLUME = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FEELOADWEIGHT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LOADFACTOR1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LOADFACTOR2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST1 = c.Boolean(nullable: false),
                        TOTALCOST1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST2 = c.Boolean(nullable: false),
                        TOTALCOST2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST3 = c.Boolean(nullable: false),
                        FLOOR = c.Int(nullable: false),
                        TOTALCOST3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST4 = c.Boolean(nullable: false),
                        TOTALCOST4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST5 = c.Boolean(nullable: false),
                        TOTALCOST5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST6 = c.Boolean(nullable: false),
                        TOTALCOST6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST7 = c.Boolean(nullable: false),
                        TOTALCOST7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CHECKEDCOST8 = c.Boolean(nullable: false),
                        TOTALCOST8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FLAG1 = c.Boolean(nullable: false),
                        NOTES1 = c.String(maxLength: 180),
                        FLAG2 = c.Boolean(nullable: false),
                        COMPANYCODE = c.String(maxLength: 20),
                        LOTTABLE1 = c.String(maxLength: 50),
                        LOTTABLE2 = c.String(maxLength: 60),
                        LOTTABLE3 = c.String(maxLength: 60),
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
                .Index(t => t.SHIPORDERKEY, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SHIPORDERDETAILs", "SHIPORDERID", "dbo.SHIPORDERs");
            DropIndex("dbo.SHIPORDERs", new[] { "SHIPORDERKEY" });
            DropIndex("dbo.SHIPORDERDETAILs", new[] { "SHIPORDERID" });
            DropIndex("dbo.SHIPORDERDETAILs", "SHIPORDERDETAIL_IX");
            DropTable("dbo.SHIPORDERs");
            DropTable("dbo.SHIPORDERDETAILs");
        }
    }
}
