namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md223 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERs", "COST3NOTE", c => c.String(maxLength: 50));
            AddColumn("dbo.SHIPORDERDETAILs", "COST3NOTE", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERDETAILs", "COST3NOTE");
            DropColumn("dbo.ORDERs", "COST3NOTE");
        }
    }
}
