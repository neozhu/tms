using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  //导入的发运单用于计算运价
  public  partial class Waybill:Entity
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "订单号", Description = "订单号")]
    [MaxLength(128)]
    [Required]
    public string OrderNo { get; set; }
    [Display(Name = "状态", Description = "状态")]
    [MaxLength(10)]
    [DefaultValue("待确认")]
    public string Status { get; set; }
    [Display(Name = "客户编码", Description = "客户编码")]
    [MaxLength(128)]
    [Required]
    public string CustomerId { get; set; }
    [Display(Name = "客户简称", Description = "客户简称")]
    [MaxLength(128)]
    public string CustomerName { get; set; }
    [Display(Name = "计划项目号", Description = "计划项目号")]
    [MaxLength(128)]
    public string ProjectNo { get; set; }
    [Display(Name = "提货单号", Description = "提货单号")]
    [MaxLength(128)]
    public string PickNo { get; set; }
    [Display(Name = "配送日期", Description = "配送日期")]
    [DefaultValue("now")]
    public DateTime ShippedDate { get; set; }
    [Display(Name = "起运地", Description = "起运地")]
    [MaxLength(128)]
    public string Original { get; set; }
    [Display(Name = "送货区域", Description = "送货区域")]
    [MaxLength(128)]
    public string Destination { get; set; }
    [Display(Name = "定单抬头文本信息", Description = "定单抬头文本信息")]
    public string Remark { get; set; }
    [Display(Name = "物料编码", Description = "物料编码")]
    [MaxLength(128)]
    public string ProductNo { get; set; }
    [Display(Name = "批次", Description = "批次")]
    [MaxLength(128)]
    public string LotNo { get; set; }
    
    [Display(Name = "交货数量", Description = "交货数量")]
    public decimal Qty { get; set; }
    [Display(Name = "重货(kg)", Description = "重货(kg)")]
    public decimal? Weight { get; set; }
    [Display(Name = "体积（m3)", Description = "体积（m3)")]
    public decimal? Cube { get; set; }
    [Display(Name = "运价", Description = "运价")]
    public decimal? SPrice { get; set; }
    [Display(Name = "合并运费（元）", Description = "合并运费（元）")]
    public decimal? SAmount { get; set; }

    [Display(Name = "搬运单价", Description = "搬运单价")]
    public decimal? CPrice { get; set; }
    [Display(Name = "合并搬运费（元）", Description = "合并搬运费（元）")]
    public decimal? CAmount { get; set; }
    [Display(Name = "备注", Description = "备注")]
    [MaxLength(128)]
    public string Way { get; set; }

    [Display(Name = "销售雇员", Description = "销售雇员")]
    [MaxLength(128)]
    public string Sales { get; set; }
    [Display(Name = "销售小组", Description = "销售小组")]
    [MaxLength(128)]
    public string SalesGroup { get; set; }

    [Display(Name = "备注1", Description = "备注1")]
    [MaxLength(256)]
    public string Remark1 { get; set; }
    [Display(Name = "联系人", Description = "联系人")]
    [MaxLength(256)]
    public string Remark2 { get; set; }
    [Display(Name = "特殊标志", Description = "特殊标志")]
    public bool Flag { get; set; }
    [Display(Name = "司机", Description = "司机")]
    [MaxLength(32)]
    public string Driver { get; set; }
    [Display(Name = "车牌", Description = "车牌")]
    [MaxLength(32)]
    public string Transport { get; set; }
  }
}