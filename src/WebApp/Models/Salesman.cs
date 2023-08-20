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

  public partial class Salesman:Entity
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "销售姓名", Description = "销售姓名")]
    [MaxLength(20)]
    [Index("Salesman_IX", IsUnique =true)]
    [Required]
    public string Name { get; set; }
    [Display(Name = "销售组", Description = "销售组")]
    [MaxLength(20)]
    public string Org { get; set; }
    [Display(Name = "销售部门", Description = "销售部门")]
    [MaxLength(20)]
    public string Dep { get; set; }
    [Display(Name = "公司名称", Description = "公司名称")]
    [MaxLength(80)]
    public string CompanyName { get; set; }
    [Display(Name = "职称", Description = "职称")]
    [MaxLength(20)]
    public string Title { get; set; }
    [Display(Name = "是否推送消息", Description = "是否推送消息")]
    [DefaultValue(true)]
    public bool IsPushNotification { get; set; }
    [Display(Name = "推送手机号码", Description = "推送手机号码")]
    [MaxLength(20)]
    [Required]
    public string PhoneNumber { get; set; }
    [Display(Name = "邮件地址", Description = "邮件地址")]
    [MaxLength(50)]

    public string Email { get; set; }
   

    [Display(Name = "备注", Description = "备注")]
    [MaxLength(80)]

    public string Notes { get; set; }
  }
}