namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md230 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Path", c => c.String());
            AlterColumn("dbo.Documents", "Url", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "Url", c => c.String(maxLength: 300));
            AlterColumn("dbo.Documents", "Path", c => c.String(maxLength: 300));
        }
    }
}
