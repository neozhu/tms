namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md228 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderKey = c.String(nullable: false, maxLength: 50),
                        FileName = c.String(nullable: false, maxLength: 50),
                        FileType = c.String(maxLength: 5),
                        Path = c.String(maxLength: 300),
                        Url = c.String(maxLength: 300),
                        MD5 = c.String(maxLength: 300),
                        Size = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(precision: 18, scale: 2),
                        Height = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(maxLength: 300),
                        User = c.String(maxLength: 20),
                        UploadDateTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
