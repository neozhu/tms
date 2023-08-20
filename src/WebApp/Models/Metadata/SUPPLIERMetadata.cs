using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="SUPPLIERMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2019/8/1 7:44:05 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(SUPPLIERMetadata))]
    public partial class SUPPLIER
    {
    }

    public partial class SUPPLIERMetadata
    {
        [Required(ErrorMessage = "Please enter : ID")]
        [Display(Name = "ID",Description ="ID",Prompt = "ID",ResourceType = typeof(resource.SUPPLIER))]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter : 供应商代码")]
        [Display(Name = "SUPPLIERCODE",Description ="供应商代码",Prompt = "供应商代码",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(20)]
        public string SUPPLIERCODE { get; set; }

        [Required(ErrorMessage = "Please enter : 供应商名称")]
        [Display(Name = "SUPPLIERNAME",Description ="供应商名称",Prompt = "供应商名称",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(80)]
        public string SUPPLIERNAME { get; set; }

        [Required(ErrorMessage = "Please enter : 是否禁用")]
        [Display(Name = "ISDISABLED",Description ="是否禁用",Prompt = "是否禁用",ResourceType = typeof(resource.SUPPLIER))]
        public bool ISDISABLED { get; set; }

        [Display(Name = "ADDRESS1",Description ="默认提货地址",Prompt = "默认提货地址",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(80)]
        public string ADDRESS1 { get; set; }

        [Display(Name = "ADDRESS2",Description ="默认收货地址",Prompt = "默认收货地址",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(80)]
        public string ADDRESS2 { get; set; }

        [Display(Name = "CONTACT",Description ="联系人",Prompt = "联系人",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(20)]
        public string CONTACT { get; set; }

        [Display(Name = "PHONENUMBER",Description ="推送手机号码",Prompt = "推送手机号码",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(20)]
        public string PHONENUMBER { get; set; }

        [Display(Name = "EMAIL",Description ="邮件地址",Prompt = "邮件地址",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(20)]
        public string EMAIL { get; set; }

        [Display(Name = "NOTES",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(80)]
        public string NOTES { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.SUPPLIER))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.SUPPLIER))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.SUPPLIER))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
