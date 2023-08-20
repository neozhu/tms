using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;

namespace WebApp.Models
{
  public partial class Document:Entity
  {
    [Key]
    public int Id { get; set; }
    [Display(Name = "业务单号", Description = "业务单号")]
    [MaxLength(50)]
    [Required]
    public string OrderKey { get; set; }
    [Display(Name = "文件名", Description = "文件名")]
    [MaxLength(300)]
    [Required]
    public string FileName { get; set; }
    [Display(Name = "文件类型", Description = "文件类型")]
    [MaxLength(5)]
    [MinLength(3)]
    public string FileType { get; set; }
    [Display(Name = "内容类型", Description = "内容类型")]
    [MaxLength(150)]
    public string ContentType { get; set; }
    [Display(Name = "保存路径", Description = "保存路径")]
    public string Path { get; set; }
    [Display(Name = "URL", Description = "URL")]
    public string Url { get; set; }
    [Display(Name = "文件MD5", Description = "文件MD5")]
    [MaxLength(300)]
    public string MD5 { get; set; }
    [Display(Name = "文件大小", Description = "文件大小")]
    public decimal Size { get; set; }
    [Display(Name = "图片宽度", Description = "图片宽度")]
    public decimal? Width { get; set; }
    [Display(Name = "图片高度", Description = "图片高度")]
    public decimal? Height { get; set; }
    [Display(Name = "描述", Description = "描述")]
    [MaxLength(300)]
    public string Description { get; set; }
    [Display(Name = "上传用户", Description = "上传用户")]
    [MaxLength(20)]
    [DefaultValue("user")]
    public string User { get; set; }
    [Display(Name = "上传时间", Description = "上传时间")]
    [DefaultValue("now")]
    public DateTime UploadDateTime { get; set; }
  }
}