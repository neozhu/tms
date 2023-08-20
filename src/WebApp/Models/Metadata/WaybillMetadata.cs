using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="WaybillMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2020/6/24 16:54:00 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(WaybillMetadata))]
    public partial class Waybill
    {
    }

    public partial class WaybillMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id",Description ="Id",Prompt = "Id",ResourceType = typeof(resource.Waybill))]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter : 订单号")]
        [Display(Name = "OrderNo",Description ="订单号",Prompt = "订单号",ResourceType = typeof(resource.Waybill))]
        [MaxLength(10)]
        public string OrderNo { get; set; }

        [Display(Name = "Status",Description ="状态",Prompt = "状态",ResourceType = typeof(resource.Waybill))]
        [MaxLength(10)]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please enter : 客户编码")]
        [Display(Name = "CustomerId",Description ="客户编码",Prompt = "客户编码",ResourceType = typeof(resource.Waybill))]
        [MaxLength(10)]
        public string CustomerId { get; set; }

        [Display(Name = "CustomerName",Description ="客户简称",Prompt = "客户简称",ResourceType = typeof(resource.Waybill))]
        [MaxLength(128)]
        public string CustomerName { get; set; }

        [Display(Name = "ProjectNo",Description ="计划项目号",Prompt = "计划项目号",ResourceType = typeof(resource.Waybill))]
        [MaxLength(32)]
        public string ProjectNo { get; set; }

        [Display(Name = "PickNo",Description ="提货单号",Prompt = "提货单号",ResourceType = typeof(resource.Waybill))]
        [MaxLength(32)]
        public string PickNo { get; set; }

        [Required(ErrorMessage = "Please enter : 配送日期")]
        [Display(Name = "ShippedDate",Description ="配送日期",Prompt = "配送日期",ResourceType = typeof(resource.Waybill))]
        public DateTime ShippedDate { get; set; }

        [Display(Name = "Original",Description ="起运地",Prompt = "起运地",ResourceType = typeof(resource.Waybill))]
        [MaxLength(38)]
        public string Original { get; set; }

        [Display(Name = "Destination",Description ="送货区域",Prompt = "送货区域",ResourceType = typeof(resource.Waybill))]
        [MaxLength(38)]
        public string Destination { get; set; }

        [Display(Name = "Remark",Description ="定单抬头文本信息",Prompt = "定单抬头文本信息",ResourceType = typeof(resource.Waybill))]
        [MaxLength(50)]
        public string Remark { get; set; }

        [Display(Name = "ProductNo",Description ="物料编码",Prompt = "物料编码",ResourceType = typeof(resource.Waybill))]
        [MaxLength(38)]
        public string ProductNo { get; set; }

        [Display(Name = "LotNo",Description ="批次",Prompt = "批次",ResourceType = typeof(resource.Waybill))]
        [MaxLength(38)]
        public string LotNo { get; set; }

        [Required(ErrorMessage = "Please enter : 交货数量")]
        [Display(Name = "Qty",Description ="交货数量",Prompt = "交货数量",ResourceType = typeof(resource.Waybill))]
        public decimal Qty { get; set; }

        [Display(Name = "Weight",Description ="重货(kg)",Prompt = "重货(kg)",ResourceType = typeof(resource.Waybill))]
        public decimal Weight { get; set; }

        [Display(Name = "Cube",Description ="体积（m3)",Prompt = "体积（m3)",ResourceType = typeof(resource.Waybill))]
        public decimal Cube { get; set; }

        [Display(Name = "SPrice",Description ="运价",Prompt = "运价",ResourceType = typeof(resource.Waybill))]
        public decimal SPrice { get; set; }

        [Display(Name = "SAmount",Description ="运费（元）",Prompt = "运费（元）",ResourceType = typeof(resource.Waybill))]
        public decimal SAmount { get; set; }

        [Display(Name = "CPrice",Description ="搬运单价",Prompt = "搬运单价",ResourceType = typeof(resource.Waybill))]
        public decimal CPrice { get; set; }

        [Display(Name = "CAmount",Description ="搬运费（元）",Prompt = "搬运费（元）",ResourceType = typeof(resource.Waybill))]
        public decimal CAmount { get; set; }

        [Display(Name = "Way",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.Waybill))]
        [MaxLength(128)]
        public string Way { get; set; }

        [Display(Name = "Sales",Description ="销售雇员",Prompt = "销售雇员",ResourceType = typeof(resource.Waybill))]
        [MaxLength(32)]
        public string Sales { get; set; }

        [Display(Name = "SalesGroup",Description ="销售小组",Prompt = "销售小组",ResourceType = typeof(resource.Waybill))]
        [MaxLength(32)]
        public string SalesGroup { get; set; }

        [Display(Name = "Remark1",Description ="备注1",Prompt = "备注1",ResourceType = typeof(resource.Waybill))]
        [MaxLength(256)]
        public string Remark1 { get; set; }

        [Display(Name = "Remark2",Description ="备注2",Prompt = "备注2",ResourceType = typeof(resource.Waybill))]
        [MaxLength(256)]
        public string Remark2 { get; set; }

        [Required(ErrorMessage = "Please enter : 特殊标志")]
        [Display(Name = "Flag",Description ="特殊标志",Prompt = "特殊标志",ResourceType = typeof(resource.Waybill))]
        public bool Flag { get; set; }

        [Display(Name = "Driver",Description ="司机",Prompt = "司机",ResourceType = typeof(resource.Waybill))]
        [MaxLength(32)]
        public string Driver { get; set; }

        [Display(Name = "Transport",Description ="车牌",Prompt = "车牌",ResourceType = typeof(resource.Waybill))]
        [MaxLength(32)]
        public string Transport { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.Waybill))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.Waybill))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.Waybill))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.Waybill))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

        [Required(ErrorMessage = "Please enter : Tenant Id")]
        [Display(Name = "TenantId",Description ="Tenant Id",Prompt = "Tenant Id",ResourceType = typeof(resource.Waybill))]
        public int TenantId { get; set; }

    }

}
