using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  public partial class StatusHistory:Entity
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "订单号", Description = "订单号")]
    [MaxLength(50)]
    [DefaultValue("")]
    public string ORDERKEY { get; set; }
    [Display(Name = "运单号", Description = "运单号")]
    [MaxLength(50)]
    [DefaultValue("")]
    public string SHIPORDERKEY { get; set; }
    [Display(Name = "状态", Description = "状态")]
    [MaxLength(3)]
    [DefaultValue("100")]
    public string STATUS { get; set; }

    [Display(Name = "描述", Description = "描述")]
    [MaxLength(100)]
    [DefaultValue("")]
    public string DESCRIPTION { get; set; }
    [Display(Name = "备注", Description = "备注")]
    [MaxLength(100)]
    [DefaultValue("")]
    public string REMARK { get; set; }
    [Display(Name = "时间", Description = "时间")]
    [DefaultValue("now")]
    public DateTime TRANSACTIONDATETIME { get; set; }
    [Display(Name = "操作人", Description = "操作人")]
    [DefaultValue("user")]
    public string USER { get; set; }
    [Display(Name = "经度", Description = "经度")]
    [DefaultValue(0.000)]

    public decimal LONGITUDE { get; set; }
    [Display(Name = "纬度", Description = "纬度")]
    [DefaultValue(0.000)]

    public decimal LATITUDE { get; set; }
  }
}