using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="FreightRuleMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2019/8/7 18:40:09 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(FreightRuleMetadata))]
    public partial class FreightRule
    {
    }

    public partial class FreightRuleMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.FreightRule))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 起始地")]
        [Display(Name = "ORIGINAL",Description ="起始地",Prompt = "起始地",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(50)]
        public string ORIGINAL { get; set; }

        [Required(ErrorMessage = "Please enter : 目的地")]
        [Display(Name = "DESTINATION",Description ="目的地",Prompt = "目的地",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(50)]
        public string DESTINATION { get; set; }

        [Required(ErrorMessage = "Please enter : 运输方式(整车/零担)")]
        [Display(Name = "SHPTYPE",Description ="运输方式(整车/零担)",Prompt = "运输方式(整车/零担)",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(1)]
        public string SHPTYPE { get; set; }

        [Required(ErrorMessage = "Please enter : 计费方式(吨/立方/立方吨)")]
        [Display(Name = "CALTYPE",Description ="计费方式(吨/立方/立方吨)",Prompt = "计费方式(吨/立方/立方吨)",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(1)]
        public string CALTYPE { get; set; }

        [Required(ErrorMessage = "Please enter : 车辆吨位起")]
        [Display(Name = "CARLWT1",Description ="车辆吨位起",Prompt = "车辆吨位起",ResourceType = typeof(resource.FreightRule))]
        public decimal CARLWT1 { get; set; }

        [Required(ErrorMessage = "Please enter : 车辆吨位至")]
        [Display(Name = "CARLWT2",Description ="车辆吨位至",Prompt = "车辆吨位至",ResourceType = typeof(resource.FreightRule))]
        public decimal CARLWT2 { get; set; }

        [Required(ErrorMessage = "Please enter : 单价")]
        [Display(Name = "PRICE",Description ="单价",Prompt = "单价",ResourceType = typeof(resource.FreightRule))]
        public decimal PRICE { get; set; }

        [Required(ErrorMessage = "Please enter : 最小收费")]
        [Display(Name = "MINAMOUNT",Description ="最小收费",Prompt = "最小收费",ResourceType = typeof(resource.FreightRule))]
        public decimal MINAMOUNT { get; set; }

        [Required(ErrorMessage = "Please enter : 状态")]
        [Display(Name = "STATUS",Description ="状态",Prompt = "状态",ResourceType = typeof(resource.FreightRule))]
        public int STATUS { get; set; }

        [Display(Name = "DESCRIPTION",Description ="说明",Prompt = "说明",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(180)]
        public string DESCRIPTION { get; set; }

        [Display(Name = "LOTTABLE1",Description ="LOTTABLE1",Prompt = "LOTTABLE1",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(50)]
        public string LOTTABLE1 { get; set; }

        [Display(Name = "LOTTABLE2",Description ="LOTTABLE2",Prompt = "LOTTABLE2",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(50)]
        public string LOTTABLE2 { get; set; }

        [Required(ErrorMessage = "Please enter : LOTTABLE3")]
        [Display(Name = "LOTTABLE3",Description ="LOTTABLE3",Prompt = "LOTTABLE3",ResourceType = typeof(resource.FreightRule))]
        public decimal LOTTABLE3 { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.FreightRule))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.FreightRule))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.FreightRule))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
