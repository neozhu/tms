namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md227 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SHIPORDERDETAILs", "CARRIERNAME", c => c.String(maxLength: 80));
            AddColumn("dbo.SHIPORDERDETAILs", "DRIVERNAME", c => c.String(maxLength: 20));
            AddColumn("dbo.SHIPORDERDETAILs", "CARRIERPHONE", c => c.String(maxLength: 20));
            AddColumn("dbo.SHIPORDERDETAILs", "TRAILERNUMBER", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERDETAILs", "TRAILERNUMBER");
            DropColumn("dbo.SHIPORDERDETAILs", "CARRIERPHONE");
            DropColumn("dbo.SHIPORDERDETAILs", "DRIVERNAME");
            DropColumn("dbo.SHIPORDERDETAILs", "CARRIERNAME");
        }
    }
}
