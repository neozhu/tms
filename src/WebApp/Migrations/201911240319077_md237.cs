namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md237 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "UNITCOST1", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.ORDERDETAILs", "UNITCOST3", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.SHIPORDERDETAILs", "UNITCOST1", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.SHIPORDERDETAILs", "UNITCOST3", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERDETAILs", "UNITCOST3");
            DropColumn("dbo.SHIPORDERDETAILs", "UNITCOST1");
            DropColumn("dbo.ORDERDETAILs", "UNITCOST3");
            DropColumn("dbo.ORDERDETAILs", "UNITCOST1");
        }
    }
}
