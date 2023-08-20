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
/// File: WaybillsController.cs
/// Purpose:结算中心/运单报表
/// Created Date: 2020/6/24 16:53:56
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
/// <![CDATA[
///    container.RegisterType<IRepositoryAsync<Waybill>, Repository<Waybill>>();
///    container.RegisterType<IWaybillService, WaybillService>();
/// ]]>
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    [Authorize]
    [RoutePrefix("Waybills")]
	public class WaybillsController : Controller
	{
		private readonly IWaybillService  waybillService;
		private readonly IUnitOfWorkAsync unitOfWork;
        private readonly NLog.ILogger logger;
		public WaybillsController (
          IWaybillService  waybillService, 
          IUnitOfWorkAsync unitOfWork,
          NLog.ILogger logger
          )
		{
			this.waybillService  = waybillService;
			this.unitOfWork = unitOfWork;
            this.logger = logger;
		}
        		//GET: Waybills/Index
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        [Route("Index", Name = "运单报表", Order = 1)]
		public ActionResult Index() => this.View();

    public async Task<JsonResult> Confirm(int[] id) {
      try
      {
        await this.waybillService.Confirm(id);
        await this.unitOfWork.SaveChangesAsync();
        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e) {
        return Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }
		//Get :Waybills/GetData
		//For Index View datagrid datasource url
        
		[HttpGet]
        //[OutputCache(Duration = 10, VaryByParam = "*")]
		 public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
		{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var pagerows  = (await this.waybillService
						               .Query(new WaybillQuery().Withfilter(filters))
							           .OrderBy(n=>n.OrderBy(sort,order).ThenBy(s=>s.CustomerName).ThenByDescending(y=>y.Id))
							           .SelectPageAsync(page, rows, out var totalCount))
                                       .Select(  n => new { 

    Id = n.Id,
    OrderNo = n.OrderNo,
    Status = n.Status,
    CustomerId = n.CustomerId,
    CustomerName = n.CustomerName,
    ProjectNo = n.ProjectNo,
    PickNo = n.PickNo,
    ShippedDate = n.ShippedDate.ToString("yyyy-MM-dd HH:mm:ss"),
    Original = n.Original,
    Destination = n.Destination,
    Remark = n.Remark,
    ProductNo = n.ProductNo,
    LotNo = n.LotNo,
    Qty = n.Qty,
    Weight = n.Weight,
    Cube = n.Cube,
    SPrice = n.SPrice,
    SAmount = n.SAmount,
    CPrice = n.CPrice,
    CAmount = n.CAmount,
    Way = n.Way,
    Sales = n.Sales,
    SalesGroup = n.SalesGroup,
    Remark1 = n.Remark1,
    Remark2 = n.Remark2,
    Flag = n.Flag,
    Driver = n.Driver,
    Transport = n.Transport
}).ToList();
			var pagelist = new { total = totalCount, rows = pagerows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
        //easyui datagrid post acceptChanges 
		[HttpPost]
		public async Task<JsonResult> SaveData(Waybill[] waybills)
		{
            if (waybills == null)
            {
                throw new ArgumentNullException(nameof(waybills));
            }
            if (ModelState.IsValid)
			{
            try{
               foreach (var item in waybills)
               {
                 this.waybillService.ApplyChanges(item);
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
						//GET: Waybills/Details/:id
		public ActionResult Details(int id)
		{
			
			var waybill = this.waybillService.Find(id);
			if (waybill == null)
			{
				return HttpNotFound();
			}
			return View(waybill);
		}
        //GET: Waybills/GetItem/:id
        [HttpGet]
        public async Task<JsonResult> GetItem(int id) {
            var  waybill = await this.waybillService.FindAsync(id);
            return Json(waybill,JsonRequestBehavior.AllowGet);
        }
		//GET: Waybills/Create
        		public ActionResult Create()
				{
			var waybill = new Waybill();
			//set default value
			return View(waybill);
		}
		//POST: Waybills/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Waybill waybill)
		{
			if (waybill == null)
            {
                throw new ArgumentNullException(nameof(waybill));
            } 
            if (ModelState.IsValid)
			{
                try{ 
				this.waybillService.Insert(waybill);
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
			    //DisplaySuccessMessage("Has update a waybill record");
			}
			else {
			   var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			   return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			   //DisplayErrorMessage(modelStateErrors);
			}
			//return View(waybill);
		}

        //新增对象初始化
        [HttpGet]
        public async Task<JsonResult> NewItem() {
            var waybill = await Task.Run(() => {
                return new Waybill();
                });
            return Json(waybill, JsonRequestBehavior.AllowGet);
        }

         
		//GET: Waybills/Edit/:id
		public ActionResult Edit(int id)
		{
			var waybill = this.waybillService.Find(id);
			if (waybill == null)
			{
				return HttpNotFound();
			}
			return View(waybill);
		}
		//POST: Waybills/Edit/:id
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Waybill waybill)
		{
            if (waybill == null)
            {
                throw new ArgumentNullException(nameof(waybill));
            }
			if (ModelState.IsValid)
			{
				waybill.TrackingState = TrackingState.Modified;
				                try{
				this.waybillService.Update(waybill);
				                
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
				
				//DisplaySuccessMessage("Has update a Waybill record");
				//return RedirectToAction("Index");
			}
			else {
			var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			//DisplayErrorMessage(modelStateErrors);
			}
						//return View(waybill);
		}
        //删除当前记录
		//GET: Waybills/Delete/:id
        [HttpGet]
		public async Task<ActionResult> Delete(int id)
		{
          try{
               await this.waybillService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
        public async Task<JsonResult> DeleteChecked(int[] id) {
           if (id == null)
           {
                throw new ArgumentNullException(nameof(id));
           }
           try{
               await this.waybillService.Delete(id);
               await this.unitOfWork.SaveChangesAsync();
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
		public async Task<ActionResult> ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "waybills_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream = await this.waybillService.ExportExcelAsync(filterRules,sort, order );
			return File(stream, "application/vnd.ms-excel", fileName);
		}
		private void DisplaySuccessMessage(string msgText) => TempData["SuccessMessage"] = msgText;
        private void DisplayErrorMessage(string msgText) => TempData["ErrorMessage"] = msgText;
		 
	}
}
