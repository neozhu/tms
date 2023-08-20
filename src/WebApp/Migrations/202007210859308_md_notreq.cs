namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md_notreq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SHIPORDERDETAILs", "SKU", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SHIPORDERDETAILs", "SKU", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
