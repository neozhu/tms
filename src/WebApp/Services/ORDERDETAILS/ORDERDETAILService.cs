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
namespace WebApp.Services
{
  /// <summary>
  /// File: ORDERDETAILService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 2019/8/8 7:20:02
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class ORDERDETAILService : Service<ORDERDETAIL>, IORDERDETAILService
  {
    private readonly IRepositoryAsync<ORDERDETAIL> repository;
    private readonly IDataTableImportMappingService mappingservice;
    public ORDERDETAILService(IRepositoryAsync<ORDERDETAIL> repository, IDataTableImportMappingService mappingservice)
        : base(repository)
    {
      this.repository = repository;
      this.mappingservice = mappingservice;
    }
    public IEnumerable<ORDERDETAIL> GetByORDERID(int orderid) => this.repository.GetByORDERID(orderid);



    private int getORDERIDByORDERKEY(string orderkey)
    {
      var orderRepository = this.repository.GetRepository<ORDER>();
      var order = orderRepository.Queryable().Where(x => x.ORDERKEY == orderkey).FirstOrDefault();
      if (order == null)
      {
        throw new Exception("not found ForeignKey:ORDERID with " + orderkey);
      }
      else
      {
        return order.ID;
      }
    }
    public void ImportDataTable(System.Data.DataTable datatable)
    {
      var mapping = this.mappingservice.Queryable().Where(x => x.EntitySetName == "ORDERDETAIL" && ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && !( x.DefaultValue == null || x.DefaultValue.Equals(string.Empty) ) ) )).ToList();
      if (mapping == null || mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到ORDERDETAIL对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      foreach (DataRow row in datatable.Rows)
      {
        var item = new ORDERDETAIL();
        var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null && !row.IsNull(requiredfield) && row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
        {
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString() != string.Empty)
            {
              var orderdetailtype = item.GetType();
              var propertyInfo = orderdetailtype.GetProperty(field.FieldName);
              //关联外键查询获取Id
              switch (field.FieldName)
              {
                case "ORDERID":
                  var orderkey = row[field.SourceFieldName].ToString();
                  var orderid = this.getORDERIDByORDERKEY(orderkey);
                  propertyInfo.SetValue(item, Convert.ChangeType(orderid, propertyInfo.PropertyType), null);
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
          this.Insert(item);
        }
      }
    }
    public Stream ExportExcel(string filterRules = "", string sort = "ID", string order = "asc")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      //var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "ORDERDETAIL" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var orderdetails = this.Query(new ORDERDETAILQuery().Withfilter(filters)).Include(p => p.ORDER).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();

      var datarows = orderdetails.Select(n => new
      {
        ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        n.SUPPLIERCODE,
        n.SUPPLIERNAME,
        n.EXTERNORDERKEY1,
        n.ORDERKEY,
        n.EXTERNORDERKEY,
       n.WHSEID,
        n.ORIGINAL,
        n.DESTINATION,
        n.CONSIGNEEADDRESS,
        n.COST3NOTE,
        n.CONTACTINFO,
        n.SKU,
        n.LOTTABLE2,
        n.ORIGINALQTY,
        n.GROSSWGT,
        n.CUBE,
        n.UNITCOST1,
        n.COST1,
        n.UNITCOST3,
        n.COST3,
        n.SALER,
        n.SALESORG,
        n.NOTES,
        n.TRAILERNUMBER,
        n.DRIVERNAME,
        n.CARRIERPHONE,
        n.LOTTABLE4
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(ORDERDETAIL), datarows);
    }
  }
}



