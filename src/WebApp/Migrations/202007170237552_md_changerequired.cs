namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md_changerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ORDERDETAILs", "SKU", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ORDERDETAILs", "SKU", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
