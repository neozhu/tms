using System;
using System.Collections.Generic;
using System.Data;
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
  /// File: ServiceRulesController.cs
  /// Purpose:结算中心/服务项目
  /// Created Date: 2019/8/7 18:37:52
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<ServiceRule>, Repository<ServiceRule>>();
  ///    container.RegisterType<IServiceRuleService, ServiceRuleService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("ServiceRules")]
  public class ServiceRulesController : Controller
  {
    private readonly IServiceRuleService serviceRuleService;
    private readonly IUnitOfWorkAsync unitOfWork;
    public ServiceRulesController(IServiceRuleService serviceRuleService, IUnitOfWorkAsync unitOfWork)
    {
      this.serviceRuleService = serviceRuleService;
      this.unitOfWork = unitOfWork;
    }
    //GET: ServiceRules/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "服务项目 ", Order = 1)]
    public ActionResult Index() => this.View();

    //Get :ServiceRules/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.serviceRuleService
                                 .Query(new ServiceRuleQuery().Withfilter(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {

                                   Id = n.Id,
                                   NAME = n.NAME,
                                   GWT1 = n.GWT1,
                                   GWT2 = n.GWT2,
                                   ELEVATOR = n.ELEVATOR,
                                   PRICE = n.PRICE,
                                   MINAMOUNT = n.MINAMOUNT,
                                   STATUS = n.STATUS,
                                   DESCRIPTION = n.DESCRIPTION,
                                   LOTTABLE1 = n.LOTTABLE1,
                                   LOTTABLE2 = n.LOTTABLE2,
                                   LOTTABLE3 = n.LOTTABLE3
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(ServiceRule[] servicerules)
    {
      if (servicerules == null)
      {
        throw new ArgumentNullException(nameof(servicerules));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in servicerules)
          {
            this.serviceRuleService.ApplyChanges(item);
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
    //GET: ServiceRules/Details/:id
    public ActionResult Details(int id)
    {

      var serviceRule = this.serviceRuleService.Find(id);
      if (serviceRule == null)
      {
        return this.HttpNotFound();
      }
      return this.View(serviceRule);
    }
    //GET: ServiceRules/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var serviceRule = await this.serviceRuleService.FindAsync(id);
      return this.Json(serviceRule, JsonRequestBehavior.AllowGet);
    }
    //GET: ServiceRules/Create
    public ActionResult Create()
    {
      var serviceRule = new ServiceRule();
      //set default value
      return this.View(serviceRule);
    }
    //POST: ServiceRules/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(ServiceRule serviceRule)
    {
      if (serviceRule == null)
      {
        throw new ArgumentNullException(nameof(serviceRule));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          this.serviceRuleService.Insert(serviceRule);
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
        //DisplaySuccessMessage("Has update a serviceRule record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(serviceRule);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var serviceRule = await Task.Run(() =>
      {
        return new ServiceRule();
      });
      return this.Json(serviceRule, JsonRequestBehavior.AllowGet);
    }


    //GET: ServiceRules/Edit/:id
    public ActionResult Edit(int id)
    {
      var serviceRule = this.serviceRuleService.Find(id);
      if (serviceRule == null)
      {
        return this.HttpNotFound();
      }
      return this.View(serviceRule);
    }
    //POST: ServiceRules/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(ServiceRule serviceRule)
    {
      if (serviceRule == null)
      {
        throw new ArgumentNullException(nameof(serviceRule));
      }
      if (this.ModelState.IsValid)
      {
        serviceRule.TrackingState = TrackingState.Modified;
        try
        {
          this.serviceRuleService.Update(serviceRule);

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

        //DisplaySuccessMessage("Has update a ServiceRule record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(serviceRule);
    }
    //删除当前记录
    //GET: ServiceRules/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.serviceRuleService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
        await this.serviceRuleService.Queryable().Where(x => id.Contains(x.Id)).DeleteAsync();
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
      var fileName = "servicerules_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.serviceRuleService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }
    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;
    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;

  }
}
