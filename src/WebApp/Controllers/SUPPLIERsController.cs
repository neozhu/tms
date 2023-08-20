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
/// File: SUPPLIERsController.cs
/// Purpose:主数据管理/供应商信息
/// Created Date: 2019/8/1 7:43:09
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
/// <![CDATA[
///    container.RegisterType<IRepositoryAsync<SUPPLIER>, Repository<SUPPLIER>>();
///    container.RegisterType<ISUPPLIERService, SUPPLIERService>();
/// ]]>
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    [Authorize]
    [RoutePrefix("SUPPLIERs")]
	public class SUPPLIERsController : Controller
	{
		private readonly ISUPPLIERService  sUPPLIERService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public SUPPLIERsController (ISUPPLIERService  sUPPLIERService, IUnitOfWorkAsync unitOfWork)
		{
			this.sUPPLIERService  = sUPPLIERService;
			this.unitOfWork = unitOfWork;
		}
        		//GET: SUPPLIERs/Index
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        [Route("Index", Name = "供应商信息 ", Order = 1)]
		public ActionResult Index() => this.View();
    [HttpGet]
    [OutputCache(Duration = 30, VaryByParam = "q")]
    public async Task<JsonResult> GetComboGridData(string q = "", int page = 1, int rows = 10, string sort = "SUPPLIERCODE", string order = "asc")
    {
      try
      {

        var pagerows = ( await this.sUPPLIERService
                                        .Query(new SUPPLIERQuery().WithfilterQ(q))
                                        .OrderBy(n => n.OrderBy(sort, order))
                                        .SelectPageAsync(page, rows, out var totalCount) )
                                        .Select(n => new
                                        {
                                          ID = n.ID,
                                          SUPPLIERCODE = n.SUPPLIERCODE,
                                          SUPPLIERNAME = n.SUPPLIERNAME,
                                          ISDISABLED = n.ISDISABLED,
                                          ADDRESS1 = n.ADDRESS1,
                                          ADDRESS2 = n.ADDRESS2,
                                          Loc1=n.Loc1,
                                          Loc2 = n.Loc2,
                                          CONTACT = n.CONTACT,
                                          PHONENUMBER = n.PHONENUMBER,
                                          EMAIL = n.EMAIL,
                                          NOTES = n.NOTES
                                        });
        var pagelist = new { total = totalCount, rows = pagerows };
        return Json(pagelist, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        throw e;
      }

    }
    [HttpGet]
    [OutputCache(Duration = 30, VaryByParam = "q")]
    public async Task<JsonResult> GetComboData(string q = "")
    {
      try
      {

        var result =  (await this.sUPPLIERService
                                        .Query(new SUPPLIERQuery().WithfilterQ(q))
                                        .OrderBy(n => n.OrderBy(x=>x.SUPPLIERNAME))
                                        .SelectAsync())
                                        .Select(n => new
                                        {
                                          ID = n.ID,
                                          SUPPLIERCODE = n.SUPPLIERCODE,
                                          SUPPLIERNAME = n.SUPPLIERNAME,
                                          ISDISABLED = n.ISDISABLED,
                                          ADDRESS1 = n.ADDRESS1,
                                          ADDRESS2 = n.ADDRESS2,
                                          Loc1 = n.Loc1,
                                          Loc2 = n.Loc2,
                                          CONTACT = n.CONTACT,
                                          PHONENUMBER = n.PHONENUMBER,
                                          EMAIL = n.EMAIL,
                                          NOTES = n.NOTES
                                        });
       
        return Json(result, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        throw e;
      }

    }

    //Get :SUPPLIERs/GetData
    //For Index View datagrid datasource url
    [HttpGet]
		 public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
		{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var pagerows  = (await this.sUPPLIERService
						               .Query(new SUPPLIERQuery().Withfilter(filters))
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out var totalCount))
                                       .Select(  n => new { 

    ID = n.ID,
    SUPPLIERCODE = n.SUPPLIERCODE,
    SUPPLIERNAME = n.SUPPLIERNAME,
    ISDISABLED = n.ISDISABLED,
                                         Loc1 = n.Loc1,
                                         Loc2 = n.Loc2,
                                         ADDRESS1 = n.ADDRESS1,
    ADDRESS2 = n.ADDRESS2,
    CONTACT = n.CONTACT,
    PHONENUMBER = n.PHONENUMBER,
    EMAIL = n.EMAIL,
    NOTES = n.NOTES
}).ToList();
			var pagelist = new { total = totalCount, rows = pagerows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
        //easyui datagrid post acceptChanges 
		[HttpPost]
		public async Task<JsonResult> SaveDataAsync(SUPPLIER[] suppliers)
		{
            if (suppliers == null)
            {
                throw new ArgumentNullException(nameof(suppliers));
            }
            if (ModelState.IsValid)
			{
            try{
               foreach (var item in suppliers)
               {
                 this.sUPPLIERService.ApplyChanges(item);
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
						//GET: SUPPLIERs/Details/:id
		public ActionResult Details(int id)
		{
			
			var sUPPLIER = this.sUPPLIERService.Find(id);
			if (sUPPLIER == null)
			{
				return HttpNotFound();
			}
			return View(sUPPLIER);
		}
        //GET: SUPPLIERs/GetItemAsync/:id
        [HttpGet]
        public async Task<JsonResult> GetItemAsync(int id) {
            var  sUPPLIER = await this.sUPPLIERService.FindAsync(id);
            return Json(sUPPLIER,JsonRequestBehavior.AllowGet);
        }
		//GET: SUPPLIERs/Create
        		public ActionResult Create()
				{
			var sUPPLIER = new SUPPLIER();
			//set default value
			return View(sUPPLIER);
		}
		//POST: SUPPLIERs/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(SUPPLIER sUPPLIER)
		{
			if (sUPPLIER == null)
            {
                throw new ArgumentNullException(nameof(sUPPLIER));
            } 
            if (ModelState.IsValid)
			{
                try{ 
				this.sUPPLIERService.Insert(sUPPLIER);
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
			    //DisplaySuccessMessage("Has update a sUPPLIER record");
			}
			else {
			   var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			   return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			   //DisplayErrorMessage(modelStateErrors);
			}
			//return View(sUPPLIER);
		}

        //新增对象初始化
        [HttpGet]
        public async Task<JsonResult> NewItemAsync() {
            var sUPPLIER = await Task.Run(() => {
                return new SUPPLIER();
                });
            return Json(sUPPLIER, JsonRequestBehavior.AllowGet);
        }

         
		//GET: SUPPLIERs/Edit/:id
		public ActionResult Edit(int id)
		{
			var sUPPLIER = this.sUPPLIERService.Find(id);
			if (sUPPLIER == null)
			{
				return HttpNotFound();
			}
			return View(sUPPLIER);
		}
		//POST: SUPPLIERs/Edit/:id
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(SUPPLIER sUPPLIER)
		{
            if (sUPPLIER == null)
            {
                throw new ArgumentNullException(nameof(sUPPLIER));
            }
			if (ModelState.IsValid)
			{
				sUPPLIER.TrackingState = TrackingState.Modified;
				                try{
				this.sUPPLIERService.Update(sUPPLIER);
				                
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
				
				//DisplaySuccessMessage("Has update a SUPPLIER record");
				//return RedirectToAction("Index");
			}
			else {
			var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			//DisplayErrorMessage(modelStateErrors);
			}
						//return View(sUPPLIER);
		}
        //删除当前记录
		//GET: SUPPLIERs/Delete/:id
        [HttpGet]
		public async Task<ActionResult> DeleteAsync(int id)
		{
          try{
               await this.sUPPLIERService.Queryable().Where(x => x.ID == id).DeleteAsync();
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
               await this.sUPPLIERService.Queryable().Where(x => id.Contains(x.ID)).DeleteAsync();
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
		public ActionResult ExportExcel( string filterRules = "",string sort = "ID", string order = "asc")
		{
			var fileName = "suppliers_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.sUPPLIERService.ExportExcel(filterRules,sort, order );
			return File(stream, "application/vnd.ms-excel", fileName);
		}
		private void DisplaySuccessMessage(string msgText) => TempData["SuccessMessage"] = msgText;
        private void DisplayErrorMessage(string msgText) => TempData["ErrorMessage"] = msgText;
		 
	}
}
