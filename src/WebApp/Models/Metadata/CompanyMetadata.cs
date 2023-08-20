using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="CompanyMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2019/7/31 18:34:12 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(CompanyMetadata))]
    public partial class Company
    {
    }

    public partial class CompanyMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.Company))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 名称")]
        [Display(Name = "Name",Description ="名称",Prompt = "名称",ResourceType = typeof(resource.Company))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter : 组织代码")]
        [Display(Name = "Code",Description ="组织代码",Prompt = "组织代码",ResourceType = typeof(resource.Company))]
        [MaxLength(12)]
        public string Code { get; set; }

        [Display(Name = "Address",Description ="地址",Prompt = "地址",ResourceType = typeof(resource.Company))]
        [MaxLength(50)]
        public string Address { get; set; }

        [Display(Name = "Contect",Description ="联系人",Prompt = "联系人",ResourceType = typeof(resource.Company))]
        [MaxLength(12)]
        public string Contect { get; set; }

        [Display(Name = "PhoneNumber",Description ="联系电话",Prompt = "联系电话",ResourceType = typeof(resource.Company))]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter : 注册日期")]
        [Display(Name = "RegisterDate",Description ="注册日期",Prompt = "注册日期",ResourceType = typeof(resource.Company))]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.Company))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.Company))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.Company))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.Company))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
