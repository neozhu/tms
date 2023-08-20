using System;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using Repository.Pattern.Infrastructure;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace WebApp.Services
{
  /// <summary>
  /// File: WaybillService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 2020/6/24 16:53:54
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class WaybillService : Service<Waybill>, IWaybillService
  {
    private readonly IRepositoryAsync<Waybill> repository;
    private readonly IDataTableImportMappingService mappingservice;
    private readonly IFreightRuleService freightservice;
    private readonly IServiceRuleService serviceruleservice;
    private readonly NLog.ILogger logger;
    public WaybillService(
      IFreightRuleService freightservice,
      IServiceRuleService serviceruleservice,
    IRepositoryAsync<Waybill> repository,
      IDataTableImportMappingService mappingservice,
      NLog.ILogger logger
      )
        : base(repository)
    {
      this.repository = repository;
      this.mappingservice = mappingservice;
      this.logger = logger;
      this.freightservice = freightservice;
      this.serviceruleservice = serviceruleservice;
    }



    public async Task ImportDataTableAsync(DataTable datatable, string username)
    {
      var mapping = await this.mappingservice.Queryable()
                        .Where(x => x.EntitySetName == "Waybill" &&
                           ( x.IsEnabled == true || ( x.IsEnabled == false && x.DefaultValue != null ) )
                           ).ToListAsync();
      if (mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到Waybill对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      foreach (DataRow row in datatable.Rows)
      {

        var requiredfield = mapping.Where(x => x.IsRequired == true && x.IsEnabled == true && x.DefaultValue == null).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null ||
          (!row.IsNull(requiredfield) &&
           !string.IsNullOrEmpty(row[requiredfield].ToString())
          )
          )
        {
          var item = new Waybill();
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain &&
              !row.IsNull(field.SourceFieldName) &&
              !string.IsNullOrEmpty(row[field.SourceFieldName].ToString())
              )
            {
              var waybilltype = item.GetType();
              var propertyInfo = waybilltype.GetProperty(field.FieldName);
              var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
              var safeValue = Convert.ChangeType(row[field.SourceFieldName], safetype);
              propertyInfo.SetValue(item, safeValue, null);
            }
            else if (!string.IsNullOrEmpty(defval))
            {
              var waybilltype = item.GetType();
              var propertyInfo = waybilltype.GetProperty(field.FieldName);
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
              else if (string.Equals(defval, "user", StringComparison.OrdinalIgnoreCase))
              {
                propertyInfo.SetValue(item, username, null);
              }
              else
              {
                var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var safeValue = Convert.ChangeType(defval, safetype);
                propertyInfo.SetValue(item, safeValue, null);
              }
            }
          }
          if (item.Weight == null || item.Weight.Value == 0)
          {
            item.Flag = false;
          }
          else
          {
            item.Flag = true;
          }
          this.Insert(item);
        }
      }
    }
    public async Task<Stream> ExportExcelAsync(string filterRules = "", string sort = "Id", string order = "asc")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var expcolopts = await this.mappingservice.Queryable()
             .Where(x => x.EntitySetName == "Waybill")
             .Select(x => new ExpColumnOpts()
             {
               EntitySetName = x.EntitySetName,
               FieldName = x.FieldName,
               IgnoredColumn = x.IgnoredColumn,
               SourceFieldName = x.SourceFieldName
             }).ToArrayAsync();

      var waybills = this.Query(new WaybillQuery().Withfilter(filters)).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();
      var datarows = waybills.Select(n => new
      {

        Id = n.Id,
        OrderNo = n.OrderNo,
        Status = n.Status,
        CustomerId = n.CustomerId,
        CustomerName = n.CustomerName,
        ProjectNo = n.ProjectNo,
        PickNo = n.PickNo,
        ShippedDate = n.ShippedDate.ToString("yyyy-MM-dd HH:mm:ss"),
        Original = n.Original,
        Destination = n.Destination,
        Remark = n.Remark,
        ProductNo = n.ProductNo,
        LotNo = n.LotNo,
        Qty = n.Qty,
        Weight = n.Weight,
        Cube = n.Cube,
        SPrice = n.SPrice,
        SAmount = n.SAmount,
        CPrice = n.CPrice,
        CAmount = n.CAmount,
        Way = n.Way,
        Sales = n.Sales,
        SalesGroup = n.SalesGroup,
        Remark1 = n.Remark1,
        Remark2 = n.Remark2,
        Flag = n.Flag,
        Driver = n.Driver,
        Transport = n.Transport
      }).ToList();
      return await NPOIHelper.ExportExcelAsync("运单报表", datarows, expcolopts);
    }
    public async Task Delete(int[] id)
    {
      var items = await this.Queryable().Where(x => id.Contains(x.Id)).ToListAsync();
      foreach (var item in items)
      {
        this.Delete(item);
      }

    }
    //确认并计算费用
    public async Task Confirm(int[] id)
    {
      var list = await this.Queryable().Where(x => id.Contains(x.Id)).ToListAsync();
      foreach (var item in list)
      {
        item.Status = "已确认";
        this.Update(item);
      }
      var group = list.GroupBy(x => new { x.ShippedDate.Date, x.Remark2, x.Original, x.Destination })
        .Select(x => new
        {
          x.Key.Remark2,
          x.Key.Date,
          x.Key.Original,
          x.Key.Destination,
          weight = x.Sum(y => y.Weight),
          cube = x.Sum(y => y.Cube),
          items = x.ToList()
        }).ToList();

      foreach (var g in group)
      {
        //计算重货的重量
        var totalweigth = g.items.Where(x => x.Flag).Sum(x => x.Weight);
        //汇总体积
        var totalcub = g.items.Where(x => !x.Flag).Sum(x => x.Cube);
        //开始计算运费
        var totalamount = 0m;
        var minamount = 0m;
        if (totalweigth > 0 )
        {
          var rule = this.freightservice.Queryable().Where(x => x.DESTINATION == g.Destination && x.ORIGINAL == g.Original && x.CALTYPE == "1").FirstOrDefault();
          if (rule == null)
          {
            throw new Exception($"{g.Original} 至 {g.Destination} 按 [每吨] 计费的规则没有维护,请先维护好规则再试.");
          }
          var amount = ( ( totalweigth.Value / 1000m ) * rule.PRICE );
          totalamount += amount;
          minamount = rule.MINAMOUNT;
          //更新单价
          foreach (var sub in g.items.Where(x=>x.Flag))
          {
            sub.SPrice = rule.PRICE;
          }
        }
        if (totalcub > 0)
        {
          var rule = this.freightservice.Queryable().Where(x => x.DESTINATION == g.Destination && x.ORIGINAL == g.Original && x.CALTYPE == "2").FirstOrDefault();
          if (rule == null)
          {
            throw new Exception($"{g.Original} 至 {g.Destination} 按 [立方] 计费的规则没有维护,请先维护好规则再试.");
          }

          var amount = ( ( totalcub.Value  ) * rule.PRICE );
          totalamount += amount;
          minamount = rule.MINAMOUNT;
          //更新单价
          foreach (var sub in g.items.Where(x => !x.Flag))
          {
            sub.SPrice = rule.PRICE;
          }
        }
        if (totalamount < minamount)
        {
          totalamount = minamount;
         }
        //计算搬运费
        var totalserviceamount = 0m;
        var minserviceamount = 0m;
        var services = g.items.Where(x=>x.Way!="不卸").GroupBy(x => new { x.Flag, x.Way })
          .Select(x => new { x.Key.Flag,
          x.Key.Way,
          w=x.Sum(y=>y.Weight),
          v=x.Sum(y=>y.Cube) });
        foreach (var sg in services)
        {
          if (!string.IsNullOrEmpty(sg.Way))
          {
            var service = this.serviceruleservice.Queryable().Where(x => x.NAME == sg.Way).FirstOrDefault();
            if (service == null)
            {
              throw new Exception($"{sg.Way} 卸货方式没有维护,请先维护好规则再试.");
            }
            minserviceamount = service.MINAMOUNT;

            if (sg.Flag)
            {
              var amount = ( ( sg.w.Value / 1000m ) * service.PRICE );
              totalserviceamount += amount;
            }
            else
            {
              var amount = ( ( sg.v.Value  ) * service.LOTTABLE3 );
              totalserviceamount += amount;
            }

            //更新单价
            foreach (var sub in g.items.Where(x => !x.Flag))
            {
              sub.CPrice = service.LOTTABLE3;
            }
            foreach (var sub in g.items.Where(x => x.Flag))
            {
              sub.CPrice = service.PRICE;
            }
          }
        }
        if (totalserviceamount < minserviceamount)
        {
          totalserviceamount = minserviceamount;
        }
         
      

        var first = g.items.OrderBy(x => x.OrderNo).ThenBy(x => x.Id).First();
        first.SAmount = totalamount;
        first.CAmount = totalserviceamount;
        this.Update(first);
      }
    }
    
  }
}



