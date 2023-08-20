namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md1004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 180),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 8),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 8),
                        Radius = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gid = c.String(maxLength: 80),
                        Enable = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "Name" });
            DropTable("dbo.Locations");
        }
    }
}
