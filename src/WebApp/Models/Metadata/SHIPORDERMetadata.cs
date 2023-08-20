using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApp.Models
{
// <copyright file="SHIPORDERMetadata.cs" tool="martCode MVC5 Scaffolder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>neo.zhu</author>
// <date>8/12/2019 9:08:25 AM </date>
// <summary>Class representing a Metadata entity </summary>
    //[MetadataType(typeof(SHIPORDERMetadata))]
    public partial class SHIPORDER
    {
    }

    public partial class SHIPORDERMetadata
    {
        [Display(Name = "SHIPORDERDETAILS",Description ="SHIPORDERDETAILS",Prompt = "SHIPORDERDETAILS",ResourceType = typeof(resource.SHIPORDER))]
        public SHIPORDERDETAIL SHIPORDERDETAILS { get; set; }

        [Required(ErrorMessage = "Please enter : ID")]
        [Display(Name = "ID",Description ="ID",Prompt = "ID",ResourceType = typeof(resource.SHIPORDER))]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter : 运单号")]
        [Display(Name = "SHIPORDERKEY",Description ="运单号",Prompt = "运单号",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(20)]
        public string SHIPORDERKEY { get; set; }

        [Display(Name = "EXTERNSHIPORDERKEY",Description ="对账单号",Prompt = "对账单号",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(50)]
        public string EXTERNSHIPORDERKEY { get; set; }

        [Required(ErrorMessage = "Please enter : 接单日期")]
        [Display(Name = "SHIPORDERDATE",Description ="接单日期",Prompt = "接单日期",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime SHIPORDERDATE { get; set; }

        [Required(ErrorMessage = "Please enter : 状态")]
        [Display(Name = "STATUS",Description ="状态",Prompt = "状态",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(3)]
        public string STATUS { get; set; }

        [Display(Name = "TYPE",Description ="运输方式(正常/加急/退运)",Prompt = "运输方式(正常/加急/退运)",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(3)]
        public string TYPE { get; set; }

        [Required(ErrorMessage = "Please enter : 起始地")]
        [Display(Name = "ORIGINAL",Description ="起始地",Prompt = "起始地",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(50)]
        public string ORIGINAL { get; set; }

        [Required(ErrorMessage = "Please enter : 目的地")]
        [Display(Name = "DESTINATION",Description ="目的地",Prompt = "目的地",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(50)]
        public string DESTINATION { get; set; }

        [Required(ErrorMessage = "Please enter : 运输车辆")]
        [Display(Name = "PLATENUMBER",Description ="运输车辆",Prompt = "运输车辆",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(10)]
        public string PLATENUMBER { get; set; }

        [Display(Name = "DRIVERNAME",Description ="司机",Prompt = "司机",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(20)]
        public string DRIVERNAME { get; set; }

        [Display(Name = "DRIVERPHONE",Description ="司机电话",Prompt = "司机电话",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(20)]
        public string DRIVERPHONE { get; set; }

        [Display(Name = "CARRIERCODE",Description ="承运人代码",Prompt = "承运人代码",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(20)]
        public string CARRIERCODE { get; set; }

        [Display(Name = "CARRIERNAME",Description ="承运人名称",Prompt = "承运人名称",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(80)]
        public string CARRIERNAME { get; set; }

        [Display(Name = "SHIPPERKEY",Description ="发货单位",Prompt = "发货单位",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(30)]
        public string SHIPPERKEY { get; set; }

        [Display(Name = "SHIPPERNAME",Description ="发货单位名称",Prompt = "发货单位名称",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(80)]
        public string SHIPPERNAME { get; set; }

        [Display(Name = "SHIPPERADDRESS",Description ="发货地址",Prompt = "发货地址",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(180)]
        public string SHIPPERADDRESS { get; set; }

        [Display(Name = "CONSIGNEEKEY",Description ="收货单位",Prompt = "收货单位",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(30)]
        public string CONSIGNEEKEY { get; set; }

        [Display(Name = "CONSIGNEENAME",Description ="收货单位名称",Prompt = "收货单位名称",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(80)]
        public string CONSIGNEENAME { get; set; }

        [Display(Name = "CONSIGNEEADDRESS",Description ="收货地址",Prompt = "收货地址",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(180)]
        public string CONSIGNEEADDRESS { get; set; }

        [Display(Name = "REQUESTEDSHIPDATE",Description ="要求配送日期",Prompt = "要求配送日期",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime REQUESTEDSHIPDATE { get; set; }

        [Display(Name = "ACTUALSHIPDATE",Description ="实际配送日期",Prompt = "实际配送日期",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime ACTUALSHIPDATE { get; set; }

        [Display(Name = "DELIVERYDATE",Description ="要求到货时间",Prompt = "要求到货时间",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime DELIVERYDATE { get; set; }

        [Display(Name = "ACTUALDELIVERYDATE",Description ="实际到货时间",Prompt = "实际到货时间",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime ACTUALDELIVERYDATE { get; set; }

        [Display(Name = "CLOSEDDATE",Description ="结案日期",Prompt = "结案日期",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime CLOSEDDATE { get; set; }

        [Required(ErrorMessage = "Please enter : 合计发运数量")]
        [Display(Name = "TOTALQTY",Description ="合计发运数量",Prompt = "合计发运数量",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALQTY { get; set; }

        [Required(ErrorMessage = "Please enter : 合计确认数量")]
        [Display(Name = "TOTALSHIPPEDQTY",Description ="合计确认数量",Prompt = "合计确认数量",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALSHIPPEDQTY { get; set; }

        [Display(Name = "TOTALCASECNT",Description ="合计件数",Prompt = "合计件数",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCASECNT { get; set; }

        [Display(Name = "TOTALGROSSWGT",Description ="合计毛重(KG)",Prompt = "合计毛重(KG)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALGROSSWGT { get; set; }

        [Display(Name = "TOTALCUBE",Description ="合计体积(M)",Prompt = "合计体积(M)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCUBE { get; set; }

        [Required(ErrorMessage = "Please enter : 标准里程(千米)")]
        [Display(Name = "STDKM",Description ="标准里程(千米)",Prompt = "标准里程(千米)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal STDKM { get; set; }

        [Required(ErrorMessage = "Please enter : 起始里程数(千米)")]
        [Display(Name = "KM1",Description ="起始里程数(千米)",Prompt = "起始里程数(千米)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal KM1 { get; set; }

        [Required(ErrorMessage = "Please enter : 结束里程数(千米)")]
        [Display(Name = "KM2",Description ="结束里程数(千米)",Prompt = "结束里程数(千米)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal KM2 { get; set; }

        [Required(ErrorMessage = "Please enter : 实际里程(千米)")]
        [Display(Name = "ACTKM",Description ="实际里程(千米)",Prompt = "实际里程(千米)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal ACTKM { get; set; }

        [Required(ErrorMessage = "Please enter : 标准油耗(升)")]
        [Display(Name = "STDOIL",Description ="标准油耗(升)",Prompt = "标准油耗(升)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal STDOIL { get; set; }

        [Required(ErrorMessage = "Please enter : 起始油量(升)")]
        [Display(Name = "OIL1",Description ="起始油量(升)",Prompt = "起始油量(升)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal OIL1 { get; set; }

        [Required(ErrorMessage = "Please enter : 结束油量(升)")]
        [Display(Name = "OIL2",Description ="结束油量(升)",Prompt = "结束油量(升)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal OIL2 { get; set; }

        [Required(ErrorMessage = "Please enter : 油耗(升)")]
        [Display(Name = "ACTOIL",Description ="油耗(升)",Prompt = "油耗(升)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal ACTOIL { get; set; }

        [Required(ErrorMessage = "Please enter : 额定载重(吨)")]
        [Display(Name = "STDLOADWEIGHT",Description ="额定载重(吨)",Prompt = "额定载重(吨)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal STDLOADWEIGHT { get; set; }

        [Required(ErrorMessage = "Please enter : 额定体积(立方米)")]
        [Display(Name = "STDLOADVOLUME",Description ="额定体积(立方米)",Prompt = "额定体积(立方米)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal STDLOADVOLUME { get; set; }

        [Required(ErrorMessage = "Please enter : 收费吨位")]
        [Display(Name = "FEELOADWEIGHT",Description ="收费吨位",Prompt = "收费吨位",ResourceType = typeof(resource.SHIPORDER))]
        public decimal FEELOADWEIGHT { get; set; }

        [Required(ErrorMessage = "Please enter : 重量装载率")]
        [Display(Name = "LOADFACTOR1",Description ="重量装载率",Prompt = "重量装载率",ResourceType = typeof(resource.SHIPORDER))]
        public decimal LOADFACTOR1 { get; set; }

        [Required(ErrorMessage = "Please enter : 体积装载率")]
        [Display(Name = "LOADFACTOR2",Description ="体积装载率",Prompt = "体积装载率",ResourceType = typeof(resource.SHIPORDER))]
        public decimal LOADFACTOR2 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否计算运费")]
        [Display(Name = "CHECKEDCOST1",Description ="是否计算运费",Prompt = "是否计算运费",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST1 { get; set; }

        [Required(ErrorMessage = "Please enter : 合计运费")]
        [Display(Name = "TOTALCOST1",Description ="合计运费",Prompt = "合计运费",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST1 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否送货上门")]
        [Display(Name = "CHECKEDCOST2",Description ="是否送货上门",Prompt = "是否送货上门",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST2 { get; set; }

        [Required(ErrorMessage = "Please enter : 送货费(RMB)")]
        [Display(Name = "TOTALCOST2",Description ="送货费(RMB)",Prompt = "送货费(RMB)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST2 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否上楼")]
        [Display(Name = "CHECKEDCOST3",Description ="是否上楼",Prompt = "是否上楼",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST3 { get; set; }

        [Required(ErrorMessage = "Please enter : 楼层")]
        [Display(Name = "FLOOR",Description ="楼层",Prompt = "楼层",ResourceType = typeof(resource.SHIPORDER))]
        public int FLOOR { get; set; }

        [Required(ErrorMessage = "Please enter : 搬运费(RMB)")]
        [Display(Name = "TOTALCOST3",Description ="搬运费(RMB)",Prompt = "搬运费(RMB)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST3 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否加急")]
        [Display(Name = "CHECKEDCOST4",Description ="是否加急",Prompt = "是否加急",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST4 { get; set; }

        [Required(ErrorMessage = "Please enter : 加急费(RMB)")]
        [Display(Name = "TOTALCOST4",Description ="加急费(RMB)",Prompt = "加急费(RMB)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST4 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否专车")]
        [Display(Name = "CHECKEDCOST5",Description ="是否专车",Prompt = "是否专车",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST5 { get; set; }

        [Required(ErrorMessage = "Please enter : 专车费(RMB)")]
        [Display(Name = "TOTALCOST5",Description ="专车费(RMB)",Prompt = "专车费(RMB)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST5 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务")]
        [Display(Name = "CHECKEDCOST6",Description ="是否其它服务",Prompt = "是否其它服务",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST6 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费(RMB)")]
        [Display(Name = "TOTALCOST6",Description ="其它服务费(RMB)",Prompt = "其它服务费(RMB)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST6 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务2")]
        [Display(Name = "CHECKEDCOST7",Description ="是否其它服务2",Prompt = "是否其它服务2",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST7 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费2(RMB)")]
        [Display(Name = "TOTALCOST7",Description ="其它服务费2(RMB)",Prompt = "其它服务费2(RMB)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST7 { get; set; }

        [Required(ErrorMessage = "Please enter : 是否其它服务3")]
        [Display(Name = "CHECKEDCOST8",Description ="是否其它服务3",Prompt = "是否其它服务3",ResourceType = typeof(resource.SHIPORDER))]
        public bool CHECKEDCOST8 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它服务费3(RMB)")]
        [Display(Name = "TOTALCOST8",Description ="其它服务费3(RMB)",Prompt = "其它服务费3(RMB)",ResourceType = typeof(resource.SHIPORDER))]
        public decimal TOTALCOST8 { get; set; }

        [Required(ErrorMessage = "Please enter : 结算标志")]
        [Display(Name = "FLAG1",Description ="结算标志",Prompt = "结算标志",ResourceType = typeof(resource.SHIPORDER))]
        public bool FLAG1 { get; set; }

        [Display(Name = "NOTES1",Description ="备注2",Prompt = "备注2",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(180)]
        public string NOTES1 { get; set; }

        [Required(ErrorMessage = "Please enter : 其它标志")]
        [Display(Name = "FLAG2",Description ="其它标志",Prompt = "其它标志",ResourceType = typeof(resource.SHIPORDER))]
        public bool FLAG2 { get; set; }

        [Display(Name = "NOTES",Description ="备注",Prompt = "备注",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(180)]
        public string NOTES { get; set; }

        [Display(Name = "COMPANYCODE",Description ="所属公司",Prompt = "所属公司",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(20)]
        public string COMPANYCODE { get; set; }

        [Display(Name = "LOTTABLE1",Description ="上传用户",Prompt = "上传用户",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(50)]
        public string LOTTABLE1 { get; set; }

        [Display(Name = "LOTTABLE2",Description ="LOTTABLE2",Prompt = "LOTTABLE2",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(60)]
        public string LOTTABLE2 { get; set; }

        [Display(Name = "LOTTABLE3",Description ="LOTTABLE3",Prompt = "LOTTABLE3",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(60)]
        public string LOTTABLE3 { get; set; }

        [Display(Name = "LOTTABLE4",Description ="LOTTABLE4",Prompt = "LOTTABLE4",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(60)]
        public string LOTTABLE4 { get; set; }

        [Display(Name = "LOTTABLE5",Description ="LOTTABLE5",Prompt = "LOTTABLE5",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(50)]
        public string LOTTABLE5 { get; set; }

        [Display(Name = "LOTTABLE6",Description ="LOTTABLE6",Prompt = "LOTTABLE6",ResourceType = typeof(resource.SHIPORDER))]
        public decimal LOTTABLE6 { get; set; }

        [Display(Name = "LOTTABLE7",Description ="LOTTABLE7",Prompt = "LOTTABLE7",ResourceType = typeof(resource.SHIPORDER))]
        public decimal LOTTABLE7 { get; set; }

        [Display(Name = "LOTTABLE8",Description ="LOTTABLE8",Prompt = "LOTTABLE8",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime LOTTABLE8 { get; set; }

        [Display(Name = "CreatedDate",Description ="创建时间",Prompt = "创建时间",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "CreatedBy",Description ="创建用户",Prompt = "创建用户",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Display(Name = "LastModifiedDate",Description ="最后更新时间",Prompt = "最后更新时间",ResourceType = typeof(resource.SHIPORDER))]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "LastModifiedBy",Description ="最后更新用户",Prompt = "最后更新用户",ResourceType = typeof(resource.SHIPORDER))]
        [MaxLength(20)]
        public string LastModifiedBy { get; set; }

    }

}
