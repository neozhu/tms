namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md229 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "ContentType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "ContentType");
        }
    }
}
