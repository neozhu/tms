using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  public partial class FreightRule:Entity
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
    [Display(Name = "运输方式", Description = "运输方式(零担/专车直送)")]
    [MaxLength(1)]
    [DefaultValue("1")]
    [Required]
    public string SHPTYPE { get; set; }
    [Display(Name = "计费方式", Description = "计费方式(吨/立方)")]
    [MaxLength(1)]
    [DefaultValue("1")]
    [Required]
    public string CALTYPE { get; set; }
    [Display(Name = "车辆吨位起", Description = "车辆吨位起")]
    [DefaultValue("0")]
    public decimal CARLWT1 { get; set; }
    [Display(Name = "车辆吨位至", Description = "车辆吨位至")]
    [DefaultValue("1")]
    public decimal CARLWT2 { get; set; }

    

    [Display(Name = "单价", Description = "单价")]
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
    
    [Display(Name = "LOTTABLE3", Description = "LOTTABLE3")]
   
    public decimal LOTTABLE3 { get; set; }


  }
}