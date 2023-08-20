namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md200 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "SKUTYPE", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.ORDERDETAILs", "SALER", c => c.String());
            AddColumn("dbo.ORDERDETAILs", "SALESORG", c => c.String());
            AddColumn("dbo.ORDERDETAILs", "COST3", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERDETAILs", "COST4", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERDETAILs", "CONSIGNEEADDRESS", c => c.String(maxLength: 180));
            AddColumn("dbo.ORDERDETAILs", "ORIGINAL", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ORDERDETAILs", "DESTINATION", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ORDERDETAILs", "SHPTYPE", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.ORDERs", "ORIGINAL", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ORDERs", "DESTINATION", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ORDERs", "SHPTYPE", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.ORDERs", "TOTALCOST1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERs", "TOTALCOST2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ORDERDETAILs", "LOTTABLE3", c => c.String(maxLength: 80));
            AlterColumn("dbo.ORDERs", "TOTALCASECNT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ORDERs", "TOTALGROSSWGT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ORDERs", "TOTALCUBE", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ORDERs", "TOTALCUBE", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ORDERs", "TOTALGROSSWGT", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ORDERs", "TOTALCASECNT", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ORDERDETAILs", "LOTTABLE3", c => c.String(maxLength: 50));
            DropColumn("dbo.ORDERs", "TOTALCOST2");
            DropColumn("dbo.ORDERs", "TOTALCOST1");
            DropColumn("dbo.ORDERs", "SHPTYPE");
            DropColumn("dbo.ORDERs", "DESTINATION");
            DropColumn("dbo.ORDERs", "ORIGINAL");
            DropColumn("dbo.ORDERDETAILs", "SHPTYPE");
            DropColumn("dbo.ORDERDETAILs", "DESTINATION");
            DropColumn("dbo.ORDERDETAILs", "ORIGINAL");
            DropColumn("dbo.ORDERDETAILs", "CONSIGNEEADDRESS");
            DropColumn("dbo.ORDERDETAILs", "COST4");
            DropColumn("dbo.ORDERDETAILs", "COST3");
            DropColumn("dbo.ORDERDETAILs", "SALESORG");
            DropColumn("dbo.ORDERDETAILs", "SALER");
            DropColumn("dbo.ORDERDETAILs", "SKUTYPE");
        }
    }
}
