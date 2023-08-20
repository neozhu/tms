namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERs", "TOTALCOST6NOTES", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ORDERs", "TOTALCOST6NOTES");
        }
    }
}
