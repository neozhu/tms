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
  /// File: LocBasesController.cs
  /// Purpose:主数据管理/地址库信息
  /// Created Date: 2019/8/5 8:58:19
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<LocBase>, Repository<LocBase>>();
  ///    container.RegisterType<ILocBaseService, LocBaseService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("LocBases")]
  public class LocBasesController : Controller
  {
    private readonly ILocBaseService locBaseService;
    private readonly IUnitOfWorkAsync unitOfWork;
    public LocBasesController(ILocBaseService locBaseService, IUnitOfWorkAsync unitOfWork)
    {
      this.locBaseService = locBaseService;
      this.unitOfWork = unitOfWork;
    }
    //GET: LocBases/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "地址库信息 ", Order = 1)]
    public ActionResult Index() => this.View();

    [HttpGet]
    public async Task<JsonResult> GetComboData(string q="") {
      var data = await this.locBaseService.Queryable().Where(x => x.Name.Contains(q))
        .Select(n => new { n.Name, n.Latitude, n.Longitude, n.Description })
        .ToListAsync();
      return Json(data, JsonRequestBehavior.AllowGet);
    }
    //Get :LocBases/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.locBaseService
                                 .Query(new LocBaseQuery().Withfilter(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {

                                   Id = n.Id,
                                   Name = n.Name,
                                   Description = n.Description,
                                   Longitude = n.Longitude,
                                   Latitude = n.Latitude,
                                   Radius = n.Radius,
                                   Gid = n.Gid,
                                   Enable = n.Enable
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(LocBase[] locbases)
    {
      if (locbases == null)
      {
        throw new ArgumentNullException(nameof(locbases));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in locbases)
          {
            this.locBaseService.ApplyChanges(item);
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
    //GET: LocBases/Details/:id
    public ActionResult Details(int id)
    {

      var locBase = this.locBaseService.Find(id);
      if (locBase == null)
      {
        return this.HttpNotFound();
      }
      return this.View(locBase);
    }
    //GET: LocBases/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var locBase = await this.locBaseService.FindAsync(id);
      return this.Json(locBase, JsonRequestBehavior.AllowGet);
    }
    //GET: LocBases/Create
    public ActionResult Create()
    {
      var locBase = new LocBase();
      //set default value
      return this.View(locBase);
    }
    //POST: LocBases/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(LocBase locBase)
    {
      if (locBase == null)
      {
        throw new ArgumentNullException(nameof(locBase));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          locBase.Latitude1 = locBase.Latitude;
          locBase.Longitude1 = locBase.Longitude;
          this.locBaseService.Insert(locBase);
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
        //DisplaySuccessMessage("Has update a locBase record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(locBase);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var locBase = await Task.Run(() =>
      {
        return new LocBase();
      });
      return this.Json(locBase, JsonRequestBehavior.AllowGet);
    }


    //GET: LocBases/Edit/:id
    public ActionResult Edit(int id)
    {
      var locBase = this.locBaseService.Find(id);
      if (locBase == null)
      {
        return this.HttpNotFound();
      }
      return this.View(locBase);
    }
    //POST: LocBases/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(LocBase locBase)
    {
      if (locBase == null)
      {
        throw new ArgumentNullException(nameof(locBase));
      }
      if (this.ModelState.IsValid)
      {
        locBase.Latitude1 = locBase.Latitude;
        locBase.Longitude1 = locBase.Longitude;

        locBase.TrackingState = TrackingState.Modified;
        try
        {
          this.locBaseService.Update(locBase);

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

        //DisplaySuccessMessage("Has update a LocBase record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(locBase);
    }
    //删除当前记录
    //GET: LocBases/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.locBaseService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
        await this.locBaseService.Queryable().Where(x => id.Contains(x.Id)).DeleteAsync();
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
    public ActionResult ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
    {
      var fileName = "locbases_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.locBaseService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }
    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;
    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;

  }
}
