using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="LocBaseMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2019/8/5 8:58:24 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(LocBaseMetadata))]
    public partial class LocBase
    {
    }

    public partial class LocBaseMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.LocBase))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 名称")]
        [Display(Name = "Name",Description ="名称",Prompt = "名称",ResourceType = typeof(resource.LocBase))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Description",Description ="描述",Prompt = "描述",ResourceType = typeof(resource.LocBase))]
        [MaxLength(180)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter : 经度")]
        [Display(Name = "Longitude",Description ="经度",Prompt = "经度",ResourceType = typeof(resource.LocBase))]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "Please enter : 纬度")]
        [Display(Name = "Latitude",Description ="纬度",Prompt = "纬度",ResourceType = typeof(resource.LocBase))]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "Please enter : 预警半径")]
        [Display(Name = "Radius",Description ="预警半径",Prompt = "预警半径",ResourceType = typeof(resource.LocBase))]
        public decimal Radius { get; set; }

        [Display(Name = "Gid",Description ="围栏ID",Prompt = "围栏ID",ResourceType = typeof(resource.LocBase))]
        [MaxLength(80)]
        public string Gid { get; set; }

        [Required(ErrorMessage = "Please enter : 是否启用")]
        [Display(Name = "Enable",Description ="是否启用",Prompt = "是否启用",ResourceType = typeof(resource.LocBase))]
        public bool Enable { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.LocBase))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.LocBase))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.LocBase))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.LocBase))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
