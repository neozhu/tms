namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md_maxlength : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ORDERDETAILs", "ORDERDETAIL_IX");
            DropIndex("dbo.ORDERs", new[] { "ORDERKEY" });
            DropIndex("dbo.SHIPORDERDETAILs", "SHIPORDERDETAIL_IX");
            DropIndex("dbo.SHIPORDERs", new[] { "SHIPORDERKEY" });
            AlterColumn("dbo.ORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ORDERDETAILs", "EXTERNLINENO", c => c.String(maxLength: 50));
            AlterColumn("dbo.ORDERs", "ORDERKEY", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SHIPORDERDETAILs", "SHIPORDERKEY", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SHIPORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SHIPORDERDETAILs", "EXTERNLINENO", c => c.String(maxLength: 50));
            AlterColumn("dbo.SHIPORDERs", "SHIPORDERKEY", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.StatusHistories", "ORDERKEY", c => c.String(maxLength: 50));
            AlterColumn("dbo.StatusHistories", "SHIPORDERKEY", c => c.String(maxLength: 50));
            CreateIndex("dbo.ORDERDETAILs", new[] { "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "ORDERDETAIL_IX");
            CreateIndex("dbo.ORDERs", "ORDERKEY", unique: true);
            CreateIndex("dbo.SHIPORDERDETAILs", new[] { "SHIPORDERKEY", "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "SHIPORDERDETAIL_IX");
            CreateIndex("dbo.SHIPORDERs", "SHIPORDERKEY", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SHIPORDERs", new[] { "SHIPORDERKEY" });
            DropIndex("dbo.SHIPORDERDETAILs", "SHIPORDERDETAIL_IX");
            DropIndex("dbo.ORDERs", new[] { "ORDERKEY" });
            DropIndex("dbo.ORDERDETAILs", "ORDERDETAIL_IX");
            AlterColumn("dbo.StatusHistories", "SHIPORDERKEY", c => c.String(maxLength: 20));
            AlterColumn("dbo.StatusHistories", "ORDERKEY", c => c.String(maxLength: 20));
            AlterColumn("dbo.SHIPORDERs", "SHIPORDERKEY", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SHIPORDERDETAILs", "EXTERNLINENO", c => c.String(maxLength: 20));
            AlterColumn("dbo.SHIPORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SHIPORDERDETAILs", "SHIPORDERKEY", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ORDERs", "ORDERKEY", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ORDERDETAILs", "EXTERNLINENO", c => c.String(maxLength: 20));
            AlterColumn("dbo.ORDERDETAILs", "ORDERKEY", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.SHIPORDERs", "SHIPORDERKEY", unique: true);
            CreateIndex("dbo.SHIPORDERDETAILs", new[] { "SHIPORDERKEY", "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "SHIPORDERDETAIL_IX");
            CreateIndex("dbo.ORDERs", "ORDERKEY", unique: true);
            CreateIndex("dbo.ORDERDETAILs", new[] { "ORDERKEY", "ORDERLINENUMBER" }, unique: true, name: "ORDERDETAIL_IX");
        }
    }
}
