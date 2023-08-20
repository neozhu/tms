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
/// File: StandardCostService.cs
/// Purpose: Within the service layer, you define and implement 
/// the service interface and the data contracts (or message types).
/// One of the more important concepts to keep in mind is that a service
/// should never expose details of the internal processes or 
/// the business entities used within the application. 
/// Created Date: 9/12/2019 1:48:34 PM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    public class StandardCostService : Service< StandardCost >, IStandardCostService
    {
        private readonly IRepositoryAsync<StandardCost> repository;
		private readonly IDataTableImportMappingService mappingservice;
        public  StandardCostService(IRepositoryAsync< StandardCost> repository,IDataTableImportMappingService mappingservice)
            : base(repository)
        {
            this.repository=repository;
			this.mappingservice = mappingservice;
        }
                  
        
        		 
                public void ImportDataTable(System.Data.DataTable datatable)
        {
            var mapping = this.mappingservice.Queryable().Where(x => x.EntitySetName == "StandardCost" && ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && !( x.DefaultValue == null || x.DefaultValue.Equals(string.Empty) ) ) )).ToList();
            if (mapping == null || mapping.Count == 0)
            {
                throw new KeyNotFoundException("没有找到StandardCost对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
            }
            foreach (DataRow row in datatable.Rows)
            {
                var item = new StandardCost();
                var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
                if (requiredfield != null && !row.IsNull(requiredfield) &&  row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
                {
                    foreach (var field in mapping)
                    {
						var defval = field.DefaultValue;
						var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
						if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString()!=string.Empty )
						{
                            var standardcosttype = item.GetType();
							var propertyInfo = standardcosttype.GetProperty(field.FieldName);
                            							        var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                                    var safeValue = (row[field.SourceFieldName] == null) ? null : Convert.ChangeType(row[field.SourceFieldName], safetype);
                                    propertyInfo.SetValue(item, safeValue, null);
						                            }
						else if (!string.IsNullOrEmpty(defval))
						{
							var standardcosttype = item.GetType();
							var propertyInfo = standardcosttype.GetProperty(field.FieldName);
							if (string.Equals(defval, "now", StringComparison.OrdinalIgnoreCase) && (propertyInfo.PropertyType ==typeof(DateTime) || propertyInfo.PropertyType == typeof(Nullable<DateTime>)))
                            {
                                var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                                var safeValue = Convert.ChangeType(DateTime.Now, safetype);
                                propertyInfo.SetValue(item, safeValue, null);
                            }
                            else if(string.Equals(defval, "guid", StringComparison.OrdinalIgnoreCase))
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
				public Stream ExportExcel(string filterRules = "",string sort = "Id", string order = "asc")
        {
            var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "StandardCost" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
                                   var standardcosts  = this.Query(new StandardCostQuery().Withfilter(filters)).OrderBy(n=>n.OrderBy(sort,order)).Select().ToList();
                        var datarows = standardcosts .Select(  n => new { 

    Id = n.Id,
    ORIGINAL = n.ORIGINAL,
    DESTINATION = n.DESTINATION,
    STDKM = n.STDKM,
    CarType = n.CarType,
    STDLOADWEIGHT = n.STDLOADWEIGHT,
    STDOIL = n.STDOIL,
    STDCOST = n.STDCOST,
    DESCRIPTION = n.DESCRIPTION,
    Notes = n.Notes,
    LOTTABLE1 = n.LOTTABLE1,
    LOTTABLE2 = n.LOTTABLE2,
    LOTTABLE3 = n.LOTTABLE3
}).ToList();
            return ExcelHelper.ExportExcel(typeof(StandardCost), datarows,ignoredColumns);
        }
        public void Delete(int[] id) {
            var items = this.Queryable().Where(x => id.Contains(x.Id));
            foreach (var item in items)
            {
               this.Delete(item);
            }

        }

    public StandardCost GetDataRule(string original, string destination, decimal stdloadweight)
    {
      var item = this.Queryable().Where(x => x.ORIGINAL == original && x.DESTINATION == destination && x.STDLOADWEIGHT == stdloadweight).FirstOrDefault();
      if (item == null)
      {

        return this.Queryable().Where(x => x.ORIGINAL == original && x.DESTINATION == destination).FirstOrDefault();

      }
      return item;
    }
  }
}



