using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Infrastructure;
using Z.EntityFramework.Plus;
using TrackableEntities;
using WebApp.Models;
using WebApp.Services;
using WebApp.Repositories;
namespace WebApp.Controllers
{
/// <summary>
/// File: FreightRulesController.cs
/// Purpose:结算中心/运费规则信息
/// Created Date: 2019/8/7 18:40:07
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
/// <![CDATA[
///    container.RegisterType<IRepositoryAsync<FreightRule>, Repository<FreightRule>>();
///    container.RegisterType<IFreightRuleService, FreightRuleService>();
/// ]]>
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    [Authorize]
    [RoutePrefix("FreightRules")]
	public class FreightRulesController : Controller
	{
		private readonly IFreightRuleService  freightRuleService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public FreightRulesController (IFreightRuleService  freightRuleService, IUnitOfWorkAsync unitOfWork)
		{
			this.freightRuleService  = freightRuleService;
			this.unitOfWork = unitOfWork;
		}
        		//GET: FreightRules/Index
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        [Route("Index", Name = "运费规则信息 ", Order = 1)]
		public ActionResult Index() => this.View();

		//Get :FreightRules/GetData
		//For Index View datagrid datasource url
		[HttpGet]
		 public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
		{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var pagerows  = (await this.freightRuleService
						               .Query(new FreightRuleQuery().Withfilter(filters))
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out var totalCount))
                                       .Select(  n => new { 

    Id = n.Id,
    ORIGINAL = n.ORIGINAL,
    DESTINATION = n.DESTINATION,
    SHPTYPE = n.SHPTYPE,
    CALTYPE = n.CALTYPE,
    CARLWT1 = n.CARLWT1,
    CARLWT2 = n.CARLWT2,
    PRICE = n.PRICE,
    MINAMOUNT = n.MINAMOUNT,
    STATUS = n.STATUS,
    DESCRIPTION = n.DESCRIPTION,
    LOTTABLE1 = n.LOTTABLE1,
    LOTTABLE2 = n.LOTTABLE2,
    LOTTABLE3 = n.LOTTABLE3
}).ToList();
			var pagelist = new { total = totalCount, rows = pagerows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
        //easyui datagrid post acceptChanges 
		[HttpPost]
		public async Task<JsonResult> SaveDataAsync(FreightRule[] freightrules)
		{
            if (freightrules == null)
            {
                throw new ArgumentNullException(nameof(freightrules));
            }
            if (ModelState.IsValid)
			{
            try{
               foreach (var item in freightrules)
               {
                 this.freightRuleService.ApplyChanges(item);
               }
			   var result = await this.unitOfWork.SaveChangesAsync();
			   return Json(new {success=true,result}, JsonRequestBehavior.AllowGet);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
                 return Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
                {
                    return Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
                }
		    }
            else
            {
                var modelStateErrors = string.Join(",", ModelState.Keys.SelectMany(key => ModelState[key].Errors.Select(n => n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
        
        }
						//GET: FreightRules/Details/:id
		public ActionResult Details(int id)
		{
			
			var freightRule = this.freightRuleService.Find(id);
			if (freightRule == null)
			{
				return HttpNotFound();
			}
			return View(freightRule);
		}
        //GET: FreightRules/GetItemAsync/:id
        [HttpGet]
        public async Task<JsonResult> GetItemAsync(int id) {
            var  freightRule = await this.freightRuleService.FindAsync(id);
            return Json(freightRule,JsonRequestBehavior.AllowGet);
        }
		//GET: FreightRules/Create
        		public ActionResult Create()
				{
			var freightRule = new FreightRule();
			//set default value
			return View(freightRule);
		}
		//POST: FreightRules/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(FreightRule freightRule)
		{
			if (freightRule == null)
            {
                throw new ArgumentNullException(nameof(freightRule));
            } 
            if (ModelState.IsValid)
			{
                try{ 
				this.freightRuleService.Insert(freightRule);
				var result = await this.unitOfWork.SaveChangesAsync();
                return Json(new { success = true,result }, JsonRequestBehavior.AllowGet);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                   var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
                   return Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
                }
			    //DisplaySuccessMessage("Has update a freightRule record");
			}
			else {
			   var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			   return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			   //DisplayErrorMessage(modelStateErrors);
			}
			//return View(freightRule);
		}

        //新增对象初始化
        [HttpGet]
        public async Task<JsonResult> NewItemAsync() {
            var freightRule = await Task.Run(() => {
                return new FreightRule();
                });
            return Json(freightRule, JsonRequestBehavior.AllowGet);
        }

         
		//GET: FreightRules/Edit/:id
		public ActionResult Edit(int id)
		{
			var freightRule = this.freightRuleService.Find(id);
			if (freightRule == null)
			{
				return HttpNotFound();
			}
			return View(freightRule);
		}
		//POST: FreightRules/Edit/:id
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(FreightRule freightRule)
		{
            if (freightRule == null)
            {
                throw new ArgumentNullException(nameof(freightRule));
            }
			if (ModelState.IsValid)
			{
				freightRule.TrackingState = TrackingState.Modified;
				                try{
				this.freightRuleService.Update(freightRule);
				                
				var result = await this.unitOfWork.SaveChangesAsync();
                return Json(new { success = true,result = result }, JsonRequestBehavior.AllowGet);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
                    return Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    return Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
                }
				
				//DisplaySuccessMessage("Has update a FreightRule record");
				//return RedirectToAction("Index");
			}
			else {
			var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			//DisplayErrorMessage(modelStateErrors);
			}
						//return View(freightRule);
		}
        //删除当前记录
		//GET: FreightRules/Delete/:id
        [HttpGet]
		public async Task<ActionResult> DeleteAsync(int id)
		{
          try{
               await this.freightRuleService.Queryable().Where(x => x.Id == id).DeleteAsync();
               return Json(new { success = true }, JsonRequestBehavior.AllowGet);
           }
           catch (System.Data.Entity.Validation.DbEntityValidationException e)
           {
                var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
                return Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
           }
           catch (Exception e)
           {
                return Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
           }
		}
		 
       
 

        //删除选中的记录
        [HttpPost]
        public async Task<JsonResult> DeleteCheckedAsync(int[] id) {
           if (id == null)
           {
                throw new ArgumentNullException(nameof(id));
           }
           try{
               await this.freightRuleService.Queryable().Where(x => id.Contains(x.Id)).DeleteAsync();
               return Json(new { success = true }, JsonRequestBehavior.AllowGet);
           }
           catch (System.Data.Entity.Validation.DbEntityValidationException e)
           {
                    var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
                    return Json(new { success = false, err = errormessage }, JsonRequestBehavior.AllowGet);
           }
           catch (Exception e)
           {
                    return Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
           }
        }
		//导出Excel
		[HttpPost]
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "freightrules_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.freightRuleService.ExportExcel(filterRules,sort, order );
			return File(stream, "application/vnd.ms-excel", fileName);
		}
		private void DisplaySuccessMessage(string msgText) => TempData["SuccessMessage"] = msgText;
        private void DisplayErrorMessage(string msgText) => TempData["ErrorMessage"] = msgText;
		 
	}
}
