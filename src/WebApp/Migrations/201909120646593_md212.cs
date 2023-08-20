namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERs", "SALER", c => c.String(maxLength: 20));
            AlterColumn("dbo.ORDERDETAILs", "SALER", c => c.String(maxLength: 20));
            AlterColumn("dbo.ORDERDETAILs", "SALESORG", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ORDERDETAILs", "SALESORG", c => c.String());
            AlterColumn("dbo.ORDERDETAILs", "SALER", c => c.String());
            DropColumn("dbo.ORDERs", "SALER");
        }
    }
}
