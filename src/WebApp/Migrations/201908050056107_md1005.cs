namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md1005 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Locations", newName: "LocBases");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LocBases", newName: "Locations");
        }
    }
}
