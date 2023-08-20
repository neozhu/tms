namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md221 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SHIPORDERDETAILs", "EXTERNORDERKEY1", c => c.String(maxLength: 50));
            AddColumn("dbo.SHIPORDERDETAILs", "FACTORY", c => c.String(maxLength: 50));
            AddColumn("dbo.SHIPORDERDETAILs", "SHOP", c => c.String(maxLength: 50));
            AddColumn("dbo.SHIPORDERDETAILs", "CHANNEL", c => c.String(maxLength: 50));
            AddColumn("dbo.SHIPORDERDETAILs", "DELIVERYVOUCHER", c => c.String(maxLength: 50));
            AddColumn("dbo.SHIPORDERDETAILs", "SALESDEP", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERDETAILs", "SALESDEP");
            DropColumn("dbo.SHIPORDERDETAILs", "DELIVERYVOUCHER");
            DropColumn("dbo.SHIPORDERDETAILs", "CHANNEL");
            DropColumn("dbo.SHIPORDERDETAILs", "SHOP");
            DropColumn("dbo.SHIPORDERDETAILs", "FACTORY");
            DropColumn("dbo.SHIPORDERDETAILs", "EXTERNORDERKEY1");
        }
    }
}
