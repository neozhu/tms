namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md208 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SHIPORDERs", "SHPTYPE", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SHIPORDERs", "SHPTYPE");
        }
    }
}
