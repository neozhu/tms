﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Infrastructure;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Services;
using WebApp.Repositories;
using Z.EntityFramework.Plus;
using TrackableEntities;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
  [Authorize]
  [RoutePrefix("DataTableImportMappings")]
  public class DataTableImportMappingsController : Controller
    {
        
        //Please RegisterType UnityConfig.cs
        //container.RegisterType<IRepositoryAsync<DataTableImportMapping>, Repository<DataTableImportMapping>>();
        //container.RegisterType<IDataTableImportMappingService, DataTableImportMappingService>();
        
        //private ImsDbContext db = new ImsDbContext();
        private readonly IDataTableImportMappingService  _dataTableImportMappingService;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public DataTableImportMappingsController (IDataTableImportMappingService  dataTableImportMappingService, IUnitOfWorkAsync unitOfWork)
        {
            _dataTableImportMappingService  = dataTableImportMappingService;
            _unitOfWork = unitOfWork;
        }

    // GET: DataTableImportMappings/Index
    [Route("Index", Name = "Excel导入导出配置", Order = 1)]
    public ActionResult Index()
        {
            
            //var datatableimportmappings  = _dataTableImportMappingService.Queryable().AsQueryable();
            //return View(datatableimportmappings  );
			return View();
        }

    // Get :DataTableImportMappings/PageList
    // For Index View Boostrap-Table load  data 
    [HttpGet]
    public async Task<JsonResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "desc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var totalCount = 0;
      //int pagenum = offset / limit +1;
      var datatableimportmappings = await this._dataTableImportMappingService.Query(new DataTableImportMappingQuery().Withfilter(filters)).OrderBy(n => n.OrderBy(sort, order)).SelectPageAsync(page, rows, out totalCount);
      var datarows = datatableimportmappings.Select(n => new
      {
        Id = n.Id,
        EntitySetName = n.EntitySetName,
        DefaultValue = n.DefaultValue,
        FieldName = n.FieldName,
        IsRequired = n.IsRequired,
        TypeName = n.TypeName,
        SourceFieldName = n.SourceFieldName,
        IsEnabled = n.IsEnabled,
        IgnoredColumn=n.IgnoredColumn,
        RegularExpression = n.RegularExpression
      }).ToList();
      var pagelist = new { total = totalCount, rows = datarows };
      return Json(pagelist, JsonRequestBehavior.AllowGet);
    }

		[HttpPost]
		public ActionResult SaveData(DataTableImportMappingChangeViewModel datatableimportmappings)
        {
            if (datatableimportmappings.updated != null)
            {
                foreach (var updated in datatableimportmappings.updated)
                {
                    _dataTableImportMappingService.Update(updated);
                }
            }
            if (datatableimportmappings.deleted != null)
            {
                foreach (var deleted in datatableimportmappings.deleted)
                {
                    _dataTableImportMappingService.Delete(deleted);
                }
            }
            if (datatableimportmappings.inserted != null)
            {
                foreach (var inserted in datatableimportmappings.inserted)
                {
                    _dataTableImportMappingService.Insert(inserted);
                }
            }
            _unitOfWork.SaveChanges();

            return Json(new {success=true}, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetAllEntites() {
            var list = _dataTableImportMappingService.GetAssemblyEntities();
            var rows = list.Select(x => new { Name = x.EntitySetName, Value = x.EntitySetName }).Distinct();
            return Json(rows, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Generate(string entityname)
        {
            _dataTableImportMappingService.GenerateByEnityName(entityname);
            _unitOfWork.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateExcelTemplate(string entityname) {

            var count = this._dataTableImportMappingService.Queryable().Where(x => x.EntitySetName == entityname && x.IsEnabled == true).DeferredAny().FromCache();
            if (count)
            {
                var filename = Server.MapPath("~/ExcelTemplate/" + entityname + ".xlsx");
                _dataTableImportMappingService.CreateExcelTemplate(entityname, filename);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { success = false,message="没有找到[" + entityname + "]配置信息请,先执行【生成】mapping关系" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: DataTableImportMappings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dataTableImportMapping = _dataTableImportMappingService.Find(id);
            if (dataTableImportMapping == null)
            {
                return HttpNotFound();
            }
            return View(dataTableImportMapping);
        }
        

        // GET: DataTableImportMappings/Create
        public ActionResult Create()
        {
            var dataTableImportMapping = new DataTableImportMapping();
            //set default value
            return View(dataTableImportMapping);
        }

        // POST: DataTableImportMappings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EntitySetName,FieldName,TypeName,SourceFieldName,DefaultValue,IsEnabled,RegularExpression")] DataTableImportMapping dataTableImportMapping)
        {
            if (ModelState.IsValid)
            {
             				_dataTableImportMappingService.Insert(dataTableImportMapping);
                           _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has append a DataTableImportMapping record");
                return RedirectToAction("Index");
            }

            if (Request.IsAjaxRequest())
            {
                var modelStateErrors = string.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(dataTableImportMapping);
        }

        // GET: DataTableImportMappings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dataTableImportMapping = _dataTableImportMappingService.Find(id);
            if (dataTableImportMapping == null)
            {
                return HttpNotFound();
            }
            return View(dataTableImportMapping);
        }

        // POST: DataTableImportMappings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EntitySetName,FieldName,TypeName,SourceFieldName,DefaultValue,IsEnabled,RegularExpression")] DataTableImportMapping dataTableImportMapping)
        {
            if (ModelState.IsValid)
            {
                dataTableImportMapping.TrackingState = TrackingState.Modified;
                				_dataTableImportMappingService.Update(dataTableImportMapping);
                                
                _unitOfWork.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                DisplaySuccessMessage("Has update a DataTableImportMapping record");
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                var modelStateErrors = string.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
                return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
            }
            DisplayErrorMessage();
            return View(dataTableImportMapping);
        }

        // GET: DataTableImportMappings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dataTableImportMapping = _dataTableImportMappingService.Find(id);
            if (dataTableImportMapping == null)
            {
                return HttpNotFound();
            }
            return View(dataTableImportMapping);
        }

        // POST: DataTableImportMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dataTableImportMapping =  _dataTableImportMappingService.Find(id);
             _dataTableImportMappingService.Delete(dataTableImportMapping);
            _unitOfWork.SaveChanges();
           if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            DisplaySuccessMessage("Has delete a DataTableImportMapping record");
            return RedirectToAction("Index");
        }


       

 

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
        }

         
    }
}
