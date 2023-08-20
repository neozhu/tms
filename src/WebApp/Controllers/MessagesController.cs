using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
  [RoutePrefix("Messages")]
  public class MessagesController : Controller
  {

    //Please RegisterType UnityConfig.cs
    //container.RegisterType<IRepositoryAsync<Message>, Repository<Message>>();
    //container.RegisterType<IMessageService, MessageService>();

    //private StoreContext db = new StoreContext();
    private readonly IMessageService _messageService;
    private readonly IUnitOfWorkAsync _unitOfWork;

    public MessagesController(IMessageService messageService, IUnitOfWorkAsync unitOfWork)
    {
      this._messageService = messageService;
      this._unitOfWork = unitOfWork;
    }
    [Route("Index", Name = "系统日志信息", Order = 1)]
    // GET: Messages/Index
    public async Task<ActionResult> Index()
    {

      this.ViewBag.TotalSysError = await this._messageService.Queryable().Where(x => x.Group == (int)MessageGroup.System &&
               x.Type == (int)MessageType.Error).CountAsync();


      this.ViewBag.TotalOpError = await this._messageService.Queryable().Where(x => x.Group == (int)MessageGroup.Operator &&
               x.Type == (int)MessageType.Error).CountAsync();
      this.ViewBag.TotalInterfaceError = await this._messageService.Queryable().Where(x => x.Group == (int)MessageGroup.Intface &&
               x.Type == (int)MessageType.Error).CountAsync();
      this.ViewBag.TotalNewError = await this._messageService.Queryable().Where(x =>
               x.Type == (int)MessageType.Error && x.IsNew == 0).CountAsync();



      return this.View();

    }

    // Get :Messages/PageList
    // For Index View Boostrap-Table load  data 
    [HttpGet]
    public async Task<ActionResult> GetData(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
    {

      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var totalCount = 0;
      //int pagenum = offset / limit +1;
      var messages = await this._messageService
                  .Query(new MessageQuery().Withfilter(filters))
                  .OrderBy(n => n.OrderBy(sort, order))
                  .SelectPageAsync(page, rows, out totalCount);


      var datarows = messages.Select(n => new
      {
        Id = n.Id,
        Group = n.Group,
        StackTrace = n.StackTrace,
        ExtensionKey1 = n.ExtensionKey1,
        Type = n.Type,
        Code = n.Code,
        Content = n.Content,
        ExtensionKey2 = n.ExtensionKey2,
        Tags = n.Tags,
        Method = n.Method,
        Created = n.Created,
        IsNew = n.IsNew,
        User = n.User,
        IsNotification = n.IsNotification
      }
      ).ToList();
      var pagelist = new { total = totalCount, rows = datarows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public async Task<ActionResult> SaveData(MessageChangeViewModel messages)
    {
      if (messages.updated != null)
      {
        foreach (var updated in messages.updated)
        {
          this._messageService.Update(updated);
        }
      }
      if (messages.deleted != null)
      {
        foreach (var deleted in messages.deleted)
        {
          this._messageService.Delete(deleted);
        }
      }
      if (messages.inserted != null)
      {
        foreach (var inserted in messages.inserted)
        {
          this._messageService.Insert(inserted);
        }
      }
      await this._unitOfWork.SaveChangesAsync();

      return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }


    [HttpGet]
    public ActionResult Notify() => this.PartialView("_notifications");

    // GET: Messages/Details/5
    public async Task<ActionResult> Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      var message = await this._messageService.FindAsync(id);
      await this._messageService.Queryable().Where(x => x.Id == id).UpdateAsync(x => new Message() { IsNew = 1 });

      if (message == null)
      {
        return this.HttpNotFound();
      }
      return this.PartialView(message);
    }


    // GET: Messages/Create
    public ActionResult Create()
    {
      var message = new Message();
      //set default value
      return this.View(message);
    }

    // POST: Messages/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Group,ExtensionKey1,Type,Code,Content,ExtensionKey2,Tags,Method,Created,IsNew,IsNotification")] Message message)
    {
      if (this.ModelState.IsValid)
      {
        this._messageService.Insert(message);
        await this._unitOfWork.SaveChangesAsync();
        if (this.Request.IsAjaxRequest())
        {
          return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        this.DisplaySuccessMessage("Has append a Message record");
        return this.RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        if (this.Request.IsAjaxRequest())
        {
          return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        }
        this.DisplayErrorMessage(modelStateErrors);
      }

      return this.View(message);
    }

    // GET: Messages/Edit/5
    public async Task<ActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var message = await this._messageService.FindAsync(id);
      if (message == null)
      {
        return this.HttpNotFound();
      }
      return this.View(message);
    }

    // POST: Messages/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,Group,ExtensionKey1,Type,Code,Content,ExtensionKey2,Tags,Method,Created,IsNew,IsNotification")] Message message)
    {
      if (this.ModelState.IsValid)
      {
        message.TrackingState = TrackingState.Modified;
        this._messageService.Update(message);

        await this._unitOfWork.SaveChangesAsync();
        if (this.Request.IsAjaxRequest())
        {
          return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        this.DisplaySuccessMessage("Has update a Message record");
        return this.RedirectToAction("Index");
      }
      else
      {
        var modelStateErrors = String.Join("", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        if (this.Request.IsAjaxRequest())
        {
          return this.Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
        }
        this.DisplayErrorMessage(modelStateErrors);
      }

      return this.View(message);
    }

    // GET: Messages/Delete/5
    public async Task<ActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var message = await this._messageService.FindAsync(id);
      if (message == null)
      {
        return this.HttpNotFound();
      }
      return this.View(message);
    }

    // POST: Messages/Delete/5
    [HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
      var message = await this._messageService.FindAsync(id);
      this._messageService.Delete(message);
      await this._unitOfWork.SaveChangesAsync();
      if (this.Request.IsAjaxRequest())
      {
        return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
      }
      this.DisplaySuccessMessage("Has delete a Message record");
      return this.RedirectToAction("Index");
    }

    //更新日志状态
    [HttpGet]
    public async Task<JsonResult> SetMessageState(int id) {

      var item = await this._messageService.Queryable().Where(x => x.Id == id)
        .UpdateAsync(x => new Message()
        { IsNew=1,IsNotification=1 });
      return Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }




    //导出Excel
    [HttpPost]
    public ActionResult ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
    {
      var fileName = "messages_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this._messageService.ExportExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);

    }

    [HttpPost]
    public async Task<ActionResult> SaveErrorLog(string tags, string content, string url = "", string line = "", string col = "")
    {
      var message = new Message()
      {
        Group = (int)MessageGroup.Operator,
        Content = $"{content} at line:{line} col:{col}.",
        Type = (int)MessageType.Error,
        Method = this.SubUrlString(url),
        Tags = tags,
        ExtensionKey1 = "js",
        User = Auth.CurrentUserName



      };
      this._messageService.Insert(message);
      await this._unitOfWork.SaveChangesAsync();
      return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }
    private string SubUrlString(string url)
    {
      string[] spstr = url.Split(new char[] { '/' });
      var strPath = string.Empty;
      for (var i = 0; i < spstr.Length; i++)
      {
        if (i >= 3)
          strPath += spstr[i] + "/";
      }
      return strPath;
    }


    private void DisplaySuccessMessage(string msgText) => this.TempData["SuccessMessage"] = msgText;

    private void DisplayErrorMessage(string msgText) => this.TempData["ErrorMessage"] = msgText;


  }
}

