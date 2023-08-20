using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  [Table("Vehicle")]
  [Serializable]
  public partial class Vehicle : Entity
  {
    [Display(Name = "系统编号", Description = "系统编号")]
    [Key]
    public int Id { get; set; }
    [Required]
    [Index(IsUnique = true)]
    [MaxLength(10)]
    [MinLength(7)]
    [Display(Name = "车牌号", Description = "车牌号")]
    public string PlateNumber { get; set; }
    #region 派车信息

    [Display(Name = "派车单号", Description = "派车单号")]
    [MaxLength(20)]
    [DefaultValue(null)]
    public string ShipOrderNo { get; set; }

    [Display(Name = "调度人员", Description = "调度人员")]
    [MaxLength(20)]
    [DefaultValue(null)]
    public string InputUser { get; set; }



    #endregion

    #region 车辆基本信息

    #region 必填字段




    [Required]
    [MaxLength(20)]
    [Display(Name = "车辆状态", Description = "车辆状态(停用/启用/维修/在途/预定)")]
    [DefaultValue("1")]
    public string Status { get; set; }

    [Required]
    [MaxLength(20)]
    [Display(Name = "车辆类型", Description = "车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)")]
    [DefaultValue("厢式车")]
    public string CarType { get; set; }




    [Display(Name = "承运人代码", Description = "所属承运人代码")]
    [MaxLength(20)]
    [DefaultValue("-")]
    public string CarrierCode { get; set; }
    [Display(Name = "所属承运人", Description = "所属承运人")]
    [MaxLength(80)]
    [DefaultValue("-")]
    public string CarrierName { get; set; }



    [Display(Name = "车长(米)", Description = "车长(米)")]
    [DefaultValue(0)]
    public decimal VehLongSize { get; set; }

    [Display(Name = "额定载重", Description = "额定载重(吨)")]
    [DefaultValue(0)]
    public decimal StdLoadWeight { get; set; }


    [Display(Name = "收费吨位", Description = "运输车型(吨,尺等等),收费吨位")]
    [DefaultValue(0)]
    public decimal FeeLoadWeight { get; set; }


    [Display(Name = "额定体积", Description = "额定体积(立方米)")]
    [DefaultValue(0)]
    public decimal StdLoadVolume { get; set; }



    [Display(Name = "车厢尺寸", Description = "车厢尺寸(尺)")]
    [DefaultValue(0)]
    public decimal CarriageSize { get; set; }


    [MaxLength(50)]
    [Display(Name = "GPS设备号", Description = "GPS设备编号")]
    [DefaultValue("xxx-xxxx-xxxx-xxxx")]
    [Required]
    public string GPSDeviceId { get; set; }

    [Required]
    [MaxLength(20)]
    [Display(Name = "主驾司机", Description = "主驾司机")]
    [DefaultValue("-")]
    public string Driver { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "主驾电话", Description = "主驾司机电话")]

    [DefaultValue("-")]
    public string DriverPhone { get; set; }

    #endregion

    [MaxLength(20)]
    [Display(Name = "副驾司机", Description = "副驾司机")]
    [DefaultValue("")]
    public string AssistantDriver { get; set; }

    [MaxLength(50)]
    [Display(Name = "副驾司机电话", Description = "副驾司机电话")]
    [DefaultValue("")]
    public string AssistantDriverPhone { get; set; }

    

    

 

    [MaxLength(20)]
    [Display(Name = "海关编号", Description = "海关编号")]
    public string CustomsNo { get; set; }

     

    [Display(Name = "总行驶里程", Description = "总行驶里程")]
    public decimal? RoadKM { get; set; }

    [Display(Name = "行驶时间", Description = "行驶时间")]
    public decimal? RoadHours { get; set; }

    

    [MaxLength(20)]
    [Display(Name = "车主", Description = "车主")]
    public string Owner { get; set; }

    [MaxLength(50)]
    [Display(Name = "车主联系电话", Description = "联系人电话")]
    public string OwnerContactPhone { get; set; }

    #endregion

    #region 档案信息

    [Display(Name = "品牌", Description = "品牌")]
    [MaxLength(20)]
    public string Brand { get; set; }

    [Display(Name = "额定转速", Description = "额定转速")]
    public int? RPM { get; set; }

    [Display(Name = "购买日期", Description = "购买日期")]
    public DateTime? PurchasedDate { get; set; }

    [Display(Name = "购买金额", Description = "购买金额")]
    public decimal? PurchasedAmount { get; set; }

    [Display(Name = "车厢长(米)", Description = "车厢长(米)")]
    public decimal? VehLong { get; set; }

    [Display(Name = "车厢宽(米)", Description = "车厢宽(米)")]
    public decimal? VehWide { get; set; }

    [Display(Name = "车厢高(米)", Description = "车厢高(米)")]
    public decimal? VehHigh { get; set; }

    [Display(Name = "车架号", Description = "车架号")]
    [MaxLength(50)]
    public string VIN { get; set; }

    [Display(Name = "使用年限", Description = "使用年限")]
    public int? ServiceLife { get; set; }

    [Display(Name = "保养公里数", Description = "保养公里数")]
    public int? MaintainKM { get; set; }

    [Display(Name = "下次保养日期", Description = "下次保养日期")]
    public DateTime? MaintainDate { get; set; }

    [Display(Name = "保养周期(月)", Description = "保养周期(月)")]
    public int? MaintainMonth { get; set; }

    #endregion

    #region 附加信息

    [Display(Name = "车辆尾板", Description = "车辆尾板")]
    public bool ExistVehTailBoard { get; set; }

    [Display(Name = "尾板品牌", Description = "尾板品牌")]
    [MaxLength(30)]
    public string VehTailBoardBrand { get; set; }

    [Display(Name = "尾板厂家", Description = "尾板厂家")]
    [MaxLength(30)]
    public string VehTailBoardFactory { get; set; }

    [Display(Name = "尾板使用年限", Description = "尾板使用年限")]
    public int? VehTailBoardLife { get; set; }

    [Display(Name = "尾板价值", Description = "尾板价值")]
    public decimal? VehTailBoardAmount { get; set; }

    [Display(Name = "尾板GPS设备编号", Description = "尾板GPS设备编号")]
    [MaxLength(50)]
    public string VehTailBoardGPSDeviceId { get; set; }

    #endregion

    #region 行驶证信息

    [Display(Name = "型号代码", Description = "型号代码")]
    [MaxLength(50)]
    public string DrLicenseModel { get; set; }

    [Display(Name = "使用性质", Description = "使用性质")]
    [MaxLength(50)]
    public string DrLicenseUseNature { get; set; }

    [Display(Name = "品牌", Description = "品牌")]
    [MaxLength(50)]
    public string DrLicenseBrand { get; set; }

    [Display(Name = "识别代码", Description = "识别代码")]
    [MaxLength(50)]
    public string DrLicenseDevId { get; set; }

    [Display(Name = "发动机号", Description = "发动机号")]
    [MaxLength(50)]
    public string DrLicenseEngineId { get; set; }

    [Display(Name = "注册日期", Description = "注册日期")]
    public DateTime? DrLicenseRegistrationDate { get; set; }

    [Display(Name = "发证日期", Description = "发证日期")]
    public DateTime? DrLicensePubDate { get; set; }

    [Display(Name = "额定人数", Description = "额定人数")]
    public int? DrLicenseRatedUsers { get; set; }

    [Display(Name = "车辆重量(吨)", Description = "车辆重量(吨)")]
    public decimal? DrLicenseVehWeight { get; set; }

    [Display(Name = "整备重量(吨)", Description = "整备重量(吨)")]
    public decimal? DrLicenseDevWeight { get; set; }

    [Display(Name = "净重(吨)", Description = "净重(吨)")]
    public decimal? DrLicenseNetWeight { get; set; }

    [Display(Name = "净空(立方)", Description = "净空(立方)")]
    public decimal? DrLicenseNetVolume { get; set; }

    [Display(Name = "外限宽(米)", Description = "外限宽(米)")]
    public decimal? DrLicenseVehWide { get; set; }

    [Display(Name = "外限高(米)", Description = "外限高(米)")]
    public decimal? DrLicenseVehHigh { get; set; }

    [Display(Name = "外限长(米)", Description = "外限长(米)")]
    public decimal? DrLicenseVehLong { get; set; }

    [Display(Name = "强制报废日期", Description = "强制报废日期")]
    public DateTime? DrLicenseScrapedDate { get; set; }

    #endregion

    #region 道路行驶证

    [Display(Name = "文管子号", Description = "文管子号")]
    [MaxLength(50)]
    public string LoLicenseManageId { get; set; }

    [Display(Name = "运营许可证号", Description = "运营许可证号")]
    [MaxLength(50)]
    public string LoLicenseId { get; set; }

    [Display(Name = "经营范围", Description = "经营范围")]
    [MaxLength(50)]
    public string LoLicenseBusinessScope { get; set; }

    [Display(Name = "发证日期", Description = "发证日期")]
    public DateTime? LoLicensePubDate { get; set; }

    [Display(Name = "二级有效期", Description = "二级有效期")]
    public DateTime? LoLicenseValidDate { get; set; }

    [Display(Name = "年检日期", Description = "年检日期")]
    public DateTime? LoLicenseCheckDate { get; set; }

    [Display(Name = "注册地", Description = "注册地")]
    [MaxLength(30)]
    public string LoLicensePlace { get; set; }

    #endregion

    #region 保险卡信息

    [Display(Name = "交强险保单", Description = "交强险保单")]
    [MaxLength(50)]
    public string InsTrafficPolicyId { get; set; }

    [Display(Name = "保险公司", Description = "保险公司")]
    [MaxLength(50)]
    public string InsTrafficPolicyCompany { get; set; }

    [Display(Name = "交强险有效期", Description = "交强险保单有效期")]
    [MaxLength(50)]
    public string InsTrafficPolicyVaildateDate { get; set; }

    [Display(Name = "交强险保额", Description = "交强险保额")]
    public decimal? InsTrafficPolicyAmount { get; set; }

    [Display(Name = "三者保单号", Description = "第三者保单号")]
    [MaxLength(50)]
    public string InsThirdPartyId { get; set; }

    [Display(Name = "三者有效期", Description = "第三者保单有效期")]
    public DateTime? InsThirdPartyVaildateDate { get; set; }

    [Display(Name = "三者保单额", Description = "第三者保单额")]
    public decimal? InsThirdPartyAmount { get; set; }

    [Display(Name = "责任险保额", Description = "物流责任险保额")]
    public decimal? InsThirdPartyLogisticsAmount { get; set; }

    [Display(Name = "责任险有效期", Description = "物流责任险有效期")]
    public DateTime? InsThirdPartyLogisticsVaildateDate { get; set; }

    #endregion


  }


}