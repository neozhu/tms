using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="ServiceRuleMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2019/8/7 18:37:55 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(ServiceRuleMetadata))]
    public partial class ServiceRule
    {
    }

    public partial class ServiceRuleMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.ServiceRule))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 服务项目")]
        [Display(Name = "NAME",Description ="服务项目",Prompt = "服务项目",ResourceType = typeof(resource.ServiceRule))]
        [MaxLength(30)]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Please enter : 货物总量起")]
        [Display(Name = "GWT1",Description ="货物总量起",Prompt = "货物总量起",ResourceType = typeof(resource.ServiceRule))]
        public decimal GWT1 { get; set; }

        [Required(ErrorMessage = "Please enter : 货物总量至")]
        [Display(Name = "GWT2",Description ="货物总量至",Prompt = "货物总量至",ResourceType = typeof(resource.ServiceRule))]
        public decimal GWT2 { get; set; }

        [Required(ErrorMessage = "Please enter : 电梯楼层")]
        [Display(Name = "ELEVATOR",Description ="电梯楼层",Prompt = "电梯楼层",ResourceType = typeof(resource.ServiceRule))]
        public bool ELEVATOR { get; set; }

        [Required(ErrorMessage = "Please enter : 单价")]
        [Display(Name = "PRICE",Description ="单价",Prompt = "单价",ResourceType = typeof(resource.ServiceRule))]
        public decimal PRICE { get; set; }

        [Required(ErrorMessage = "Please enter : 最小收费")]
        [Display(Name = "MINAMOUNT",Description ="最小收费",Prompt = "最小收费",ResourceType = typeof(resource.ServiceRule))]
        public decimal MINAMOUNT { get; set; }

        [Required(ErrorMessage = "Please enter : 状态")]
        [Display(Name = "STATUS",Description ="状态",Prompt = "状态",ResourceType = typeof(resource.ServiceRule))]
        public int STATUS { get; set; }

        [Display(Name = "DESCRIPTION",Description ="说明",Prompt = "说明",ResourceType = typeof(resource.ServiceRule))]
        [MaxLength(180)]
        public string DESCRIPTION { get; set; }

        [Display(Name = "LOTTABLE1",Description ="LOTTABLE1",Prompt = "LOTTABLE1",ResourceType = typeof(resource.ServiceRule))]
        [MaxLength(50)]
        public string LOTTABLE1 { get; set; }

        [Display(Name = "LOTTABLE2",Description ="LOTTABLE2",Prompt = "LOTTABLE2",ResourceType = typeof(resource.ServiceRule))]
        [MaxLength(50)]
        public string LOTTABLE2 { get; set; }

        [Required(ErrorMessage = "Please enter : LOTTABLE3")]
        [Display(Name = "LOTTABLE3",Description ="LOTTABLE3",Prompt = "LOTTABLE3",ResourceType = typeof(resource.ServiceRule))]
        public decimal LOTTABLE3 { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.ServiceRule))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.ServiceRule))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.ServiceRule))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.ServiceRule))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
