namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md222 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "ORDERDATE", c => c.DateTime());
            AddColumn("dbo.SHIPORDERDETAILs", "ORDERDATE", c => c.DateTime());
            AddColumn("dbo.SHIPORDERDETAILs", "SHIPORDERDATE", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERDETAILs", "SHIPORDERDATE");
            DropColumn("dbo.SHIPORDERDETAILs", "ORDERDATE");
            DropColumn("dbo.ORDERDETAILs", "ORDERDATE");
        }
    }
}
