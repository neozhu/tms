namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md225 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salesmen", "Org", c => c.String(maxLength: 20));
            AddColumn("dbo.Salesmen", "Dep", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salesmen", "Dep");
            DropColumn("dbo.Salesmen", "Org");
        }
    }
}
