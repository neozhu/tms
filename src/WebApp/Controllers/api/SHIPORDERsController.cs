using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;
using Z.EntityFramework.Plus;
namespace WebApp.Controllers.api
{
  /// <summary>
  /// File: SHIPORDERsController.cs
  /// Purpose:
  /// Created Date: 9/25/2019 9:07:19 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// TODO: Registers the type mappings with the Unity container(WebApi.UnityConfig.cs)
  /// <![CDATA[
  ///    container.RegisterType<IRepositoryAsync<SHIPORDER>, Repository<SHIPORDER>>();
  ///    container.RegisterType<ISHIPORDERService, SHIPORDERService>();
  /// ]]>
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  //[Authorize]
  public class SHIPORDERsController : ApiController
  {
    private readonly ISHIPORDERService sHIPORDERService;
    private readonly IUnitOfWorkAsync unitOfWork;
    public SHIPORDERsController(ISHIPORDERService sHIPORDERService, IUnitOfWorkAsync unitOfWork)
    {
      this.sHIPORDERService = sHIPORDERService;
      this.unitOfWork = unitOfWork;
    }
    // GET: api/SHIPORDERS$skip=2&$top=10
    //[Queryable]
    public IQueryable<SHIPORDER> GetSHIPORDERS() => this.sHIPORDERService.Queryable();

    // GET: api/GetPageData
    [HttpGet]
    public async Task<IHttpActionResult> GetPageData(string phonenumber, string status, int page = 1, int rows = 100, string sort = "ID", string order = "desc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var pagerows = ( await this.sHIPORDERService
                                 .Query(new SHIPORDERQuery().WithfilterWithDriverPhone(phonenumber, status, filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {

                                   SHIPORDERDETAILS = n.SHIPORDERDETAILS,
                                   ID = n.ID,
                                   SHIPORDERKEY = n.SHIPORDERKEY,
                                   EXTERNSHIPORDERKEY = n.EXTERNSHIPORDERKEY,
                                   SHIPORDERDATE = n.SHIPORDERDATE.ToString("yyyy/MM/dd HH:mm:ss"),
                                   STATUS = n.STATUS,
                                   STATUSMS = PublicPara.CodeText.Data.CodeListSet.CLS.Code2Value("shipstatus", n.STATUS),
                                   TYPE = PublicPara.CodeText.Data.CodeListSet.CLS.Code2Value("shptype", n.TYPE),
                                   STATEMS=diff(n.DELIVERYDATE.Value,n.ACTUALDELIVERYDATE),
                                   STATE=after(n.DELIVERYDATE.Value, n.ACTUALDELIVERYDATE),
                                   SHPTYPE = n.SHPTYPE,
                                   ORIGINAL = n.ORIGINAL,
                                   DESTINATION = n.DESTINATION,
                                   PLATENUMBER = n.PLATENUMBER,
                                   DRIVERNAME = n.DRIVERNAME,
                                   DRIVERPHONE = n.DRIVERPHONE,
                                   CARRIERCODE = n.CARRIERCODE,
                                   CARRIERNAME = n.CARRIERNAME,
                                   SHIPPERKEY = n.SHIPPERKEY,
                                   SHIPPERNAME = n.SHIPPERNAME,
                                   SHIPPERADDRESS = n.SHIPPERADDRESS,
                                   CONSIGNEEKEY = n.CONSIGNEEKEY,
                                   CONSIGNEENAME = n.CONSIGNEENAME,
                                   CONSIGNEEADDRESS = n.CONSIGNEEADDRESS,
                                   REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE?.ToString("yyyy/MM/dd HH:mm:ss"),
                                   ACTUALSHIPDATE = n.ACTUALSHIPDATE?.ToString("yyyy/MM/dd HH:mm:ss"),
                                   DELIVERYDATE = n.DELIVERYDATE?.ToString("yyyy/MM/dd HH:mm:ss"),
                                   DELIVERYDATEFM = n.DELIVERYDATE?.ToString("MM-dd HH:mm"),
                                   ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy/MM/dd HH:mm:ss"),
                                   CLOSEDDATE = n.CLOSEDDATE?.ToString("yyyy/MM/dd HH:mm:ss"),
                                   TOTALQTY = n.TOTALQTY,
                                   TOTALSHIPPEDQTY = n.TOTALSHIPPEDQTY,
                                   TOTALCASECNT = n.TOTALCASECNT,
                                   TOTALGROSSWGT = n.TOTALGROSSWGT,
                                   TOTALCUBE = n.TOTALCUBE,
                                   STDKM = n.STDKM,
                                   KM1 = n.KM1,
                                   KM2 = n.KM2,
                                   ACTKM = n.ACTKM,
                                   STDOIL = n.STDOIL,
                                   OIL1 = n.OIL1,
                                   OIL2 = n.OIL2,
                                   ACTOIL = n.ACTOIL,
                                   STDLOADWEIGHT = n.STDLOADWEIGHT,
                                   STDLOADVOLUME = n.STDLOADVOLUME,
                                   FEELOADWEIGHT = n.FEELOADWEIGHT,
                                   LOADFACTOR1 = n.LOADFACTOR1,
                                   LOADFACTOR2 = n.LOADFACTOR2,
                                   STDCOST = n.STDCOST,
                                   STDTOLL = n.STDTOLL,
                                   GROSSMARGINS = n.GROSSMARGINS,
                                   GROSSMARGINSRATE = n.GROSSMARGINSRATE,
                                   TOTALSERVICECOST = n.TOTALSERVICECOST,
                                   CHECKEDCOST1 = n.CHECKEDCOST1,
                                   TOTALCOST1 = n.TOTALCOST1,
                                   CHECKEDCOST2 = n.CHECKEDCOST2,
                                   TOTALCOST2 = n.TOTALCOST2,
                                   CHECKEDCOST3 = n.CHECKEDCOST3,
                                   FLOOR = n.FLOOR,
                                   TOTALCOST3 = n.TOTALCOST3,
                                   CHECKEDCOST4 = n.CHECKEDCOST4,
                                   TOTALCOST4 = n.TOTALCOST4,
                                   CHECKEDCOST5 = n.CHECKEDCOST5,
                                   TOTALCOST5 = n.TOTALCOST5,
                                   CHECKEDCOST6 = n.CHECKEDCOST6,
                                   TOTALCOST6 = n.TOTALCOST6,
                                   CHECKEDCOST7 = n.CHECKEDCOST7,
                                   TOTALCOST7 = n.TOTALCOST7,
                                   CHECKEDCOST8 = n.CHECKEDCOST8,
                                   TOTALCOST8 = n.TOTALCOST8,
                                   FLAG1 = n.FLAG1,
                                   NOTES1 = n.NOTES1,
                                   FLAG2 = n.FLAG2,
                                   NOTES = n.NOTES,
                                   COMPANYCODE = n.COMPANYCODE,
                                   LOTTABLE1 = n.LOTTABLE1,
                                   LOTTABLE2 = n.LOTTABLE2,
                                   LOTTABLE3 = n.LOTTABLE3,
                                   LOTTABLE4 = n.LOTTABLE4,
                                   LOTTABLE5 = n.LOTTABLE5,
                                   LOTTABLE6 = n.LOTTABLE6,
                                   LOTTABLE7 = n.LOTTABLE7,
                                   LOTTABLE8 = n.LOTTABLE8?.ToString("yyyy/MM/dd HH:mm:ss")
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Ok(pagelist);
    }
    private bool after(DateTime dt1, DateTime? dt2) {
      var dt = dt2 == null ? DateTime.Now : dt2.Value;
      if (dt1 <= dt)
        return true;
      else
        return false;
      }
    private string diff(DateTime dt1, DateTime? dt2) {
      var dt = dt2 == null ? DateTime.Now : dt2.Value;
      if (dt1 <= dt)
      {
        var ts1 = new TimeSpan(dt1.Ticks);
        var ts2 = new TimeSpan(dt.Ticks);
        var res = ts2.Subtract(ts1);
        if (res.Days > 0 && res.Hours >= 0 && res.Minutes >= 0)
        {
          return $"超时{res.Days}天{res.Hours}小时";
        }
        else if (res.Hours > 0 && res.Minutes >= 0 && res.Seconds >= 0)
        {
          return $"超时{res.Hours}小时{res.Minutes}分钟";
        }
        else if (res.Minutes > 0 && res.Seconds >= 0)
        {
          return $"超时{res.Minutes}分钟";
        }
        else
        {
          return $"已经超时";
        }

      }
      else
      {
        var ts1 = new TimeSpan(dt1.Ticks);
        var ts2 = new TimeSpan(dt.Ticks);
        var res = ts1.Subtract(ts2);

        if (res.Days > 0 && res.Hours >= 0 && res.Minutes >= 0)
        {
          return $"还剩{res.Days}天{res.Hours}小时";
        }
        else if (res.Hours > 0 && res.Minutes >= 0 && res.Seconds >= 0)
        {
          return $"还剩{res.Hours}小时{res.Minutes}分钟";
        }
        else if (res.Minutes > 0 && res.Seconds >= 0)
        {
          return $"还剩{res.Minutes}分钟";
        }
        else
        {
          return $"马上就要超时";
        }
      }


    }
    //Post SaveData:SHIPORDER[]
    [HttpPost]
    public async Task<IHttpActionResult> SaveData(SHIPORDER[] shiporders)
    {
      if (shiporders == null)
      {
        throw new ArgumentNullException(nameof(shiporders));
      }
      if (!this.ModelState.IsValid)
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Ok(new { success = false, err = modelStateErrors });
      }
      try
      {
        foreach (var item in shiporders)
        {
          this.sHIPORDERService.ApplyChanges(item);
        }
        await this.unitOfWork.SaveChangesAsync();
        return this.Ok(new { success = true, shiporders });
      }
      catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
      {
        return this.Ok(new { success = false, err = e.GetBaseException().Message });
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Ok(new { success = false, err = errormessage });
      }
      catch (Exception e)
      {
        return this.Ok(new { success = false, err = e.GetBaseException().Message });
      }
    }
    [HttpGet]
    public async Task<IHttpActionResult> DoShipping(int id) {
      this.sHIPORDERService.DoPrint(id,"");
      await this.unitOfWork.SaveChangesAsync();
      return this.Ok(new { success = true });
    }
    [HttpGet]
    public async Task<IHttpActionResult> DoCompleted(int id)
    {
      this.sHIPORDERService.DoCompleted(id, "");
      await this.unitOfWork.SaveChangesAsync();
      return this.Ok(new { success = true });
    }
    [HttpGet]
    public async Task<IHttpActionResult> DoClosed(int id)
    {
      this.sHIPORDERService.DoClosed(id, "");
      await this.unitOfWork.SaveChangesAsync();
      return this.Ok(new { success = true });
    }
    //GET:api/GetSHIPORDER/:id
    [ResponseType(typeof(SHIPORDER))]
    public async Task<IHttpActionResult> Get([FromUri]int id)
    {
      var sHIPORDER = await this.sHIPORDERService.FindAsync(id);
      if (sHIPORDER == null)
      {
        return this.NotFound();
      }
      return this.Ok(sHIPORDER);
    }
    // PUT: api/SHIPORDERS/5
    //[ResponseType(typeof(void))]
    [HttpPut]
    public async Task<IHttpActionResult> Put([FromUri]int id, [FromBody]SHIPORDER shiporder)
    {
      if (id != shiporder.ID)
      {
        return this.BadRequest();
      }
      if (!this.ModelState.IsValid)
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Ok(new { success = false, err = modelStateErrors });
      }
      try
      {
        shiporder.TrackingState = TrackableEntities.TrackingState.Modified;
        this.sHIPORDERService.ApplyChanges(shiporder);
        await this.unitOfWork.SaveChangesAsync();
        return this.Ok(new { success = true });
      }
      catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
      {
        return this.Ok(new { success = false, err = e.GetBaseException().Message });
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Ok(new { success = false, err = errormessage });
      }
      catch (Exception e)
      {
        return this.Ok(new { success = false, err = e.GetBaseException().Message });
      }
    }

    // POST: api/SHIPORDERS
    //[ResponseType(typeof(SHIPORDER))]
    [HttpPost]
    public async Task<IHttpActionResult> Post([FromBody]SHIPORDER shiporder)
    {
      if (!this.ModelState.IsValid)
      {
        var modelStateErrors = string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n => n.ErrorMessage)));
        return this.Ok(new { success = false, err = modelStateErrors });
      }
      try
      {
        this.sHIPORDERService.Insert(shiporder);
        await this.unitOfWork.SaveChangesAsync();
        return this.Ok(new { success = true, shiporder.ID });
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Ok(new { success = false, err = errormessage });
      }
      catch (Exception e)
      {
        return this.Ok(new { success = false, err = e.GetBaseException().Message });
      }
    }

    // DELETE: api/SHIPORDERS/5
    [HttpDelete]
    public async Task<IHttpActionResult> Delete([FromUri]int id)
    {
      var shiporder = await this.sHIPORDERService.FindAsync(id);
      if (shiporder == null)
      {
        return this.NotFound();
      }
      try
      {
        await this.sHIPORDERService.DeleteAsync(shiporder);
        await this.unitOfWork.SaveChangesAsync();
        return this.Ok(new { success = true });
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Ok(new { success = false, err = errormessage });
      }
      catch (Exception e)
      {
        return this.Ok(new { success = false, err = e.GetBaseException().Message });
      }
    }
    private bool SHIPORDERExists(int id) => this.sHIPORDERService.Queryable().Where(x => x.ID == id).Any();



    //删除选中的记录
    [HttpPost]
    public async Task<IHttpActionResult> DeleteChecked(int[] id)
    {
      if (id == null)
      {
        throw new ArgumentNullException(nameof(id));
      }
      try
      {
        await this.sHIPORDERService.Queryable().Where(x => id.Contains(x.ID)).DeleteAsync();
        return this.Ok(new { success = true });
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage));
        return this.Ok(new { success = false, err = errormessage });
      }
      catch (Exception e)
      {
        return this.Ok(new { success = false, err = e.GetBaseException().Message });
      }
    }
    //导出Excel
    [HttpPost]
    public HttpResponseMessage ExportExcel(string filterRules = "", string sort = "ID", string order = "asc")
    {
      var fileName = "shiporders_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.sHIPORDERService.ExportExcel(filterRules, sort, order);
      var response = this.Request.CreateResponse(HttpStatusCode.OK);
      response.Content = new StreamContent(stream);
      response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
      response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
      {
        FileName = fileName
      };
      return response;
    }


  }
}
