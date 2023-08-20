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
using WebApp.App_Helpers;

namespace WebApp.Controllers
{
/// <summary>
/// File: StatusHistoriesController.cs
/// Purpose:业务操作/历史状态查询
/// Created Date: 8/13/2019 3:05:27 PM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
/// <![CDATA[
///    container.RegisterType<IRepositoryAsync<StatusHistory>, Repository<StatusHistory>>();
///    container.RegisterType<IStatusHistoryService, StatusHistoryService>();
/// ]]>
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    [Authorize]
    [RoutePrefix("StatusHistories")]
	public class StatusHistoriesController : Controller
	{
		private readonly IStatusHistoryService  statusHistoryService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public StatusHistoriesController (IStatusHistoryService  statusHistoryService, IUnitOfWorkAsync unitOfWork)
		{
			this.statusHistoryService  = statusHistoryService;
			this.unitOfWork = unitOfWork;
		}
        		//GET: StatusHistories/Index
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        [Route("Index", Name = "历史状态查询 ", Order = 1)]
		public ActionResult Index() => this.View();
    //获取订单历史记录
    [HttpGet]
    public async Task<JsonResult> GetOrderHistory(string orderkey) {
      //var test = GPSHelper.GetAddress(116.310003m, 39.991957m);

      var rows = (await this.statusHistoryService.Queryable().Where(x => x.ORDERKEY == orderkey)
        .ToListAsync())
        .Select(n => new
        {
          ORDERKEY = n.ORDERKEY,
          SHIPORDERKEY = n.SHIPORDERKEY,
          STATUS = n.STATUS,
          DESCRIPTION = n.DESCRIPTION,
          REMARK = n.REMARK,
          TRANSACTIONDATETIME = n.TRANSACTIONDATETIME.ToString("yyyy-MM-dd HH:mm:00"),
        }).Distinct();
      return Json(new {success=true,data=rows }, JsonRequestBehavior.AllowGet);
    }
    //获取运单记录
    [HttpGet]
    public async Task<JsonResult> GetShipOrderHistory(string shiporderkey)
    {
      //var test = GPSHelper.GetAddress(116.310003m, 39.991957m);

      var rows = ( await this.statusHistoryService.Queryable().Where(x => x.SHIPORDERKEY == shiporderkey && (x.ORDERKEY==null || x.ORDERKEY==string.Empty))
        .ToListAsync() )
        .Select(n => new
        {
          ORDERKEY = n.ORDERKEY,
          SHIPORDERKEY = n.SHIPORDERKEY,
          STATUS = n.STATUS,
          DESCRIPTION = n.DESCRIPTION,
          REMARK = n.REMARK,
          TRANSACTIONDATETIME = n.TRANSACTIONDATETIME.ToString("yyyy-MM-dd HH:mm:00"),
        }).Distinct();
      return Json(new { success = true, data = rows }, JsonRequestBehavior.AllowGet);
    }

    //Get :StatusHistories/GetData
    //For Index View datagrid datasource url
    [HttpGet]
		 public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
		{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var pagerows  = (await this.statusHistoryService
						               .Query(new StatusHistoryQuery().Withfilter(filters))
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out var totalCount))
                                       .Select(  n => new { 

    Id = n.Id,
    ORDERKEY = n.ORDERKEY,
    SHIPORDERKEY = n.SHIPORDERKEY,
    STATUS = n.STATUS,
    DESCRIPTION = n.DESCRIPTION,
    REMARK = n.REMARK,
    TRANSACTIONDATETIME = n.TRANSACTIONDATETIME.ToString("yyyy-MM-dd HH:mm:ss"),
    USER = n.USER,
    LONGITUDE = n.LONGITUDE,
    LATITUDE = n.LATITUDE
}).ToList();
			var pagelist = new { total = totalCount, rows = pagerows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
        //easyui datagrid post acceptChanges 
		[HttpPost]
		public async Task<JsonResult> SaveDataAsync(StatusHistory[] statushistories)
		{
            if (statushistories == null)
            {
                throw new ArgumentNullException(nameof(statushistories));
            }
            if (ModelState.IsValid)
			{
            try{
               foreach (var item in statushistories)
               {
                 this.statusHistoryService.ApplyChanges(item);
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
						//GET: StatusHistories/Details/:id
		public ActionResult Details(int id)
		{
			
			var statusHistory = this.statusHistoryService.Find(id);
			if (statusHistory == null)
			{
				return HttpNotFound();
			}
			return View(statusHistory);
		}
        //GET: StatusHistories/GetItemAsync/:id
        [HttpGet]
        public async Task<JsonResult> GetItemAsync(int id) {
            var  statusHistory = await this.statusHistoryService.FindAsync(id);
            return Json(statusHistory,JsonRequestBehavior.AllowGet);
        }
		//GET: StatusHistories/Create
        		public ActionResult Create()
				{
			var statusHistory = new StatusHistory();
			//set default value
			return View(statusHistory);
		}
		//POST: StatusHistories/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(StatusHistory statusHistory)
		{
			if (statusHistory == null)
            {
                throw new ArgumentNullException(nameof(statusHistory));
            } 
            if (ModelState.IsValid)
			{
                try{ 
				this.statusHistoryService.Insert(statusHistory);
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
			    //DisplaySuccessMessage("Has update a statusHistory record");
			}
			else {
			   var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			   return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			   //DisplayErrorMessage(modelStateErrors);
			}
			//return View(statusHistory);
		}

        //新增对象初始化
        [HttpGet]
        public async Task<JsonResult> NewItemAsync() {
            var statusHistory = await Task.Run(() => {
                return new StatusHistory();
                });
            return Json(statusHistory, JsonRequestBehavior.AllowGet);
        }

         
		//GET: StatusHistories/Edit/:id
		public ActionResult Edit(int id)
		{
			var statusHistory = this.statusHistoryService.Find(id);
			if (statusHistory == null)
			{
				return HttpNotFound();
			}
			return View(statusHistory);
		}
		//POST: StatusHistories/Edit/:id
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(StatusHistory statusHistory)
		{
            if (statusHistory == null)
            {
                throw new ArgumentNullException(nameof(statusHistory));
            }
			if (ModelState.IsValid)
			{
				statusHistory.TrackingState = TrackingState.Modified;
				                try{
				this.statusHistoryService.Update(statusHistory);
				                
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
				
				//DisplaySuccessMessage("Has update a StatusHistory record");
				//return RedirectToAction("Index");
			}
			else {
			var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			//DisplayErrorMessage(modelStateErrors);
			}
						//return View(statusHistory);
		}
        //删除当前记录
		//GET: StatusHistories/Delete/:id
        [HttpGet]
		public async Task<ActionResult> DeleteAsync(int id)
		{
          try{
               await this.statusHistoryService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
               await this.statusHistoryService.Queryable().Where(x => id.Contains(x.Id)).DeleteAsync();
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
			var fileName = "statushistories_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.statusHistoryService.ExportExcel(filterRules,sort, order );
			return File(stream, "application/vnd.ms-excel", fileName);
		}
		private void DisplaySuccessMessage(string msgText) => TempData["SuccessMessage"] = msgText;
        private void DisplayErrorMessage(string msgText) => TempData["ErrorMessage"] = msgText;
		 
	}
}
