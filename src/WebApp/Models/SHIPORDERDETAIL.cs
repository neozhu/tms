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
  public partial class SHIPORDERDETAIL:Entity
  {
    [Key]
    public int ID { get; set; }
    [Display(Name = "运单号", Description = "运单号")]
    [MaxLength(50)]
    [Index("SHIPORDERDETAIL_IX", IsUnique = true,Order =1)]
    [Required]
    [DefaultValue("00000001")]
    public string SHIPORDERKEY { get; set; }
    
   
    [Display(Name = "对账单号", Description = "对账单号")]
    [MaxLength(50)]
    public string EXTERNSHIPORDERKEY { get; set; }
    
    [Display(Name = "行号", Description = "行号")]
    [MaxLength(6)]
    [Index("SHIPORDERDETAIL_IX", IsUnique = true, Order = 3)]
    [Required]
    [DefaultValue("001")]
    public string ORDERLINENUMBER { get; set; }

    [Display(Name = "状态", Description = "状态")]
    [MaxLength(3)]
    [DefaultValue("105")]
    public string STATUS { get; set; }
   
    [Display(Name = "客户代码", Description = "客户代码")]
    [MaxLength(20)]
    public string SUPPLIERCODE { get; set; }
    [Display(Name = "客户名称", Description = "客户名称")]
    [MaxLength(80)]
    public string SUPPLIERNAME { get; set; }
    [Display(Name = "联系方式", Description = "联系方式")]
    [MaxLength(200)]
    public string CONTACTINFO { get; set; }
    [Display(Name = "提货地址", Description = "提货地址")]
    [DefaultValue("-")]
    [MaxLength(80)]
    public string LOTTABLE3 { get; set; }
    [Display(Name = "收货地址", Description = "收货地址")]
    [MaxLength(180)]
    public string CONSIGNEEADDRESS { get; set; }
    [Display(Name = "物料编码", Description = "物料编码")]
    [MaxLength(30)]
    //[MinLength(6)]
    //[Required]
    //[DefaultValue("-")]
    public string SKU { get; set; }
    [Display(Name = "物料类型", Description = "物料类型(洁具/瓷砖)")]
    [MaxLength(10)]
    [Required]
    [DefaultValue("瓷砖")]
    public string SKUTYPE { get; set; }

    [Display(Name = "物料名称", Description = "物料名称")]
    [MaxLength(80)]
    public string SKUNAME { get; set; }


    [Display(Name = "交货数量", Description = "交货数量")]
    [DefaultValue(0)]
    public decimal ORIGINALQTY { get; set; }
    [Display(Name = "已发运数量", Description = "已发运数量")]
    [DefaultValue(0)]
    public decimal SHIPPEDQTY { get; set; }

    [Display(Name = "单位", Description = "单位")]
    [MaxLength(10)]
    [Required]
    [DefaultValue("EA")]
    public string UMO { get; set; }
    [Display(Name = "包装", Description = "包装")]
    [MaxLength(10)]
    [DefaultValue("-")]
    public string PACKKEY { get; set; }
    [Display(Name = "交货件数", Description = "交货件数")]
    [DefaultValue(0)]
    public decimal CASECNT { get; set; }

    [Display(Name = "毛重(KG)", Description = "毛重(KG)")]
    [DefaultValue(0)]
    public decimal GROSSWGT { get; set; }
    [Display(Name = "净重(KG)", Description = "净重(KG)")]
    [DefaultValue(0)]
    public decimal NETWGT { get; set; }
    [Display(Name = "体积(M)", Description = "体积(M)")]
    [DefaultValue(0)]
    public decimal CUBE { get; set; }
    [Display(Name = "配送要求", Description = "配送要求")]
    [MaxLength(500)]
    public string REQUIREMENTS { get; set; }
    [Display(Name = "备注", Description = "备注")]
    [MaxLength(180)]
    public string NOTES { get; set; }
    [Display(Name = "销售雇员", Description = "销售雇员")]
    public string SALER { get; set; }
    [Display(Name = "销售组", Description = "销售组")]
    public string SALESORG { get; set; }
    [Display(Name = "是否计算运费", Description = "是否计算运费")]
    [DefaultValue(false)]
    public bool CHECKEDCOST1 { get; set; }
    [Display(Name = "运费", Description = "运费")]
    [DefaultValue(0)]
    public decimal COST1 { get; set; }
    [Display(Name = "是否送货上门", Description = "是否送货上门")]
    [DefaultValue(false)]
    public bool CHECKEDCOST2 { get; set; }
    [Display(Name = "送货费", Description = "送货费")]
    [DefaultValue(0)]
    public decimal COST2 { get; set; }
    [Display(Name = "是否上楼", Description = "是否上楼")]
    [DefaultValue(false)]
    public bool CHECKEDCOST3 { get; set; }
    [Display(Name = "搬货方式", Description = "搬货方式")]
    [MaxLength(50)]
    public string COST3NOTE { get; set; }
    [Display(Name = "楼层", Description = "楼层")]
    [DefaultValue(0)]
    public int FLOOR { get; set; }
    [Display(Name = "搬运费", Description = "搬运费")]
    [DefaultValue(0)]
    public decimal COST3 { get; set; }
    [Display(Name = "是否加急", Description = "是否加急")]
    [DefaultValue(false)]
    public bool CHECKEDCOST4 { get; set; }
    [Display(Name = "加急费", Description = "加急费(RMB)")]
    [DefaultValue(0)]
    public decimal COST4 { get; set; }
    [Display(Name = "是否专车", Description = "是否专车")]
    [DefaultValue(false)]
    public bool CHECKEDCOST5 { get; set; }
    [Display(Name = "专车费", Description = "专车费(RMB)")]
    [DefaultValue(0)]
    public decimal COST5 { get; set; }
    [Display(Name = "是否其它服务1", Description = "是否其它服务1")]
    [DefaultValue(false)]
    public bool CHECKEDCOST6 { get; set; }
    [Display(Name = "其它服务费", Description = "其它服务费")]
    [DefaultValue(0)]
    public decimal COST6 { get; set; }
    [Display(Name = "其它服务项目", Description = "其它服务项目")]
    public string COST6NOTES { get; set; }
    [Display(Name = "是否其它服务2", Description = "是否其它服务2")]
    [DefaultValue(false)]
    public bool CHECKEDCOST7 { get; set; }
    [Display(Name = "其它服务费2", Description = "其它服务费2(RMB)")]
    [DefaultValue(0)]
    public decimal COST7 { get; set; }
    [Display(Name = "是否其它服务3", Description = "是否其它服务3")]
    [DefaultValue(false)]
    public bool CHECKEDCOST8 { get; set; }
    [Display(Name = "合计运费", Description = "合计运费")]
    [DefaultValue(0)]
    public decimal COST8 { get; set; }
    
    [Display(Name = "订单号", Description = "订单号")]
    [MaxLength(128)]
    [Index("SHIPORDERDETAIL_IX", IsUnique = true, Order = 2)]
    [Required]
    [DefaultValue("00000001")]
    public string ORDERKEY { get; set; }

    [Display(Name = "批次号", Description = "批次号")]
    [DefaultValue("-")]
    [MaxLength(50)]
    public string LOTTABLE2 { get; set; }
    [Display(Name = "提货单号", Description = "提货单号")]
    [MaxLength(50)]
    public string EXTERNORDERKEY { get; set; }
    [Display(Name = "结算标志", Description = "结算标志")]
    [DefaultValue(false)]
    public bool FLAG1 { get; set; }
    [Display(Name = "其它标志", Description = "其它标志")]
    [DefaultValue(false)]
    public bool FLAG2 { get; set; }
    [Display(Name = "备注2", Description = "备注2")]
    [MaxLength(180)]
    public string NOTES1 { get; set; }
    [Display(Name = "要求配送日期", Description = "要求配送日期")]
    [DefaultValue("now")]
    public DateTime? REQUESTEDSHIPDATE { get; set; }
    [Display(Name = "要求到货时间", Description = "要求到货时间")]
    [DefaultValue("now")]
    public DateTime? DELIVERYDATE { get; set; }
    [Display(Name = "实际配送日期", Description = "实际配送日期")]
    [DefaultValue(null)]
    public DateTime? ACTUALSHIPDATE { get; set; }
    [Display(Name = "实际到货时间", Description = "实际到货时间")]
    [DefaultValue(null)]
    public DateTime? ACTUALDELIVERYDATE { get; set; }

    [Display(Name = "仓库号", Description = "仓库号")]
    [MaxLength(20)]
    [Required]
    [DefaultValue("WHSE01")]
    public string WHSEID { get; set; }

    [Display(Name = "货主", Description = "货主")]
    [MaxLength(50)]
    [Required]
    [DefaultValue("东鹏")]
    public string STORERKEY { get; set; }


    
    [Display(Name = "上传用户", Description = "上传用户")]
    [DefaultValue("-")]
    [MaxLength(50)]
    public string LOTTABLE1 { get; set; }

    [Display(Name = "外部行项号", Description = "外部行项号")]
    [MaxLength(50)]

    public string EXTERNLINENO { get; set; }
    [Display(Name = "订单类型", Description = "订单类型(普通/急货/专车)")]
    [MaxLength(10)]
    [DefaultValue("1")]
    public string TYPE { get; set; }
    [Display(Name = "启运地", Description = "启运地")]
    [MaxLength(50)]
    [DefaultValue("")]
    public string ORIGINAL { get; set; }
    [Display(Name = "送货区域", Description = "送货区域")]
    [MaxLength(50)]
    [DefaultValue("")]
    public string DESTINATION { get; set; }
    [Display(Name = "运输方式", Description = "运输方式(整车/零担)")]
    [MaxLength(1)]
    [DefaultValue("1")]
    [Required]
    public string SHPTYPE { get; set; }
    [Display(Name = "所属公司", Description = "所属公司")]
    [MaxLength(20)]
    [DefaultValue("000001")]
    public string COMPANYCODE { get; set; }
    [Display(Name = "LOTTABLE4", Description = "LOTTABLE4")]
    [MaxLength(50)]
    public string LOTTABLE4 { get; set; }
    [Display(Name = "LOTTABLE5", Description = "LOTTABLE5")]
    [MaxLength(50)]
    public string LOTTABLE5 { get; set; }
    [Display(Name = "LOTTABLE6", Description = "LOTTABLE6")]
    public decimal? LOTTABLE6 { get; set; }
    [Display(Name = "LOTTABLE7", Description = "LOTTABLE7")]
    public decimal? LOTTABLE7 { get; set; }
    [Display(Name = "LOTTABLE8", Description = "LOTTABLE7")]
    public DateTime? LOTTABLE8 { get; set; }
    [Display(Name = "LOTTABLE9", Description = "LOTTABLE9")]
    public DateTime? LOTTABLE9 { get; set; }
    [Display(Name = "LOTTABLE10", Description = "LOTTABLE10")]
    [MaxLength(50)]
    public string LOTTABLE10 { get; set; }
    [Display(Name = "项目计划号", Description = "项目计划号")]
    [MaxLength(50)]
    public string EXTERNORDERKEY1 { get; set; }
    [Display(Name = "工厂", Description = "工厂")]
    [MaxLength(50)]
    public string FACTORY { get; set; }
    [Display(Name = "门店", Description = "门店")]
    [MaxLength(50)]
    public string SHOP { get; set; }
    [Display(Name = "销售渠道", Description = "销售渠道")]
    [MaxLength(50)]
    public string CHANNEL { get; set; }
    [Display(Name = "交货凭证", Description = "交货凭证")]
    [MaxLength(50)]
    public string DELIVERYVOUCHER { get; set; }
    [Display(Name = "销售部门", Description = "销售部门")]
    [MaxLength(20)]
    public string SALESDEP { get; set; }
    [Display(Name = "接单日期", Description = "接单日期")]
    [DefaultValue("now")]
    public DateTime? ORDERDATE { get; set; }
    [Display(Name = "派车日期", Description = "派车日期")]
    [DefaultValue("now")]
    public DateTime SHIPORDERDATE { get; set; }
    [Display(Name = "承运人", Description = "承运人")]
    [MaxLength(80)]
    public string CARRIERNAME { get; set; }
    [Display(Name = "司机", Description = "司机")]
    [MaxLength(20)]
    public string DRIVERNAME { get; set; }
    [Display(Name = "司机电话", Description = "司机电话")]
    [MaxLength(20)]
    public string CARRIERPHONE { get; set; }
    [Display(Name = "运输车辆", Description = "运输车辆")]
    [MaxLength(80)]
    public string TRAILERNUMBER { get; set; }
    [Display(Name = "运单ID", Description = "运单ID")]
    public int SHIPORDERID { get; set; }
    [ForeignKey("SHIPORDERID")]
    [Display(Name = "运单信息", Description = "运单信息")]
    public virtual SHIPORDER SHIPORDER { get; set; }

    [Display(Name = "运价", Description = "运价")]
    public decimal? UNITCOST1 { get; set; }
    [Display(Name = "搬运价", Description = "搬运价")]
    public decimal? UNITCOST3 { get; set; }
  }
}