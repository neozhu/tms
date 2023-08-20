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
  public partial class ORDER:Entity
  {
    public ORDER()
    {
      this.ORDERDETAILS = new HashSet<ORDERDETAIL>();
    }
    [Key]
    public int ID { get; set; }
    [Display(Name = "订单号", Description = "订单号")]
    [MaxLength(128)]
    [Index(IsUnique = true)]
    [Required]
    [DefaultValue("00000001")]
    public string ORDERKEY { get; set; }
    [Display(Name = "提货单号", Description = "提货单号")]
    [MaxLength(50)]
    [DefaultValue("-")]
    public string EXTERNORDERKEY { get; set; }
    [Display(Name = "仓库号", Description = "仓库号")]
    [MaxLength(20)]
    [Required]
    [DefaultValue("WHSE01")]
    public string WHSEID { get; set; }
    [Display(Name = "批次号", Description = "批次号")]
    [MaxLength(80)]
    [DefaultValue("-")]
    public string LOTTABLE2 { get; set; }

    [Display(Name = "启运地", Description = "启运地")]
    [MaxLength(50)]
    //[Required]
    [DefaultValue("")]
    public string ORIGINAL { get; set; }
    [Display(Name = "送货区域", Description = "送货区域")]
    [MaxLength(50)]
    //[Required]
    [DefaultValue("")]
    public string DESTINATION { get; set; }
    [Display(Name = "订单类型", Description = "订单类型(普通/急货/专车)")]
    [MaxLength(10)]
    [DefaultValue("1")]
    public string TYPE { get; set; }

    [Display(Name = "运输方式", Description = "运输方式(整车/零担)")]
    [MaxLength(1)]
    [DefaultValue("1")]
    [Required]
    public string SHPTYPE { get; set; }


    [Display(Name = "状态", Description = "状态")]
    [MaxLength(3)]
    [Required]
    [DefaultValue("100")]
    public string STATUS { get; set; }
    [Display(Name = "货主", Description = "货主")]
    [MaxLength(50)]
    [Required]
    [DefaultValue("东鹏")]
    public string STORERKEY { get; set; }
    [Display(Name = "客户代码", Description = "客户代码")]
    [MaxLength(20)]
    [DefaultValue("-")]
    public string SUPPLIERCODE { get; set; }
    [Display(Name = "客户名称", Description = "客户名称")]
    [MaxLength(80)]
    [DefaultValue("-")]
    public string SUPPLIERNAME { get; set; }
    [Display(Name = "联系方式", Description = "联系方式")]
    [MaxLength(200)]
    public string CONTACTINFO { get; set; }

    [Display(Name = "接单日期", Description = "接单日期")]
    [DefaultValue("now")]
    public DateTime ORDERDATE { get; set; }
    [Display(Name = "要求配送日期", Description = "要求配送日期")]
    [DefaultValue("now")]
    public DateTime? REQUESTEDSHIPDATE { get; set; }
    [Display(Name = "要求送达时间", Description = "要求送达时间")]
    [DefaultValue("now")]
    public DateTime? DELIVERYDATE { get; set; }
    
    

    [Display(Name = "提货地址", Description = "提货地址")]
    [MaxLength(80)]
    [DefaultValue("-")]
    public string LOTTABLE3 { get; set; }
    [Display(Name = "收货单位", Description = "收货单位")]
    [MaxLength(30)]
    public string CONSIGNEEKEY { get; set; }
    [Display(Name = "收货单位名称", Description = "收货单位名称")]
    [MaxLength(80)]
    public string CONSIGNEENAME { get; set; }
    [Display(Name = "收货地址", Description = "收货地址")]
    [MaxLength(180)]
    [DefaultValue("-")]
    public string CONSIGNEEADDRESS { get; set; }
    [Display(Name = "配送要求", Description = "配送要求")]
    [MaxLength(500)]
    public string REQUIREMENTS { get; set; }
    [Display(Name = "销售雇员", Description = "销售雇员")]
    [MaxLength(20)]
    public string SALER { get; set; }
    [Display(Name = "销售组", Description = "销售组")]
    [MaxLength(20)]
    public string SALESORG { get; set; }
    [Display(Name = "销售部门", Description = "销售部门")]
    [MaxLength(20)]
    public string SALESDEP { get; set; }

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
    [Display(Name = "实际配送日期", Description = "实际配送日期")]
    [DefaultValue(null)]
    public DateTime? ACTUALSHIPDATE { get; set; }
    [Display(Name = "实际到货时间", Description = "实际到货时间")]
    [DefaultValue(null)]
    public DateTime? ACTUALDELIVERYDATE { get; set; }

    [Display(Name = "结案日期", Description = "结案日期")]
    [DefaultValue(null)]
    public DateTime? CLOSEDDATE { get; set; }
    [Display(Name = "合计交货数量", Description = "合计交货数量")]
    [DefaultValue(0.00)]
    public decimal TOTALQTY { get; set; }

    [Display(Name = "合计发运数量", Description = "合计发运数量")]
    [DefaultValue(0.00)]
    public decimal TOTALSHIPPEDQTY { get; set; }



    [Display(Name = "合计件数", Description = "合计件数")]
    [DefaultValue(0.00)]
    public decimal TOTALCASECNT { get; set; }
    [Display(Name = "合计毛重(KG)", Description = "合计毛重(KG)")]
    [DefaultValue(0.00)]
    public decimal TOTALGROSSWGT { get; set; }
    [Display(Name = "合计体积(M)", Description = "合计体积(M)")]
    [DefaultValue(0.00)]
    public decimal TOTALCUBE { get; set; }
    [Display(Name = "是否计算运费", Description = "是否计算运费")]
    [DefaultValue(false)]
    public bool CHECKEDCOST1 { get; set; }
    [Display(Name = "合计运费", Description = "合计运费")]
    [DefaultValue(0.00)]
    public decimal TOTALCOST1 { get; set; }
    [Display(Name = "是否送货上门", Description = "是否送货上门")]
    [DefaultValue(false)]
    public bool CHECKEDCOST2 { get; set; }

    [Display(Name = "送货费", Description = "送货费(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST2 { get; set; }
    [Display(Name = "是否搬货", Description = "是否搬货")]
    [DefaultValue(false)]
    public bool CHECKEDCOST3 { get; set; }
    [Display(Name = "搬货方式", Description = "搬货方式")]
    [MaxLength(50)]
    public string COST3NOTE { get; set; }
    [Display(Name = "楼层", Description = "楼层")]
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
    [Display(Name = "其它服务费3", Description = "其它服务费3(RMB)")]
    [DefaultValue(0)]
    public decimal TOTALCOST8 { get; set; }
    [Display(Name = "备注", Description = "备注")]
    [MaxLength(180)]
    public string NOTES { get; set; }
    [Display(Name = "结算标志", Description = "结算标志")]
    [DefaultValue(false)]
    public bool FLAG1 { get; set; }
    [Display(Name = "备注2", Description = "备注2")]
    [MaxLength(180)]
    public string NOTES1 { get; set; }
    [Display(Name = "其它标志", Description = "其它标志")]
    [DefaultValue(false)]
    public bool FLAG2 { get; set; }
    [Display(Name = "所属公司", Description = "所属公司")]
    [MaxLength(20)]
    [DefaultValue("000001")]
    public string COMPANYCODE { get; set; }
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

    [Display(Name = "上传用户", Description = "上传用户")]
    [MaxLength(50)]
    [DefaultValue("user")]
    public string LOTTABLE1 { get; set; }
    

    
    [Display(Name = "派车单号", Description = "派车单号")]
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

    public virtual ICollection<ORDERDETAIL> ORDERDETAILS { get; set; }
 

    

  }
}