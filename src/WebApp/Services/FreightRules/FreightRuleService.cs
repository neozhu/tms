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
  /// File: FreightRuleService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 2019/8/7 18:40:05
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class FreightRuleService : Service<FreightRule>, IFreightRuleService
  {
    private readonly IRepositoryAsync<FreightRule> repository;
    private readonly IDataTableImportMappingService mappingservice;
    public FreightRuleService(IRepositoryAsync<FreightRule> repository, IDataTableImportMappingService mappingservice)
        : base(repository)
    {
      this.repository = repository;
      this.mappingservice = mappingservice;
    }



    public void ImportDataTable(System.Data.DataTable datatable)
    {
      var mapping = this.mappingservice.Queryable().Where(x => x.EntitySetName == "FreightRule" && ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && !( x.DefaultValue == null || x.DefaultValue.Equals(string.Empty) ) ) )).ToList();
      if (mapping == null || mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到FreightRule对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      foreach (DataRow row in datatable.Rows)
      {
        var item = new FreightRule();
        var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null && !row.IsNull(requiredfield) && row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
        {
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString() != string.Empty)
            {
              var freightruletype = item.GetType();
              var propertyInfo = freightruletype.GetProperty(field.FieldName);
              var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
              var safeValue = ( row[field.SourceFieldName] == null ) ? null : Convert.ChangeType(row[field.SourceFieldName], safetype);
              propertyInfo.SetValue(item, safeValue, null);
            }
            else if (!string.IsNullOrEmpty(defval))
            {
              var freightruletype = item.GetType();
              var propertyInfo = freightruletype.GetProperty(field.FieldName);
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
          switch (item.SHPTYPE)
          {
            case "零担":
              item.SHPTYPE = "2";
              break;
            case "专车直送":
              item.SHPTYPE = "1";
              break;
            default:
              item.SHPTYPE = "2";
              break;
          }
          switch (item.CALTYPE)
          {
            case "吨":
              item.CALTYPE = "1";
              break;
            case "立方":
              item.CALTYPE = "2";
              break;
            default:
              item.CALTYPE = "1";
              break;
          }
          this.Insert(item);
        }
      }
    }
    public Stream ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "FreightRule" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var freightrules = this.Query(new FreightRuleQuery().Withfilter(filters)).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();
      var datarows = freightrules.Select(n => new
      {

        Id = n.Id,
        ORIGINAL = n.ORIGINAL,
        DESTINATION = n.DESTINATION,
        SHPTYPE =this.getshptypename(n.SHPTYPE),
        CALTYPE =this. getcaltypename(n.CALTYPE),
        CARLWT1 = n.CARLWT1,
        CARLWT2 = n.CARLWT2,
        PRICE = n.PRICE,
        MINAMOUNT = n.MINAMOUNT,
        STATUS = n.STATUS,
        DESCRIPTION = n.DESCRIPTION,
        LOTTABLE1 = n.LOTTABLE1,
        LOTTABLE2 = n.LOTTABLE2,
        LOTTABLE3 = n.LOTTABLE3
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(FreightRule), datarows, ignoredColumns);
    }

    private string getshptypename(string code) {
      switch (code)
      {
        case "1":
          return "专车直送";
        case "2":
          return "零担";
        default:
          return "零担";
      }
    }
    private string getcaltypename(string code) {
      switch (code)
      {
        case "1":
          return "吨";
        case "2":
          return "立方";
        case "3":
          return "立方/吨";
        default:
          return "吨";
      }
    }
  }
}



