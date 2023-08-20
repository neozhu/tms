namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md231 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "ContentType", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "ContentType", c => c.String(maxLength: 50));
        }
    }
}
