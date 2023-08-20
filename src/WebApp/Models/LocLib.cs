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
  public partial class LocBase:Entity
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "名称", Description = "名称")]
    [MaxLength(50)]
    [MinLength(2)]
    [Index(IsUnique = true)]
    [Required]
    [DefaultValue("-")]
    public string Name { get; set; }
    [Display(Name = "描述", Description = "描述")]
    [MaxLength(180)]
    [MinLength(3)]
    public string Description { get; set; }
    [Display(Name = "经度", Description = "经度")]
    [DefaultValue(0.000)]
    [Column(TypeName = "decimal")]
    public decimal Longitude { get; set; }
    [Display(Name = "纬度", Description = "纬度")]
    [DefaultValue(0.000)]
    [Column(TypeName = "decimal")]
    public decimal Latitude { get; set; }

    [Display(Name = "经度", Description = "经度")]
    [DefaultValue(0.000)]
    [Column(TypeName = "decimal")]
    public decimal Longitude1 { get; set; }
    [Display(Name = "纬度", Description = "纬度")]
    [DefaultValue(0.000)]
    [Column(TypeName = "decimal")]
    public decimal Latitude1 { get; set; }
    [Display(Name = "预警半径", Description = "预警半径")]
    [DefaultValue(0.000)]
    public decimal Radius { get; set; }
    [Display(Name = "围栏ID", Description = "围栏ID")]
    [MaxLength(80)]
    public string Gid { get; set; }
    [Display(Name = "是否启用", Description = "是否启用")]
    [DefaultValue(false)]
    public bool Enable { get; set; }
  }
}