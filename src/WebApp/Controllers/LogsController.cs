using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
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
  /// File: LogsController.cs
  /// Purpose:系统管理/系统日志
  /// Created Date: 9/19/2019 8:51:53 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<Log>, Repository<Log>>();
  ///    container.RegisterType<ILogService, LogService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("Logs")]
  public class LogsController : Controller
  {
    private readonly ILogService logService;
    private readonly IUnitOfWorkAsync unitOfWork;
    private readonly NLog.ILogger logger;
    public LogsController(
      ILogService logService,
      IUnitOfWorkAsync unitOfWork,
      NLog.ILogger logger
      )
    {
      this.logService = logService;
      this.unitOfWork = unitOfWork;
      this.logger = logger;
    }
    //GET: Logs/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "系统日志", Order = 1)]
    public async Task<ActionResult> Index() {

      var start = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
      var end = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));

      this.ViewBag.TotalError = await this.logService.Queryable().Where(x => x.Level == "Error"
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0).CountAsync();
      this.ViewBag.TotalFatal = await this.logService.Queryable().Where(x => x.Level == "Fatal"
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0).CountAsync();

      this.ViewBag.TotalWarn = await this.logService.Queryable().Where(x => x.Level == "Warn"
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0).CountAsync();
      this.ViewBag.TotalInfo = await this.logService.Queryable().Where(x => x.Level == "Info"
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0
      && SqlFunctions.DateDiff("d", start, x.Logged) >= 0).CountAsync();

      
      return View();
    }

    //Get :Logs/GetData
    //For Index View datagrid datasource url
    //更新日志状态
    [HttpGet]
    public async Task<JsonResult> SetLogState(int id)
    {

      var item = await this.logService.Queryable().Where(x => x.Id == id)
        .UpdateAsync(x => new Log()
        {  Resolved=true });
      return Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }
    [HttpGet]
    public ActionResult Notify() => this.PartialView("_notifications");
    [HttpGet]
    [OutputCache(Duration = 10, VaryByParam = "*")]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.logService
                                 .Query(new LogQuery().Withfilter(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {

                                   Id = n.Id,
                                   MachineName = n.MachineName,
                                   Logged = n.Logged?.ToString("yyyy-MM-dd HH:mm:ss"),
                                   Level = n.Level,
                                   Message = n.Message,
                                   Exception = n.Exception,
                                   Properties = n.Properties,
                                   User = n.User,
                                   Logger = n.Logger,
                                   Callsite = n.Callsite,
                                   Resolved = n.Resolved
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(Log[] logs)
    {
      if (logs == null)
      {
        throw new ArgumentNullException(nameof(logs));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in logs)
          {
            this.logService.ApplyChanges(item);
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
    //GET: Logs/Details/:id
    public ActionResult Details(int id)
    {

      var log = this.logService.Find(id);
      if (log == null)
      {
        return this.HttpNotFound();
      }
      return this.View(log);
    }
    //GET: Logs/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var log = await this.logService.FindAsync(id);
      return this.Json(log, JsonRequestBehavior.AllowGet);
    }
    //GET: Logs/Create
    public ActionResult Create()
    {
      var log = new Log();
      //set default value
      return this.View(log);
    }
    //POST: Logs/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(Log log)
    {
      if (log == null)
      {
        throw new ArgumentNullException(nameof(log));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          this.logService.Insert(log);
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
        //DisplaySuccessMessage("Has update a log record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(log);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var log = await Task.Run(() =>
      {
        return new Log();
      });
      return this.Json(log, JsonRequestBehavior.AllowGet);
    }


    //GET: Logs/Edit/:id
    public ActionResult Edit(int id)
    {
      var log = this.logService.Find(id);
      if (log == null)
      {
        return this.HttpNotFound();
      }
      return this.View(log);
    }
    //POST: Logs/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(Log log)
    {
      if (log == null)
      {
        throw new ArgumentNullException(nameof(log));
      }
      if (this.ModelState.IsValid)
      {
        log.TrackingState = TrackingState.Modified;
        try
        {
          this.logService.Update(log);

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

        //DisplaySuccessMessage("Has update a Log record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(log);
    }
    //删除当前记录
    //GET: Logs/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.logService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
        this.logService.Delete(id);
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
    public ActionResult ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
    {
      var fileName = "logs_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.logService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }
    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;
    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;

  }
}
