using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using Repository.Pattern.Infrastructure;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
namespace WebApp.Services
{
  /// <summary>
  /// File: SHIPORDERDETAILService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 8/12/2019 8:47:30 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class SHIPORDERDETAILService : Service<SHIPORDERDETAIL>, ISHIPORDERDETAILService
  {
    private readonly IRepositoryAsync<SHIPORDERDETAIL> repository;
    private readonly IDataTableImportMappingService mappingservice;
    public SHIPORDERDETAILService(IRepositoryAsync<SHIPORDERDETAIL> repository, IDataTableImportMappingService mappingservice)
        : base(repository)
    {
      this.repository = repository;
      this.mappingservice = mappingservice;
    }
    public IEnumerable<SHIPORDERDETAIL> GetBySHIPORDERID(int shiporderid) => repository.GetBySHIPORDERID(shiporderid);



    private int getSHIPORDERIDBySHIPORDERKEY(string shiporderkey)
    {
      var shiporderRepository = this.repository.GetRepository<SHIPORDER>();
      var shiporder = shiporderRepository.Queryable().Where(x => x.SHIPORDERKEY == shiporderkey).FirstOrDefault();
      if (shiporder == null)
      {
        throw new Exception("not found ForeignKey:SHIPORDERID with " + shiporderkey);
      }
      else
      {
        return shiporder.ID;
      }
    }
    public void ImportDataTable(System.Data.DataTable datatable)
    {
      var mapping = this.mappingservice.Queryable().Where(x => x.EntitySetName == "SHIPORDERDETAIL" && ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && !( x.DefaultValue == null || x.DefaultValue.Equals(string.Empty) ) ) )).ToList();
      if (mapping == null || mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到SHIPORDERDETAIL对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      foreach (DataRow row in datatable.Rows)
      {
        var item = new SHIPORDERDETAIL();
        var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null && !row.IsNull(requiredfield) && row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
        {
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString() != string.Empty)
            {
              var shiporderdetailtype = item.GetType();
              var propertyInfo = shiporderdetailtype.GetProperty(field.FieldName);
              //关联外键查询获取Id
              switch (field.FieldName)
              {
                case "SHIPORDERID":
                  var shiporderkey = row[field.SourceFieldName].ToString();
                  var shiporderid = this.getSHIPORDERIDBySHIPORDERKEY(shiporderkey);
                  propertyInfo.SetValue(item, Convert.ChangeType(shiporderid, propertyInfo.PropertyType), null);
                  break;
                default:
                  var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                  var safeValue = ( row[field.SourceFieldName] == null ) ? null : Convert.ChangeType(row[field.SourceFieldName], safetype);
                  propertyInfo.SetValue(item, safeValue, null);
                  break;
              }
            }
            else if (!string.IsNullOrEmpty(defval))
            {
              var shiporderdetailtype = item.GetType();
              var propertyInfo = shiporderdetailtype.GetProperty(field.FieldName);
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
          this.Insert(item);
        }
      }
    }
    public Stream ExportExcel(string filterRules = "", string sort = "ID", string order = "asc")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "SHIPORDERDETAIL" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var shiporderdetails = this.Query(new SHIPORDERDETAILQuery().Withfilter(filters)).Include(p => p.SHIPORDER).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();

      
      foreach (var item in shiporderdetails)
      {
        item.COST1 = 0;
        item.COST2 = 0;
        item.COST3 = 0;
        item.COST4 = 0;
        item.COST5 = 0;
        item.COST6 = 0;
        item.COST7 = 0;
        item.COST8 = 0;
      }
      foreach (var shipno in shiporderdetails.Select(x => x.SHIPORDERKEY).Distinct())
      {
        var first = shiporderdetails.Where(x => x.SHIPORDERKEY == shipno).First();
        var head = this.GetShipOrderHead(shipno);
        if (head != null)
        {
          first.COST1 = head.TOTALCOST1;
          first.COST2 = head.TOTALCOST2;
          first.COST3 = head.TOTALCOST3;
          first.COST4 = head.TOTALCOST4;
          first.COST5 = head.TOTALCOST5;
          first.COST6 = head.TOTALCOST6;
          first.COST7 = head.TOTALCOST7;
          first.COST8 = head.TOTALCOST8;

        }
      }
      var datarows = shiporderdetails.Select(n => new
      {
        SHIPORDERKEY = n.SHIPORDERKEY,
        ORIGINAL = n.ORIGINAL,
        DESTINATION = n.DESTINATION,
        EXTERNSHIPORDERKEY = n.EXTERNSHIPORDERKEY,
        ORDERLINENUMBER = n.ORDERLINENUMBER,
        SHPTYPE = PublicPara.CodeText.Data.CodeListSet.CLS.Code2Value("shptype", n.SHPTYPE),
        STATUS = PublicPara.CodeText.Data.CodeListSet.CLS.Code2Value("shipstatus", n.STATUS),
        ORDERDATE = n.ORDERDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALSHIPDATE = n.ACTUALSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        CARRIERNAME = n.CARRIERNAME,
        DRIVERNAME = n.DRIVERNAME,
        CARRIERPHONE = n.CARRIERPHONE,
        TRAILERNUMBER = n.TRAILERNUMBER,
        SUPPLIERCODE = n.SUPPLIERCODE,
        SUPPLIERNAME = n.SUPPLIERNAME,
        LOTTABLE3 = n.LOTTABLE3,
        CONSIGNEEADDRESS = n.CONSIGNEEADDRESS,
        STORERKEY = n.STORERKEY,
        SKU = n.SKU,
        SKUTYPE = n.SKUTYPE,
        SKUNAME = n.SKUNAME,
        ORIGINALQTY = n.ORIGINALQTY,
        SHIPPEDQTY = n.SHIPPEDQTY,
        UMO = n.UMO,
        PACKKEY = n.PACKKEY,
        CASECNT = n.CASECNT,
        GROSSWGT = n.GROSSWGT,
        NETWGT = n.NETWGT,
        CUBE = n.CUBE,
        NOTES = n.NOTES,
        SALER = n.SALER,
        SALESORG = n.SALESORG,
        CHECKEDCOST1 = n.CHECKEDCOST1,
        COST1 = n.COST1>0? n.COST1.ToString():"",
        CHECKEDCOST2 = n.CHECKEDCOST2,
        COST2 = n.COST2 > 0 ? n.COST2.ToString() : "",
        CHECKEDCOST3 = n.CHECKEDCOST3,
        COST3NOTE = n.COST3NOTE,
        FLOOR = n.FLOOR,
        COST3 = n.COST3 > 0 ? n.COST3.ToString() : "",
        CHECKEDCOST4 = n.CHECKEDCOST4,
        COST4 = n.COST4 > 0 ? n.COST4.ToString() : "",
        CHECKEDCOST5 = n.CHECKEDCOST5,
        COST5 = n.COST5 > 0 ? n.COST5.ToString() : "",
        CHECKEDCOST6 = n.CHECKEDCOST6,
        COST6 = n.COST6 > 0 ? n.COST6.ToString() : "",
        CHECKEDCOST7 = n.CHECKEDCOST7,
        COST7 = n.COST7 > 0 ? n.COST7.ToString() : "",
        CHECKEDCOST8 = n.CHECKEDCOST8,
        COST8 = n.COST8 > 0 ? n.COST8.ToString() : "",
        ORDERKEY = n.ORDERKEY,
        LOTTABLE2 = n.LOTTABLE2,
        EXTERNORDERKEY = n.EXTERNORDERKEY,
        FLAG1 = n.FLAG1,
        FLAG2 = n.FLAG2,
        NOTES1 = n.NOTES1,
        REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        DELIVERYDATE = n.DELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),

        WHSEID = n.WHSEID,

        LOTTABLE1 = n.LOTTABLE1,
        EXTERNLINENO = n.EXTERNLINENO,
        TYPE = n.TYPE,

        COMPANYCODE = n.COMPANYCODE,
        CONTACTINFO = n.CONTACTINFO,
        REQUIREMENTS = n.REQUIREMENTS,
        LOTTABLE4 = n.LOTTABLE4,
        LOTTABLE5 = n.LOTTABLE5,
        LOTTABLE6 = n.LOTTABLE6,
        LOTTABLE7 = n.LOTTABLE7,
        LOTTABLE8 = n.LOTTABLE8?.ToString("yyyy-MM-dd HH:mm:ss"),
        LOTTABLE9 = n.LOTTABLE9?.ToString("yyyy-MM-dd HH:mm:ss"),
        LOTTABLE10 = n.LOTTABLE10,
        FACTORY = n.FACTORY,
        SHOP = n.SHOP,
        CHANNEL = n.CHANNEL,
        DELIVERYVOUCHER = n.DELIVERYVOUCHER,
        SALESDEP = n.SALESDEP,
        SHIPORDERDATE = n.SHIPORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
        SHIPORDERID = n.SHIPORDERID
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(SHIPORDERDETAIL), datarows, ignoredColumns);
    }


    private SHIPORDER GetShipOrderHead(string shipno) {
      var shiporder = this.repository.GetRepositoryAsync<SHIPORDER>().Queryable().Where(x => x.SHIPORDERKEY == shipno).FirstOrDefault();
      return shiporder;

    }
  }
}



