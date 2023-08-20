namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md219 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "CONTACTINFO", c => c.String(maxLength: 200));
            AddColumn("dbo.ORDERDETAILs", "REQUIREMENTS", c => c.String(maxLength: 500));
            AddColumn("dbo.ORDERs", "CONTACTINFO", c => c.String(maxLength: 200));
            AddColumn("dbo.ORDERs", "REQUIREMENTS", c => c.String(maxLength: 500));
            AddColumn("dbo.SHIPORDERDETAILs", "CONTACTINFO", c => c.String(maxLength: 200));
            AddColumn("dbo.SHIPORDERDETAILs", "REQUIREMENTS", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERDETAILs", "REQUIREMENTS");
            DropColumn("dbo.SHIPORDERDETAILs", "CONTACTINFO");
            DropColumn("dbo.ORDERs", "REQUIREMENTS");
            DropColumn("dbo.ORDERs", "CONTACTINFO");
            DropColumn("dbo.ORDERDETAILs", "REQUIREMENTS");
            DropColumn("dbo.ORDERDETAILs", "CONTACTINFO");
        }
    }
}
