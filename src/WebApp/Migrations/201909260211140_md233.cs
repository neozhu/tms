namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md233 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "OrderKey", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Documents", "FileName", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "FileName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Documents", "OrderKey", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
