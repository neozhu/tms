using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  public partial class StandardCost:Entity
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "起始地", Description = "起始地")]
    [MaxLength(50)]
    [Required]
    [DefaultValue("")]
    public string ORIGINAL { get; set; }
    [Display(Name = "目的地", Description = "目的地")]
    [MaxLength(50)]
    [Required]
    [DefaultValue("")]
    public string DESTINATION { get; set; }

    [Display(Name = "标准里程", Description = "标准里程(千米)")]
    [DefaultValue(0)]
    public decimal STDKM { get; set; }
    [Display(Name = "标准过路费", Description = "标准过路费")]
    [DefaultValue(0)]
    public decimal STDTOLL { get; set; }
    [MaxLength(20)]
    [Display(Name = "车辆类型", Description = "车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)")]
    [DefaultValue("厢式车")]
    public string CarType { get; set; }
    [Display(Name = "额定载重", Description = "额定载重(吨)")]
    [DefaultValue(0)]
    public decimal STDLOADWEIGHT { get; set; }
    [Display(Name = "标准油耗", Description = "标准油耗(升)")]
    [DefaultValue(0.00)]
    public decimal STDOIL { get; set; }

    [Display(Name = "标准运费", Description = "标准运费")]
    [DefaultValue(0.00)]
    public decimal STDCOST { get; set; }
    [Display(Name = "说明", Description = "说明")]
    [MaxLength(180)]
    public string DESCRIPTION { get; set; }

    [Display(Name = "备注", Description = "备注")]
    [MaxLength(80)]
    public string Notes { get; set; }

    [Display(Name = "LOTTABLE1", Description = "LOTTABLE1")]
    [MaxLength(50)]
    public string LOTTABLE1 { get; set; }
    [Display(Name = "LOTTABLE2", Description = "LOTTABLE2")]
    [MaxLength(50)]
    public string LOTTABLE2 { get; set; }

    [Display(Name = "LOTTABLE3", Description = "LOTTABLE3")]

    public decimal LOTTABLE3 { get; set; }
  }
}