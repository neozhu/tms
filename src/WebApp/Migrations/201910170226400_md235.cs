namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md235 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "COST6NOTES", c => c.String());
            AddColumn("dbo.SHIPORDERDETAILs", "COST6NOTES", c => c.String());
            AddColumn("dbo.SHIPORDERs", "TOTALCOST6NOTES", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERs", "TOTALCOST6NOTES");
            DropColumn("dbo.SHIPORDERDETAILs", "COST6NOTES");
            DropColumn("dbo.ORDERDETAILs", "COST6NOTES");
        }
    }
}
