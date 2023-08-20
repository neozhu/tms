namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md206 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "CHECKEDCOST1", c => c.Boolean(nullable: false));
            AddColumn("dbo.ORDERs", "CHECKEDCOST1", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ORDERs", "CHECKEDCOST1");
            DropColumn("dbo.ORDERDETAILs", "CHECKEDCOST1");
        }
    }
}
