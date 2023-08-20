using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  public partial class ServiceRule:Entity
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "服务项目", Description = "服务项目")]
    [Required]
    [MaxLength(30)]
    [DefaultValue("-")]
    public string NAME { get; set; }
    [Display(Name = "货物总量起(吨)", Description = "货物总量起(吨)")]
    [DefaultValue(0.00)]
    public decimal GWT1 { get; set; }
    [Display(Name = "货物总量至(吨)", Description = "货物总量至(吨)")]
    [DefaultValue(1.00)]
    public decimal GWT2 { get; set; }
    [Display(Name = "电梯楼层", Description = "电梯楼层")]
    [DefaultValue(true)]
    public bool ELEVATOR { get; set; }

    [Display(Name = "重货(元/吨)", Description = "重货(元/吨)")]
    [DefaultValue(0.00)]
    public decimal PRICE { get; set; }
    [Display(Name = "最小收费", Description = "最小收费")]
    [DefaultValue(0.00)]
    public decimal MINAMOUNT { get; set; }
    [Display(Name = "状态", Description = "状态")]
    [DefaultValue(1)]
    public int STATUS { get; set; }
    [Display(Name = "说明", Description = "说明")]
    [MaxLength(180)]
    public string DESCRIPTION { get; set; }

    [Display(Name = "LOTTABLE1", Description = "LOTTABLE1")]
    [MaxLength(50)]
    public string LOTTABLE1 { get; set; }
    [Display(Name = "LOTTABLE2", Description = "LOTTABLE2")]
    [MaxLength(50)]
    public string LOTTABLE2 { get; set; }

    [Display(Name = "轻货(元/立方)", Description = "轻货(元/立方)")]

    public decimal LOTTABLE3 { get; set; }

  }
}