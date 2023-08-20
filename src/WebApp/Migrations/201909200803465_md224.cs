namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md224 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "COST3NOTE", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ORDERDETAILs", "COST3NOTE");
        }
    }
}
