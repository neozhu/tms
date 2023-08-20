using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="StatusHistoryMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>8/13/2019 3:05:31 PM </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(StatusHistoryMetadata))]
    public partial class StatusHistory
    {
    }

    public partial class StatusHistoryMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.StatusHistory))]
        public int Id { get; set; }

        [Display(Name = "ORDERKEY",Description ="订单号",Prompt = "订单号",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(20)]
        public string ORDERKEY { get; set; }

        [Display(Name = "SHIPORDERKEY",Description ="运单号",Prompt = "运单号",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(20)]
        public string SHIPORDERKEY { get; set; }

        [Display(Name = "STATUS",Description ="状态",Prompt = "状态",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(3)]
        public string STATUS { get; set; }

        [Display(Name = "DESCRIPTION",Description ="描述",Prompt = "描述",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(100)]
        public string DESCRIPTION { get; set; }

        [Display(Name = "REMARK",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(100)]
        public string REMARK { get; set; }

        [Required(ErrorMessage = "Please enter : 时间")]
        [Display(Name = "TRANSACTIONDATETIME",Description ="时间",Prompt = "时间",ResourceType = typeof(resource.StatusHistory))]
        public DateTime TRANSACTIONDATETIME { get; set; }

        [Display(Name = "USER",Description ="操作人",Prompt = "操作人",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(50)]
        public string USER { get; set; }

        [Required(ErrorMessage = "Please enter : 经度")]
        [Display(Name = "LONGITUDE",Description ="经度",Prompt = "经度",ResourceType = typeof(resource.StatusHistory))]
        public decimal LONGITUDE { get; set; }

        [Required(ErrorMessage = "Please enter : 纬度")]
        [Display(Name = "LATITUDE",Description ="纬度",Prompt = "纬度",ResourceType = typeof(resource.StatusHistory))]
        public decimal LATITUDE { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.StatusHistory))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.StatusHistory))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.StatusHistory))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
