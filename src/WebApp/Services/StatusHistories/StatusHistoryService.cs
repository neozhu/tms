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
  /// File: StatusHistoryService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 8/13/2019 3:05:19 PM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class StatusHistoryService : Service<StatusHistory>, IStatusHistoryService
  {
    private readonly IRepositoryAsync<StatusHistory> repository;
    private readonly IDataTableImportMappingService mappingservice;
    public StatusHistoryService(IRepositoryAsync<StatusHistory> repository, IDataTableImportMappingService mappingservice)
        : base(repository)
    {
      this.repository = repository;
      this.mappingservice = mappingservice;
    }



    public void ImportDataTable(System.Data.DataTable datatable)
    {
      var mapping = this.mappingservice.Queryable().Where(x => x.EntitySetName == "StatusHistory" && ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && !( x.DefaultValue == null || x.DefaultValue.Equals(string.Empty) ) ) )).ToList();
      if (mapping == null || mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到StatusHistory对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      foreach (DataRow row in datatable.Rows)
      {
        var item = new StatusHistory();
        var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null && !row.IsNull(requiredfield) && row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
        {
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString() != string.Empty)
            {
              var statushistorytype = item.GetType();
              var propertyInfo = statushistorytype.GetProperty(field.FieldName);
              var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
              var safeValue = ( row[field.SourceFieldName] == null ) ? null : Convert.ChangeType(row[field.SourceFieldName], safetype);
              propertyInfo.SetValue(item, safeValue, null);
            }
            else if (!string.IsNullOrEmpty(defval))
            {
              var statushistorytype = item.GetType();
              var propertyInfo = statushistorytype.GetProperty(field.FieldName);
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
    public Stream ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "StatusHistory" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var statushistories = this.Query(new StatusHistoryQuery().Withfilter(filters)).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();
      var datarows = statushistories.Select(n => new
      {

        Id = n.Id,
        ORDERKEY = n.ORDERKEY,
        SHIPORDERKEY = n.SHIPORDERKEY,
        STATUS = n.STATUS,
        DESCRIPTION = n.DESCRIPTION,
        REMARK = n.REMARK,
        TRANSACTIONDATETIME = n.TRANSACTIONDATETIME.ToString("yyyy-MM-dd HH:mm:ss"),
        USER = n.USER,
        LONGITUDE = n.LONGITUDE,
        LATITUDE = n.LATITUDE
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(StatusHistory), datarows, ignoredColumns);
    }

    public void Append(string orderkey, string shiporderkey, string status, string description, string user, string remark="", decimal? longitude = 0, decimal? latitude = 0) {
      var item = new StatusHistory()
      {
        ORDERKEY = orderkey,
        SHIPORDERKEY = shiporderkey,
        DESCRIPTION = description,
        LATITUDE = latitude==null?0: latitude.Value,
        LONGITUDE = latitude == null ?0: latitude.Value,
        STATUS = status,
        TRANSACTIONDATETIME = DateTime.Now,
        USER = user,
        REMARK=remark
      };
      this.Insert(item);

      }
  }
}



