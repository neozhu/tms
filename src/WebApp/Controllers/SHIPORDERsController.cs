using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using TrackableEntities;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;
using Z.EntityFramework.Plus;
namespace WebApp.Controllers
{
  /// <summary>
  /// File: SHIPORDERsController.cs
  /// Purpose:业务操作/派车单信息
  /// Created Date: 8/12/2019 9:08:23 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<SHIPORDER>, Repository<SHIPORDER>>();
  ///    container.RegisterType<ISHIPORDERService, SHIPORDERService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("SHIPORDERs")]
  public class SHIPORDERsController : Controller
  {
    private readonly ISHIPORDERService sHIPORDERService;
    private readonly IUnitOfWorkAsync unitOfWork;
    private readonly IORDERService orderservice;
    private readonly IORDERDETAILService orderdetailservice;
    private readonly IMapper mapper;
    public SHIPORDERsController(
      IMapper mapper,
      IORDERService orderservice,
      IORDERDETAILService orderdetailservice,
      ISHIPORDERService sHIPORDERService, IUnitOfWorkAsync unitOfWork)
    {
      this.mapper = mapper;
      this.orderdetailservice = orderdetailservice;
      this.orderservice = orderservice;
      this.sHIPORDERService = sHIPORDERService;
      this.unitOfWork = unitOfWork;
    }
    //GET: SHIPORDERs/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "派车单信息 ", Order = 1)]
    public ActionResult Index() => this.View();
    //获取运单的历史状态和跟踪信息
    [HttpGet]
    public JsonResult GetTracks(int id) {
      var tracks = this.sHIPORDERService.GetTracks(id);
      



      return Json(new {success=true, tracks }, JsonRequestBehavior.AllowGet);

    }
    //获取运输计划，创建派车单号
    [HttpPost]
    public async Task<JsonResult> GetOrdersWithOrderId(int[] orderid) {
      var order = await this.orderservice.FindAsync(orderid[0]);
      var orderdetails = await this.orderdetailservice.Queryable().Where(x => orderid.Contains(x.ORDERID))
        .Select(n=>new {
          ID = n.ID,
          ORDERKEY = n.ORDERKEY,
          LOTTABLE2 = n.LOTTABLE2,
          EXTERNORDERKEY = n.EXTERNORDERKEY,
          ORDERLINENUMBER = n.ORDERLINENUMBER,
          STATUS = n.STATUS,
          SUPPLIERCODE = n.SUPPLIERCODE,
          SUPPLIERNAME = n.SUPPLIERNAME,
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
          SALER = n.SALER,
          SALESORG = n.SALESORG,
          CHECKEDCOST1 = n.CHECKEDCOST1,
          COST1 = n.COST1,
          CHECKEDCOST2 = n.CHECKEDCOST2,
          COST2 = n.COST2,
          CHECKEDCOST3 = n.CHECKEDCOST3,
          COST3NOTE = n.COST3NOTE,
          FLOOR = n.FLOOR,
          COST3 = n.COST3,
          CHECKEDCOST4 = n.CHECKEDCOST4,
          COST4 = n.COST4,
          CHECKEDCOST5 = n.CHECKEDCOST5,
          COST5 = n.COST5,
          CHECKEDCOST6 = n.CHECKEDCOST6,
          COST6 = n.COST6,
          COST6NOTES = n.COST6NOTES,
          CHECKEDCOST7 = n.CHECKEDCOST7,
          COST7 = n.COST7,
          CHECKEDCOST8 = n.CHECKEDCOST8,
          COST8 = n.COST8,
          NOTES = n.NOTES,
          FLAG1 = n.FLAG1,
          FLAG2 = n.FLAG2,
          NOTES1 = n.NOTES1,
          REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE,
          DELIVERYDATE = n.DELIVERYDATE,
          ACTUALSHIPDATE = n.ACTUALSHIPDATE,
          ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE,
          WHSEID = n.WHSEID,
          STORERKEY = n.STORERKEY,
          LOTTABLE3 = n.LOTTABLE3,
          CONSIGNEEADDRESS = n.CONSIGNEEADDRESS,
          LOTTABLE1 = n.LOTTABLE1,
          EXTERNLINENO = n.EXTERNLINENO,
          TYPE = n.TYPE,
          ORIGINAL = n.ORIGINAL,
          DESTINATION = n.DESTINATION,
          SHPTYPE = n.SHPTYPE,
          COMPANYCODE = n.COMPANYCODE,
          CONTACTINFO = n.CONTACTINFO,
          REQUIREMENTS = n.REQUIREMENTS,
          LOTTABLE4 = n.LOTTABLE4,
          LOTTABLE5 = n.LOTTABLE5,
          LOTTABLE6 = n.LOTTABLE6,
          LOTTABLE7 = n.LOTTABLE7,
          LOTTABLE8 = n.LOTTABLE8,
          LOTTABLE9 = n.LOTTABLE9,
          LOTTABLE10 = n.LOTTABLE10,
          FACTORY = n.FACTORY,
          SHOP = n.SHOP,
          CHANNEL = n.CHANNEL,
          DELIVERYVOUCHER = n.DELIVERYVOUCHER,
          SALESDEP = n.SALESDEP,
          ORDERDATE = n.ORDERDATE,
          ORDERID = n.ORDERID
        })
        .ToListAsync();
      var shiporder = this.mapper.Map<SHIPORDER>(order);
      shiporder.SHIPORDERDATE = DateTime.Now;
      shiporder.TOTALCASECNT = orderdetails.Sum(x => x.CASECNT);
      shiporder.TOTALGROSSWGT = orderdetails.Sum(x => x.GROSSWGT);
      shiporder.TOTALQTY = orderdetails.Sum(x => x.ORIGINALQTY);
      shiporder.TOTALSHIPPEDQTY = orderdetails.Sum(x => x.SHIPPEDQTY);
      shiporder.TOTALCUBE = orderdetails.Sum(x => x.CUBE);
      shiporder.SHIPORDERKEY = KeyGenerator.GetShipKey();
      shiporder.LOTTABLE1 = this.User.Identity.Name;
      if(order.SHPTYPE=="4")
      {
        shiporder.TYPE = "2";
      }
      else
      {
        shiporder.TYPE = "1";
      }
      shiporder.STATUS = "110";
      shiporder.COMPANYCODE = Auth.GetCompanyCode();
      return Json(new { shiporder, orderdetails }, JsonRequestBehavior.AllowGet);

    }
    //计算运费和其他费用
    [HttpPost]
    public JsonResult CalTotalCost(string original, string destination,
      decimal stdloadwt, string shptype, int[] orderdetailsid)
    {
      try
      {
        var result = this.sHIPORDERService.CalTotalCost(original, destination, stdloadwt, shptype, orderdetailsid);



        return Json(new {success=true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e) {
        return Json(new { success=false,err=e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }
    //创建派车单
    [HttpPost]
    public async Task<JsonResult> PostCreateShipOrder(SHIPORDER header, int[] orderdetailsid) {
      try
      {
        this.sHIPORDERService.PostCreateShipOrder(header, orderdetailsid, this.User.Identity.Name);
        var result=await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }
    //打印派车单
    public async Task<ActionResult> Print(int id) {
      var shiporder = await this.sHIPORDERService.Queryable().Where(x => x.ID == id)
        .Include(x => x.SHIPORDERDETAILS).FirstOrDefaultAsync();
      return View(shiporder);
    }
    //批量发运

    [HttpGet]
    public async Task<JsonResult> DoShippingALL(int[] shiporderid)
    {

      try
      {
        foreach (var id in shiporderid)
        {
          this.sHIPORDERService.DoPrint(id, this.User.Identity.Name);
        }

        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }

    }
    //打印派车单修改状态
    [HttpGet]
    public async Task<JsonResult> DoPrint(int id) {

      try
      {
        this.sHIPORDERService.DoPrint(id, this.User.Identity.Name);
        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }

    }
    //运输完成
    [HttpGet]
    public async Task<JsonResult> DoCompleted(int id)
    {

      try
      {
        this.sHIPORDERService.DoCompleted(id, this.User.Identity.Name);
        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }

    }
    //运输完成
    [HttpGet]
    public async Task<JsonResult> DoCompletedALL(int[] shiporderid)
    {

      try
      {
        foreach(var id in shiporderid)
        {
          this.sHIPORDERService.DoCompleted(id, this.User.Identity.Name);
        }
       
        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }

    }
    //通知客户车辆位置
    [HttpGet]
    public async Task<JsonResult> NotifyLocToCustom(int id,string loc) {
      try
      {
        this.sHIPORDERService.NotifyLocToCustom(id,  loc);
        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }
    //获取派车单号
    [HttpGet]
    public JsonResult GetShipOrderKey()
    {
      var shipkey = KeyGenerator.GetShipKey();
      return Json(new { shipkey }, JsonRequestBehavior.AllowGet);
    }
    //获取运单毛利数据
    [HttpGet]
    public async Task<JsonResult> GetBillDataAsync(int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var all = await this.sHIPORDERService
                                 .Query(new SHIPORDERQuery().WithBillDatafilter(filters))
                                 .SelectAsync();
      var footer =new dynamic[]{ new { SHIPORDERKEY="汇总:",
        STATUS="次数：" + all.Count().ToString(),
        TOTALQTY = all.Sum(x=>x.TOTALQTY),
        STDCOST=all.Sum(x=>x.STDCOST),
        GROSSMARGINS = all.Sum(x=>x.GROSSMARGINS),
        TOTALCOST1 = all.Sum(x => x.TOTALCOST1),
        TOTALSERVICECOST = all.Sum(x => x.TOTALSERVICECOST),
      } };


      var pagerows = ( await this.sHIPORDERService
                                 .Query(new SHIPORDERQuery().WithBillDatafilter(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {
                                   SHIPORDERDETAILS = n.SHIPORDERDETAILS,
                                   ID = n.ID,
                                   SHIPORDERKEY = n.SHIPORDERKEY,
                                   EXTERNSHIPORDERKEY = n.EXTERNSHIPORDERKEY,
                                   SHIPORDERDATE = n.SHIPORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                   STATUS = n.STATUS,
                                   GROSSMARGINS = n.GROSSMARGINS,
                                   GROSSMARGINSRATE = n.GROSSMARGINSRATE,
                                   TOTALSERVICECOST = n.TOTALSERVICECOST,
                                   STDTOLL = n.STDTOLL,
                                   TYPE = n.TYPE,

                                   STDCOST = n.STDCOST,
                                   ORIGINAL = n.ORIGINAL,
                                   SHPTYPE = n.SHPTYPE,
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
                                   TOTALCOST6NOTES = n.TOTALCOST6NOTES,
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
      var pagelist = new { total = totalCount, rows = pagerows, footer= footer };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //获取运单跟踪状态
    [HttpGet]
    public async Task<JsonResult> GetTrackList() {
      var list = await Task.Run(() => this.sHIPORDERService.GetTrackList());
      return Json(list, JsonRequestBehavior.AllowGet);
     }
    //Get :SHIPORDERs/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.sHIPORDERService
                                 .Query(new SHIPORDERQuery().Withfilter(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {
                                   SHIPORDERDETAILS = n.SHIPORDERDETAILS,
                                   ID = n.ID,
                                   SHIPORDERKEY = n.SHIPORDERKEY,
                                   EXTERNSHIPORDERKEY = n.EXTERNSHIPORDERKEY,
                                   SHIPORDERDATE = n.SHIPORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                   STATUS = n.STATUS,
                                   GROSSMARGINS = n.GROSSMARGINS,
                                   GROSSMARGINSRATE = n.GROSSMARGINSRATE,
                                   TOTALSERVICECOST=n.TOTALSERVICECOST,
                                   STDTOLL = n.STDTOLL,
                                   TYPE = n.TYPE,
                                   
                                   STDCOST =n.STDCOST,
                                   ORIGINAL = n.ORIGINAL,
                                   SHPTYPE = n.SHPTYPE,
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
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(SHIPORDER[] shiporders)
    {
      if (shiporders == null)
      {
        throw new ArgumentNullException(nameof(shiporders));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in shiporders)
          {
            this.sHIPORDERService.ApplyChanges(item);
          }
          var result = await this.unitOfWork.SaveChangesAsync();
          return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException e)
        {
          var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
          return this.Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
        }
        catch (Exception e)
        {
          return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
        }
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
      }

    }
    //[OutputCache(Duration = 20, VaryByParam = "q")]
    public async Task<JsonResult> GetSHIPORDERSAsync(string q = "")
    {
      var shiporderRepository = this.unitOfWork.RepositoryAsync<SHIPORDER>();
      var rows = await shiporderRepository
                      .Queryable()
                      .Where(n => n.SHIPORDERKEY.Contains(q))
                      .OrderBy(n => n.SHIPORDERKEY)
                      .Select(n => new { ID = n.ID, SHIPORDERKEY = n.SHIPORDERKEY })
                      .ToListAsync();

      return this.Json(rows, JsonRequestBehavior.AllowGet);
    }
    //GET: SHIPORDERs/Details/:id
    public ActionResult Details(int id)
    {

      var sHIPORDER = this.sHIPORDERService.Find(id);
      if (sHIPORDER == null)
      {
        return this.HttpNotFound();
      }
      return this.View(sHIPORDER);
    }
    //GET: SHIPORDERs/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var sHIPORDER = await this.sHIPORDERService.FindAsync(id);
      return this.Json(sHIPORDER, JsonRequestBehavior.AllowGet);
    }
    //GET: SHIPORDERs/Create
    public ActionResult Create()
    {
      var sHIPORDER = new SHIPORDER();
      //set default value
      return this.View(sHIPORDER);
    }
    //POST: SHIPORDERs/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(SHIPORDER sHIPORDER)
    {
      if (sHIPORDER == null)
      {
        throw new ArgumentNullException(nameof(sHIPORDER));
      }
      if (this.ModelState.IsValid)
      {
        sHIPORDER.TrackingState = TrackingState.Added;
        foreach (var item in sHIPORDER.SHIPORDERDETAILS)
        {
          item.SHIPORDERID = sHIPORDER.ID;
          item.TrackingState = TrackingState.Added;
        }
        try
        {
          this.sHIPORDERService.ApplyChanges(sHIPORDER);
          var result = await this.unitOfWork.SaveChangesAsync();
          return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException e)
        {
          var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
          return this.Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
        }
        catch (Exception e)
        {
          return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
        }
        //DisplaySuccessMessage("Has update a sHIPORDER record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(sHIPORDER);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var sHIPORDER = await Task.Run(() =>
      {
        return new SHIPORDER();
      });
      return this.Json(sHIPORDER, JsonRequestBehavior.AllowGet);
    }


    //GET: SHIPORDERs/Edit/:id
    public ActionResult Edit(int id)
    {
      var sHIPORDER = this.sHIPORDERService.Find(id);
      if (sHIPORDER == null)
      {
        return this.HttpNotFound();
      }
      return this.View(sHIPORDER);
    }
    //POST: SHIPORDERs/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(SHIPORDER sHIPORDER)
    {
      if (sHIPORDER == null)
      {
        throw new ArgumentNullException(nameof(sHIPORDER));
      }
      if (this.ModelState.IsValid)
      {
        sHIPORDER.TrackingState = TrackingState.Modified;
        foreach (var item in sHIPORDER.SHIPORDERDETAILS)
        {
          item.SHIPORDERID = sHIPORDER.ID;
        }

        try
        {
          this.sHIPORDERService.ApplyChanges(sHIPORDER);

          var result = await this.unitOfWork.SaveChangesAsync();
          return this.Json(new { success = true, result = result }, JsonRequestBehavior.AllowGet);
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException e)
        {
          var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
          return this.Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
        }
        catch (Exception e)
        {
          return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
        }

        //DisplaySuccessMessage("Has update a SHIPORDER record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(sHIPORDER);
    }
    //删除当前记录
    //GET: SHIPORDERs/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.sHIPORDERService.Queryable().Where(x => x.ID == id).DeleteAsync();
        return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }

    //Get Detail Row By Id For Edit
    //Get : SHIPORDERs/EditSHIPORDERDETAIL/:id
    [HttpGet]
    public async Task<ActionResult> EditSHIPORDERDETAIL(int id)
    {
      var shiporderdetailRepository = this.unitOfWork.RepositoryAsync<SHIPORDERDETAIL>();
      var shiporderdetail = await shiporderdetailRepository.FindAsync(id);
      var shiporderRepository = this.unitOfWork.RepositoryAsync<SHIPORDER>();
      if (shiporderdetail == null)
      {
        this.ViewBag.SHIPORDERID = new SelectList(await shiporderRepository.Queryable().OrderBy(n => n.SHIPORDERKEY).ToListAsync(), "ID", "SHIPORDERKEY");
        //return HttpNotFound();
        return this.PartialView("_SHIPORDERDETAILEditForm", new SHIPORDERDETAIL());
      }
      else
      {
        this.ViewBag.SHIPORDERID = new SelectList(await shiporderRepository.Queryable().ToListAsync(), "ID", "SHIPORDERKEY", shiporderdetail.SHIPORDERID);
      }
      return this.PartialView("_SHIPORDERDETAILEditForm", shiporderdetail);
    }
    //Get Create Row By Id For Edit
    //Get : SHIPORDERs/CreateSHIPORDERDETAIL
    [HttpGet]
    public async Task<ActionResult> CreateSHIPORDERDETAILAsync(int shiporderid)
    {
      var shiporderRepository = this.unitOfWork.RepositoryAsync<SHIPORDER>();
      this.ViewBag.SHIPORDERID = new SelectList(await shiporderRepository.Queryable().OrderBy(n => n.SHIPORDERKEY).ToListAsync(), "ID", "SHIPORDERKEY");
      return this.PartialView("_SHIPORDERDETAILEditForm");
    }
    //Post Delete Detail Row By Id
    //Get : SHIPORDERs/DeleteSHIPORDERDETAIL/:id
    [HttpGet]
    public async Task<ActionResult> DeleteSHIPORDERDETAILAsync(int id)
    {
      try
      {
        var shiporderdetailRepository = this.unitOfWork.RepositoryAsync<SHIPORDERDETAIL>();
        shiporderdetailRepository.Delete(id);
        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }

    //Get : SHIPORDERs/GetSHIPORDERDETAILSBySHIPORDERID/:id
    [HttpGet]
    public async Task<JsonResult> GetSHIPORDERDETAILSBySHIPORDERIDAsync(int id)
    {
      var shiporderdetails = this.sHIPORDERService.GetSHIPORDERDETAILSBySHIPORDERID(id);
      var data = await shiporderdetails.AsQueryable().ToListAsync();
      var rows = data.Select(n => new
      {
        SHIPORDERSHIPORDERKEY = n.SHIPORDER?.SHIPORDERKEY,
        ID = n.ID,
        SHIPORDERKEY = n.SHIPORDERKEY,
        EXTERNSHIPORDERKEY = n.EXTERNSHIPORDERKEY,
        ORDERLINENUMBER = n.ORDERLINENUMBER,
        STATUS = n.STATUS,
        SUPPLIERCODE = n.SUPPLIERCODE,
        SUPPLIERNAME = n.SUPPLIERNAME,
        LOTTABLE3 = n.LOTTABLE3,
        CONSIGNEEADDRESS = n.CONSIGNEEADDRESS,
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
        COST1 = n.COST1,
        CHECKEDCOST2 = n.CHECKEDCOST2,
        COST2 = n.COST2,
        CHECKEDCOST3 = n.CHECKEDCOST3,
        COST3NOTE = n.COST3NOTE,
        FLOOR = n.FLOOR,
        COST3 = n.COST3,
        CHECKEDCOST4 = n.CHECKEDCOST4,
        COST4 = n.COST4,
        CHECKEDCOST5 = n.CHECKEDCOST5,
        COST5 = n.COST5,
        CHECKEDCOST6 = n.CHECKEDCOST6,
        COST6 = n.COST6,
        COST6NOTES =n.COST6NOTES,
        CHECKEDCOST7 = n.CHECKEDCOST7,
        COST7 = n.COST7,
        CHECKEDCOST8 = n.CHECKEDCOST8,
        COST8 = n.COST8,
        ORDERKEY = n.ORDERKEY,
        LOTTABLE2 = n.LOTTABLE2,
        EXTERNORDERKEY = n.EXTERNORDERKEY,
        FLAG1 = n.FLAG1,
        FLAG2 = n.FLAG2,
        NOTES1 = n.NOTES1,
        REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        DELIVERYDATE = n.DELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALSHIPDATE = n.ACTUALSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        WHSEID = n.WHSEID,
        STORERKEY = n.STORERKEY,
        LOTTABLE1 = n.LOTTABLE1,
        EXTERNLINENO = n.EXTERNLINENO,
        TYPE = n.TYPE,
        ORIGINAL = n.ORIGINAL,
        DESTINATION = n.DESTINATION,
        SHPTYPE = n.SHPTYPE,
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
        ORDERDATE = n.ORDERDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        SHIPORDERDATE = n.SHIPORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
        SHIPORDERID = n.SHIPORDERID
      });
      return this.Json(rows, JsonRequestBehavior.AllowGet);

    }


    //删除选中的记录
    [HttpPost]
    public async Task<JsonResult> DeleteCheckedAsync(int[] id)
    {
      if (id == null)
      {
        throw new ArgumentNullException(nameof(id));
      }
      try
      {
         this.sHIPORDERService.Cancle(id, this.User.Identity.Name);
        await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }
    //导出Excel
    [HttpPost]
    public ActionResult ExportExcel(string filterRules = "", string sort = "ID", string order = "asc")
    {
      var fileName = "shiporders_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.sHIPORDERService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }

    //获取看板数据
    [HttpGet]
    public async Task<JsonResult> GetKanbanData(DateTime dt1, DateTime dt2, string platenumber)
    {
      var array = new string[] {  "120", "130", "140", "150", "160" };
      var query = this.sHIPORDERService.Queryable().Where(x =>
        array.Contains(x.STATUS) &&
        DbFunctions.TruncateTime(x.SHIPORDERDATE) >= dt1 &&
        DbFunctions.TruncateTime(x.SHIPORDERDATE) <= dt2
       );
      if (!string.IsNullOrEmpty(platenumber))
      {
        query = query.Where(x => x.PLATENUMBER == platenumber);
      }

      var data = await query.OrderByDescending(x => x.DELIVERYDATE).ToListAsync();
      var rows = query.Select(n => new {
        n.SHIPORDERKEY,
        EXTERNORDERKEY = n.EXTERNSHIPORDERKEY,
        n.PLATENUMBER,
        n.ORIGINAL,
        n.DESTINATION,
        REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE,
        QTY = n.TOTALQTY,
        STATUS = n.STATUS,
        DELIVERYDATE = n.DELIVERYDATE,
        n.ACTUALSHIPDATE,
        n.NOTES
      }).ToList();

      return Json(rows, JsonRequestBehavior.AllowGet);


    }


    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;
    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;

  }
}
