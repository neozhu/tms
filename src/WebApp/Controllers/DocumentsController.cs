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
using System.IO;

namespace WebApp.Controllers
{
/// <summary>
/// File: DocumentsController.cs
/// Purpose:业务操作/附件信息
/// Created Date: 9/26/2019 8:15:03 AM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
/// <![CDATA[
///    container.RegisterType<IRepositoryAsync<Document>, Repository<Document>>();
///    container.RegisterType<IDocumentService, DocumentService>();
/// ]]>
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    [Authorize]
    [RoutePrefix("Documents")]
	public class DocumentsController : Controller
	{
		private readonly IDocumentService  documentService;
		private readonly IUnitOfWorkAsync unitOfWork;
        private readonly NLog.ILogger logger;
		public DocumentsController (
          IDocumentService  documentService, 
          IUnitOfWorkAsync unitOfWork,
          NLog.ILogger logger
          )
		{
			this.documentService  = documentService;
			this.unitOfWork = unitOfWork;
            this.logger = logger;
		}
        		//GET: Documents/Index
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        [Route("Index", Name = "附件信息", Order = 1)]
		public ActionResult Index() => this.View();
    [HttpPost]
    public async Task<JsonResult> UploadFile() {
      if (this.Request.Files.Count > 0)
      {
        for (int i = 0; i < this.Request.Files.Count; i++)
        {
          var file = this.Request.Files[i];
          var filename = file.FileName;
          var contenttype = file.ContentType;
          var size = file.ContentLength;
          var ext= System.IO.Path.GetExtension(filename);
          
          var folder = this.Server.MapPath("~/UploadFiles");
          if (!Directory.Exists(folder))
          {
            Directory.CreateDirectory(folder);
          }
          var newfilename = $"{filename.Replace(ext,"")}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{ext}";
          var virtualPath = Path.Combine(folder, newfilename
            );
          // 文件系统不能使用虚拟路径
          //string path = this.Server.MapPath(virtualPath);
          file.SaveAs(virtualPath);
          var doc = new Document();
          doc.OrderKey = this.Request.Form["OrderKey"];
          doc.Description = this.Request.Form["Description"];
          doc.UploadDateTime = DateTime.Now;
          doc.User= this.Request.Form["User"];
          doc.FileName = filename;
          doc.ContentType = contenttype;
          doc.FileType = ext;
          doc.Size = size;
          doc.Path = virtualPath;
          doc.Url = $"/UploadFiles/{newfilename}";
          this.documentService.Insert(doc);

        }
        await this.unitOfWork.SaveChangesAsync();
      }
     
      return Json(new { success = true });
      }
		//Get :Documents/GetData
		//For Index View datagrid datasource url
        
		[HttpGet]
        //[OutputCache(Duration = 10, VaryByParam = "*")]
		 public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
		{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var pagerows  = (await this.documentService
						               .Query(new DocumentQuery().Withfilter(filters))
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out var totalCount))
                                       .Select(  n => new { 

    Id = n.Id,
    OrderKey = n.OrderKey,
    FileName = n.FileName,
    FileType = n.FileType,
                                         ContentType=n.ContentType,
    Path = n.Path,
    Url = n.Url,
    MD5 = n.MD5,
    Size = n.Size,
    Width = n.Width,
    Height = n.Height,
    Description = n.Description,
    User = n.User,
    UploadDateTime = n.UploadDateTime.ToString("yyyy-MM-dd HH:mm:ss")
}).ToList();
			var pagelist = new { total = totalCount, rows = pagerows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
        //easyui datagrid post acceptChanges 
		[HttpPost]
		public async Task<JsonResult> SaveDataAsync(Document[] documents)
		{
            if (documents == null)
            {
                throw new ArgumentNullException(nameof(documents));
            }
            if (ModelState.IsValid)
			{
            try{
               foreach (var item in documents)
               {
                 this.documentService.ApplyChanges(item);
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
						//GET: Documents/Details/:id
		public ActionResult Details(int id)
		{
			
			var document = this.documentService.Find(id);
			if (document == null)
			{
				return HttpNotFound();
			}
			return View(document);
		}
        //GET: Documents/GetItemAsync/:id
        [HttpGet]
        public async Task<JsonResult> GetItemAsync(int id) {
            var  document = await this.documentService.FindAsync(id);
            return Json(document,JsonRequestBehavior.AllowGet);
        }
		//GET: Documents/Create
        		public ActionResult Create()
				{
			var document = new Document();
			//set default value
			return View(document);
		}
		//POST: Documents/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(Document document)
		{
			if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            } 
            if (ModelState.IsValid)
			{
                try{ 
				this.documentService.Insert(document);
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
			    //DisplaySuccessMessage("Has update a document record");
			}
			else {
			   var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			   return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			   //DisplayErrorMessage(modelStateErrors);
			}
			//return View(document);
		}

        //新增对象初始化
        [HttpGet]
        public async Task<JsonResult> NewItemAsync() {
            var document = await Task.Run(() => {
                return new Document();
                });
            return Json(document, JsonRequestBehavior.AllowGet);
        }

         
		//GET: Documents/Edit/:id
		public ActionResult Edit(int id)
		{
			var document = this.documentService.Find(id);
			if (document == null)
			{
				return HttpNotFound();
			}
			return View(document);
		}
		//POST: Documents/Edit/:id
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(Document document)
		{
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }
			if (ModelState.IsValid)
			{
				document.TrackingState = TrackingState.Modified;
				                try{
				this.documentService.Update(document);
				                
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
				
				//DisplaySuccessMessage("Has update a Document record");
				//return RedirectToAction("Index");
			}
			else {
			var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			//DisplayErrorMessage(modelStateErrors);
			}
						//return View(document);
		}
        //删除当前记录
		//GET: Documents/Delete/:id
        [HttpGet]
		public async Task<ActionResult> DeleteAsync(int id)
		{
          try{
               await this.documentService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
               this.documentService.Delete(id);
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
		public ActionResult ExportExcel( string filterRules = "",string sort = "Id", string order = "asc")
		{
			var fileName = "documents_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.documentService.ExportExcel(filterRules,sort, order );
			return File(stream, "application/vnd.ms-excel", fileName);
		}
		private void DisplaySuccessMessage(string msgText) => TempData["SuccessMessage"] = msgText;
        private void DisplayErrorMessage(string msgText) => TempData["ErrorMessage"] = msgText;
		 
	}
}
