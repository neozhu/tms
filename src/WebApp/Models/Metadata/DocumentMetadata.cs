using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="DocumentMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>9/26/2019 8:15:05 AM </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(DocumentMetadata))]
    public partial class Document
    {
    }

    public partial class DocumentMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.Document))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 业务单号")]
        [Display(Name = "OrderKey",Description ="业务单号",Prompt = "业务单号",ResourceType = typeof(resource.Document))]
        [MaxLength(50)]
        public string OrderKey { get; set; }

        [Required(ErrorMessage = "Please enter : 文件名")]
        [Display(Name = "FileName",Description ="文件名",Prompt = "文件名",ResourceType = typeof(resource.Document))]
        [MaxLength(50)]
        public string FileName { get; set; }

        [Display(Name = "FileType",Description ="文件类型",Prompt = "文件类型",ResourceType = typeof(resource.Document))]
        [MaxLength(5)]
        public string FileType { get; set; }

        [Display(Name = "Path",Description ="保存路径",Prompt = "保存路径",ResourceType = typeof(resource.Document))]
        [MaxLength(300)]
        public string Path { get; set; }

        [Display(Name = "Url",Description ="URL",Prompt = "URL",ResourceType = typeof(resource.Document))]
        [MaxLength(300)]
        public string Url { get; set; }

        [Display(Name = "MD5",Description ="文件MD5",Prompt = "文件MD5",ResourceType = typeof(resource.Document))]
        [MaxLength(300)]
        public string MD5 { get; set; }

        [Required(ErrorMessage = "Please enter : 文件大小")]
        [Display(Name = "Size",Description ="文件大小",Prompt = "文件大小",ResourceType = typeof(resource.Document))]
        public decimal Size { get; set; }

        [Display(Name = "Width",Description ="图片宽度",Prompt = "图片宽度",ResourceType = typeof(resource.Document))]
        public decimal Width { get; set; }

        [Display(Name = "Height",Description ="图片高度",Prompt = "图片高度",ResourceType = typeof(resource.Document))]
        public decimal Height { get; set; }

        [Display(Name = "Description",Description ="描述",Prompt = "描述",ResourceType = typeof(resource.Document))]
        [MaxLength(300)]
        public string Description { get; set; }

        [Display(Name = "User",Description ="上传用户",Prompt = "上传用户",ResourceType = typeof(resource.Document))]
        [MaxLength(20)]
        public string User { get; set; }

        [Required(ErrorMessage = "Please enter : 上传时间")]
        [Display(Name = "UploadDateTime",Description ="上传时间",Prompt = "上传时间",ResourceType = typeof(resource.Document))]
        public DateTime UploadDateTime { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.Document))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.Document))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.Document))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.Document))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

        [Required(ErrorMessage = "Please enter : Tenant Id")]
        [Display(Name = "TenantId",Description ="Tenant Id",Prompt = "Tenant Id",ResourceType = typeof(resource.Document))]
        public int TenantId { get; set; }

    }

}
