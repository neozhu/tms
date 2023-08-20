using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using System.Linq.Expressions;
using EntityFramework;
using System.Data.Entity;
using PublicPara.CodeText.Data;
using AutoMapper;
using System.Text.RegularExpressions;

namespace WebApp.Services
{
  /// <summary>
  /// File: ORDERService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 2019/8/8 7:25:04
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class ORDERService : Service<ORDER>, IORDERService
  {
    private readonly IRepositoryAsync<ORDER> repository;
    private readonly ISUPPLIERService supplierservice;
    private readonly IORDERDETAILService orderdetailservice;
    private readonly IStatusHistoryService historyService;
    private readonly IDataTableImportMappingService mappingservice;
    private readonly ISalesmanService salesmanservice;
    private readonly ILocBaseService locservice;
    private readonly IMapper mapper;
    public ORDERService(
      IMapper mapper,
      ILocBaseService locservice,
      IORDERDETAILService orderdetailservice,
    ISalesmanService salesmanservice,
    IStatusHistoryService historyService,
      ISUPPLIERService supplierservice,
    IRepositoryAsync<ORDER> repository, IDataTableImportMappingService mappingservice)
        : base(repository)
    {
      this.historyService = historyService;
      this.repository = repository;
      this.mappingservice = mappingservice;
      this.supplierservice = supplierservice;
      this.salesmanservice = salesmanservice;
      this.mapper = mapper;
      this.orderdetailservice = orderdetailservice;
      this.locservice = locservice;
    }
    public IEnumerable<ORDERDETAIL> GetORDERDETAILSByORDERID(int orderid) => this.repository.GetORDERDETAILSByORDERID(orderid);



    public void ImportDataTable(System.Data.DataTable datatable, string username = "", string companycode = "")
    {
      var mapping = this.mappingservice.Queryable()
        .Where(x => x.EntitySetName == "ORDERDETAIL" &&
        ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && x.DefaultValue!=null) ) ).ToList();
      if (mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到ORDERDETAIL对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      var list = new List<ORDERDETAIL>();
      var now = DateTime.Now;
      var newsupplierlist = new List<SUPPLIER>();
      foreach (DataRow row in datatable.Rows)
      {
       
        var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null && !row.IsNull(requiredfield) && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
        {
          var item = new ORDERDETAIL();
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString() != string.Empty)
            {
              var orderdetailtype = item.GetType();
              var propertyInfo = orderdetailtype.GetProperty(field.FieldName);

              var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
              var safeValue = ( row[field.SourceFieldName] == null ) ? null : Convert.ChangeType(row[field.SourceFieldName], safetype);
              propertyInfo.SetValue(item, safeValue, null);
            }
            else if (!string.IsNullOrEmpty(defval))
            {
              var orderdetailtype = item.GetType();
              var propertyInfo = orderdetailtype.GetProperty(field.FieldName);
              if (string.Equals(defval, "now", StringComparison.OrdinalIgnoreCase) && ( propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(Nullable<DateTime>) ))
              {
                var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var safeValue = Convert.ChangeType(DateTime.Now, safetype);
                propertyInfo.SetValue(item, safeValue, null);
              }
              else if (string.Equals(defval, "guid", StringComparison.OrdinalIgnoreCase))
              {
                propertyInfo.SetValue(item, Guid.NewGuid().ToString(), null);
              }
              else
              {
                var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var safeValue = Convert.ChangeType(defval, safetype);
                propertyInfo.SetValue(item, safeValue, null);
              }
            }
          }


          item.LOTTABLE1 = username;
          item.COMPANYCODE = companycode;
          item.REQUESTEDSHIPDATE = ( item.REQUESTEDSHIPDATE == null ) ? now.AddHours(3) : item.REQUESTEDSHIPDATE;
          item.DELIVERYDATE = ( item.DELIVERYDATE == null ) ? now.AddDays(2) : item.DELIVERYDATE;
          if (string.IsNullOrEmpty(item.ORIGINAL) && string.IsNullOrEmpty(item.DESTINATION))
          {
            var supplier = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == item.SUPPLIERCODE).FirstOrDefault();
            if (supplier == null)
            {
              var newsupplier = new SUPPLIER()
              {
                SUPPLIERCODE = item.SUPPLIERCODE,
                SUPPLIERNAME = item.SUPPLIERNAME,
                NOTES = item.CONTACTINFO,
                ADDRESS2 = item.CONSIGNEEADDRESS,
                Loc1 = "",
                Loc2 = ""
              };
              item.ORIGINAL = "";
              item.DESTINATION = "";
              item.LOTTABLE3 = string.IsNullOrEmpty(item.LOTTABLE3) ? supplier.ADDRESS1 : item.LOTTABLE3;
              if (!newsupplierlist.Where(x => x.SUPPLIERCODE == newsupplier.SUPPLIERCODE).Any())
              {
                newsupplierlist.Add(newsupplier);
              }
              //this.supplierservice.Insert(newsupplier);
            }
            else
            {
              item.ORIGINAL = ( string.IsNullOrEmpty(supplier.Loc1) ) ? "-" : supplier.Loc1;
              item.DESTINATION = ( string.IsNullOrEmpty(supplier.Loc2) ) ? "-" : supplier.Loc2;
              item.LOTTABLE3 = string.IsNullOrEmpty(item.LOTTABLE3) ? supplier.ADDRESS1 : item.LOTTABLE3;
            }
          }


          switch (item.SHPTYPE)
          {
            case "整车":
              item.SHPTYPE = "1";
              break;
            case "零担":
              item.SHPTYPE = "2";
              break;
            case "专车":
              item.SHPTYPE = "3";
              break;
            case "当日送达":
              item.SHPTYPE = "4";
              break;
            default:
              item.SHPTYPE = "2";
              break;
          }
          if (item.CUBE <= 0 )
          {
            item.SKUTYPE = "瓷砖";
          }
          else
          {
            item.SKUTYPE = "洁具";
          }
          //截取联系人/联系电话

          if (!string.IsNullOrEmpty(item.CONSIGNEEADDRESS) && item.CONSIGNEEADDRESS.Length >= 2)
          {
            var loc = item.CONSIGNEEADDRESS.Substring(0, 2);
            item.DESTINATION = loc;
            //判断是否算广州市内,市内延后一天发运/到货
            var locbase = locservice.Queryable().Where(x => x.Name == loc).FirstOrDefault();
            if (locbase != null && locbase.Description.IndexOf("广州") >= 0)
            {
              item.ORIGINAL = "广州";
              item.REQUESTEDSHIPDATE = DateTime.Now.AddHours(12);
              //item.DELIVERYDATE = DateTime.Now.AddHours(24);
            }
            else
            {
              item.ORIGINAL = "广州";
              item.REQUESTEDSHIPDATE = DateTime.Now.AddHours(24);
              //item.DELIVERYDATE = DateTime.Now.AddHours(48);
            }
          }
          if (!string.IsNullOrEmpty(item.NOTES))
          {
            //默认读取搬运方式，就地卸车
            if (item.NOTES.IndexOf("就地卸车") > 0)
            {
              item.CHECKEDCOST3 = true;
              item.COST3NOTE = "就地卸车";
              item.FLOOR = 1;
            }
            else if (item.NOTES.IndexOf("平移") > 0 && item.NOTES.IndexOf("无电梯") > 0)
            {
              item.CHECKEDCOST3 = true;
              item.COST3NOTE = "楼梯上楼";
              var re = new Regex(@"[\u0391-\uFFE5]([1-9])[\u4e00-\u9fa5]");
              var result = re.Matches(item.NOTES);
              foreach (Match m in result)
              {
                if (m.Value.IndexOf("楼") > 0)
                {
                  var re1 = new Regex(@"([\u0391-\uFFE5]+)(\d+)");
                  var result1 = re.Match(m.Value);
                  var num = result1.Groups[1].Value;
                  var t = int.TryParse(num, out var n);
                  if (t)
                  {
                    item.FLOOR = n;
                  }
                }
              }
            }
            else if (item.NOTES.IndexOf("电梯上") > 0)
            {
              item.CHECKEDCOST3 = true;
              if (item.NOTES.IndexOf("平移100米") > 0)
              {
                item.COST3NOTE = "电梯上楼+平移100米";
              }
              else
              {
                item.COST3NOTE = "电梯上楼+平移";
              }

              item.FLOOR = 1;
            }
          }

          list.Add(item);
        }
      }
      if (list.Count > 0)
      {
        if (newsupplierlist.Count > 0)
        {
          this.supplierservice.InsertRange(newsupplierlist);
        }
        
        //foreach (var item in newsupplierlist)
        //{
        //  this.supplierservice.Insert(item);

        //}
       
        var keys = list.GroupBy(x => new { x.SUPPLIERCODE, x.ORDERKEY })
                 .Select(x => new { x.Key, ITEMS = x.ToList() });

        foreach (var g in keys)
        {
          var orderkey = g.Key.ORDERKEY;
          var suppliercode = g.Key.SUPPLIERCODE;
          var supplier = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == suppliercode).FirstOrDefault();
          var exist = this.Queryable().Where(x => x.ORDERKEY == orderkey).Any();
          if (exist)
          {
            throw new Exception($"该订单[{orderkey}]已经导入,不允许重复导入!");
          }
          var head = this.mapper.Map<ORDER>(g.ITEMS.First());
          head.TOTALQTY = g.ITEMS.Sum(x => x.ORIGINALQTY);
          head.TOTALSHIPPEDQTY = g.ITEMS.Sum(x => x.SHIPPEDQTY);
          head.TOTALCASECNT = g.ITEMS.Sum(x => x.CASECNT);
          head.TOTALGROSSWGT = g.ITEMS.Where(x => x.SKUTYPE == "瓷砖").Sum(x => x.GROSSWGT);
          head.TOTALCUBE = g.ITEMS.Where(x=>x.SKUTYPE == "洁具").Sum(x => x.CUBE);
          head.TOTALCOST1 = g.ITEMS.Sum(x => x.COST1);
          head.TOTALCOST2 = g.ITEMS.Sum(x => x.COST2);
          head.TOTALCOST3 = g.ITEMS.Sum(x => x.COST3);
          head.TOTALCOST4 = g.ITEMS.Sum(x => x.COST4);
          head.TOTALCOST5 = g.ITEMS.Sum(x => x.COST5);
          head.TOTALCOST6 = g.ITEMS.Sum(x => x.COST6);
          head.TOTALCOST7 = g.ITEMS.Sum(x => x.COST7);
          head.TOTALCOST8 = g.ITEMS.Sum(x => x.COST8);
          head.TrackingState = TrackableEntities.TrackingState.Added;
          this.historyService.Append(head.ORDERKEY, "", head.STATUS, "导入运输计划", username, "完成导入运输计划,等待派车。");
          var line = 0;
          foreach (var item in g.ITEMS)
          {
            ++line;
            item.ORDERLINENUMBER = line.ToString("000");
            item.ORDERKEY = head.ORDERKEY;
            item.TrackingState = TrackableEntities.TrackingState.Added;
            item.ORDERID = head.ID;
            item.REQUESTEDSHIPDATE = head.REQUESTEDSHIPDATE;
            item.DELIVERYDATE = head.DELIVERYDATE;
            head.ORDERDETAILS.Add(item);
          }
          var to1 = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == head.SUPPLIERCODE).FirstOrDefault()?.PHONENUMBER;

          if (!string.IsNullOrEmpty(head.CONTACTINFO) && head.CONTACTINFO.Length >= 11)
          {
            try
            {
              if (head.CONTACTINFO.Length == 11)
              {
                App_Helpers.QCloudHelper.SendSMSWithTPL(head.CONTACTINFO, 457903, head.ORDERKEY, head.DELIVERYDATE?.ToString("MM-dd"));
              }
              else
              {
                var re = new Regex(@"([\u0391-\uFFE5]+)(\d+)");
                var result = re.Match(head.CONTACTINFO);
                var alphaPart = result.Groups[1].Value;
                var numberPart = result.Groups[2].Value;
                if (numberPart.Length == 11)
                {
                  App_Helpers.QCloudHelper.SendSMSWithTPL(numberPart, 457903, head.ORDERKEY, head.DELIVERYDATE?.ToString("MM-dd"));
                }
              }
            }
            catch {
              if (!string.IsNullOrEmpty(to1))
              {
                App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 457903, head.ORDERKEY, head.DELIVERYDATE?.ToString("MM-dd"));
              }
            }
          }
          else
          {
            if (!string.IsNullOrEmpty(to1))
            {
              App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 457903, head.ORDERKEY, head.DELIVERYDATE?.ToString("MM-dd"));
            }
          }
          //var to2 = this.salesmanservice.Queryable().Where(x => x.Name == head.SALER).FirstOrDefault()?.PhoneNumber;
          //if (!string.IsNullOrEmpty(to2))
          //{
          //  App_Helpers.QCloudHelper.SendSMSWithTPL(to2, 424707, head.ORDERKEY, DateTime.Now.ToString("MM-dd HH:mm"));
          //}
          this.ApplyChanges(head);
        }
      }
    }
    public Stream ExportFinanceExcel(string filterRules = "", string sort = "ID", string order = "asc")
    {

      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "ORDER" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var orders = this.Query(new ORDERQuery().Withfilter170(filters)).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();
      var datarows = orders.Select(n => new
      {
        ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        SUPPLIERCODE=n.SUPPLIERCODE,
        SUPPLIERNAME = n.SUPPLIERNAME,
        n.EXTERNORDERKEY1,
        ORDERKEY = n.ORDERKEY,
        EXTERNORDERKEY = n.EXTERNORDERKEY,
        ORIGINAL = n.ORIGINAL,
        DESTINATION = n.DESTINATION,
        n.CONSIGNEEADDRESS,
        n.COST3NOTE,
        n.CONTACTINFO,
        n.LOTTABLE2,
        n.TOTALQTY,
        n.TOTALGROSSWGT,
        n.TOTALCUBE,
        n.TOTALCOST1,
        n.TOTALCOST3,
        n.SALER,
        n.SALESORG,
        n.NOTES,
        n.TRAILERNUMBER,
        n.DRIVERNAME,
        n.LOTTABLE4
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(ORDER), datarows);
    }

    public  void CreateOrder(ORDER entity) {
      this.ApplyChanges(entity);
      this.historyService.Append(entity.ORDERKEY, "", entity.STATUS, "新增运输计划", entity.LOTTABLE1, "新增运输计划,等待派车");
    }

    public void Delete(int[] id) {
      var items = this.Queryable().Where(x => id.Contains(x.ID));
      foreach (var item in items)
      {
        this.historyService.Append(item.ORDERKEY, "", item.STATUS, "删除记录", item.LOTTABLE1, "删除运输计划");
        this.Delete(item);
      }

    }
    //确认费用
    public void Confirm(int[] id) {
      var items = this.Queryable().Where(x => id.Contains(x.ID)).Include(x=>x.ORDERDETAILS).ToList();
      foreach (var item in items)
      {
        item.FLAG1 = true;
        foreach (var detail in item.ORDERDETAILS)
        {
          detail.FLAG1 = true;
          detail.TrackingState = TrackableEntities.TrackingState.Modified;
        }
        item.TrackingState = TrackableEntities.TrackingState.Modified;
        this.ApplyChanges(item);
        this.historyService.Append(item.ORDERKEY, "", item.STATUS, "运费确认", item.LOTTABLE1, "运费确认");
      }
      
     }
    //取消确认
    public void CancelConfirm(int id) {
      var items = this.Queryable().Where(x => x.ID==id).Include(x => x.ORDERDETAILS).ToList();
      foreach (var item in items)
      {
        item.FLAG1 = false;
        foreach (var detail in item.ORDERDETAILS)
        {
          detail.FLAG1 = false;
          detail.TrackingState = TrackableEntities.TrackingState.Modified;
        }
        item.TrackingState = TrackableEntities.TrackingState.Modified;
        this.ApplyChanges(item);
        this.historyService.Append(item.ORDERKEY, "", item.STATUS, "取消运费确认", item.LOTTABLE1, "取消运费确认");
      }
    }

    public Stream ExportExcel(string filterRules = "", string sort = "ID", string order = "asc") {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "ORDER" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var orders = this.Query(new ORDERQuery().Withfilter(filters)).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();
      var datarows = orders.Select(n => new
      {

        ORDERDETAILS = n.ORDERDETAILS,
        ID = n.ID,
        ORDERKEY = n.ORDERKEY,
        EXTERNORDERKEY = n.EXTERNORDERKEY,
        WHSEID = n.WHSEID,
        LOTTABLE2 = n.LOTTABLE2,
        ORIGINAL = n.ORIGINAL,
        DESTINATION = n.DESTINATION,
        TYPE = n.TYPE,
        SHPTYPE = n.SHPTYPE,
        STATUS = n.STATUS,
        STORERKEY = n.STORERKEY,
        SUPPLIERCODE = n.SUPPLIERCODE,
        SUPPLIERNAME = n.SUPPLIERNAME,
        ORDERDATE = n.ORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
        REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        DELIVERYDATE = n.DELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        LOTTABLE3 = n.LOTTABLE3,
        CONSIGNEEKEY = n.CONSIGNEEKEY,
        CONSIGNEENAME = n.CONSIGNEENAME,
        CONSIGNEEADDRESS = n.CONSIGNEEADDRESS,
        CARRIERNAME = n.CARRIERNAME,
        DRIVERNAME = n.DRIVERNAME,
        CARRIERPHONE = n.CARRIERPHONE,
        TRAILERNUMBER = n.TRAILERNUMBER,
        ACTUALSHIPDATE = n.ACTUALSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        CLOSEDDATE = n.CLOSEDDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        TOTALQTY = n.TOTALQTY,
        TOTALSHIPPEDQTY = n.TOTALSHIPPEDQTY,
        TOTALCASECNT = n.TOTALCASECNT,
        TOTALGROSSWGT = n.TOTALGROSSWGT,
        TOTALCUBE = n.TOTALCUBE,
        TOTALCOST1 = n.TOTALCOST1,
        CHECKEDCOST2 = n.CHECKEDCOST2,
        TOTALCOST2 = n.TOTALCOST2,
        CHECKEDCOST3 = n.CHECKEDCOST3,
        FLOOR = n.FLOOR,
        TOTALCOST3 = n.TOTALCOST3,
        CHECKEDCOST4 = n.CHECKEDCOST4,
        TOTALCOST4 = n.TOTALCOST4,
        CHECKEDCOST5 = n.CHECKEDCOST5,
        TOTALCOST5 = n.TOTALCOST5,
        CHECKEDCOST6 = n.CHECKEDCOST6,
        TOTALCOST6 = n.TOTALCOST6,
        CHECKEDCOST7 = n.CHECKEDCOST7,
        TOTALCOST7 = n.TOTALCOST7,
        CHECKEDCOST8 = n.CHECKEDCOST8,
        TOTALCOST8 = n.TOTALCOST8,
        NOTES = n.NOTES,
        FLAG1 = n.FLAG1,
        NOTES1 = n.NOTES1,
        FLAG2 = n.FLAG2,
        COMPANYCODE = n.COMPANYCODE,
        LOTTABLE1 = n.LOTTABLE1,
        LOTTABLE4 = n.LOTTABLE4,
        LOTTABLE5 = n.LOTTABLE5,
        LOTTABLE6 = n.LOTTABLE6,
        LOTTABLE7 = n.LOTTABLE7,
        LOTTABLE8 = n.LOTTABLE8?.ToString("yyyy-MM-dd HH:mm:ss")
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(ORDER), datarows, ignoredColumns);
    }


    public void SyncUpdate(int id) {
      var order = this.Find(id);
      var items = this.orderdetailservice.Queryable().Where(x => x.ORDERID == id).ToList();
      order.TOTALQTY = items.Sum(x => x.ORIGINALQTY);
      order.TOTALSHIPPEDQTY = items.Sum(x => x.SHIPPEDQTY);
      order.TOTALCASECNT = items.Sum(x => x.CASECNT);
      order.TOTALGROSSWGT = items.Where(x => x.SKUTYPE == "瓷砖").Sum(x => x.GROSSWGT);
      order.TOTALCUBE = items.Where(x => x.SKUTYPE == "洁具").Sum(x => x.CUBE);
      //order.TOTALCOST1 = items.Sum(x => x.COST1);
      //order.TOTALCOST2 = items.Sum(x => x.COST2);
      //order.TOTALCOST3 = items.Sum(x => x.COST3);
      //order.TOTALCOST4 = items.Sum(x => x.COST4);
      //order.TOTALCOST5 = items.Sum(x => x.COST5);
      //order.TOTALCOST6 = items.Sum(x => x.COST6);
      //order.TOTALCOST7 = items.Sum(x => x.COST7);
      //order.TOTALCOST8 = items.Sum(x => x.COST8);
      foreach (var item in items)
      {
        item.CHECKEDCOST1 = order.CHECKEDCOST1;
        item.CHECKEDCOST2 = order.CHECKEDCOST2;
        item.CHECKEDCOST3 = order.CHECKEDCOST3;
        item.CHECKEDCOST4 = order.CHECKEDCOST4;
        item.CHECKEDCOST5 = order.CHECKEDCOST5;
        item.CHECKEDCOST6 = order.CHECKEDCOST6;
        item.CHECKEDCOST7 = order.CHECKEDCOST7;
        item.CHECKEDCOST8 = order.CHECKEDCOST8;
        item.ORIGINAL = order.ORIGINAL;
        item.DESTINATION = order.DESTINATION;
        item.TYPE = order.TYPE;
        item.COST3NOTE = order.COST3NOTE;
        item.COST6NOTES = order.TOTALCOST6NOTES;
        item.CONSIGNEEADDRESS = order.CONSIGNEEADDRESS;
        item.SUPPLIERCODE = order.SUPPLIERCODE;
        item.SUPPLIERNAME = order.SUPPLIERNAME;
        //item.STATUS = order.STATUS;
        item.FLOOR = order.FLOOR;

      }
    }
  }
}



