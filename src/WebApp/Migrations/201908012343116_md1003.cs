namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class md1003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlateNumber = c.String(nullable: false, maxLength: 10),
                        ShipOrderNo = c.String(maxLength: 20),
                        InputUser = c.String(maxLength: 20),
                        Status = c.String(nullable: false, maxLength: 20),
                        CarType = c.String(nullable: false, maxLength: 20),
                        CarrierCode = c.String(maxLength: 20),
                        CarrierName = c.String(maxLength: 80),
                        VehLongSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StdLoadWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeeLoadWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StdLoadVolume = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarriageSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GPSDeviceId = c.String(nullable: false, maxLength: 50),
                        Driver = c.String(nullable: false, maxLength: 20),
                        DriverPhone = c.String(nullable: false, maxLength: 50),
                        AssistantDriver = c.String(maxLength: 20),
                        AssistantDriverPhone = c.String(maxLength: 50),
                        CustomsNo = c.String(maxLength: 20),
                        RoadKM = c.Decimal(precision: 18, scale: 2),
                        RoadHours = c.Decimal(precision: 18, scale: 2),
                        Owner = c.String(maxLength: 20),
                        OwnerContactPhone = c.String(maxLength: 50),
                        Brand = c.String(maxLength: 20),
                        RPM = c.Int(),
                        PurchasedDate = c.DateTime(),
                        PurchasedAmount = c.Decimal(precision: 18, scale: 2),
                        VehLong = c.Decimal(precision: 18, scale: 2),
                        VehWide = c.Decimal(precision: 18, scale: 2),
                        VehHigh = c.Decimal(precision: 18, scale: 2),
                        VIN = c.String(maxLength: 50),
                        ServiceLife = c.Int(),
                        MaintainKM = c.Int(),
                        MaintainDate = c.DateTime(),
                        MaintainMonth = c.Int(),
                        ExistVehTailBoard = c.Boolean(nullable: false),
                        VehTailBoardBrand = c.String(maxLength: 30),
                        VehTailBoardFactory = c.String(maxLength: 30),
                        VehTailBoardLife = c.Int(),
                        VehTailBoardAmount = c.Decimal(precision: 18, scale: 2),
                        VehTailBoardGPSDeviceId = c.String(maxLength: 50),
                        DrLicenseModel = c.String(maxLength: 50),
                        DrLicenseUseNature = c.String(maxLength: 50),
                        DrLicenseBrand = c.String(maxLength: 50),
                        DrLicenseDevId = c.String(maxLength: 50),
                        DrLicenseEngineId = c.String(maxLength: 50),
                        DrLicenseRegistrationDate = c.DateTime(),
                        DrLicensePubDate = c.DateTime(),
                        DrLicenseRatedUsers = c.Int(),
                        DrLicenseVehWeight = c.Decimal(precision: 18, scale: 2),
                        DrLicenseDevWeight = c.Decimal(precision: 18, scale: 2),
                        DrLicenseNetWeight = c.Decimal(precision: 18, scale: 2),
                        DrLicenseNetVolume = c.Decimal(precision: 18, scale: 2),
                        DrLicenseVehWide = c.Decimal(precision: 18, scale: 2),
                        DrLicenseVehHigh = c.Decimal(precision: 18, scale: 2),
                        DrLicenseVehLong = c.Decimal(precision: 18, scale: 2),
                        DrLicenseScrapedDate = c.DateTime(),
                        LoLicenseManageId = c.String(maxLength: 50),
                        LoLicenseId = c.String(maxLength: 50),
                        LoLicenseBusinessScope = c.String(maxLength: 50),
                        LoLicensePubDate = c.DateTime(),
                        LoLicenseValidDate = c.DateTime(),
                        LoLicenseCheckDate = c.DateTime(),
                        LoLicensePlace = c.String(maxLength: 30),
                        InsTrafficPolicyId = c.String(maxLength: 50),
                        InsTrafficPolicyCompany = c.String(maxLength: 50),
                        InsTrafficPolicyVaildateDate = c.String(maxLength: 50),
                        InsTrafficPolicyAmount = c.Decimal(precision: 18, scale: 2),
                        InsThirdPartyId = c.String(maxLength: 50),
                        InsThirdPartyVaildateDate = c.DateTime(),
                        InsThirdPartyAmount = c.Decimal(precision: 18, scale: 2),
                        InsThirdPartyLogisticsAmount = c.Decimal(precision: 18, scale: 2),
                        InsThirdPartyLogisticsVaildateDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.PlateNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicle", new[] { "PlateNumber" });
            DropTable("dbo.Vehicle");
        }
    }
}
