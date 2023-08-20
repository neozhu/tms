namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md205 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SUPPLIERs", "Loc1", c => c.String(maxLength: 50));
            AddColumn("dbo.SUPPLIERs", "Loc2", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SUPPLIERs", "Loc2");
            DropColumn("dbo.SUPPLIERs", "Loc1");
        }
    }
}
