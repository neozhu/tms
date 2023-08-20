namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md226 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "CARRIERNAME", c => c.String(maxLength: 80));
            AddColumn("dbo.ORDERDETAILs", "DRIVERNAME", c => c.String(maxLength: 20));
            AddColumn("dbo.ORDERDETAILs", "CARRIERPHONE", c => c.String(maxLength: 20));
            AddColumn("dbo.ORDERDETAILs", "TRAILERNUMBER", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ORDERDETAILs", "TRAILERNUMBER");
            DropColumn("dbo.ORDERDETAILs", "CARRIERPHONE");
            DropColumn("dbo.ORDERDETAILs", "DRIVERNAME");
            DropColumn("dbo.ORDERDETAILs", "CARRIERNAME");
        }
    }
}
