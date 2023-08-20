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
  /// File: StandardCostsController.cs
  /// Purpose:结算中心/标准运输成本
  /// Created Date: 9/12/2019 1:48:38 PM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<StandardCost>, Repository<StandardCost>>();
  ///    container.RegisterType<IStandardCostService, StandardCostService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  [Authorize]
  [RoutePrefix("StandardCosts")]
  public class StandardCostsController : Controller
  {
    private readonly IStandardCostService standardCostService;
    private readonly IUnitOfWorkAsync unitOfWork;
    public StandardCostsController(IStandardCostService standardCostService, IUnitOfWorkAsync unitOfWork)
    {
      this.standardCostService = standardCostService;
      this.unitOfWork = unitOfWork;
    }
    //GET: StandardCosts/Index
    //[OutputCache(Duration = 60, VaryByParam = "none")]
    [Route("Index", Name = "标准运输成本", Order = 1)]
    public ActionResult Index() => this.View();

    //获取标准成本
    [HttpGet]
    public async Task<JsonResult> GetDataRule(string original, string destination, decimal stdloadweight)
    {
      var item = await Task.Run(() => {
        return this.standardCostService.GetDataRule(original, destination, stdloadweight);

      });
      return this.Json(new {success=true,  item=item }, JsonRequestBehavior.AllowGet);
      
    }
    //Get :StandardCosts/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.standardCostService
                                 .Query(new StandardCostQuery().Withfilter(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {

                                   Id = n.Id,
                                   ORIGINAL = n.ORIGINAL,
                                   DESTINATION = n.DESTINATION,
                                   STDKM = n.STDKM,
                                   STDTOLL= n.STDTOLL,
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
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    //easyui datagrid post acceptChanges 
    [HttpPost]
    public async Task<JsonResult> SaveDataAsync(StandardCost[] standardcosts)
    {
      if (standardcosts == null)
      {
        throw new ArgumentNullException(nameof(standardcosts));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          foreach (var item in standardcosts)
          {
            this.standardCostService.ApplyChanges(item);
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
    //GET: StandardCosts/Details/:id
    public ActionResult Details(int id)
    {

      var standardCost = this.standardCostService.Find(id);
      if (standardCost == null)
      {
        return this.HttpNotFound();
      }
      return this.View(standardCost);
    }
    //GET: StandardCosts/GetItemAsync/:id
    [HttpGet]
    public async Task<JsonResult> GetItemAsync(int id)
    {
      var standardCost = await this.standardCostService.FindAsync(id);
      return this.Json(standardCost, JsonRequestBehavior.AllowGet);
    }
    //GET: StandardCosts/Create
    public ActionResult Create()
    {
      var standardCost = new StandardCost();
      //set default value
      return this.View(standardCost);
    }
    //POST: StandardCosts/Create
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(StandardCost standardCost)
    {
      if (standardCost == null)
      {
        throw new ArgumentNullException(nameof(standardCost));
      }
      if (this.ModelState.IsValid)
      {
        try
        {
          this.standardCostService.Insert(standardCost);
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
        //DisplaySuccessMessage("Has update a standardCost record");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(standardCost);
    }

    //新增对象初始化
    [HttpGet]
    public async Task<JsonResult> NewItemAsync()
    {
      var standardCost = await Task.Run(() =>
      {
        return new StandardCost();
      });
      return this.Json(standardCost, JsonRequestBehavior.AllowGet);
    }


    //GET: StandardCosts/Edit/:id
    public ActionResult Edit(int id)
    {
      var standardCost = this.standardCostService.Find(id);
      if (standardCost == null)
      {
        return this.HttpNotFound();
      }
      return this.View(standardCost);
    }
    //POST: StandardCosts/Edit/:id
    //To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(StandardCost standardCost)
    {
      if (standardCost == null)
      {
        throw new ArgumentNullException(nameof(standardCost));
      }
      if (this.ModelState.IsValid)
      {
        standardCost.TrackingState = TrackingState.Modified;
        try
        {
          this.standardCostService.Update(standardCost);

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

        //DisplaySuccessMessage("Has update a StandardCost record");
        //return RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        //DisplayErrorMessage(modelStateErrors);
      }
      //return View(standardCost);
    }
    //删除当前记录
    //GET: StandardCosts/Delete/:id
    [HttpGet]
    public async Task<ActionResult> DeleteAsync(int id)
    {
      try
      {
        await this.standardCostService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
        this.standardCostService.Delete(id);
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
      var fileName = "standardcosts_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.standardCostService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }
    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;
    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;

  }
}
