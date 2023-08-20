namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataTableImportMappings", "IgnoredColumn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataTableImportMappings", "IgnoredColumn");
        }
    }
}
