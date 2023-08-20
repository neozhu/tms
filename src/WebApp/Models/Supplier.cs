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
  public partial class SUPPLIER:Entity
  {
    [Key]
    public int ID { get; set; }
    [Display(Name = "客户代码", Description = "客户代码")]
    [MaxLength(20)]
    [Index(IsUnique =true)]
    [DefaultValue("-")]
    [Required]
    public string SUPPLIERCODE { get; set; }
    [Display(Name = "客户名称", Description = "客户名称")]
    [MaxLength(80)]
    [DefaultValue("-")]
    [Required]

    public string SUPPLIERNAME { get; set; }
    [Display(Name = "是否禁用", Description = "是否禁用")]
    [DefaultValue(false)]
    public bool ISDISABLED { get; set; }
    [Display(Name = "默认起始地", Description = "默认起始地")]
    [MaxLength(50)]
    [DefaultValue("-")]
    public string Loc1 { get; set; }
    [Display(Name = "默认提货地址", Description = "默认提货地址")]
    [MaxLength(80)]
    [DefaultValue("-")]

    public string ADDRESS1 { get; set; }
    [Display(Name = "默认目的地", Description = "默认目的地")]
    [MaxLength(50)]
    [DefaultValue("-")]
    public string Loc2 { get; set; }
    [Display(Name = "默认收货地址", Description = "默认收货地址")]
    [MaxLength(80)]
    [DefaultValue("-")]
    public string ADDRESS2 { get; set; }
    [Display(Name = "联系人", Description = "联系人")]
    [MaxLength(20)]

    public string CONTACT { get; set; }
    [Display(Name = "推送手机号码", Description = "推送手机号码")]
    [MaxLength(20)]

    public string PHONENUMBER { get; set; }
    [Display(Name = "邮件地址", Description = "邮件地址")]
    [MaxLength(20)]

    public string EMAIL { get; set; }
    [Display(Name = "备注", Description = "备注")]
    [MaxLength(80)]

    public string NOTES { get; set; }
  }
}