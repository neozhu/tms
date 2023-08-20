using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  public partial class SHIPORDER:Entity
  {
    public SHIPORDER() => this.SHIPORDERDETAILS = new HashSet<SHIPORDERDETAIL>();
    [Key]
    public int ID { get; set; }
    [Display(Name = "运单号", Description = "运单号")]
    [MaxLength(50)]
    [Index(IsUnique = true)]
    [Required]
    [DefaultValue("00000001")]
    public string SHIPORDERKEY { get; set; }

    [Display(Name = "对账单号", Description = "对账单号")]
    [MaxLength(50)]
    public string EXTERNSHIPORDERKEY { get; set; }
    [Display(Name = "接单日期", Description = "接单日期")]
    [DefaultValue("now")]
    public DateTime SHIPORDERDATE { get; set; }
    [Display(Name = "状态", Description = "状态")]
    [MaxLength(3)]
    [Required]
    [DefaultValue("100")]
    public string STATUS { get; set; }
    //----------------------------------------------------------------------
    [Display(Name = "运输方式", Description = "运输方式(正常/加急/退运)")]
    [MaxLength(3)]
    [DefaultValue("1")]
    public string TYPE { get; set; }
    [Display(Name = "计费方式", Description = "计费方式(整车/零担)")]
    [MaxLength(3)]
    [DefaultValue("1")]
    public string SHPTYPE { get; set; }
    [Display(Name = "启运地", Description = "启运地")]
    [MaxLength(50)]
    [Required]
    [DefaultValue("")]
    public string ORIGINAL { get; set; }
    [Display(Name = "送货区域", Description = "送货区域")]
    [MaxLength(50)]
    [Required]
    [DefaultValue("")]
    public string DESTINATION { get; set; }

   
    
    [Display(Name = "运输车辆", Description = "运输车辆")]
    [MaxLength(10)]
    [DefaultValue("-")]
    [Required]
    public string PLATENUMBER { get; set; }
    //-----------------------------------------------------
    [Display(Name = "司机", Description = "司机")]
    [MaxLength(20)]
    [DefaultValue(null)]
    public string DRIVERNAME { get; set; }
    [Display(Name = "司机电话", Description = "司机电话")]
    [MaxLength(20)]
    [DefaultValue(null)]
    public string DRIVERPHONE { get; set; }
    [Display(Name = "承运人代码", Description = "承运人代码")]
    [MaxLength(20)]
    [DefaultValue(null)]
    public string CARRIERCODE { get; set; }

    [Display(Name = "承运人名称", Description = "承运人名称")]
    [MaxLength(80)]
    [DefaultValue(null)]
    public string CARRIERNAME { get; set; }
    [Display(Name = "发货单位", Description = "发货单位")]
    [MaxLength(30)]
    [DefaultValue(null)]
    public string SHIPPERKEY { get; set; }
    [Display(Name = "发货单位名称", Description = "发货单位名称")]
    [MaxLength(80)]
    [DefaultValue(null)]
    public string SHIPPERNAME { get; set; }
    [Display(Name = "发货地址", Description = "发货地址")]
    [MaxLength(180)]
    [DefaultValue("-")]
    public string SHIPPERADDRESS { get; set; }
    [Display(Name = "收货单位", Description = "收货单位")]
    [MaxLength(30)]
    [DefaultValue(null)]
    public string CONSIGNEEKEY { get; set; }
    [Display(Name = "收货单位名称", Description = "收货单位名称")]
    [MaxLength(80)]
    [DefaultValue(null)]
    public string CONSIGNEENAME { get; set; }
    [Display(Name = "收货地址", Description = "收货地址")]
    [MaxLength(180)]
    [DefaultValue("-")]
    public string CONSIGNEEADDRESS { get; set; }

    //-------------------------------------------------

    [Display(Name = "要求配送日期", Description = "要求配送日期")]
    [DefaultValue("now")]
    public DateTime? REQUESTEDSHIPDATE { get; set; }
    [Display(Name = "实际配送日期", Description = "实际配送日期")]
    [DefaultValue(null)]
    public DateTime? ACTUALSHIPDATE { get; set; }
    [Display(Name = "要求到货时间", Description = "要求到货时间")]
    [DefaultValue("now")]
    public DateTime? DELIVERYDATE { get; set; }

    [Display(Name = "实际到货时间", Description = "实际到货时间")]
    [DefaultValue(null)]
    public DateTime? ACTUALDELIVERYDATE { get; set; }
    //---------------------------------------------------------
    [Display(Name = "结案日期", Description = "结案日期")]
    [DefaultValue(null)]
    public DateTime? CLOSEDDATE { get; set; }

    
   


   
    

    [Display(Name = "合计发运数量", Description = "合计发运数量")]

    public decimal TOTALQTY { get; set; }

    [Display(Name = "合计确认数量", Description = "合计确认数量")]
    public decimal TOTALSHIPPEDQTY { get; set; }



    [Display(Name = "合计件数", Description = "合计件数")]

    public decimal? TOTALCASECNT { get; set; }
    [Display(Name = "合计毛重(KG)", Description = "合计毛重(KG)")]
    public decimal? TOTALGROSSWGT { get; set; }
    [Display(Name = "合计体积(M)", Description = "合计体积(M)")]
    public decimal? TOTALCUBE { get; set; }
    #region 配载量计算
    [Display(Name = "标准里程", Description = "标准里程(千米)")]
    [DefaultValue(0)]
    public decimal STDKM { get; set; }
    [Display(Name = "起始里程数", Description = "起始里程数(千米)")]
    [DefaultValue(0)]
    public decimal KM1 { get; set; }
    [Display(Name = "结束里程数", Description = "结束里程数(千米)")]
    [DefaultValue(0)]
    public decimal KM2 { get; set; }
    [Display(Name = "实际里程", Description = "实际里程(千米)")]
    [DefaultValue(0)]
    public decimal ACTKM { get; set; }
    [Display(Name = "标准油耗", Description = "标准油耗(升)")]
    [DefaultValue(0)]
    public decimal STDOIL { get; set; }
    [Display(Name = "起始油量", Description = "起始油量(升)")]
    [DefaultValue(0)]
    public decimal OIL1 { get; set; }
    [Display(Name = "结束油量", Description = "结束油量(升)")]
    [DefaultValue(0)]
    public decimal OIL2 { get; set; }
    [Display(Name = "实际油耗", Description = "油耗(升)")]
    [DefaultValue(0)]
    public decimal ACTOIL { get; set; }
    [Display(Name = "额定载重", Description = "额定载重(吨)")]
    [DefaultValue(0)]
    public decimal STDLOADWEIGHT { get; set; }
    [Display(Name = "额定体积", Description = "额定体积(立方米)")]
    [DefaultValue(0)]
    public decimal STDLOADVOLUME { get; set; }

    [Display(Name = "收费吨位", Description = "收费吨位")]
    [DefaultValue(0)]
    public decimal FEELOADWEIGHT { get; set; }
    [Display(Name = "重量装载率", Description = "重量装载率")]
    [DefaultValue(0)]
    public decimal LOADFACTOR1 { get; set; }
    [Display(Name = "体积装载率", Description = "体积装载率")]
    [DefaultValue(0)]
    public decimal LOADFACTOR2 { get; set; }
    [Display(Name = "标准运费", Description = "标准运费")]
    [DefaultValue(0.00)]
    public decimal STDCOST { get; set; }
    [Display(Name = "标准过路费", Description = "标准过路费")]
    [DefaultValue(0)]
    public decimal STDTOLL { get; set; }
    [Display(Name = "毛利", Description = "毛利")]
    [DefaultValue(0.00)]
    public decimal GROSSMARGINS { get; set; }
    [Display(Name = "毛利率", Description = "毛利率")]
    [DefaultValue(0.00)]
    public decimal GROSSMARGINSRATE { get; set; }
    [Display(Name = "合计服务费", Description = "合计服务费")]
    [DefaultValue(0.00)]
    public decimal TOTALSERVICECOST { get; set; }
    #endregion

    #region 费用结算
    [Display(Name = "是否计算运费", Description = "是否计算运费")]
    [DefaultValue(false)]
    public bool CHECKEDCOST1 { get; set; }
    [Display(Name = "运费", Description = "运费")]
    [DefaultValue(0.00)]
    public decimal TOTALCOST1 { get; set; }
    [Display(Name = "是否送货上门", Description = "是否送货上门")]
    [DefaultValue(false)]
    public bool CHECKEDCOST2 { get; set; }

    [Display(Name = "送货费", Description = "送货费(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST2 { get; set; }
    [Display(Name = "是否上楼", Description = "是否上楼")]
    [DefaultValue(false)]
    public bool CHECKEDCOST3 { get; set; }
    [Display(Name = "楼层", Description = "楼层")]
    [DefaultValue(0)]
    public int FLOOR { get; set; }

    [Display(Name = "搬运费", Description = "搬运费(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST3 { get; set; }
    [Display(Name = "是否加急", Description = "是否加急")]
    [DefaultValue(false)]
    public bool CHECKEDCOST4 { get; set; }
    [Display(Name = "加急费", Description = "加急费(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST4 { get; set; }
    [Display(Name = "是否专车", Description = "是否专车")]
    [DefaultValue(false)]
    public bool CHECKEDCOST5 { get; set; }
    [Display(Name = "专车费", Description = "专车费(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST5 { get; set; }
    [Display(Name = "其它服务", Description = "是否其它服务")]
    [DefaultValue(false)]
    public bool CHECKEDCOST6 { get; set; }
    [Display(Name = "其它服务项目", Description = "其它服务项目")]
    public string TOTALCOST6NOTES { get; set; }

    [Display(Name = "其它服务费", Description = "其它服务费(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST6 { get; set; }
    [Display(Name = "是否其它服务2", Description = "是否其它服务2")]
    [DefaultValue(false)]
    public bool CHECKEDCOST7 { get; set; }
    [Display(Name = "其它服务费2", Description = "其它服务费2(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST7 { get; set; }
    [Display(Name = "是否其它服务3", Description = "是否其它服务3")]
    [DefaultValue(false)]
    public bool CHECKEDCOST8 { get; set; }
    [Display(Name = "汇总运费", Description = "汇总运费")]
    [DefaultValue(0)]
    public decimal TOTALCOST8 { get; set; }
    [Display(Name = "结算标志", Description = "结算标志")]
    [DefaultValue(false)]
    public bool FLAG1 { get; set; }
    [Display(Name = "备注2", Description = "备注2")]
    [MaxLength(180)]
    public string NOTES1 { get; set; }
    [Display(Name = "其它标志", Description = "其它标志")]
    [DefaultValue(false)]
    public bool FLAG2 { get; set; }
    #endregion
    [Display(Name = "备注", Description = "备注")]
    [MaxLength(180)]
    public string NOTES { get; set; }
    [Display(Name = "所属公司", Description = "所属公司")]
    [MaxLength(20)]
    [DefaultValue("000001")]
    public string COMPANYCODE { get; set; }
    [Display(Name = "上传用户", Description = "上传用户")]
    [MaxLength(50)]
    [DefaultValue("user")]
    public string LOTTABLE1 { get; set; }

    [Display(Name = "LOTTABLE2", Description = "LOTTABLE2")]
    [MaxLength(60)]
    public string LOTTABLE2 { get; set; }

    [Display(Name = "LOTTABLE3", Description = "LOTTABLE3")]
    [MaxLength(60)]
    public string LOTTABLE3 { get; set; }
    [Display(Name = "LOTTABLE4", Description = "LOTTABLE4")]
    [MaxLength(60)]
    public string LOTTABLE4 { get; set; }
    [Display(Name = "LOTTABLE5", Description = "LOTTABLE5")]
    [MaxLength(50)]
    public string LOTTABLE5 { get; set; }
    [Display(Name = "LOTTABLE6", Description = "LOTTABLE6")]
    [DefaultValue(null)]
    public decimal? LOTTABLE6 { get; set; }
    [Display(Name = "LOTTABLE7", Description = "LOTTABLE7")]
    [DefaultValue(null)]
    public decimal? LOTTABLE7 { get; set; }
    [Display(Name = "LOTTABLE8", Description = "LOTTABLE8")]
    [DefaultValue(null)]
    public DateTime? LOTTABLE8 { get; set; }

    public virtual ICollection<SHIPORDERDETAIL> SHIPORDERDETAILS { get; set; }
 

    

  }
}