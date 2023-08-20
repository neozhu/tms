namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md_chlen : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ORDERDETAILs", "ORDERDETAIL_IX");
            DropIndex("dbo.ORDERs", new[] { "ORDERKEY" });
            DropIndex("dbo.SHIPORDERDETAILs", "SHIPORDERDETAIL_IX");
            AlterColumn("dbo.ORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ORDERs", "ORDERKEY", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SHIPORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ORDERDETAILs", new[] { "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "ORDERDETAIL_IX");
            CreateIndex("dbo.ORDERs", "ORDERKEY", unique: true);
            CreateIndex("dbo.SHIPORDERDETAILs", new[] { "SHIPORDERKEY", "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "SHIPORDERDETAIL_IX");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SHIPORDERDETAILs", "SHIPORDERDETAIL_IX");
            DropIndex("dbo.ORDERs", new[] { "ORDERKEY" });
            DropIndex("dbo.ORDERDETAILs", "ORDERDETAIL_IX");
            AlterColumn("dbo.SHIPORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ORDERs", "ORDERKEY", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.SHIPORDERDETAILs", new[] { "SHIPORDERKEY", "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "SHIPORDERDETAIL_IX");
            CreateIndex("dbo.ORDERs", "ORDERKEY", unique: true);
            CreateIndex("dbo.ORDERDETAILs", new[] { "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "ORDERDETAIL_IX");
        }
    }
}
