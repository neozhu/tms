using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="StandardCostMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>9/12/2019 1:48:43 PM </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(StandardCostMetadata))]
    public partial class StandardCost
    {
    }

    public partial class StandardCostMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.StandardCost))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 起始地")]
        [Display(Name = "ORIGINAL",Description ="起始地",Prompt = "起始地",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(50)]
        public string ORIGINAL { get; set; }

        [Required(ErrorMessage = "Please enter : 目的地")]
        [Display(Name = "DESTINATION",Description ="目的地",Prompt = "目的地",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(50)]
        public string DESTINATION { get; set; }

        [Required(ErrorMessage = "Please enter : 标准里程(千米)")]
        [Display(Name = "STDKM",Description ="标准里程(千米)",Prompt = "标准里程(千米)",ResourceType = typeof(resource.StandardCost))]
        public decimal STDKM { get; set; }

        [Display(Name = "CarType",Description ="车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)",Prompt = "车辆类型(厢式车（默认）/平板车/轿车/面包车/高栏车/飞翼车等)",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(20)]
        public string CarType { get; set; }

        [Required(ErrorMessage = "Please enter : 额定载重(吨)")]
        [Display(Name = "STDLOADWEIGHT",Description ="额定载重(吨)",Prompt = "额定载重(吨)",ResourceType = typeof(resource.StandardCost))]
        public decimal STDLOADWEIGHT { get; set; }

        [Required(ErrorMessage = "Please enter : 标准油耗(升)")]
        [Display(Name = "STDOIL",Description ="标准油耗(升)",Prompt = "标准油耗(升)",ResourceType = typeof(resource.StandardCost))]
        public decimal STDOIL { get; set; }

        [Required(ErrorMessage = "Please enter : 标准运费")]
        [Display(Name = "STDCOST",Description ="标准运费",Prompt = "标准运费",ResourceType = typeof(resource.StandardCost))]
        public decimal STDCOST { get; set; }

        [Display(Name = "DESCRIPTION",Description ="说明",Prompt = "说明",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(180)]
        public string DESCRIPTION { get; set; }

        [Display(Name = "Notes",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(80)]
        public string Notes { get; set; }

        [Display(Name = "LOTTABLE1",Description ="LOTTABLE1",Prompt = "LOTTABLE1",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(50)]
        public string LOTTABLE1 { get; set; }

        [Display(Name = "LOTTABLE2",Description ="LOTTABLE2",Prompt = "LOTTABLE2",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(50)]
        public string LOTTABLE2 { get; set; }

        [Required(ErrorMessage = "Please enter : LOTTABLE3")]
        [Display(Name = "LOTTABLE3",Description ="LOTTABLE3",Prompt = "LOTTABLE3",ResourceType = typeof(resource.StandardCost))]
        public decimal LOTTABLE3 { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.StandardCost))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.StandardCost))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.StandardCost))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

        [Required(ErrorMessage = "Please enter : Tenant Id")]
        [Display(Name = "TenantId",Description ="Tenant Id",Prompt = "Tenant Id",ResourceType = typeof(resource.StandardCost))]
        public int TenantId { get; set; }

    }

}
