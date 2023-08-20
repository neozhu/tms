namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md218 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logs", "Logger", c => c.String(maxLength: 300));
            AlterColumn("dbo.Logs", "Callsite", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logs", "Callsite", c => c.String(maxLength: 150));
            AlterColumn("dbo.Logs", "Logger", c => c.String(maxLength: 30));
        }
    }
}
