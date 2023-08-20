using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="SHIPORDERDETAILMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>8/12/2019 8:47:36 AM </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(SHIPORDERDETAILMetadata))]
    public partial class SHIPORDERDETAIL
    {
    }

    public partial class SHIPORDERDETAILMetadata
    {
        [Display(Name = "SHIPORDER",Description ="运单信息",Prompt = "运单信息",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public SHIPORDER SHIPORDER { get; set; }

        [Required(ErrorMessage = "Please enter : ID")]
        [Display(Name = "ID",Description ="ID",Prompt = "ID",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter : 运单号")]
        [Display(Name = "SHIPORDERKEY",Description ="运单号",Prompt = "运单号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string SHIPORDERKEY { get; set; }

        [Display(Name = "EXTERNSHIPORDERKEY",Description ="对账单号",Prompt = "对账单号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string EXTERNSHIPORDERKEY { get; set; }

        [Required(ErrorMessage = "Please enter : 行号")]
        [Display(Name = "ORDERLINENUMBER",Description ="行号",Prompt = "行号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(6)]
        public string ORDERLINENUMBER { get; set; }

        [Display(Name = "STATUS",Description ="状态",Prompt = "状态",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(3)]
        public string STATUS { get; set; }

        [Display(Name = "SUPPLIERCODE",Description ="客户代码",Prompt = "客户代码",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string SUPPLIERCODE { get; set; }

        [Display(Name = "SUPPLIERNAME",Description ="客户名称",Prompt = "客户名称",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(80)]
        public string SUPPLIERNAME { get; set; }

        [Display(Name = "LOTTABLE3",Description ="提货地址",Prompt = "提货地址",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(80)]
        public string LOTTABLE3 { get; set; }

        [Display(Name = "CONSIGNEEADDRESS",Description ="收货地址",Prompt = "收货地址",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(180)]
        public string CONSIGNEEADDRESS { get; set; }

        [Required(ErrorMessage = "Please enter : 物料编码")]
        [Display(Name = "SKU",Description ="物料编码",Prompt = "物料编码",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(30)]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Please enter : 物料类型(洁具/瓷砖)")]
        [Display(Name = "SKUTYPE",Description ="物料类型(洁具/瓷砖)",Prompt = "物料类型(洁具/瓷砖)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(10)]
        public string SKUTYPE { get; set; }

        [Display(Name = "SKUNAME",Description ="物料名称",Prompt = "物料名称",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(80)]
        public string SKUNAME { get; set; }

        [Required(ErrorMessage = "Please enter : 交货数量")]
        [Display(Name = "ORIGINALQTY",Description ="交货数量",Prompt = "交货数量",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal ORIGINALQTY { get; set; }

        [Required(ErrorMessage = "Please enter : 已发运数量")]
        [Display(Name = "SHIPPEDQTY",Description ="已发运数量",Prompt = "已发运数量",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal SHIPPEDQTY { get; set; }

        [Required(ErrorMessage = "Please enter : 单位")]
        [Display(Name = "UMO",Description ="单位",Prompt = "单位",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(10)]
        public string UMO { get; set; }

        [Display(Name = "PACKKEY",Description ="包装",Prompt = "包装",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(10)]
        public string PACKKEY { get; set; }

        [Required(ErrorMessage = "Please enter : 交货件数")]
        [Display(Name = "CASECNT",Description ="交货件数",Prompt = "交货件数",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal CASECNT { get; set; }

        [Required(ErrorMessage = "Please enter : 毛重(KG)")]
        [Display(Name = "GROSSWGT",Description ="毛重(KG)",Prompt = "毛重(KG)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal GROSSWGT { get; set; }

        [Required(ErrorMessage = "Please enter : 净重(KG)")]
        [Display(Name = "NETWGT",Description ="净重(KG)",Prompt = "净重(KG)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal NETWGT { get; set; }

        [Required(ErrorMessage = "Please enter : 体积(M)")]
        [Display(Name = "CUBE",Description ="体积(M)",Prompt = "体积(M)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal CUBE { get; set; }

        [Display(Name = "NOTES",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(180)]
        public string NOTES { get; set; }

        [Display(Name = "SALER",Description ="销售雇员",Prompt = "销售雇员",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string SALER { get; set; }

        [Display(Name = "SALESORG",Description ="销售组",Prompt = "销售组",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string SALESORG { get; set; }

        [Required(ErrorMessage = "Please enter : 是否计算运费")]
        [Display(Name = "CHECKEDCOST1",Description ="是否计算运费",Prompt = "是否计算运费",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST1 { get; set; }

        [Required(ErrorMessage = "Please enter : 运费(RMB)")]
        [Display(Name = "COST1",Description ="运费(RMB)",Prompt = "运费(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST1 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否送货上门")]
        [Display(Name = "CHECKEDCOST2",Description ="是否送货上门",Prompt = "是否送货上门",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST2 { get; set; }

        [Required(ErrorMessage = "Please enter : 送货费(RMB)")]
        [Display(Name = "COST2",Description ="送货费(RMB)",Prompt = "送货费(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST2 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否上楼")]
        [Display(Name = "CHECKEDCOST3",Description ="是否上楼",Prompt = "是否上楼",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST3 { get; set; }

        [Required(ErrorMessage = "Please enter : 楼层")]
        [Display(Name = "FLOOR",Description ="楼层",Prompt = "楼层",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public int FLOOR { get; set; }

        [Required(ErrorMessage = "Please enter : 搬运费(RMB)")]
        [Display(Name = "COST3",Description ="搬运费(RMB)",Prompt = "搬运费(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST3 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否加急")]
        [Display(Name = "CHECKEDCOST4",Description ="是否加急",Prompt = "是否加急",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST4 { get; set; }

        [Required(ErrorMessage = "Please enter : 加急费(RMB)")]
        [Display(Name = "COST4",Description ="加急费(RMB)",Prompt = "加急费(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST4 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否专车")]
        [Display(Name = "CHECKEDCOST5",Description ="是否专车",Prompt = "是否专车",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST5 { get; set; }

        [Required(ErrorMessage = "Please enter : 专车费(RMB)")]
        [Display(Name = "COST5",Description ="专车费(RMB)",Prompt = "专车费(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST5 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务1")]
        [Display(Name = "CHECKEDCOST6",Description ="是否其它服务1",Prompt = "是否其它服务1",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST6 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费1(RMB)")]
        [Display(Name = "COST6",Description ="其它服务费1(RMB)",Prompt = "其它服务费1(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST6 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务2")]
        [Display(Name = "CHECKEDCOST7",Description ="是否其它服务2",Prompt = "是否其它服务2",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST7 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费2(RMB)")]
        [Display(Name = "COST7",Description ="其它服务费2(RMB)",Prompt = "其它服务费2(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST7 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务3")]
        [Display(Name = "CHECKEDCOST8",Description ="是否其它服务3",Prompt = "是否其它服务3",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool CHECKEDCOST8 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费3(RMB)")]
        [Display(Name = "COST8",Description ="其它服务费3(RMB)",Prompt = "其它服务费3(RMB)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal COST8 { get; set; }

        [Required(ErrorMessage = "Please enter : 订单号")]
        [Display(Name = "ORDERKEY",Description ="订单号",Prompt = "订单号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string ORDERKEY { get; set; }

        [Display(Name = "LOTTABLE2",Description ="批次号",Prompt = "批次号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string LOTTABLE2 { get; set; }

        [Display(Name = "EXTERNORDERKEY",Description ="提货单号",Prompt = "提货单号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string EXTERNORDERKEY { get; set; }

        [Required(ErrorMessage = "Please enter : 结算标志")]
        [Display(Name = "FLAG1",Description ="结算标志",Prompt = "结算标志",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool FLAG1 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它标志")]
        [Display(Name = "FLAG2",Description ="其它标志",Prompt = "其它标志",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public bool FLAG2 { get; set; }

        [Display(Name = "NOTES1",Description ="备注2",Prompt = "备注2",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(180)]
        public string NOTES1 { get; set; }

        [Display(Name = "REQUESTEDSHIPDATE",Description ="要求配送日期",Prompt = "要求配送日期",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime REQUESTEDSHIPDATE { get; set; }

        [Display(Name = "DELIVERYDATE",Description ="要求到货时间",Prompt = "要求到货时间",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime DELIVERYDATE { get; set; }

        [Display(Name = "ACTUALSHIPDATE",Description ="实际配送日期",Prompt = "实际配送日期",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime ACTUALSHIPDATE { get; set; }

        [Display(Name = "ACTUALDELIVERYDATE",Description ="实际到货时间",Prompt = "实际到货时间",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime ACTUALDELIVERYDATE { get; set; }

        [Required(ErrorMessage = "Please enter : 仓库号")]
        [Display(Name = "WHSEID",Description ="仓库号",Prompt = "仓库号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string WHSEID { get; set; }

        [Required(ErrorMessage = "Please enter : 货主")]
        [Display(Name = "STORERKEY",Description ="货主",Prompt = "货主",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string STORERKEY { get; set; }

        [Display(Name = "LOTTABLE1",Description ="上传用户",Prompt = "上传用户",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string LOTTABLE1 { get; set; }

        [Display(Name = "EXTERNLINENO",Description ="外部行项号",Prompt = "外部行项号",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string EXTERNLINENO { get; set; }

        [Display(Name = "TYPE",Description ="订单类型(普通/急货/专车)",Prompt = "订单类型(普通/急货/专车)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(10)]
        public string TYPE { get; set; }

        [Display(Name = "ORIGINAL",Description ="起始地",Prompt = "起始地",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string ORIGINAL { get; set; }

        [Display(Name = "DESTINATION",Description ="目的地",Prompt = "目的地",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string DESTINATION { get; set; }

        [Required(ErrorMessage = "Please enter : 运输方式(整车/零担)")]
        [Display(Name = "SHPTYPE",Description ="运输方式(整车/零担)",Prompt = "运输方式(整车/零担)",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(1)]
        public string SHPTYPE { get; set; }

        [Display(Name = "COMPANYCODE",Description ="所属公司",Prompt = "所属公司",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string COMPANYCODE { get; set; }

        [Display(Name = "LOTTABLE4",Description ="LOTTABLE4",Prompt = "LOTTABLE4",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string LOTTABLE4 { get; set; }

        [Display(Name = "LOTTABLE5",Description ="LOTTABLE5",Prompt = "LOTTABLE5",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string LOTTABLE5 { get; set; }

        [Display(Name = "LOTTABLE6",Description ="LOTTABLE6",Prompt = "LOTTABLE6",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal LOTTABLE6 { get; set; }

        [Display(Name = "LOTTABLE7",Description ="LOTTABLE7",Prompt = "LOTTABLE7",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public decimal LOTTABLE7 { get; set; }

        [Display(Name = "LOTTABLE8",Description ="LOTTABLE7",Prompt = "LOTTABLE7",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime LOTTABLE8 { get; set; }

        [Display(Name = "LOTTABLE9",Description ="LOTTABLE9",Prompt = "LOTTABLE9",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime LOTTABLE9 { get; set; }

        [Display(Name = "LOTTABLE10",Description ="LOTTABLE10",Prompt = "LOTTABLE10",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(50)]
        public string LOTTABLE10 { get; set; }

        [Required(ErrorMessage = "Please enter : 运单ID")]
        [Display(Name = "SHIPORDERID",Description ="运单ID",Prompt = "运单ID",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public int SHIPORDERID { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.SHIPORDERDETAIL))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
