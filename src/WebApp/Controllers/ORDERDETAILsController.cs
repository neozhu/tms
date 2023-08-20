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
  /// File: ORDERDETAILsController.cs
  /// Purpose:业务操作/配送计划明细
  /// Created Date: 2019/8/8 7:20:05
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<ORDERDETAIL>, Repository<ORDERDETAIL>>();
  ///    container.RegisterType<IORDERDETAILService, ORDERDETAILService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("ORDERDETAILs")]
  public class ORDERDETAILsController : Controller
  {
    private readonly IORDERDETAILService oRDERDETAILService;
    private readonly IUnitOfWorkAsync unitOfWork;
    private readonly IORDERService orderService;
    public ORDERDETAILsController(
      IORDERService orderService,
      IORDERDETAILService oRDERDETAILService, IUnitOfWorkAsync unitOfWork)
    {
      this.oRDERDETAILService = oRDERDETAILService;
      this.unitOfWork = unitOfWork;
      this.orderService = orderService;
    }
    //GET: ORDERDETAILs/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "配送计划明细 ", Order = 1)]
    public ActionResult Index() => this.View();

    //Get :ORDERDETAILs/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.oRDERDETAILService
                                 .Query(new ORDERDETAILQuery().Withfilter170(filters)).Include(o => o.ORDER)
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {

                                   ORDERORDERKEY = n.ORDER?.ORDERKEY,
                                   ID = n.ID,
                                   ORDERKEY = n.ORDERKEY,
                                   LOTTABLE2 = n.LOTTABLE2,
                                   EXTERNORDERKEY = n.EXTERNORDERKEY,
                                   EXTERNORDERKEY1=n.EXTERNORDERKEY1,
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
                                   UNITCOST1=n.UNITCOST1,
                                   UNITCOST3=n.UNITCOST3,
                                   CHECKEDCOST1 = n.CHECKEDCOST1,
                                   COST1 = n.COST1,
                                   CHECKEDCOST2 = n.CHECKEDCOST2,
                                   COST2 = n.COST2,
                                   CHECKEDCOST3 = n.CHECKEDCOST3,
                                   COST3NOTE=n.COST3NOTE,
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
                                   CARRIERNAME=n.CARRIERNAME,
                                   DRIVERNAME=n.DRIVERNAME,
                                   CARRIERPHONE=n.CARRIERPHONE,
                                   TRAILERNUMBER=n.TRAILERNUMBER,
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
                                   ORDERDATE=n.ORDERDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
                                   ORDERID = n.ORDERID
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    [HttpGet]
    public async Task<JsonResult> GetDataByORDERIDAsync(int orderid, int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.oRDERDETAILService
                             .Query(new ORDERDETAILQuery().ByORDERIDWithfilter(orderid, filters)).Include(o => o.ORDER)
                             .OrderBy(n => n.OrderBy(sort, order))
                             .SelectPageAsync(page, rows, out var totalCount) )
                             .Select(n => new
                             {

                               ORDERORDERKEY = n.ORDER?.ORDERKEY,
                               ID = n.ID,
                               ORDERKEY = n.ORDERKEY,
                               LOTTABLE2 = n.LOTTABLE2,
                               EXTERNORDERKEY = n.EXTERNORDERKEY,
                               EXTERNORDERKEY1 = n.EXTERNORDERKEY1,
                               ORDERLINENUMBER = n.ORDERLINENUMBER,
                               STATUS = n.STATUS,
                               SUPPLIERCODE = n.SUPPLIERCODE,
                               SUPPLIERNAME = n.SUPPLIERNAME,
                               SKU = n.SKU,
                               SKUTYPE = n.SKUTYPE,
                               SKUNAME = n.SKUNAME,
                               UNITCOST1 = n.UNITCOST1,
                               UNITCOST3 = n.UNITCOST3,
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
                               CARRIERNAME = n.CARRIERNAME,
                               DRIVERNAME = n.DRIVERNAME,
                               CARRIERPHONE = n.CARRIERPHONE,
                               TRAILERNUMBER = n.TRAILERNUMBER,
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
                             }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(ORDERDETAIL[] orderdetails)
    {
      if (orderdetails == null)
      {
        throw new ArgumentNullException(nameof(orderdetails));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in orderdetails)
          {
            this.oRDERDETAILService.ApplyChanges(item);
          }
          var result = await this.unitOfWork.SaveChangesAsync();

          this.orderService.SyncUpdate(orderdetails[0].ORDERID);
          await this.unitOfWork.SaveChangesAsync();

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
    //GET: ORDERDETAILs/Details/:id
    public ActionResult Details(int id)
    {

      var oRDERDETAIL = this.oRDERDETAILService.Find(id);
      if (oRDERDETAIL == null)
      {
        return this.HttpNotFound();
      }
      return this.View(oRDERDETAIL);
    }
    //GET: ORDERDETAILs/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var oRDERDETAIL = await this.oRDERDETAILService.FindAsync(id);
      return this.Json(oRDERDETAIL, JsonRequestBehavior.AllowGet);
    }
    //GET: ORDERDETAILs/Create
    public ActionResult Create()
    {
      var oRDERDETAIL = new ORDERDETAIL();
      //set default value
      var orderRepository = this.unitOfWork.RepositoryAsync<ORDER>();
      this.ViewBag.ORDERID = new SelectList(orderRepository.Queryable().OrderBy(n => n.ORDERKEY), "ID", "ORDERKEY");
      return this.View(oRDERDETAIL);
    }
    //POST: ORDERDETAILs/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(ORDERDETAIL oRDERDETAIL)
    {
      if (oRDERDETAIL == null)
      {
        throw new ArgumentNullException(nameof(oRDERDETAIL));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          this.oRDERDETAILService.Insert(oRDERDETAIL);
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
        //DisplaySuccessMessage("Has update a oRDERDETAIL record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //var orderRepository = this.unitOfWork.RepositoryAsync<ORDER>();
      //ViewBag.ORDERID = new SelectList(await orderRepository.Queryable().OrderBy(n=>n.ORDERKEY).ToListAsync(), "ID", "ORDERKEY", oRDERDETAIL.ORDERID);
      //return View(oRDERDETAIL);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var oRDERDETAIL = await Task.Run(() =>
      {
        return new ORDERDETAIL();
      });
      return this.Json(oRDERDETAIL, JsonRequestBehavior.AllowGet);
    }


    //GET: ORDERDETAILs/Edit/:id
    public ActionResult Edit(int id)
    {
      var oRDERDETAIL = this.oRDERDETAILService.Find(id);
      if (oRDERDETAIL == null)
      {
        return this.HttpNotFound();
      }
      var orderRepository = this.unitOfWork.RepositoryAsync<ORDER>();
      this.ViewBag.ORDERID = new SelectList(orderRepository.Queryable().OrderBy(n => n.ORDERKEY), "ID", "ORDERKEY", oRDERDETAIL.ORDERID);
      return this.View(oRDERDETAIL);
    }
    //POST: ORDERDETAILs/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(ORDERDETAIL oRDERDETAIL)
    {
      if (oRDERDETAIL == null)
      {
        throw new ArgumentNullException(nameof(oRDERDETAIL));
      }
      if (this.ModelState.IsValid)
      {
        oRDERDETAIL.TrackingState = TrackingState.Modified;
        try
        {
          this.oRDERDETAILService.Update(oRDERDETAIL);

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

        //DisplaySuccessMessage("Has update a ORDERDETAIL record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //var orderRepository = this.unitOfWork.RepositoryAsync<ORDER>();
      //return View(oRDERDETAIL);
    }
    //删除当前记录
    //GET: ORDERDETAILs/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.oRDERDETAILService.Queryable().Where(x => x.ID == id).DeleteAsync();
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
        await this.oRDERDETAILService.Queryable().Where(x => id.Contains(x.ID)).DeleteAsync();
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
      var fileName = "对账单明细_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.oRDERDETAILService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }
    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;
    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;

  }
}
