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
  /// File: SHIPORDERDETAILsController.cs
  /// Purpose:业务操作/派车单明细
  /// Created Date: 8/12/2019 8:47:33 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<SHIPORDERDETAIL>, Repository<SHIPORDERDETAIL>>();
  ///    container.RegisterType<ISHIPORDERDETAILService, SHIPORDERDETAILService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("SHIPORDERDETAILs")]
  public class SHIPORDERDETAILsController : Controller
  {
    private readonly ISHIPORDERDETAILService sHIPORDERDETAILService;
    private readonly IUnitOfWorkAsync unitOfWork;
    public SHIPORDERDETAILsController(ISHIPORDERDETAILService sHIPORDERDETAILService, IUnitOfWorkAsync unitOfWork)
    {
      this.sHIPORDERDETAILService = sHIPORDERDETAILService;
      this.unitOfWork = unitOfWork;
    }
    //GET: SHIPORDERDETAILs/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "派车单明细 ", Order = 1)]
    public ActionResult Index() => this.View();

    //Get :SHIPORDERDETAILs/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.sHIPORDERDETAILService
                                 .Query(new SHIPORDERDETAILQuery().Withfilter(filters)).Include(s => s.SHIPORDER)
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
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
                                   ORDERKEY = n.ORDERKEY,
                                   LOTTABLE2 = n.LOTTABLE2,
                                   EXTERNORDERKEY = n.EXTERNORDERKEY,
                                   FLAG1 = n.FLAG1,
                                   FLAG2 = n.FLAG2,
                                   NOTES1 = n.NOTES1,
                                   EXTERNORDERKEY1 = n.EXTERNORDERKEY1,
                                   n.UNITCOST1,
                                   n.UNITCOST3,
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
                                   SHIPORDERID = n.SHIPORDERID
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    [HttpGet]
    public async Task<JsonResult> GetDataBySHIPORDERIDAsync(int shiporderid, int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.sHIPORDERDETAILService
                             .Query(new SHIPORDERDETAILQuery().BySHIPORDERIDWithfilter(shiporderid, filters))
                             .Include(s => s.SHIPORDER)
                             .OrderBy(n => n.OrderBy(sort, order))
                             .SelectPageAsync(page, rows, out var totalCount) )
                             .Select(n => new
                             {

                               SHIPORDERSHIPORDERKEY = n.SHIPORDER?.SHIPORDERKEY,
                               ID = n.ID,
                               SHIPORDERKEY = n.SHIPORDERKEY,
                               EXTERNSHIPORDERKEY = n.EXTERNSHIPORDERKEY,
                               ORDERLINENUMBER = n.ORDERLINENUMBER,
                               SHPTYPE =  n.SHPTYPE,
                               STATUS = n.STATUS,
                               ORIGINAL = n.ORIGINAL,
                               DESTINATION = n.DESTINATION,
                               SUPPLIERCODE = n.SUPPLIERCODE,
                               SUPPLIERNAME = n.SUPPLIERNAME,
                               CARRIERNAME = n.CARRIERNAME,
                               DRIVERNAME = n.DRIVERNAME,
                               CARRIERPHONE = n.CARRIERPHONE,
                               TRAILERNUMBER = n.TRAILERNUMBER,
                               EXTERNORDERKEY1 = n.EXTERNORDERKEY1,
                               n.UNITCOST1,
                               n.UNITCOST3,
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
                               SHIPORDERDATE=n.SHIPORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
                               SHIPORDERID = n.SHIPORDERID
                             }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(SHIPORDERDETAIL[] shiporderdetails)
    {
      if (shiporderdetails == null)
      {
        throw new ArgumentNullException(nameof(shiporderdetails));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in shiporderdetails)
          {
            this.sHIPORDERDETAILService.ApplyChanges(item);
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
    //GET: SHIPORDERDETAILs/Details/:id
    public ActionResult Details(int id)
    {

      var sHIPORDERDETAIL = this.sHIPORDERDETAILService.Find(id);
      if (sHIPORDERDETAIL == null)
      {
        return this.HttpNotFound();
      }
      return this.View(sHIPORDERDETAIL);
    }
    //GET: SHIPORDERDETAILs/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var sHIPORDERDETAIL = await this.sHIPORDERDETAILService.FindAsync(id);
      return this.Json(sHIPORDERDETAIL, JsonRequestBehavior.AllowGet);
    }
    //GET: SHIPORDERDETAILs/Create
    public ActionResult Create()
    {
      var sHIPORDERDETAIL = new SHIPORDERDETAIL();
      //set default value
      var shiporderRepository = this.unitOfWork.RepositoryAsync<SHIPORDER>();
      this.ViewBag.SHIPORDERID = new SelectList(shiporderRepository.Queryable().OrderBy(n => n.SHIPORDERKEY), "ID", "SHIPORDERKEY");
      return this.View(sHIPORDERDETAIL);
    }
    //POST: SHIPORDERDETAILs/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(SHIPORDERDETAIL sHIPORDERDETAIL)
    {
      if (sHIPORDERDETAIL == null)
      {
        throw new ArgumentNullException(nameof(sHIPORDERDETAIL));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          this.sHIPORDERDETAILService.Insert(sHIPORDERDETAIL);
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
        //DisplaySuccessMessage("Has update a sHIPORDERDETAIL record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //var shiporderRepository = this.unitOfWork.RepositoryAsync<SHIPORDER>();
      //ViewBag.SHIPORDERID = new SelectList(await shiporderRepository.Queryable().OrderBy(n=>n.SHIPORDERKEY).ToListAsync(), "ID", "SHIPORDERKEY", sHIPORDERDETAIL.SHIPORDERID);
      //return View(sHIPORDERDETAIL);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var sHIPORDERDETAIL = await Task.Run(() =>
      {
        return new SHIPORDERDETAIL();
      });
      return this.Json(sHIPORDERDETAIL, JsonRequestBehavior.AllowGet);
    }


    //GET: SHIPORDERDETAILs/Edit/:id
    public ActionResult Edit(int id)
    {
      var sHIPORDERDETAIL = this.sHIPORDERDETAILService.Find(id);
      if (sHIPORDERDETAIL == null)
      {
        return this.HttpNotFound();
      }
      var shiporderRepository = this.unitOfWork.RepositoryAsync<SHIPORDER>();
      this.ViewBag.SHIPORDERID = new SelectList(shiporderRepository.Queryable().OrderBy(n => n.SHIPORDERKEY), "ID", "SHIPORDERKEY", sHIPORDERDETAIL.SHIPORDERID);
      return this.View(sHIPORDERDETAIL);
    }
    //POST: SHIPORDERDETAILs/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(SHIPORDERDETAIL sHIPORDERDETAIL)
    {
      if (sHIPORDERDETAIL == null)
      {
        throw new ArgumentNullException(nameof(sHIPORDERDETAIL));
      }
      if (this.ModelState.IsValid)
      {
        sHIPORDERDETAIL.TrackingState = TrackingState.Modified;
        try
        {
          this.sHIPORDERDETAILService.Update(sHIPORDERDETAIL);

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

        //DisplaySuccessMessage("Has update a SHIPORDERDETAIL record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //var shiporderRepository = this.unitOfWork.RepositoryAsync<SHIPORDER>();
      //return View(sHIPORDERDETAIL);
    }
    //删除当前记录
    //GET: SHIPORDERDETAILs/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.sHIPORDERDETAILService.Queryable().Where(x => x.ID == id).DeleteAsync();
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
        await this.sHIPORDERDETAILService.Queryable().Where(x => id.Contains(x.ID)).DeleteAsync();
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
      var fileName = "配送明细记录_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.sHIPORDERDETAILService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }
    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;
    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;

  }
}
