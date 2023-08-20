namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md236 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ORDERs", "ORIGINAL", c => c.String(maxLength: 50));
            AlterColumn("dbo.ORDERs", "DESTINATION", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ORDERs", "DESTINATION", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ORDERs", "ORIGINAL", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
