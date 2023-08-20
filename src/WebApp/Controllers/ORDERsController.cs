using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
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
  /// File: ORDERsController.cs
  /// Purpose:业务操作/运输计划
  /// Created Date: 2019/8/8 7:25:06
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<ORDER>, Repository<ORDER>>();
  ///    container.RegisterType<IORDERService, ORDERService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("ORDERs")]
  public class ORDERsController : Controller
  {
    private readonly IORDERService oRDERService;
    private readonly IUnitOfWorkAsync unitOfWork;
    private readonly ISalesmanService salesmanservice;
    private readonly ISUPPLIERService supplierservice;
    public ORDERsController(
      ISalesmanService salesmanservice,
      ISUPPLIERService supplierservice,
      IORDERService oRDERService, IUnitOfWorkAsync unitOfWork)
    {
      this.oRDERService = oRDERService;
      this.unitOfWork = unitOfWork;
      this.supplierservice = supplierservice;
      this.salesmanservice = salesmanservice;
    }
    //GET: ORDERs/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "运输计划 ", Order = 1)]
    public ActionResult Index() => this.View();

    //Get :ORDERs/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
    
      if (!string.IsNullOrEmpty(Auth.GetCompanyCode()))
      {
        if (filters == null)
        {
          filters = new List<filterRule>().ToArray();
        }
        filters = filters.Concat(new filterRule[] {
          new filterRule(){
             field="COMPANYCODE",
             value=Auth.GetCompanyCode()
          }
        });
      }
      var pagerows = ( await this.oRDERService
                                 .Query(new ORDERQuery().Withfilter(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {
                                
                                   ID = n.ID,
                                   SALER=n.SALER,
                                   ORDERKEY = n.ORDERKEY,
                                   EXTERNORDERKEY = n.EXTERNORDERKEY,
                                   WHSEID = n.WHSEID,
                                   LOTTABLE2 = n.LOTTABLE2,
                                   ORIGINAL = n.ORIGINAL,
                                   DESTINATION = n.DESTINATION,
                                   TYPE = n.TYPE,
                                   SHPTYPE = n.SHPTYPE,
                                   STATUS = n.STATUS,
                                   COST3NOTE=n.COST3NOTE,
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
                                   NOTES = n.NOTES,
                                   FLAG1 = n.FLAG1,
                                   NOTES1 = n.NOTES1,
                                   FLAG2 = n.FLAG2,
                                   COMPANYCODE = n.COMPANYCODE,
                                   CONTACTINFO=n.CONTACTINFO,
                                   REQUIREMENTS=n.REQUIREMENTS,
                                   EXTERNORDERKEY1=n.EXTERNORDERKEY1,
                                   FACTORY=n.FACTORY,
                                   SHOP=n.SHOP,
                                   CHANNEL=n.CHANNEL,
                                   DELIVERYVOUCHER=n.DELIVERYVOUCHER,
                                   SALESDEP=n.SALESDEP,
                                   SALESORG = n.SALESORG,
                                   LOTTABLE1 = n.LOTTABLE1,
                                   LOTTABLE4 = n.LOTTABLE4,
                                   LOTTABLE5 = n.LOTTABLE5,
                                   LOTTABLE6 = n.LOTTABLE6,
                                   LOTTABLE7 = n.LOTTABLE7,
                                   LOTTABLE8 = n.LOTTABLE8?.ToString("yyyy-MM-dd HH:mm:ss")
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //获取订单号
    [HttpGet]
    public JsonResult GetOrderKey() {
      var orderkey = KeyGenerator.GetNextOrderKey();
      return Json(new { orderkey }, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(ORDER[] orders)
    {
      if (orders == null)
      {
        throw new ArgumentNullException(nameof(orders));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in orders)
          {
            this.oRDERService.ApplyChanges(item);
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
    public async Task<JsonResult> GetORDERSAsync(string q = "")
    {
      var orderRepository = this.unitOfWork.RepositoryAsync<ORDER>();
      var rows = await orderRepository
                      .Queryable()
                      .Where(n => n.ORDERKEY.Contains(q))
                      .OrderBy(n => n.ORDERKEY)
                      .Select(n => new { ID = n.ID, ORDERKEY = n.ORDERKEY })
                      .ToListAsync();

      return this.Json(rows, JsonRequestBehavior.AllowGet);
    }
    //GET: ORDERs/Details/:id
    public ActionResult Details(int id)
    {

      var oRDER = this.oRDERService.Find(id);
      if (oRDER == null)
      {
        return this.HttpNotFound();
      }
      return this.View(oRDER);
    }
    //GET: ORDERs/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var oRDER = await this.oRDERService.FindAsync(id);
      return this.Json(oRDER, JsonRequestBehavior.AllowGet);
    }
    //GET: ORDERs/Create
    public ActionResult Create()
    {
      var oRDER = new ORDER();
      //set default value
      return this.View(oRDER);
    }
    //POST: ORDERs/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(ORDER oRDER)
    {
      if (oRDER == null)
      {
        throw new ArgumentNullException(nameof(oRDER));
      }
      if (this.ModelState.IsValid)
      {
        oRDER.TrackingState = TrackingState.Added;
        foreach (var item in oRDER.ORDERDETAILS)
        {
          item.ORDERID = oRDER.ID;
          item.ORIGINAL = oRDER.ORIGINAL;
          item.DESTINATION = oRDER.DESTINATION;
          item.CONTACTINFO = oRDER.CONTACTINFO;
          item.REQUIREMENTS = oRDER.REQUIREMENTS;
          item.SALER = oRDER.SALER;
          item.CHECKEDCOST1 = oRDER.CHECKEDCOST1;
          item.CHECKEDCOST2 = oRDER.CHECKEDCOST2;
          item.CHECKEDCOST3 = oRDER.CHECKEDCOST3;
          item.COST3NOTE = oRDER.COST3NOTE;
          item.FLOOR = oRDER.FLOOR;
          item.CHECKEDCOST4 = oRDER.CHECKEDCOST4;
          item.CHECKEDCOST5 = oRDER.CHECKEDCOST5;
          item.CHECKEDCOST6 = oRDER.CHECKEDCOST6;
          item.COST6NOTES = oRDER.TOTALCOST6NOTES;
          item.CHECKEDCOST7 = oRDER.CHECKEDCOST7;
          item.CHECKEDCOST8 = oRDER.CHECKEDCOST8;
          item.SHPTYPE = oRDER.SHPTYPE;
          item.TYPE = oRDER.TYPE;
          item.CONSIGNEEADDRESS = oRDER.CONSIGNEEADDRESS;
          item.COMPANYCODE = oRDER.COMPANYCODE;
          item.ORDERKEY = oRDER.ORDERKEY;
          item.EXTERNORDERKEY = oRDER.EXTERNORDERKEY;
          item.LOTTABLE1 = oRDER.LOTTABLE1;
          item.LOTTABLE2 = oRDER.LOTTABLE2;
          item.LOTTABLE3 = oRDER.LOTTABLE3;
          item.SUPPLIERCODE = oRDER.SUPPLIERCODE;
          item.SUPPLIERNAME = oRDER.SUPPLIERNAME;
          item.TrackingState = TrackingState.Added;
        }
        try
        {
          this.oRDERService.CreateOrder(oRDER);
          var result = await this.unitOfWork.SaveChangesAsync();

          var to1 = this.supplierservice.Queryable().Where(x => x.SUPPLIERCODE == oRDER.SUPPLIERCODE).FirstOrDefault()?.PHONENUMBER;
          if (!string.IsNullOrEmpty(to1))
          {
            App_Helpers.QCloudHelper.SendSMSWithTPL(to1, 457903, oRDER.ORDERKEY, oRDER.REQUESTEDSHIPDATE?.ToString("MM-dd"));
          }
          

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
        //DisplaySuccessMessage("Has update a oRDER record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(oRDER);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var oRDER = await Task.Run(() =>
      {
        return new ORDER();
      });
      return this.Json(oRDER, JsonRequestBehavior.AllowGet);
    }


    //GET: ORDERs/Edit/:id
    public ActionResult Edit(int id)
    {
      var oRDER = this.oRDERService.Find(id);
      if (oRDER == null)
      {
        return this.HttpNotFound();
      }
      return this.View(oRDER);
    }
    //POST: ORDERs/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(ORDER oRDER)
    {
      if (oRDER == null)
      {
        throw new ArgumentNullException(nameof(oRDER));
      }
      if (this.ModelState.IsValid)
      {
        oRDER.TrackingState = TrackingState.Modified;
        foreach (var item in oRDER.ORDERDETAILS)
        {
          item.ORDERID = oRDER.ID;
        }

        try
        {
          this.oRDERService.ApplyChanges(oRDER);

          var result = await this.unitOfWork.SaveChangesAsync();
          this.oRDERService.SyncUpdate(oRDER.ID);
          await this.unitOfWork.SaveChangesAsync();

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

        //DisplaySuccessMessage("Has update a ORDER record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(oRDER);
    }
    //删除当前记录
    //GET: ORDERs/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.oRDERService.Queryable().Where(x => x.ID == id).DeleteAsync();
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
    //Get : ORDERs/EditORDERDETAIL/:id
    [HttpGet]
    public async Task<ActionResult> EditORDERDETAIL(int id)
    {
      var orderdetailRepository = this.unitOfWork.RepositoryAsync<ORDERDETAIL>();
      var orderdetail = await orderdetailRepository.FindAsync(id);
      var orderRepository = this.unitOfWork.RepositoryAsync<ORDER>();
      if (orderdetail == null)
      {
        this.ViewBag.ORDERID = new SelectList(await orderRepository.Queryable().OrderBy(n => n.ORDERKEY).ToListAsync(), "ID", "ORDERKEY");
        //return HttpNotFound();
        return this.PartialView("_ORDERDETAILEditForm", new ORDERDETAIL());
      }
      else
      {
        this.ViewBag.ORDERID = new SelectList(await orderRepository.Queryable().ToListAsync(), "ID", "ORDERKEY", orderdetail.ORDERID);
      }
      return this.PartialView("_ORDERDETAILEditForm", orderdetail);
    }
    //Get Create Row By Id For Edit
    //Get : ORDERs/CreateORDERDETAIL
    [HttpGet]
    public async Task<ActionResult> CreateORDERDETAILAsync(int orderid)
    {
      var orderRepository = this.unitOfWork.RepositoryAsync<ORDER>();
      this.ViewBag.ORDERID = new SelectList(await orderRepository.Queryable().OrderBy(n => n.ORDERKEY).ToListAsync(), "ID", "ORDERKEY");
      return this.PartialView("_ORDERDETAILEditForm");
    }
    //Post Delete Detail Row By Id
    //Get : ORDERs/DeleteORDERDETAIL/:id
    [HttpGet]
    public async Task<ActionResult> DeleteORDERDETAILAsync(int id)
    {
      try
      {
        var orderdetailRepository = this.unitOfWork.RepositoryAsync<ORDERDETAIL>();
        orderdetailRepository.Delete(id);
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

    //Get : ORDERs/GetORDERDETAILSByORDERID/:id
    [HttpGet]
    public async Task<JsonResult> GetORDERDETAILSByORDERIDAsync(int id)
    {
      var orderdetails = this.oRDERService.GetORDERDETAILSByORDERID(id);
      var data = await orderdetails.AsQueryable().ToListAsync();
      var rows = data.Select(n => new
      {
        ORDERORDERKEY = n.ORDER?.ORDERKEY,
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
        COST6NOTES = n.COST6NOTES,
        COST6 = n.COST6,
        CHECKEDCOST7 = n.CHECKEDCOST7,
        COST7 = n.COST7,
        CHECKEDCOST8 = n.CHECKEDCOST8,
        COST8 = n.COST8,
        NOTES = n.NOTES,
        FLAG1 = n.FLAG1,
        FLAG2 = n.FLAG2,
        NOTES1 = n.NOTES1,
        REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        DELIVERYDATE = n.DELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALSHIPDATE = n.ACTUALSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
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
        LOTTABLE8 = n.LOTTABLE8?.ToString("yyyy-MM-dd HH:mm:ss"),
        LOTTABLE9 = n.LOTTABLE9?.ToString("yyyy-MM-dd HH:mm:ss"),
        LOTTABLE10 = n.LOTTABLE10,
        FACTORY = n.FACTORY,
        SHOP = n.SHOP,
        CHANNEL = n.CHANNEL,
        DELIVERYVOUCHER = n.DELIVERYVOUCHER,
        SALESDEP = n.SALESDEP,
        ORDERDATE = n.ORDERDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
        ORDERID = n.ORDERID
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
        this.oRDERService.Delete(id);
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
      var fileName = "orders_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.oRDERService.ExportFinanceExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }

    //获取看板数据
    [HttpGet]
    public async Task<JsonResult> GetKanbanData(DateTime dt1, DateTime dt2, string supplier)
    {
      var array = new string[] { "100", "110", "120", "130", "140" };
      var query = this.oRDERService.Queryable().Where(x =>
        array.Contains(x.STATUS) &&
        DbFunctions.TruncateTime(x.ORDERDATE) >= dt1 &&
        DbFunctions.TruncateTime(x.ORDERDATE) <= dt2
       );
      if (!string.IsNullOrEmpty(supplier))
      {
        query = query.Where(x => x.SUPPLIERCODE == supplier);
      }
      
      var data = await query.OrderByDescending(x => x.REQUESTEDSHIPDATE).ToListAsync();
      var rows = query.Select(n => new {
        n.ORDERKEY,
        EXTERNORDERKEY = n.EXTERNORDERKEY,
        SUPPLIERNAME = n.SUPPLIERNAME,
        n.CONSIGNEEADDRESS,
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
