using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using AutoMapper;
using Newtonsoft.Json;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Service.Pattern;
using WebApp.App_Helpers;
using WebApp.Models;
using WebApp.Models.ViewModel;
using WebApp.Repositories;

namespace WebApp.Services
{
  /// <summary>
  /// File: SHIPORDERService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 8/12/2019 9:08:20 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class SHIPORDERService : Service<SHIPORDER>, ISHIPORDERService
  {
    private readonly IRepositoryAsync<SHIPORDER> repository;
    private readonly IDataTableImportMappingService mappingservice;
    private readonly IORDERDETAILService orderdetailservice;
    private readonly ISHIPORDERDETAILService shipdetailservice;
    private readonly IORDERService orderservice;
    private readonly IFreightRuleService freightservice;
    private readonly IServiceRuleService serviceruleservice;
    private readonly IStatusHistoryService historyService;
    private readonly IVehicleService vehicleservice;
    private readonly IStandardCostService standardcostservice;
    private readonly ISalesmanService salesmanservice;
    private readonly ISUPPLIERService supplierservice;
    private readonly IMapper mapper;
    private readonly ICodeItemService codeItemService;
    public SHIPORDERService(
      ICodeItemService codeItemService,
      ISalesmanService salesmanservice,
      ISUPPLIERService supplierservice,
      IStandardCostService standardcostservice,
      IStatusHistoryService historyService,
      IVehicleService vehicleservice,
      IMapper mapper,
      ISHIPORDERDETAILService shipdetailservice,
      IORDERService orderservice,
      IORDERDETAILService orderdetailservice,
      IFreightRuleService freightservice,
      IServiceRuleService serviceruleservice,
    IRepositoryAsync<SHIPORDER> repository, IDataTableImportMappingService mappingservice)
        : base(repository)
    {
      this.mapper = mapper;
      this.orderservice = orderservice;
      this.freightservice = freightservice;
      this.orderdetailservice = orderdetailservice;
      this.serviceruleservice = serviceruleservice;
      this.repository = repository;
      this.mappingservice = mappingservice;
      this.vehicleservice = vehicleservice;
      this.shipdetailservice = shipdetailservice;
      this.historyService = historyService;
      this.standardcostservice = standardcostservice;
      this.supplierservice = supplierservice;
      this.salesmanservice = salesmanservice;
      this.codeItemService = codeItemService;
    }
    public IEnumerable<SHIPORDERDETAIL> GetSHIPORDERDETAILSBySHIPORDERID(int shiporderid) => this.repository.GetSHIPORDERDETAILSBySHIPORDERID(shiporderid);



    public void ImportDataTable(System.Data.DataTable datatable)
    {
      var mapping = this.mappingservice.Queryable().Where(x => x.EntitySetName == "SHIPORDER" && ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && !( x.DefaultValue == null || x.DefaultValue.Equals(string.Empty) ) ) )).ToList();
      if (mapping == null || mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到SHIPORDER对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      foreach (DataRow row in datatable.Rows)
      {
        var item = new SHIPORDER();
        var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null && !row.IsNull(requiredfield) && row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
        {
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString() != string.Empty)
            {
              var shipordertype = item.GetType();
              var propertyInfo = shipordertype.GetProperty(field.FieldName);
              var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
              var safeValue = ( row[field.SourceFieldName] == null ) ? null : Convert.ChangeType(row[field.SourceFieldName], safetype);
              propertyInfo.SetValue(item, safeValue, null);
            }
            else if (!string.IsNullOrEmpty(defval))
            {
              var shipordertype = item.GetType();
              var propertyInfo = shipordertype.GetProperty(field.FieldName);
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
      var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "SHIPORDER" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var shiporders = this.Query(new SHIPORDERQuery().Withfilter(filters)).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();
      var datarows = shiporders.Select(n => new
      {

        SHIPORDERDETAILS = n.SHIPORDERDETAILS,
        ID = n.ID,
        SHIPORDERKEY = n.SHIPORDERKEY,
        EXTERNSHIPORDERKEY = n.EXTERNSHIPORDERKEY,
        SHIPORDERDATE = n.SHIPORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
        STATUS = n.STATUS,
        TYPE = n.TYPE,
        ORIGINAL = n.ORIGINAL,
        DESTINATION = n.DESTINATION,
        PLATENUMBER = n.PLATENUMBER,
        DRIVERNAME = n.DRIVERNAME,
        DRIVERPHONE = n.DRIVERPHONE,
        CARRIERCODE = n.CARRIERCODE,
        CARRIERNAME = n.CARRIERNAME,
        SHIPPERKEY = n.SHIPPERKEY,
        SHIPPERNAME = n.SHIPPERNAME,
        SHIPPERADDRESS = n.SHIPPERADDRESS,
        CONSIGNEEKEY = n.CONSIGNEEKEY,
        CONSIGNEENAME = n.CONSIGNEENAME,
        CONSIGNEEADDRESS = n.CONSIGNEEADDRESS,
        REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALSHIPDATE = n.ACTUALSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        DELIVERYDATE = n.DELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        CLOSEDDATE = n.CLOSEDDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        TOTALQTY = n.TOTALQTY,
        TOTALSHIPPEDQTY = n.TOTALSHIPPEDQTY,
        TOTALCASECNT = n.TOTALCASECNT,
        TOTALGROSSWGT = n.TOTALGROSSWGT,
        TOTALCUBE = n.TOTALCUBE,
        STDKM = n.STDKM,
        KM1 = n.KM1,
        KM2 = n.KM2,
        ACTKM = n.ACTKM,
        STDOIL = n.STDOIL,
        OIL1 = n.OIL1,
        OIL2 = n.OIL2,
        ACTOIL = n.ACTOIL,
        STDLOADWEIGHT = n.STDLOADWEIGHT,
        STDLOADVOLUME = n.STDLOADVOLUME,
        FEELOADWEIGHT = n.FEELOADWEIGHT,
        LOADFACTOR1 = n.LOADFACTOR1,
        LOADFACTOR2 = n.LOADFACTOR2,
        CHECKEDCOST1 = n.CHECKEDCOST1,
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
        FLAG1 = n.FLAG1,
        NOTES1 = n.NOTES1,
        FLAG2 = n.FLAG2,
        NOTES = n.NOTES,
        COMPANYCODE = n.COMPANYCODE,
        LOTTABLE1 = n.LOTTABLE1,
        LOTTABLE2 = n.LOTTABLE2,
        LOTTABLE3 = n.LOTTABLE3,
        LOTTABLE4 = n.LOTTABLE4,
        LOTTABLE5 = n.LOTTABLE5,
        LOTTABLE6 = n.LOTTABLE6,
        LOTTABLE7 = n.LOTTABLE7,
        LOTTABLE8 = n.LOTTABLE8?.ToString("yyyy-MM-dd HH:mm:ss")
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(SHIPORDER), datarows, ignoredColumns);
    }
    //计算运费
    public CalTotalCostViewModel CalTotalCost(string original, string destination, decimal stdloadwt, string shptype, int[] orderdetailsid)
    {
      var result = new CalTotalCostViewModel();
      var orderid = this.orderdetailservice.Queryable().Where(x => orderdetailsid.Contains(x.ID)).Select(x => x.ORDERID).ToArray();
      var orders = this.orderservice.Queryable().Where(x => orderid.Contains(x.ID)).ToList();
      var shptypes = new[] {"专车直送", "零担"};
      var shptypename = shptypes[Convert.ToInt32(shptype) - 1];
      //先汇总重量和体积
      //考虑统一车的同一个客户的收货地址订单需要合并计算后再收费
      var groupbycustom = this.orderdetailservice.Queryable()
          .Where(x => orderdetailsid.Contains(x.ID))
          .Include(x => x.ORDER)
          .GroupBy(x => new { x.CHECKEDCOST1, x.SUPPLIERCODE, x.CONSIGNEEADDRESS, x.SKUTYPE, })
          .Select(x => new { x.Key, WGT = x.Sum(y => y.GROSSWGT), CUBE = x.Sum(y => y.CUBE), x });
      //计算整车
      if (shptype == "1")
      {
        var rule1 = this.freightservice.Queryable().Where(x => x.ORIGINAL == original &&
                                                    x.DESTINATION == destination &&
                                                    x.SHPTYPE == shptype 
                                                   ).FirstOrDefault();
        //计算运费
        if (rule1 == null)
        {
          result.TOTALCOST1 = 0;
          throw new Exception($"无法计算运费!请先维护[专车直送]报价规则，从[{original}]至[{destination}],运输方式[专车直送]。");
        }
        else
        {
          result.TOTALCOST1 = rule1.PRICE;
        }
      }
      //零担，需要根据体积，和重量来计算
      else
      {
        foreach (var g in groupbycustom)
        {
          if (!g.Key.CHECKEDCOST1)
          {
            result.TOTALCOST1 += g.x.Sum(y => y.ORDER.TOTALCOST1);
          }
          else
          {


            if (!string.IsNullOrEmpty(g.x.First().ORIGINAL) && !string.IsNullOrEmpty(g.x.First().DESTINATION))
            {//零担计费如果订单按订单维护的起始地目的地为准
              original = g.x.First().ORIGINAL;
              destination = g.x.First().DESTINATION;
            }
            var caltype = g.Key.SKUTYPE == "瓷砖" ? "1" : "2";
            var name = g.Key.SKUTYPE == "瓷砖" ? "每吨" : "每方";
            var rule2 = this.freightservice.Queryable().Where(x => x.ORIGINAL == original &&
                                                      x.DESTINATION == destination &&
                                                      x.SHPTYPE == shptype &&
                                                      x.CALTYPE == caltype
                                                     ).FirstOrDefault();
            if (rule2 == null)
            {
              result.TOTALCOST1 = 0;
              throw new Exception($"无法计算运费!请先维护[{shptypename}]报价规则，从[{original}]至[{destination}],计费方式[{name}]。");
            }
            else
            {
              if (caltype == "1")
              {
                var cal = ( g.WGT / 1000 ) * rule2.PRICE;
                if (cal < rule2.MINAMOUNT)
                {
                  cal = rule2.MINAMOUNT;
                }
                result.TOTALCOST1 += cal;
              }
              else
              {
                var cal = g.CUBE * rule2.PRICE;
                if (cal < rule2.MINAMOUNT)
                {
                  cal = rule2.MINAMOUNT;
                }
                result.TOTALCOST1 += cal;
              }

            }



          }
        }
        #region 注销掉
        //foreach (var order in orders)
        //{
        //  if (!order.CHECKEDCOST1)
        //  {
        //    result.TOTALCOST1 += order.TOTALCOST1;
        //  }
        //  else
        //  {
        //    var totalnum = this.orderdetailservice.Queryable().Where(x => x.ORDERID == order.ID)
        //      .GroupBy(x => new { x.ORDERKEY, x.SKUTYPE })
        //      .Select(n => new { n.Key, WGT = n.Sum(x => x.GROSSWGT), CUBE = n.Sum(x => x.CUBE) })
        //      .ToList();
        //    decimal totalcost1 = 0;
        //    foreach (var g in totalnum)
        //    {
        //      if (!string.IsNullOrEmpty(order.ORIGINAL) && !string.IsNullOrEmpty(order.DESTINATION))
        //      {//零担计费如果订单按订单维护的起始地目的地为准
        //        original = order.ORIGINAL;
        //        destination = order.DESTINATION;
        //      }
        //      var caltype = g.Key.SKUTYPE == "瓷砖" ? "1" : "2";
        //      var name = g.Key.SKUTYPE == "瓷砖" ? "每吨" : "每方";
        //      var rule2 = this.freightservice.Queryable().Where(x => x.ORIGINAL == original &&
        //                                                x.DESTINATION == destination &&
        //                                                x.CARLWT1 <= stdloadwt &&
        //                                                x.CARLWT2 >= stdloadwt &&
        //                                                x.SHPTYPE == shptype &&
        //                                                x.CALTYPE == caltype
        //                                               ).FirstOrDefault();

        //      if (rule2 == null)
        //      {
        //        result.TOTALCOST1 = 0;
        //        throw new Exception($"无法计算【{shptypename}】运费!请先维护报价规则，从[{original}]至[{destination}],运输车辆吨位[{stdloadwt}],按[{name}]。");
        //      }
        //      else
        //      {
        //        if (caltype == "1")
        //        {
        //          var cal = ( g.WGT / 1000 ) * rule2.PRICE;
        //          if (cal < rule2.MINAMOUNT)
        //          {
        //            cal = rule2.MINAMOUNT;
        //          }
        //          totalcost1 += cal;
        //        }
        //        else
        //        {
        //          var cal = g.CUBE * rule2.PRICE;
        //          if (cal < rule2.MINAMOUNT)
        //          {
        //            cal = rule2.MINAMOUNT;
        //          }
        //          totalcost1 += cal;
        //        }

        //      }

        //    }
        //    result.TOTALCOST1 += totalcost1;
        //  }
        //}
        #endregion
      }

      //计算服务费,送货费，搬运费，加急费，专车费，其它服务
      //decimal totalcost2, totalcost3, totalcost4, totalcost5, totalcost6;
      foreach (var g in groupbycustom)
      {

        var totalgwt = g.WGT;
        var wt = totalgwt / 1000M;
        if (wt > 0)
        {
          var order = g.x.First();
          if (order.CHECKEDCOST2)
          {
            var sr = this.serviceruleservice.Queryable().Where(x => x.NAME == "送货费" ).FirstOrDefault();
            if (sr == null)
            {
              throw new Exception($"无法计算送货费,请先维护服务项目报的价规则，[送货费]");
            }
            else
            {
              var calcost = wt * sr.PRICE;
              if (calcost < sr.MINAMOUNT)
              {
                calcost = sr.MINAMOUNT;
              }
              result.TOTALCOST2 += calcost;
            }
          }
          if (order.CHECKEDCOST3)
          {

            var floor = order.FLOOR <= 0 ? 1 : order.FLOOR;
            var note = order.COST3NOTE;

            var sr = this.serviceruleservice.Queryable().Where(x => x.NAME == note ).FirstOrDefault();
            if (sr == null)
            {
              throw new Exception($"无法计算搬运费,请先维护服务项目报的价规则,[{note}]");
            }
            else
            {
              var calcost = wt * sr.PRICE * floor;
              if (calcost < sr.MINAMOUNT)
              {
                calcost = sr.MINAMOUNT;
              }
              result.TOTALCOST3 += calcost;
            }

          }
          if (order.CHECKEDCOST4)
          {

            var sr = this.serviceruleservice.Queryable().Where(x => x.NAME == "加急费" ).FirstOrDefault();
            if (sr == null)
            {
              throw new Exception($"无法计算加急费,请先维护服务项目报的价规则,[加急费]");
            }
            else
            {
              var calcost = wt * sr.PRICE;
              if (calcost < sr.MINAMOUNT)
              {
                calcost = sr.MINAMOUNT;
              }
              result.TOTALCOST4 += calcost;
            }

          }
          if (order.CHECKEDCOST5)
          {

            var sr = this.serviceruleservice.Queryable().Where(x => x.NAME == "专车费").FirstOrDefault();
            if (sr == null)
            {
              throw new Exception($"无法计算专车费,请先维护服务项目报的价规则,[专车费] ");
            }
            else
            {
              var calcost = wt * sr.PRICE;
              if (calcost < sr.MINAMOUNT)
              {
                calcost = sr.MINAMOUNT;
              }
              result.TOTALCOST5 += calcost;
            }

          }
          if (order.CHECKEDCOST6)
          {
            //手工制定费用，不参与计算
            result.TOTALCOST6 += g.x.First().ORDER.TOTALCOST6;


          }
        }

      }
      return result;
    }
    //创建派车单
    public void PostCreateShipOrder(SHIPORDER header, int[] orderdetailsid,string user)
    {
      //this.Insert(header);
      var status = "110";
      var orderdetails = this.orderdetailservice.Queryable().Where(x => orderdetailsid.Contains(x.ID)).ToList();
      var orderidarray = orderdetails.Select(x => x.ORDERID).Distinct().ToArray();
      var orders = this.orderservice.Queryable().Where(x => orderidarray.Contains(x.ID)).ToList();
      var shptypes = new[] { "零担", "专车直送" };
      var shptypename = shptypes[Convert.ToInt32(header.SHPTYPE) - 1];
      header.TOTALCOST1 = 0;
      header.TOTALCOST2 = 0;
      header.TOTALCOST3 = 0;
      header.TOTALCOST4 = 0;
      header.TOTALCOST5 = 0;
      header.TOTALCOST6 = 0;
      //合并计算费用根据客户和收货地址
      var groupbycustom = this.orderdetailservice.Queryable()
          .Where(x => orderdetailsid.Contains(x.ID))
          .Include(x => x.ORDER)
          .GroupBy(x => new { x.CHECKEDCOST1, x.SUPPLIERCODE, x.CONSIGNEEADDRESS, x.SKUTYPE, })
          .Select(x => new { x.Key, WGT = x.Sum(y => y.GROSSWGT), CUBE = x.Sum(y => y.CUBE), x });

      //计算运费
      //整车运费
      if (header.SHPTYPE == "1")
      {

        var rule = this.freightservice.Queryable().Where(x => x.ORIGINAL == header.ORIGINAL &&
                                                    x.DESTINATION == header.DESTINATION &&
                                                    x.SHPTYPE == header.SHPTYPE
                                                    ).FirstOrDefault();
        if (rule != null)
        {
          header.TOTALCOST1 += rule.PRICE;
          //分摊运费根据货物重量分摊运费
          var totalgwt = orderdetails.Sum(x => x.GROSSWGT);
          if (totalgwt > 0)
          {
            foreach (var orderdetail in orderdetails)
            {
              //分摊比例
              var ratio = orderdetail.GROSSWGT / totalgwt;
              orderdetail.COST1 = header.TOTALCOST1 * ratio;

            }
          }


        }
        else
        {
          throw new Exception($"无法计算运费!请先维护[专车直送]报价规则，从[{header.ORIGINAL}]至[{header.DESTINATION}], 运输方式[专车直送]。");
        }
      }
      else //零担
      {
        foreach (var g in groupbycustom)
        {
          //先根据订单/货物类型分组计算出总的运费，再分摊到每个明细行上
          //根据物料类型，洁具按体积，瓷砖按重量
          if (g.Key.CHECKEDCOST1)
          {
            var caltype = g.Key.SKUTYPE == "瓷砖" ? "1" : "2";
            var name = g.Key.SKUTYPE == "瓷砖" ? "每吨" : "每方";
            var original = string.IsNullOrEmpty(g.x.First().ORIGINAL) ? header.ORIGINAL : g.x.First().ORIGINAL;
            var destination = string.IsNullOrEmpty(g.x.First().DESTINATION) ? header.DESTINATION : g.x.First().DESTINATION;
            var shptype = g.x.First().ORDER.SHPTYPE;
            var rule = this.freightservice.Queryable().Where(x => x.ORIGINAL == original &&
                                                    x.DESTINATION == destination &&
                                                    x.SHPTYPE == shptype &&
                                                    x.CALTYPE == caltype
                                                    ).FirstOrDefault();
            if (rule != null)
            {
              //判断取重量还是体积
              var num = 0M;
              var totalgwt = g.WGT;
              var totalcube = g.CUBE;
              if (caltype == "1")
              {
                num = totalgwt / 1000M;

              }
              else
              {
                num = totalcube;
              }
              var amount = num * rule.PRICE;
              if (amount < rule.MINAMOUNT)
              {
                //由于汇总计算出来的运费小于最小计费（起步价），这里需要对订单明细按总价进行分摊
                amount = rule.MINAMOUNT;
              }
              //分摊运费
              foreach (var orderdetail in g.x)
              {
                orderdetail.UNITCOST1= rule.PRICE;
                if (caltype == "1")
                {
                  if (totalgwt > 0)
                  {
                    var ratio = orderdetail.GROSSWGT / totalgwt;
                    orderdetail.COST1 = amount * ratio;
                 
                  }
                  else
                  {
                    orderdetail.COST1 = 0;
                  }
                }
                else
                {
                  if (totalcube > 0)
                  {
                    var ratio = orderdetail.CUBE / totalcube;
                    orderdetail.COST1 = amount * ratio;
                  }
                  else
                  {
                    orderdetail.COST1 = 0;
                  }
                }
              }
              header.TOTALCOST1 += amount;
            }
            else
            {
              throw new Exception($"无法计算运费!请先维护[{shptypename}]报价规则，从[{header.ORIGINAL}]至[{header.DESTINATION}],计费方式[{name}].");
            }

          }
          else
          {
            //如果是一口价，不用计算，但需要考虑分摊运费
            var totalgwt = g.WGT;
            var totalcube = g.CUBE;
            var caltype = g.Key.SKUTYPE == "瓷砖" ? "1" : "2";
            var amount = g.x.First().ORDER.TOTALCOST1;
            foreach (var orderdetail in g.x)
            {
              if (caltype == "1")
              {
                if (totalgwt > 0)
                {
                  var ratio = orderdetail.GROSSWGT / totalgwt;
                  orderdetail.COST1 = amount * ratio;
                }
                else
                {
                  orderdetail.COST1 = 0;
                }
              }
              else
              {
                if (totalcube > 0)
                {
                  var ratio = orderdetail.CUBE / totalcube;
                  orderdetail.COST1 = amount * ratio;
                }
                else
                {
                  orderdetail.COST1 = 0;
                }
              }
            }

            header.TOTALCOST1 += amount;
          }

        }
      }
      //计算服务费
      //先根据订单/货物类型分组计算出总的运费，再分摊到每个明细行上
      foreach (var g in groupbycustom)
      {
        var totalgwt = g.WGT;
        var wt = totalgwt / 1000M;
        if (g.x.First().ORDER.CHECKEDCOST2)
        {
          var rule = this.serviceruleservice.Queryable().Where(x => x.NAME == "送货费" ).FirstOrDefault();
          if (rule != null)
          {
            var amount = totalgwt / 1000M * rule.PRICE;
            if (amount < rule.MINAMOUNT)
            {
              //由于汇总计算出来的服务费小于最小计费（起步价），这里需要对订单明细按总价进行分摊
              amount = rule.MINAMOUNT;
            }
            //分摊费用
            foreach (var orderdetail in g.x)
            {

              var ratio = orderdetail.GROSSWGT / totalgwt;
              orderdetail.COST2 = amount * ratio;
            }
            header.TOTALCOST2 += amount;
          }
          else
          {
            throw new Exception($"无法计算送货费,请先维护服务项目报的价规则，[送货费]");
          }
        }
        //计算搬运费
        if (g.x.First().ORDER.CHECKEDCOST3)
        {
          var floor = g.x.First().ORDER.FLOOR <= 0 ? 1 : g.x.First().ORDER.FLOOR;
          var note = g.x.First().ORDER.COST3NOTE;
          var rule = this.serviceruleservice.Queryable().Where(x => x.NAME == note ).FirstOrDefault();
          if (rule != null)
          {
            var amount = totalgwt / 1000M * rule.PRICE * floor;
            if (amount < rule.MINAMOUNT)
            {
              //由于汇总计算出来的服务费小于最小计费（起步价），这里需要对订单明细按总价进行分摊
              amount = rule.MINAMOUNT;
            }
            //再计算一次每个明细行的服务费
            foreach (var orderdetail in g.x)
            {
              orderdetail.UNITCOST3 = rule.PRICE;
              var ratio = orderdetail.GROSSWGT / totalgwt;
              orderdetail.COST3 = amount * ratio;
            }

            header.TOTALCOST3 += amount;
          }
          else
          {
            throw new Exception($"无法计算搬运费,请先维护服务项目报的价规则");
          }
        }
        if (g.x.First().ORDER.CHECKEDCOST4)
        {
          var rule = this.serviceruleservice.Queryable().Where(x => x.NAME == "加急费" ).FirstOrDefault();
          if (rule != null)
          {
            var amount = totalgwt / 1000M * rule.PRICE;
            if (amount < rule.MINAMOUNT)
            {
              //由于汇总计算出来的服务费小于最小计费（起步价），这里需要对订单明细按总价进行分摊
              amount = rule.MINAMOUNT;

            }
            foreach (var orderdetail in g.x)
            {
              var ratio = orderdetail.GROSSWGT / totalgwt;
              orderdetail.COST4 = amount * ratio;
            }
            header.TOTALCOST4 += amount;
          }
          else
          {
            throw new Exception($"无法计算加急费,请先维护服务项目报的价规则，[加急费]");
          }
        }
        if (g.x.First().ORDER.CHECKEDCOST5)
        {
          var rule = this.serviceruleservice.Queryable().Where(x => x.NAME == "专车费").FirstOrDefault();
          if (rule != null)
          {
            var amount = totalgwt / 1000M * rule.PRICE;
            if (amount < rule.MINAMOUNT)
            {
              //由于汇总计算出来的服务费小于最小计费（起步价），这里需要对订单明细按总价进行分摊
              amount = rule.MINAMOUNT;

            }
            foreach (var orderdetail in g.x)
            {
              var ratio = orderdetail.GROSSWGT / totalgwt;
              orderdetail.COST5 = amount * ratio;
            }
            header.TOTALCOST5 += amount;
          }
          else
          {
            throw new Exception($"无法计算专车费,请先维护服务项目报的价规则，[专车费] ");
          }
        }
        if (g.x.First().ORDER.CHECKEDCOST6)
        {
          //手工制定费用，不参与计算
          var amount = g.x.First().ORDER.TOTALCOST6;
          //再计算一次每个明细行的服务费
          foreach (var orderdetail in g.x)
          {
            var ratio = orderdetail.GROSSWGT / totalgwt;
            orderdetail.COST6 = amount * ratio;
          }
          header.TOTALCOST6 += amount;
        }

      }

      foreach (var order in orders)
      {
        
        
        foreach (var g in groupbycustom)
        {
          foreach (var orderdetail in g.x.Where(x=>x.ORDERID==order.ID))
          {
            orderdetail.LOTTABLE4 = header.SHIPORDERKEY;
            orderdetail.SHIPPEDQTY = orderdetail.ORIGINALQTY;
            orderdetail.STATUS = status;
            orderdetail.CARRIERNAME = header.CARRIERNAME;
            orderdetail.CARRIERPHONE = header.DRIVERPHONE;
            orderdetail.DRIVERNAME = header.DRIVERNAME;
            orderdetail.TRAILERNUMBER = header.PLATENUMBER;
            this.orderdetailservice.Update(orderdetail);
            order.ORDERDETAILS.Add(orderdetail);
            
          }
         
        }
        order.TOTALCOST1 =Math.Round( order.ORDERDETAILS.Sum(x => x.COST1), 2);
        order.TOTALCOST2 = Math.Round(order.ORDERDETAILS.Sum(x => x.COST2), 2);
        order.TOTALCOST3 = Math.Round(order.ORDERDETAILS.Sum(x => x.COST3), 2);
        order.TOTALCOST4 = Math.Round(order.ORDERDETAILS.Sum(x => x.COST4), 2);
        order.TOTALCOST5 = Math.Round(order.ORDERDETAILS.Sum(x => x.COST5), 2);
        order.TOTALCOST6 = Math.Round(order.ORDERDETAILS.Sum(x => x.COST6), 2);
        order.STATUS = status;
        order.CARRIERNAME = header.CARRIERNAME;
        order.CARRIERPHONE = header.DRIVERPHONE;
        order.DRIVERNAME = header.DRIVERNAME;
        order.TRAILERNUMBER = header.PLATENUMBER;
        order.ORIGINAL = string.IsNullOrEmpty(order.ORIGINAL) ? header.ORIGINAL : order.ORIGINAL;
        order.DESTINATION = string.IsNullOrEmpty(order.DESTINATION) ? header.DESTINATION : order.DESTINATION;
        order.TOTALSHIPPEDQTY = orderdetails.Where(x => x.ORDERID == order.ID).Sum(x => x.SHIPPEDQTY);
        order.LOTTABLE4 = header.SHIPORDERKEY;
        this.orderservice.Update(order);
        this.historyService.Append(order.ORDERKEY, header.SHIPORDERKEY, status, "创建派车计划", user, $"运单号：{header.SHIPORDERKEY},等待司机接单");
        this.sendSMS(header, order);
      }
      
      header.TOTALSERVICECOST = header.TOTALCOST2 + header.TOTALCOST3 + header.TOTALCOST4 + header.TOTALCOST5 + header.TOTALCOST6 + header.TOTALCOST7 + header.TOTALCOST8;
      header.TrackingState = TrackableEntities.TrackingState.Added;
      header.STATUS = status;
      //再次计算成本和毛利
      var standarcost = this.standardcostservice.GetDataRule(header.ORIGINAL, header.DESTINATION, header.STDLOADWEIGHT);
      if (standarcost != null)
      {
        header.STDKM = standarcost.STDKM;
        header.STDOIL = standarcost.STDOIL;
        header.STDCOST = standarcost.STDCOST;
        header.GROSSMARGINS = header.TOTALCOST1 - header.STDCOST;
        if (header.TOTALCOST1 == 0)
        {
          header.GROSSMARGINSRATE = 0;
        }
        else
        {
          header.GROSSMARGINSRATE = header.GROSSMARGINS / ( header.TOTALCOST1 );
        }
      }
      else
      {
        header.STDKM = 0;
        header.STDOIL = 0;
        header.STDCOST = 0;
        header.GROSSMARGINS = 0;
        header.GROSSMARGINSRATE = 0;
      }
      //更新添加派车明细
      foreach (var g in groupbycustom)
      {
        foreach (var detail in g.x)
        {
          detail.STATUS = status;
          var shipdetail = this.mapper.Map<SHIPORDERDETAIL>(detail);
          shipdetail.SHIPORDERKEY = header.SHIPORDERKEY;
          shipdetail.EXTERNSHIPORDERKEY = header.EXTERNSHIPORDERKEY;
          shipdetail.TYPE = header.TYPE;
          shipdetail.TrackingState = TrackableEntities.TrackingState.Added;
          shipdetail.SHIPORDERDATE = header.SHIPORDERDATE;
          header.SHIPORDERDETAILS.Add(shipdetail);
        }
      }
      this.ApplyChanges(header);
      var p = this.vehicleservice.Queryable().Where(x => x.PlateNumber == header.PLATENUMBER).FirstOrDefault();
      var gps = GPSHelper.GetLocState(p?.GPSDeviceId);
      this.historyService.Append("", header.SHIPORDERKEY, status, "创建派车单成功", user, $"运单号：{header.SHIPORDERKEY},等待司机接单,当前位置:{gps?.result.gpsLocatinAddr}",gps?.result.lon, gps?.result.lat);
      //更新车辆状态
      this.vehicleservice.UpdateStatus(header.PLATENUMBER, header.STATUS, header.SHIPORDERKEY, header.LOTTABLE1);
    }

    private void sendSMS(SHIPORDER header, ORDER order)
    {
      var to1 = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == order.SUPPLIERCODE).FirstOrDefault()?.PHONENUMBER;
      if (!string.IsNullOrEmpty(order.CONTACTINFO) && order.CONTACTINFO.Length >= 11)
      {
        try
        {
          if (order.CONTACTINFO.Length == 11)
          {
            App_Helpers.QCloudHelper.SendSMSWithTPL(order.CONTACTINFO, 457899, order.ORDERKEY, header.PLATENUMBER, header.DRIVERNAME + header.DRIVERPHONE, header.SHIPORDERKEY, order.REQUESTEDSHIPDATE?.ToString("MM-dd"));
          }
          else
          {
            var re = new Regex(@"([\u0391-\uFFE5]+)(\d+)");
            var result = re.Match(order.CONTACTINFO);
            var alphaPart = result.Groups[1].Value;
            var numberPart = result.Groups[2].Value;
            if (numberPart.Length == 11)
            {
              App_Helpers.QCloudHelper.SendSMSWithTPL(numberPart, 761502, header.DRIVERNAME , header.DRIVERPHONE);
              //App_Helpers.QCloudHelper.SendSMSWithTPL(numberPart, 457899, order.ORDERKEY, header.PLATENUMBER, header.DRIVERNAME + header.DRIVERPHONE, header.SHIPORDERKEY, order.REQUESTEDSHIPDATE?.ToString("MM-dd"));
            }
          }
        }
        catch
        {
          if (!string.IsNullOrEmpty(to1))
          {
            App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 761502, header.DRIVERNAME, header.DRIVERPHONE);
            //App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 457899, order.ORDERKEY, header.PLATENUMBER, header.DRIVERNAME + header.DRIVERPHONE, header.SHIPORDERKEY, order.REQUESTEDSHIPDATE?.ToString("MM-dd"));
          }
        }
      }
      else
      {
        if (!string.IsNullOrEmpty(to1))
        {
          App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 761502, header.DRIVERNAME, header.DRIVERPHONE);
          //App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 457899, order.ORDERKEY, header.PLATENUMBER, header.DRIVERNAME + header.DRIVERPHONE, header.SHIPORDERKEY, order.REQUESTEDSHIPDATE?.ToString("MM-dd"));
        }
      }

      //if (!string.IsNullOrEmpty(to1))
      //{
      //  App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 457899, order.ORDERKEY, header.PLATENUMBER, header.DRIVERNAME + header.DRIVERPHONE, header.SHIPORDERKEY, DateTime.Now.ToString("MM-dd HH:mm"));
      //}
      //var to2 = this.salesmanservice.Queryable().Where(x => x.Name == order.SALER).FirstOrDefault()?.PhoneNumber;
      //if (!string.IsNullOrEmpty(to2))
      //{
      //  App_Helpers.QCloudHelper.SendSMSWithTPL(to2, 457899, order.ORDERKEY, header.PLATENUMBER, header.DRIVERNAME + header.DRIVERPHONE, header.SHIPORDERKEY, DateTime.Now.ToString("MM-dd HH:mm"));
      //}
    }

    //打印派车单，修改状态
    public void DoPrint(int id,string user)
    {
      var head = this.Find(id);
      var now = DateTime.Now;
      var status = "120";

      var details = this.shipdetailservice.Queryable().Where(x => x.SHIPORDERID == id);
      foreach (var detail in details)
      {
        detail.STATUS = status;
        detail.ACTUALSHIPDATE = now;
        this.shipdetailservice.Update(detail);

      }
      var orderskey = details.Select(x => x.ORDERKEY).Distinct().ToArray();
      var orders = this.orderservice.Queryable().Where(x => orderskey.Contains(x.ORDERKEY));
      var orderdetails = this.orderdetailservice.Queryable().Where(x => orderskey.Contains(x.ORDERKEY));
      foreach (var order in orders)
      {
        order.STATUS = status;
        order.ACTUALSHIPDATE = now;
        this.orderservice.Update(order);
        this.historyService.Append(order.ORDERKEY, head.SHIPORDERKEY, status, "司机已接单", user, "司机已接单,准备去提货");
      }
      foreach (var detail in orderdetails)
      {
        detail.STATUS = status;
        detail.ACTUALSHIPDATE = now;
        this.orderdetailservice.Update(detail);
      }
      //获取设备ID,用于获取GSP定位
      var devid = this.vehicleservice.GetDevId(head.PLATENUMBER);
      if (!string.IsNullOrEmpty(devid))
      {
        var gps_location = GPSHelper.GetLocState(devid);
        if (gps_location != null && gps_location.error == 0)
        {
          this.historyService.Append("", head.SHIPORDERKEY, status, "司机已接单", user, $"司机已接单,准备去提货,当前地址:{gps_location.result.gpsLocatinAddr}",  gps_location.result.lon, gps_location.result.lat);
        }
      }
      else
      {
        this.historyService.Append("", head.SHIPORDERKEY, status, "司机已接单", user, "司机已接单,准备去提货");
      }

      this.vehicleservice.UpdateStatus(head.PLATENUMBER, status, head.SHIPORDERKEY, user);
      head.STATUS = status;
      head.ACTUALSHIPDATE = now;
      this.Update(head);


    }
    //运输完成，修改状态
    public void DoCompleted(int id,string user)
    {
      var head = this.Find(id);
      var now = DateTime.Now;
      var status = "170";
      
      var details = this.shipdetailservice.Queryable().Where(x => x.SHIPORDERID == id);
      foreach (var detail in details)
      {
        detail.STATUS = status;
        detail.ACTUALDELIVERYDATE = now;
        this.shipdetailservice.Update(detail);

      }
      var orderskey = details.Select(x => x.ORDERKEY).Distinct().ToArray();
      var orders = this.orderservice.Queryable().Where(x => orderskey.Contains(x.ORDERKEY));
      var orderdetails = this.orderdetailservice.Queryable().Where(x => orderskey.Contains(x.ORDERKEY));
      foreach (var order in orders)
      {
        order.STATUS = status;
        order.ACTUALDELIVERYDATE = now;
        this.orderservice.Update(order);
        this.historyService.Append(order.ORDERKEY, head.SHIPORDERKEY, status, "派送完成", user, "派送完成!");
        var to1 = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == order.SUPPLIERCODE).FirstOrDefault()?.PHONENUMBER;
        if (!string.IsNullOrEmpty(to1))
        {
          App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 424723, head.SHIPORDERKEY, head.PLATENUMBER, head.DRIVERNAME, head.DRIVERPHONE, order.ORDERKEY, DateTime.Now.ToString("MM-dd HH:mm"));
        }
        var to2 = this.salesmanservice.Queryable().Where(x => x.Name == order.SALER).FirstOrDefault()?.PhoneNumber;
        if (!string.IsNullOrEmpty(to2))
        {
          App_Helpers.QCloudHelper.SendSMSWithTPL(to2, 424723, head.SHIPORDERKEY, head.PLATENUMBER, head.DRIVERNAME, head.DRIVERPHONE, order.ORDERKEY, DateTime.Now.ToString("MM-dd HH:mm"));
        }
      }
      foreach (var detail in orderdetails)
      {
        detail.STATUS = status;
        detail.ACTUALDELIVERYDATE = now;
        this.orderdetailservice.Update(detail);
      }
      //获取设备ID,用于获取GSP定位
      var devid = this.vehicleservice.GetDevId(head.PLATENUMBER);
      if (!string.IsNullOrEmpty(devid))
      {
        var gps_location = GPSHelper.GetLocState(devid);
        if (gps_location != null && gps_location.error == 0)
        {
          this.historyService.Append("", head.SHIPORDERKEY, status, "运单送货完成", user, $"运单送货完成,当前地址:{gps_location.result.gpsLocatinAddr}",  gps_location.result.lon, gps_location.result.lat);
        }
      }
      else
      {
        this.historyService.Append("", head.SHIPORDERKEY, status, "派送完成", user, "派送完成");
      }

      this.vehicleservice.UpdateStatus(head.PLATENUMBER, status, head.SHIPORDERKEY, user);
      head.STATUS = status;
      head.ACTUALDELIVERYDATE = now;
      this.Update(head);


    }
    public void DoClosed(int id,string user)
    {
      var head = this.Find(id);
      var now = DateTime.Now;
      var status = "190";

      var details = this.shipdetailservice.Queryable().Where(x => x.SHIPORDERID == id);
      foreach (var detail in details)
      {
        detail.STATUS = status;
        detail.LOTTABLE9 = now;
        this.shipdetailservice.Update(detail);

      }
      var orderskey = details.Select(x => x.ORDERKEY).Distinct().ToArray();
      var orders = this.orderservice.Queryable().Where(x => orderskey.Contains(x.ORDERKEY));
      var orderdetails = this.orderdetailservice.Queryable().Where(x => orderskey.Contains(x.ORDERKEY));
      foreach (var order in orders)
      {
        order.STATUS = status;
        order.CLOSEDDATE = now;
        this.orderservice.Update(order);
        this.historyService.Append(order.ORDERKEY, head.SHIPORDERKEY, status, "结案", user, "结案");
        //var to1 = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == order.SUPPLIERCODE).FirstOrDefault()?.PHONENUMBER;
        //if (!string.IsNullOrEmpty(to1))
        //{
        //  App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 424723, head.SHIPORDERKEY, head.PLATENUMBER, head.DRIVERNAME, head.DRIVERPHONE, order.ORDERKEY, DateTime.Now.ToString("MM-dd HH:mm"));
        //}
        //var to2 = this.salesmanservice.Queryable().Where(x => x.Name == order.SALER).FirstOrDefault()?.PhoneNumber;
        //if (!string.IsNullOrEmpty(to2))
        //{
        //  App_Helpers.QCloudHelper.SendSMSWithTPL(to2, 424723, head.SHIPORDERKEY, head.PLATENUMBER, head.DRIVERNAME, head.DRIVERPHONE, order.ORDERKEY, DateTime.Now.ToString("MM-dd HH:mm"));
        //}
      }
      foreach (var detail in orderdetails)
      {
        detail.STATUS = status;
        detail.LOTTABLE9 = now;
        this.orderdetailservice.Update(detail);
      }
      //获取设备ID,用于获取GSP定位
      var devid = this.vehicleservice.GetDevId(head.PLATENUMBER);
      if (!string.IsNullOrEmpty(devid))
      {
        var gps_location = GPSHelper.GetLocState(devid);
        if (gps_location != null && gps_location.error == 0)
        {
          this.historyService.Append("", head.SHIPORDERKEY, status, "结案", user, $"运单结案,当前地址:{gps_location.result.gpsLocatinAddr}", gps_location.result.lon, gps_location.result.lat);
        }
      }
      else
      {
        this.historyService.Append("", head.SHIPORDERKEY, status, "结案", user, "结案");
      }

      //this.vehicleservice.UpdateStatus(head.PLATENUMBER, status, head.SHIPORDERKEY, user);
      head.STATUS = status;
      head.CLOSEDDATE = now;
      this.Update(head);

    }
    public ShipOrderTrackViewModel GetTracks(int id)
    {

      var item = this.Find(id);
      var viewmodel = this.mapper.Map<ShipOrderTrackViewModel>(item);
      var devid = this.vehicleservice.GetDevId(viewmodel.PLATENUMBER);
      var gps = GPSHelper.GetLocState(devid);
      if (gps!=null && gps.error == 0)
      {
       
        viewmodel.LATITUDE = Convert.ToDecimal(gps.result.lat);
        viewmodel.LONGITUDE = Convert.ToDecimal(gps.result.lon);
        viewmodel.Speed = gps.result.speed;
        viewmodel.dayMileage = gps.result.dayMileage;
        viewmodel.mileage = gps.result.mileage;
        viewmodel.location = gps.result.gpsLocatinAddr;
        viewmodel.isstopState = gps.result.isstopState;
      }
      if (viewmodel.DELIVERYDATE != null && viewmodel.ACTUALDELIVERYDATE == null)
      {
        var ts = DateTime.Now.Subtract(viewmodel.DELIVERYDATE.Value).Duration();
        if (ts.TotalMinutes > 0)
        {
          if (ts.Days > 0)
          {
            viewmodel.STATUS = $"已超过指定时间{ts.Days}天";
          }
          else if (ts.Hours > 0)
          {
            viewmodel.STATUS = $"已超过指定时间{ts.Hours}小时";
          }
          else if (ts.Minutes > 0)
          {
            viewmodel.STATUS = $"已超过指定时间{ts.Minutes}分钟";
          }
          else
          {
            viewmodel.STATUS = "正常";
          }
        }

      }
      else
      {
        if (viewmodel.DELIVERYDATE.Value >= viewmodel.ACTUALDELIVERYDATE.Value)
        {
          viewmodel.STATUS = "正常送达";
        }
        else
        {
          viewmodel.STATUS = "超时送达";
        }

      }
      viewmodel.devIdno = devid;
      return viewmodel;
    }

    public void NotifyLocToCustom(int id, string loc)
    {
      var head = this.Find(id);
      var orders = this.orderservice.Queryable().Where(x => x.LOTTABLE4 == head.SHIPORDERKEY).ToList();
      foreach (var order in orders)
      {

        //var to1 = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == order.SUPPLIERCODE).FirstOrDefault()?.PHONENUMBER;
        //if (!string.IsNullOrEmpty(to1))
        //{
        //  App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 424728, head.SHIPORDERKEY, head.PLATENUMBER, head.DRIVERNAME, head.DRIVERPHONE, order.ORDERKEY, loc, DateTime.Now.ToString("MM-dd HH:mm"));
        //}
        var to2 = this.salesmanservice.Queryable().Where(x => x.Name == order.SALER).FirstOrDefault()?.PhoneNumber;
        if (!string.IsNullOrEmpty(to2))
        {
          App_Helpers.QCloudHelper.SendSMSWithTPL(to2, 424728, head.SHIPORDERKEY, head.PLATENUMBER, head.DRIVERNAME, head.DRIVERPHONE, order.ORDERKEY, loc, DateTime.Now.ToString("MM-dd HH:mm"));
        }
        try
        {
          if (order.CONTACTINFO.Length == 11)
          {
            App_Helpers.QCloudHelper.SendSMSWithTPL(order.CONTACTINFO, 457903, order.ORDERKEY, order.DELIVERYDATE?.ToString("MM-dd"));
          }
          else
          {
            var re = new Regex(@"([\u0391-\uFFE5]+)(\d+)");
            var result = re.Match(order.CONTACTINFO);
            var alphaPart = result.Groups[1].Value;
            var numberPart = result.Groups[2].Value;
            if (numberPart.Length == 11)
            {
              App_Helpers.QCloudHelper.SendSMSWithTPL(numberPart, 457903, order.ORDERKEY, order.DELIVERYDATE?.ToString("MM-dd"));
            }
          }
        }
        catch
        {
          if (!string.IsNullOrEmpty(to2))
          {
            App_Helpers.QCloudHelper.SendSMSWithTPL(to2, 457903, order.ORDERKEY, order.DELIVERYDATE?.ToString("MM-dd"));
          }
        }

        
      }

    }
    //取消派车单，回滚订单状态
    public void Cancle(int[] id,string user)
    {
      var shiporders = this.Queryable().Where(x => id.Contains(x.ID)).Include(x => x.SHIPORDERDETAILS).ToList();
      var status = "100";
      foreach (var head in shiporders)
      {
        foreach (var orderkey in head.SHIPORDERDETAILS.Select(x => x.ORDERKEY).Distinct())
        {

          var order = this.orderservice.Queryable().Where(x => x.ORDERKEY == orderkey).FirstOrDefault();
          if (order != null)
          {
            order.STATUS = status;
            order.TOTALCOST2 = 0;
            order.TOTALCOST3 = 0;
            order.TOTALCOST4 = 0;
            order.TOTALCOST5 = 0;
            order.TOTALCOST6 = 0;
            order.CARRIERNAME = null;
            order.CARRIERPHONE = null;
            order.DRIVERNAME = null;
            order.TRAILERNUMBER = null;
            //order.ORIGINAL = header.ORIGINAL;
            //order.DESTINATION = header.DESTINATION;
            order.TOTALSHIPPEDQTY = 0;
            order.LOTTABLE4 = null;
            this.orderservice.Update(order);
            this.historyService.Append(order.ORDERKEY, "", status, "取消派车", user, $"取消派车，等待重新派车");
          }
        }
        foreach (var detail in head.SHIPORDERDETAILS)
        {
          var orderdetail = this.orderdetailservice.Queryable().Where(x => x.ORDERKEY == detail.ORDERKEY && x.ORDERLINENUMBER == detail.ORDERLINENUMBER).First();
          orderdetail.LOTTABLE4 = status;
          orderdetail.STATUS = status;
          orderdetail.COST2 = 0;
          orderdetail.COST3 = 0;
          orderdetail.COST4 = 0;
          orderdetail.COST5 = 0;
          orderdetail.COST6 = 0;
          this.orderdetailservice.Update(orderdetail);
        }
        this.historyService.Append("", head.SHIPORDERKEY, status, "取消派车计划", user, "取消派车计划");
        this.Delete(head);
        this.vehicleservice.UpdateStatus(head.PLATENUMBER, "170", head.SHIPORDERKEY, user);

      }

    }



    public IEnumerable<ShipOrderTrackViewModel> GetTrackList()
    {
      var status = new string[] { "120", "130", "140", "150" };
      var codeitems = this.codeItemService.Queryable().Where(x => x.CodeType == "shipstatus").ToList();
      var list = this.vehicleservice.Queryable().ToList(); //this.Queryable().Where(x => status.Contains(x.STATUS)).ToList();
      var tracklist = new List<ShipOrderTrackViewModel>();
      foreach (var item in list)
      {
        var track = new ShipOrderTrackViewModel();
        var shiporder = this.Queryable().Where(x => status.Contains(x.STATUS) && x.PLATENUMBER == item.PlateNumber).FirstOrDefault();
        if (shiporder != null)
        {
          track = this.mapper.Map<ShipOrderTrackViewModel>(shiporder);
        }
        else
        {
          track.PLATENUMBER = item.PlateNumber;
          track.DRIVERNAME = item.Driver;
          track.DRIVERPHONE = item.DriverPhone;
        }
        var devid = item.GPSDeviceId;
        var gps = GPSHelper.GetLocState(devid);
        track.STATUS = codeitems.Where(x => x.Code == track.STATUS).FirstOrDefault()?.Text;
        if (gps !=null && gps.error == 0)
        {
          //var pos = gps.infos.First().pos;
          var lat = Convert.ToDecimal(gps.result.lat);
          var lon = Convert.ToDecimal(gps.result.lon);


          track.LATITUDE = lat;
          track.LONGITUDE = lon;
          track.location = gps.result.gpsLocatinAddr;
          track.Speed = gps.result.speed;
          track.dayMileage = gps.result.dayMileage;
          track.mileage = gps.result.mileage;
          track.isstopState = gps.result.isstopState;
        }

        tracklist.Add(track);
      }


      return tracklist;

    }
  }
}



