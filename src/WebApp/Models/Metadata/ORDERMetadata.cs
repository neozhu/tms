using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="ORDERMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>2019/8/8 7:25:09 </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(ORDERMetadata))]
    public partial class ORDER
    {
    }

    public partial class ORDERMetadata
    {
        [Display(Name = "ORDERDETAILS",Description ="ORDERDETAILS",Prompt = "ORDERDETAILS",ResourceType = typeof(resource.ORDER))]
        public ORDERDETAIL ORDERDETAILS { get; set; }

        [Required(ErrorMessage = "Please enter : ID")]
        [Display(Name = "ID",Description ="ID",Prompt = "ID",ResourceType = typeof(resource.ORDER))]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter : 订单号")]
        [Display(Name = "ORDERKEY",Description ="订单号",Prompt = "订单号",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string ORDERKEY { get; set; }

        [Display(Name = "EXTERNORDERKEY",Description ="提货单号",Prompt = "提货单号",ResourceType = typeof(resource.ORDER))]
        [MaxLength(50)]
        public string EXTERNORDERKEY { get; set; }

        [Required(ErrorMessage = "Please enter : 仓库号")]
        [Display(Name = "WHSEID",Description ="仓库号",Prompt = "仓库号",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string WHSEID { get; set; }

        [Display(Name = "LOTTABLE2",Description ="批次号",Prompt = "批次号",ResourceType = typeof(resource.ORDER))]
        [MaxLength(80)]
        public string LOTTABLE2 { get; set; }

        [Required(ErrorMessage = "Please enter : 起始地")]
        [Display(Name = "ORIGINAL",Description ="起始地",Prompt = "起始地",ResourceType = typeof(resource.ORDER))]
        [MaxLength(50)]
        public string ORIGINAL { get; set; }

        [Required(ErrorMessage = "Please enter : 目的地")]
        [Display(Name = "DESTINATION",Description ="目的地",Prompt = "目的地",ResourceType = typeof(resource.ORDER))]
        [MaxLength(50)]
        public string DESTINATION { get; set; }

        [Display(Name = "TYPE",Description ="订单类型(普通/急货/专车)",Prompt = "订单类型(普通/急货/专车)",ResourceType = typeof(resource.ORDER))]
        [MaxLength(10)]
        public string TYPE { get; set; }

        [Required(ErrorMessage = "Please enter : 运输方式(整车/零担)")]
        [Display(Name = "SHPTYPE",Description ="运输方式(整车/零担)",Prompt = "运输方式(整车/零担)",ResourceType = typeof(resource.ORDER))]
        [MaxLength(1)]
        public string SHPTYPE { get; set; }

        [Required(ErrorMessage = "Please enter : 状态")]
        [Display(Name = "STATUS",Description ="状态",Prompt = "状态",ResourceType = typeof(resource.ORDER))]
        [MaxLength(3)]
        public string STATUS { get; set; }

        [Required(ErrorMessage = "Please enter : 货主")]
        [Display(Name = "STORERKEY",Description ="货主",Prompt = "货主",ResourceType = typeof(resource.ORDER))]
        [MaxLength(50)]
        public string STORERKEY { get; set; }

        [Display(Name = "SUPPLIERCODE",Description ="客户代码",Prompt = "客户代码",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string SUPPLIERCODE { get; set; }

        [Display(Name = "SUPPLIERNAME",Description ="客户名称",Prompt = "客户名称",ResourceType = typeof(resource.ORDER))]
        [MaxLength(80)]
        public string SUPPLIERNAME { get; set; }

        [Required(ErrorMessage = "Please enter : 接单日期")]
        [Display(Name = "ORDERDATE",Description ="接单日期",Prompt = "接单日期",ResourceType = typeof(resource.ORDER))]
        public DateTime ORDERDATE { get; set; }

        [Display(Name = "REQUESTEDSHIPDATE",Description ="要求配送日期",Prompt = "要求配送日期",ResourceType = typeof(resource.ORDER))]
        public DateTime REQUESTEDSHIPDATE { get; set; }

        [Display(Name = "DELIVERYDATE",Description ="要求到货时间",Prompt = "要求到货时间",ResourceType = typeof(resource.ORDER))]
        public DateTime DELIVERYDATE { get; set; }

        [Display(Name = "LOTTABLE3",Description ="提货地址",Prompt = "提货地址",ResourceType = typeof(resource.ORDER))]
        [MaxLength(80)]
        public string LOTTABLE3 { get; set; }

        [Display(Name = "CONSIGNEEKEY",Description ="收货单位",Prompt = "收货单位",ResourceType = typeof(resource.ORDER))]
        [MaxLength(30)]
        public string CONSIGNEEKEY { get; set; }

        [Display(Name = "CONSIGNEENAME",Description ="收货单位名称",Prompt = "收货单位名称",ResourceType = typeof(resource.ORDER))]
        [MaxLength(80)]
        public string CONSIGNEENAME { get; set; }

        [Display(Name = "CONSIGNEEADDRESS",Description ="收货地址",Prompt = "收货地址",ResourceType = typeof(resource.ORDER))]
        [MaxLength(180)]
        public string CONSIGNEEADDRESS { get; set; }

        [Display(Name = "CARRIERNAME",Description ="承运人",Prompt = "承运人",ResourceType = typeof(resource.ORDER))]
        [MaxLength(80)]
        public string CARRIERNAME { get; set; }

        [Display(Name = "DRIVERNAME",Description ="司机",Prompt = "司机",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string DRIVERNAME { get; set; }

        [Display(Name = "CARRIERPHONE",Description ="司机电话",Prompt = "司机电话",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string CARRIERPHONE { get; set; }

        [Display(Name = "TRAILERNUMBER",Description ="运输车辆",Prompt = "运输车辆",ResourceType = typeof(resource.ORDER))]
        [MaxLength(80)]
        public string TRAILERNUMBER { get; set; }

        [Display(Name = "ACTUALSHIPDATE",Description ="实际配送日期",Prompt = "实际配送日期",ResourceType = typeof(resource.ORDER))]
        public DateTime ACTUALSHIPDATE { get; set; }

        [Display(Name = "ACTUALDELIVERYDATE",Description ="实际到货时间",Prompt = "实际到货时间",ResourceType = typeof(resource.ORDER))]
        public DateTime ACTUALDELIVERYDATE { get; set; }

        [Display(Name = "CLOSEDDATE",Description ="结案日期",Prompt = "结案日期",ResourceType = typeof(resource.ORDER))]
        public DateTime CLOSEDDATE { get; set; }

        [Required(ErrorMessage = "Please enter : 合计交货数量")]
        [Display(Name = "TOTALQTY",Description ="合计交货数量",Prompt = "合计交货数量",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALQTY { get; set; }

        [Required(ErrorMessage = "Please enter : 合计发运数量")]
        [Display(Name = "TOTALSHIPPEDQTY",Description ="合计发运数量",Prompt = "合计发运数量",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALSHIPPEDQTY { get; set; }

        [Required(ErrorMessage = "Please enter : 合计件数")]
        [Display(Name = "TOTALCASECNT",Description ="合计件数",Prompt = "合计件数",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCASECNT { get; set; }

        [Required(ErrorMessage = "Please enter : 合计毛重(KG)")]
        [Display(Name = "TOTALGROSSWGT",Description ="合计毛重(KG)",Prompt = "合计毛重(KG)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALGROSSWGT { get; set; }

        [Required(ErrorMessage = "Please enter : 合计体积(M)")]
        [Display(Name = "TOTALCUBE",Description ="合计体积(M)",Prompt = "合计体积(M)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCUBE { get; set; }

        [Required(ErrorMessage = "Please enter : 合计运费")]
        [Display(Name = "TOTALCOST1",Description ="合计运费",Prompt = "合计运费",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST1 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否送货上门")]
        [Display(Name = "CHECKEDCOST2",Description ="是否送货上门",Prompt = "是否送货上门",ResourceType = typeof(resource.ORDER))]
        public bool CHECKEDCOST2 { get; set; }

        [Required(ErrorMessage = "Please enter : 送货费(RMB)")]
        [Display(Name = "TOTALCOST2",Description ="送货费(RMB)",Prompt = "送货费(RMB)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST2 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否上楼")]
        [Display(Name = "CHECKEDCOST3",Description ="是否上楼",Prompt = "是否上楼",ResourceType = typeof(resource.ORDER))]
        public bool CHECKEDCOST3 { get; set; }

        [Required(ErrorMessage = "Please enter : 楼层")]
        [Display(Name = "FLOOR",Description ="楼层",Prompt = "楼层",ResourceType = typeof(resource.ORDER))]
        public int FLOOR { get; set; }

        [Required(ErrorMessage = "Please enter : 搬运费(RMB)")]
        [Display(Name = "TOTALCOST3",Description ="搬运费(RMB)",Prompt = "搬运费(RMB)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST3 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否加急")]
        [Display(Name = "CHECKEDCOST4",Description ="是否加急",Prompt = "是否加急",ResourceType = typeof(resource.ORDER))]
        public bool CHECKEDCOST4 { get; set; }

        [Required(ErrorMessage = "Please enter : 加急费(RMB)")]
        [Display(Name = "TOTALCOST4",Description ="加急费(RMB)",Prompt = "加急费(RMB)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST4 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否专车")]
        [Display(Name = "CHECKEDCOST5",Description ="是否专车",Prompt = "是否专车",ResourceType = typeof(resource.ORDER))]
        public bool CHECKEDCOST5 { get; set; }

        [Required(ErrorMessage = "Please enter : 专车费(RMB)")]
        [Display(Name = "TOTALCOST5",Description ="专车费(RMB)",Prompt = "专车费(RMB)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST5 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务1")]
        [Display(Name = "CHECKEDCOST6",Description ="是否其它服务1",Prompt = "是否其它服务1",ResourceType = typeof(resource.ORDER))]
        public bool CHECKEDCOST6 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费1(RMB)")]
        [Display(Name = "TOTALCOST6",Description ="其它服务费1(RMB)",Prompt = "其它服务费1(RMB)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST6 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务2")]
        [Display(Name = "CHECKEDCOST7",Description ="是否其它服务2",Prompt = "是否其它服务2",ResourceType = typeof(resource.ORDER))]
        public bool CHECKEDCOST7 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费2(RMB)")]
        [Display(Name = "TOTALCOST7",Description ="其它服务费2(RMB)",Prompt = "其它服务费2(RMB)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST7 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务3")]
        [Display(Name = "CHECKEDCOST8",Description ="是否其它服务3",Prompt = "是否其它服务3",ResourceType = typeof(resource.ORDER))]
        public bool CHECKEDCOST8 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费3(RMB)")]
        [Display(Name = "TOTALCOST8",Description ="其它服务费3(RMB)",Prompt = "其它服务费3(RMB)",ResourceType = typeof(resource.ORDER))]
        public decimal TOTALCOST8 { get; set; }

        [Display(Name = "NOTES",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.ORDER))]
        [MaxLength(180)]
        public string NOTES { get; set; }

        [Required(ErrorMessage = "Please enter : 结算标志")]
        [Display(Name = "FLAG1",Description ="结算标志",Prompt = "结算标志",ResourceType = typeof(resource.ORDER))]
        public bool FLAG1 { get; set; }

        [Display(Name = "NOTES1",Description ="备注2",Prompt = "备注2",ResourceType = typeof(resource.ORDER))]
        [MaxLength(180)]
        public string NOTES1 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它标志")]
        [Display(Name = "FLAG2",Description ="其它标志",Prompt = "其它标志",ResourceType = typeof(resource.ORDER))]
        public bool FLAG2 { get; set; }

        [Display(Name = "COMPANYCODE",Description ="所属公司",Prompt = "所属公司",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string COMPANYCODE { get; set; }

        [Display(Name = "LOTTABLE1",Description ="上传用户",Prompt = "上传用户",ResourceType = typeof(resource.ORDER))]
        [MaxLength(50)]
        public string LOTTABLE1 { get; set; }

        [Display(Name = "LOTTABLE4",Description ="LOTTABLE4",Prompt = "LOTTABLE4",ResourceType = typeof(resource.ORDER))]
        [MaxLength(60)]
        public string LOTTABLE4 { get; set; }

        [Display(Name = "LOTTABLE5",Description ="LOTTABLE5",Prompt = "LOTTABLE5",ResourceType = typeof(resource.ORDER))]
        [MaxLength(50)]
        public string LOTTABLE5 { get; set; }

        [Display(Name = "LOTTABLE6",Description ="LOTTABLE6",Prompt = "LOTTABLE6",ResourceType = typeof(resource.ORDER))]
        public decimal LOTTABLE6 { get; set; }

        [Display(Name = "LOTTABLE7",Description ="LOTTABLE7",Prompt = "LOTTABLE7",ResourceType = typeof(resource.ORDER))]
        public decimal LOTTABLE7 { get; set; }

        [Display(Name = "LOTTABLE8",Description ="LOTTABLE8",Prompt = "LOTTABLE8",ResourceType = typeof(resource.ORDER))]
        public DateTime LOTTABLE8 { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.ORDER))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.ORDER))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.ORDER))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
