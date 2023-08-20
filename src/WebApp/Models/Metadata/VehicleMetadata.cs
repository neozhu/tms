using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="VehicleMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2019/8/2 7:53:58 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(VehicleMetadata))]
    public partial class Vehicle
    {
    }

    public partial class VehicleMetadata
    {
        [Required(ErrorMessage = "Please enter : 系统编号")]
        [Display(Name = "Id",Description ="系统编号",Prompt = "系统编号",ResourceType = typeof(resource.Vehicle))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 车牌号")]
        [Display(Name = "PlateNumber",Description ="车牌号",Prompt = "车牌号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(10)]
        public string PlateNumber { get; set; }

        [Display(Name = "ShipOrderNo",Description ="派车单号",Prompt = "派车单号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string ShipOrderNo { get; set; }

        [Display(Name = "InputUser",Description ="调度人员",Prompt = "调度人员",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string InputUser { get; set; }

        [Required(ErrorMessage = "Please enter : 车辆状态(停用/启用/维修/在途/预定)")]
        [Display(Name = "Status",Description ="车辆状态(停用/启用/维修/在途/预定)",Prompt = "车辆状态(停用/启用/维修/在途/预定)",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please enter : 车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)")]
        [Display(Name = "CarType",Description ="车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)",Prompt = "车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string CarType { get; set; }

        [Display(Name = "CarrierCode",Description ="所属承运人代码",Prompt = "所属承运人代码",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string CarrierCode { get; set; }

        [Display(Name = "CarrierName",Description ="所属承运人",Prompt = "所属承运人",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(80)]
        public string CarrierName { get; set; }

        [Required(ErrorMessage = "Please enter : 车长(米)")]
        [Display(Name = "VehLongSize",Description ="车长(米)",Prompt = "车长(米)",ResourceType = typeof(resource.Vehicle))]
        public decimal VehLongSize { get; set; }

        [Required(ErrorMessage = "Please enter : 额定载重(吨)")]
        [Display(Name = "StdLoadWeight",Description ="额定载重(吨)",Prompt = "额定载重(吨)",ResourceType = typeof(resource.Vehicle))]
        public decimal StdLoadWeight { get; set; }

        [Required(ErrorMessage = "Please enter : 运输车型(吨,尺等等),收费吨位")]
        [Display(Name = "FeeLoadWeight",Description ="运输车型(吨,尺等等),收费吨位",Prompt = "运输车型(吨,尺等等),收费吨位",ResourceType = typeof(resource.Vehicle))]
        public decimal FeeLoadWeight { get; set; }

        [Required(ErrorMessage = "Please enter : 额定体积(立方米)")]
        [Display(Name = "StdLoadVolume",Description ="额定体积(立方米)",Prompt = "额定体积(立方米)",ResourceType = typeof(resource.Vehicle))]
        public decimal StdLoadVolume { get; set; }

        [Required(ErrorMessage = "Please enter : 车厢尺寸(尺)")]
        [Display(Name = "CarriageSize",Description ="车厢尺寸(尺)",Prompt = "车厢尺寸(尺)",ResourceType = typeof(resource.Vehicle))]
        public decimal CarriageSize { get; set; }

        [Required(ErrorMessage = "Please enter : GPS设备编号")]
        [Display(Name = "GPSDeviceId",Description ="GPS设备编号",Prompt = "GPS设备编号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string GPSDeviceId { get; set; }

        [Required(ErrorMessage = "Please enter : 主驾司机")]
        [Display(Name = "Driver",Description ="主驾司机",Prompt = "主驾司机",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string Driver { get; set; }

        [Required(ErrorMessage = "Please enter : 主驾司机电话")]
        [Display(Name = "DriverPhone",Description ="主驾司机电话",Prompt = "主驾司机电话",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string DriverPhone { get; set; }

        [Display(Name = "AssistantDriver",Description ="副驾司机",Prompt = "副驾司机",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string AssistantDriver { get; set; }

        [Display(Name = "AssistantDriverPhone",Description ="副驾司机电话",Prompt = "副驾司机电话",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string AssistantDriverPhone { get; set; }

        [Display(Name = "CustomsNo",Description ="海关编号",Prompt = "海关编号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string CustomsNo { get; set; }

        [Display(Name = "RoadKM",Description ="总行驶里程",Prompt = "总行驶里程",ResourceType = typeof(resource.Vehicle))]
        public decimal RoadKM { get; set; }

        [Display(Name = "RoadHours",Description ="行驶时间",Prompt = "行驶时间",ResourceType = typeof(resource.Vehicle))]
        public decimal RoadHours { get; set; }

        [Display(Name = "Owner",Description ="车主",Prompt = "车主",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string Owner { get; set; }

        [Display(Name = "OwnerContactPhone",Description ="联系人电话",Prompt = "联系人电话",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string OwnerContactPhone { get; set; }

        [Display(Name = "Brand",Description ="品牌",Prompt = "品牌",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string Brand { get; set; }

        [Display(Name = "RPM",Description ="额定转速",Prompt = "额定转速",ResourceType = typeof(resource.Vehicle))]
        public int RPM { get; set; }

        [Display(Name = "PurchasedDate",Description ="购买日期",Prompt = "购买日期",ResourceType = typeof(resource.Vehicle))]
        public DateTime PurchasedDate { get; set; }

        [Display(Name = "PurchasedAmount",Description ="购买金额",Prompt = "购买金额",ResourceType = typeof(resource.Vehicle))]
        public decimal PurchasedAmount { get; set; }

        [Display(Name = "VehLong",Description ="车厢长(米)",Prompt = "车厢长(米)",ResourceType = typeof(resource.Vehicle))]
        public decimal VehLong { get; set; }

        [Display(Name = "VehWide",Description ="车厢宽(米)",Prompt = "车厢宽(米)",ResourceType = typeof(resource.Vehicle))]
        public decimal VehWide { get; set; }

        [Display(Name = "VehHigh",Description ="车厢高(米)",Prompt = "车厢高(米)",ResourceType = typeof(resource.Vehicle))]
        public decimal VehHigh { get; set; }

        [Display(Name = "VIN",Description ="车架号",Prompt = "车架号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string VIN { get; set; }

        [Display(Name = "ServiceLife",Description ="使用年限",Prompt = "使用年限",ResourceType = typeof(resource.Vehicle))]
        public int ServiceLife { get; set; }

        [Display(Name = "MaintainKM",Description ="保养公里数",Prompt = "保养公里数",ResourceType = typeof(resource.Vehicle))]
        public int MaintainKM { get; set; }

        [Display(Name = "MaintainDate",Description ="下次保养日期",Prompt = "下次保养日期",ResourceType = typeof(resource.Vehicle))]
        public DateTime MaintainDate { get; set; }

        [Display(Name = "MaintainMonth",Description ="保养周期(月)",Prompt = "保养周期(月)",ResourceType = typeof(resource.Vehicle))]
        public int MaintainMonth { get; set; }

        [Required(ErrorMessage = "Please enter : 车辆尾板")]
        [Display(Name = "ExistVehTailBoard",Description ="车辆尾板",Prompt = "车辆尾板",ResourceType = typeof(resource.Vehicle))]
        public bool ExistVehTailBoard { get; set; }

        [Display(Name = "VehTailBoardBrand",Description ="尾板品牌",Prompt = "尾板品牌",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(30)]
        public string VehTailBoardBrand { get; set; }

        [Display(Name = "VehTailBoardFactory",Description ="尾板厂家",Prompt = "尾板厂家",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(30)]
        public string VehTailBoardFactory { get; set; }

        [Display(Name = "VehTailBoardLife",Description ="尾板使用年限",Prompt = "尾板使用年限",ResourceType = typeof(resource.Vehicle))]
        public int VehTailBoardLife { get; set; }

        [Display(Name = "VehTailBoardAmount",Description ="尾板价值",Prompt = "尾板价值",ResourceType = typeof(resource.Vehicle))]
        public decimal VehTailBoardAmount { get; set; }

        [Display(Name = "VehTailBoardGPSDeviceId",Description ="尾板GPS设备编号",Prompt = "尾板GPS设备编号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string VehTailBoardGPSDeviceId { get; set; }

        [Display(Name = "DrLicenseModel",Description ="型号代码",Prompt = "型号代码",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string DrLicenseModel { get; set; }

        [Display(Name = "DrLicenseUseNature",Description ="使用性质",Prompt = "使用性质",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string DrLicenseUseNature { get; set; }

        [Display(Name = "DrLicenseBrand",Description ="品牌",Prompt = "品牌",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string DrLicenseBrand { get; set; }

        [Display(Name = "DrLicenseDevId",Description ="识别代码",Prompt = "识别代码",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string DrLicenseDevId { get; set; }

        [Display(Name = "DrLicenseEngineId",Description ="发动机号",Prompt = "发动机号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string DrLicenseEngineId { get; set; }

        [Display(Name = "DrLicenseRegistrationDate",Description ="注册日期",Prompt = "注册日期",ResourceType = typeof(resource.Vehicle))]
        public DateTime DrLicenseRegistrationDate { get; set; }

        [Display(Name = "DrLicensePubDate",Description ="发证日期",Prompt = "发证日期",ResourceType = typeof(resource.Vehicle))]
        public DateTime DrLicensePubDate { get; set; }

        [Display(Name = "DrLicenseRatedUsers",Description ="额定人数",Prompt = "额定人数",ResourceType = typeof(resource.Vehicle))]
        public int DrLicenseRatedUsers { get; set; }

        [Display(Name = "DrLicenseVehWeight",Description ="车辆重量(吨)",Prompt = "车辆重量(吨)",ResourceType = typeof(resource.Vehicle))]
        public decimal DrLicenseVehWeight { get; set; }

        [Display(Name = "DrLicenseDevWeight",Description ="整备重量(吨)",Prompt = "整备重量(吨)",ResourceType = typeof(resource.Vehicle))]
        public decimal DrLicenseDevWeight { get; set; }

        [Display(Name = "DrLicenseNetWeight",Description ="净重(吨)",Prompt = "净重(吨)",ResourceType = typeof(resource.Vehicle))]
        public decimal DrLicenseNetWeight { get; set; }

        [Display(Name = "DrLicenseNetVolume",Description ="净空(立方)",Prompt = "净空(立方)",ResourceType = typeof(resource.Vehicle))]
        public decimal DrLicenseNetVolume { get; set; }

        [Display(Name = "DrLicenseVehWide",Description ="外限宽(米)",Prompt = "外限宽(米)",ResourceType = typeof(resource.Vehicle))]
        public decimal DrLicenseVehWide { get; set; }

        [Display(Name = "DrLicenseVehHigh",Description ="外限高(米)",Prompt = "外限高(米)",ResourceType = typeof(resource.Vehicle))]
        public decimal DrLicenseVehHigh { get; set; }

        [Display(Name = "DrLicenseVehLong",Description ="外限长(米)",Prompt = "外限长(米)",ResourceType = typeof(resource.Vehicle))]
        public decimal DrLicenseVehLong { get; set; }

        [Display(Name = "DrLicenseScrapedDate",Description ="强制报废日期",Prompt = "强制报废日期",ResourceType = typeof(resource.Vehicle))]
        public DateTime DrLicenseScrapedDate { get; set; }

        [Display(Name = "LoLicenseManageId",Description ="文管子号",Prompt = "文管子号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string LoLicenseManageId { get; set; }

        [Display(Name = "LoLicenseId",Description ="运营许可证号",Prompt = "运营许可证号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string LoLicenseId { get; set; }

        [Display(Name = "LoLicenseBusinessScope",Description ="经营范围",Prompt = "经营范围",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string LoLicenseBusinessScope { get; set; }

        [Display(Name = "LoLicensePubDate",Description ="发证日期",Prompt = "发证日期",ResourceType = typeof(resource.Vehicle))]
        public DateTime LoLicensePubDate { get; set; }

        [Display(Name = "LoLicenseValidDate",Description ="二级有效期",Prompt = "二级有效期",ResourceType = typeof(resource.Vehicle))]
        public DateTime LoLicenseValidDate { get; set; }

        [Display(Name = "LoLicenseCheckDate",Description ="年检日期",Prompt = "年检日期",ResourceType = typeof(resource.Vehicle))]
        public DateTime LoLicenseCheckDate { get; set; }

        [Display(Name = "LoLicensePlace",Description ="注册地",Prompt = "注册地",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(30)]
        public string LoLicensePlace { get; set; }

        [Display(Name = "InsTrafficPolicyId",Description ="交强险保单",Prompt = "交强险保单",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string InsTrafficPolicyId { get; set; }

        [Display(Name = "InsTrafficPolicyCompany",Description ="保险公司",Prompt = "保险公司",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string InsTrafficPolicyCompany { get; set; }

        [Display(Name = "InsTrafficPolicyVaildateDate",Description ="交强险保单有效期",Prompt = "交强险保单有效期",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string InsTrafficPolicyVaildateDate { get; set; }

        [Display(Name = "InsTrafficPolicyAmount",Description ="交强险保额",Prompt = "交强险保额",ResourceType = typeof(resource.Vehicle))]
        public decimal InsTrafficPolicyAmount { get; set; }

        [Display(Name = "InsThirdPartyId",Description ="第三者保单号",Prompt = "第三者保单号",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(50)]
        public string InsThirdPartyId { get; set; }

        [Display(Name = "InsThirdPartyVaildateDate",Description ="第三者保单有效期",Prompt = "第三者保单有效期",ResourceType = typeof(resource.Vehicle))]
        public DateTime InsThirdPartyVaildateDate { get; set; }

        [Display(Name = "InsThirdPartyAmount",Description ="第三者保单额",Prompt = "第三者保单额",ResourceType = typeof(resource.Vehicle))]
        public decimal InsThirdPartyAmount { get; set; }

        [Display(Name = "InsThirdPartyLogisticsAmount",Description ="物流责任险保额",Prompt = "物流责任险保额",ResourceType = typeof(resource.Vehicle))]
        public decimal InsThirdPartyLogisticsAmount { get; set; }

        [Display(Name = "InsThirdPartyLogisticsVaildateDate",Description ="物流责任险有效期",Prompt = "物流责任险有效期",ResourceType = typeof(resource.Vehicle))]
        public DateTime InsThirdPartyLogisticsVaildateDate { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.Vehicle))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.Vehicle))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.Vehicle))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
