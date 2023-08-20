using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="SalesmanMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>9/12/2019 1:26:21 PM </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(SalesmanMetadata))]
    public partial class Salesman
    {
    }

    public partial class SalesmanMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.Salesman))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 销售姓名")]
        [Display(Name = "Name",Description ="销售姓名",Prompt = "销售姓名",ResourceType = typeof(resource.Salesman))]
        [MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "CompanyName",Description ="公司名称",Prompt = "公司名称",ResourceType = typeof(resource.Salesman))]
        [MaxLength(80)]
        public string CompanyName { get; set; }

        [Display(Name = "Title",Description ="职称",Prompt = "职称",ResourceType = typeof(resource.Salesman))]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter : 是否推送消息")]
        [Display(Name = "IsPushNotification",Description ="是否推送消息",Prompt = "是否推送消息",ResourceType = typeof(resource.Salesman))]
        public bool IsPushNotification { get; set; }

        [Required(ErrorMessage = "Please enter : 推送手机号码")]
        [Display(Name = "PhoneNumber",Description ="推送手机号码",Prompt = "推送手机号码",ResourceType = typeof(resource.Salesman))]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email",Description ="邮件地址",Prompt = "邮件地址",ResourceType = typeof(resource.Salesman))]
        [MaxLength(50)]
        public string Email { get; set; }

        [Display(Name = "Notes",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.Salesman))]
        [MaxLength(80)]
        public string Notes { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.Salesman))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.Salesman))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.Salesman))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.Salesman))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

        [Required(ErrorMessage = "Please enter : Tenant Id")]
        [Display(Name = "TenantId",Description ="Tenant Id",Prompt = "Tenant Id",ResourceType = typeof(resource.Salesman))]
        public int TenantId { get; set; }

    }

}
