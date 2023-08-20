namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md220 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ORDERDETAILs", "SALESDEP", c => c.String(maxLength: 20));
            AddColumn("dbo.ORDERDETAILs", "EXTERNORDERKEY1", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERDETAILs", "FACTORY", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERDETAILs", "SHOP", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERDETAILs", "CHANNEL", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERDETAILs", "DELIVERYVOUCHER", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERs", "SALESORG", c => c.String(maxLength: 20));
            AddColumn("dbo.ORDERs", "SALESDEP", c => c.String(maxLength: 20));
            AddColumn("dbo.ORDERs", "EXTERNORDERKEY1", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERs", "FACTORY", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERs", "SHOP", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERs", "CHANNEL", c => c.String(maxLength: 50));
            AddColumn("dbo.ORDERs", "DELIVERYVOUCHER", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ORDERs", "DELIVERYVOUCHER");
            DropColumn("dbo.ORDERs", "CHANNEL");
            DropColumn("dbo.ORDERs", "SHOP");
            DropColumn("dbo.ORDERs", "FACTORY");
            DropColumn("dbo.ORDERs", "EXTERNORDERKEY1");
            DropColumn("dbo.ORDERs", "SALESDEP");
            DropColumn("dbo.ORDERs", "SALESORG");
            DropColumn("dbo.ORDERDETAILs", "DELIVERYVOUCHER");
            DropColumn("dbo.ORDERDETAILs", "CHANNEL");
            DropColumn("dbo.ORDERDETAILs", "SHOP");
            DropColumn("dbo.ORDERDETAILs", "FACTORY");
            DropColumn("dbo.ORDERDETAILs", "EXTERNORDERKEY1");
            DropColumn("dbo.ORDERDETAILs", "SALESDEP");
        }
    }
}
