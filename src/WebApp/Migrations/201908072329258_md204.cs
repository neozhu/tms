namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md204 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST2", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST3", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST4", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST5", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST6", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST7", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "COST7", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST8", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "COST8", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERDETAILs", "FLAG1", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "FLAG2", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERDETAILs", "NOTES1", c => c.String(maxLength: 180));
            AddColumn("dbo.ORDERDETAILs", "COMPANYCODE", c => c.String(maxLength: 20));
            AddColumn("dbo.ORDERs", "CHECKEDCOST2", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "CHECKEDCOST3", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "CHECKEDCOST4", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "CHECKEDCOST5", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "CHECKEDCOST6", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "CHECKEDCOST7", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "TOTALCOST7", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERs", "CHECKEDCOST8", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "TOTALCOST8", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ORDERs", "FLAG1", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "NOTES1", c => c.String(maxLength: 180));
            AddColumn("dbo.ORDERs", "FLAG2", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "COMPANYCODE", c => c.String(maxLength: 20));
            AlterColumn("dbo.ORDERDETAILs", "ORIGINAL", c => c.String(maxLength: 50));
            AlterColumn("dbo.ORDERDETAILs", "DESTINATION", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ORDERDETAILs", "DESTINATION", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ORDERDETAILs", "ORIGINAL", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.ORDERs", "COMPANYCODE");
            DropColumn("dbo.ORDERs", "FLAG2");
            DropColumn("dbo.ORDERs", "NOTES1");
            DropColumn("dbo.ORDERs", "FLAG1");
            DropColumn("dbo.ORDERs", "TOTALCOST8");
            DropColumn("dbo.ORDERs", "CHECKEDCOST8");
            DropColumn("dbo.ORDERs", "TOTALCOST7");
            DropColumn("dbo.ORDERs", "CHECKEDCOST7");
            DropColumn("dbo.ORDERs", "CHECKEDCOST6");
            DropColumn("dbo.ORDERs", "CHECKEDCOST5");
            DropColumn("dbo.ORDERs", "CHECKEDCOST4");
            DropColumn("dbo.ORDERs", "CHECKEDCOST3");
            DropColumn("dbo.ORDERs", "CHECKEDCOST2");
            DropColumn("dbo.ORDERDETAILs", "COMPANYCODE");
            DropColumn("dbo.ORDERDETAILs", "NOTES1");
            DropColumn("dbo.ORDERDETAILs", "FLAG2");
            DropColumn("dbo.ORDERDETAILs", "FLAG1");
            DropColumn("dbo.ORDERDETAILs", "COST8");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST8");
            DropColumn("dbo.ORDERDETAILs", "COST7");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST7");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST6");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST5");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST4");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST3");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST2");
        }
    }
}
