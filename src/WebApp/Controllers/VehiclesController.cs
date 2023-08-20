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
using System.Net.Http;
using System.Text;
using WebApp.Models.ViewModel;

namespace WebApp.Controllers
{
/// <summary>
/// File: VehiclesController.cs
/// Purpose:主数据管理/车辆信息
/// Created Date: 2019/8/2 7:53:52
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// TODO: Registers the type mappings with the Unity container(Mvc.UnityConfig.cs)
/// <![CDATA[
///    container.RegisterType<IRepositoryAsync<Vehicle>, Repository<Vehicle>>();
///    container.RegisterType<IVehicleService, VehicleService>();
/// ]]>
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    [Authorize]
    [RoutePrefix("Vehicles")]
	public class VehiclesController : Controller
	{
		private readonly IVehicleService  vehicleService;
		private readonly IUnitOfWorkAsync unitOfWork;
		public VehiclesController (IVehicleService  vehicleService, IUnitOfWorkAsync unitOfWork)
		{
			this.vehicleService  = vehicleService;
			this.unitOfWork = unitOfWork;
		}
    //获取视频直播地址
    [HttpGet]
    public async Task<JsonResult> GetRtmp(string p)
    {
      var item = await this.vehicleService.Queryable().Where(x=>x.PlateNumber==p).FirstAsync();
      var client = new HttpClient();
      var url = Settings.GpsApiURL + "/userlogin";
      var appkey = Settings.GpsAppKey;
      var pwd = Settings.GpsPassword;
      var user = Settings.GpsAccount;
      var content = new StringContent($@"{{ 
   'mobile': '{user}',
    'logintype': 0,
    'platform': '第三方',
    'packname':'com.mapgoo.chedaibao.mgkj',
    'pwd': '{pwd}',
    'devicetoken':'',
    'version':'1.0.0',
    'flag': 1
       }}", Encoding.UTF8, "application/json");
      client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
      client.DefaultRequestHeaders.TryAddWithoutValidation("AppKey", appkey);
      var result = await client.PostAsync(url, content);
      if (result.StatusCode == HttpStatusCode.OK)
      {
        var jsonstr = await result.Content.ReadAsStringAsync();
        var loginstate = JsonConvert.DeserializeObject<LoginState>(jsonstr);
        if (loginstate.error == 0)
        {
          var token = loginstate.result.authtoken;
          var sim = loginstate.result.sim;
          var objectid = loginstate.result.objectid;
          var client2 = new HttpClient();
          client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
          client2.DefaultRequestHeaders.TryAddWithoutValidation("AppKey", appkey);
          client2.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
          url = $"{Settings.GpsApiURL}/startlive?objectid={item.GPSDeviceId}";
          var result2 = await client2.GetAsync(url);
          if (result2.StatusCode == HttpStatusCode.OK)
          {
            var rtmpstate = JsonConvert.DeserializeObject<RtmpState>(await result2.Content.ReadAsStringAsync());
            if (rtmpstate.error == 0)
            {

              return Json(new { success = true, src = rtmpstate.result, v = item }, JsonRequestBehavior.AllowGet);
            }
            else
            {
              return Json(new { success = false, err = rtmpstate.reason }, JsonRequestBehavior.AllowGet);
            }
          }
          else
          {
            return Json(new { success = false, err = result2.ToString()}, JsonRequestBehavior.AllowGet);
          }
        }
        else
        {
          return Json(new { success = false, err = loginstate.reason }, JsonRequestBehavior.AllowGet);
        }
      }

      return Json(new { }, JsonRequestBehavior.AllowGet);
    }
    //获取车辆GPS位置
    [HttpGet]
    public async Task<JsonResult> GetLoc(string p) {
      var item = await this.vehicleService.Queryable().Where(x => x.PlateNumber == p).FirstAsync();
      var client = new HttpClient();
      var url = Settings.GpsApiURL + "/userlogin";
      var appkey = Settings.GpsAppKey;
      var pwd = Settings.GpsPassword;
      var user = Settings.GpsAccount;
      var content = new StringContent($@"{{ 
   'mobile': '{user}',
    'logintype': 0,
    'platform': '第三方',
    'packname':'com.mapgoo.chedaibao.mgkj',
    'pwd': '{pwd}',
    'devicetoken':'',
    'version':'1.0.0',
    'flag': 1
       }}", Encoding.UTF8, "application/json");
      client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
      client.DefaultRequestHeaders.TryAddWithoutValidation("AppKey", appkey);
      var result = await client.PostAsync(url, content);
      if (result.StatusCode ==  HttpStatusCode.OK)
      {
        var jsonstr = await result.Content.ReadAsStringAsync();
        var loginstate = JsonConvert.DeserializeObject<LoginState>(jsonstr);
        if (loginstate.error == 0)
        {
          var token = loginstate.result.authtoken;
          var sim = loginstate.result.sim;
          var objectid= loginstate.result.objectid;
          var client2 = new HttpClient();
          client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
          client2.DefaultRequestHeaders.TryAddWithoutValidation("AppKey", appkey);
          client2.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
          var result2 = await client2.GetStringAsync($"{Settings.GpsApiURL}/GetSimpleObjectTracks?objectid={item.GPSDeviceId}");
          var locstate= JsonConvert.DeserializeObject<LocState>(result2);
          if (locstate.error == 0)
          {

            return Json(new { success = true, loc = locstate.result,v=item }, JsonRequestBehavior.AllowGet);
          }
          else
          {
            return Json(new { success = false, err = locstate.reason }, JsonRequestBehavior.AllowGet);
          }
        }
        else
        {
          return Json(new {success=false,err= loginstate.reason }, JsonRequestBehavior.AllowGet);
        }
      }

      return Json(new { }, JsonRequestBehavior.AllowGet);

    }
        		//GET: Vehicles/Index
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        [Route("Index", Name = "车辆信息 ", Order = 1)]
		public ActionResult Index() => this.View();
    [HttpGet]
    public async Task<JsonResult> GetComboData(string q="",int page = 1, int rows = 10, string sort = "Id", string order = "asc")
    {
      
      var pagerows = ( await this.vehicleService
                                 .Query(new VehicleQuery().WithfilterQ(q))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new {

                                   Id = n.Id,
                                   PlateNumber = n.PlateNumber,
                                   ShipOrderNo = n.ShipOrderNo,
                                   InputUser = n.InputUser,
                                   Status = n.Status,
                                   CarType = n.CarType,
                                   CarrierCode = n.CarrierCode,
                                   CarrierName = n.CarrierName,
                                   VehLongSize = n.VehLongSize,
                                   StdLoadWeight = n.StdLoadWeight,
                                   FeeLoadWeight = n.FeeLoadWeight,
                                   StdLoadVolume = n.StdLoadVolume,
                                   CarriageSize = n.CarriageSize,
                                   GPSDeviceId = n.GPSDeviceId,
                                   Driver = n.Driver,
                                   DriverPhone = n.DriverPhone
                                    
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    [HttpGet]
    public async Task<JsonResult> GetComboDataALL(int page = 1, int rows = 10, string sort = "Id", string order = "asc")
    {

      var pagerows = ( await this.vehicleService
                                 .Query()
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new {

                                   Id = n.Id,
                                   PlateNumber = n.PlateNumber,
                                   ShipOrderNo = n.ShipOrderNo,
                                   InputUser = n.InputUser,
                                   Status = n.Status,
                                   CarType = n.CarType,
                                   CarrierCode = n.CarrierCode,
                                   CarrierName = n.CarrierName,
                                   VehLongSize = n.VehLongSize,
                                   StdLoadWeight = n.StdLoadWeight,
                                   FeeLoadWeight = n.FeeLoadWeight,
                                   StdLoadVolume = n.StdLoadVolume,
                                   CarriageSize = n.CarriageSize,
                                   GPSDeviceId = n.GPSDeviceId,
                                   Driver = n.Driver,
                                   DriverPhone = n.DriverPhone

                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return Json(pagelist, JsonRequestBehavior.AllowGet);
    }

    //Get :Vehicles/GetData
    //For Index View datagrid datasource url
    [HttpGet]
		 public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "Id", string order = "asc", string filterRules = "")
		{
			var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
			var pagerows  = (await this.vehicleService
						               .Query(new VehicleQuery().Withfilter(filters))
							           .OrderBy(n=>n.OrderBy(sort,order))
							           .SelectPageAsync(page, rows, out var totalCount))
                                       .Select(  n => new { 

    Id = n.Id,
    PlateNumber = n.PlateNumber,
    ShipOrderNo = n.ShipOrderNo,
    InputUser = n.InputUser,
    Status = n.Status,
    CarType = n.CarType,
    CarrierCode = n.CarrierCode,
    CarrierName = n.CarrierName,
    VehLongSize = n.VehLongSize,
    StdLoadWeight = n.StdLoadWeight,
    FeeLoadWeight = n.FeeLoadWeight,
    StdLoadVolume = n.StdLoadVolume,
    CarriageSize = n.CarriageSize,
    GPSDeviceId = n.GPSDeviceId,
    Driver = n.Driver,
    DriverPhone = n.DriverPhone,
    AssistantDriver = n.AssistantDriver,
    AssistantDriverPhone = n.AssistantDriverPhone,
    CustomsNo = n.CustomsNo,
    RoadKM = n.RoadKM,
    RoadHours = n.RoadHours,
    Owner = n.Owner,
    OwnerContactPhone = n.OwnerContactPhone,
    Brand = n.Brand,
    RPM = n.RPM,
    PurchasedDate = n.PurchasedDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    PurchasedAmount = n.PurchasedAmount,
    VehLong = n.VehLong,
    VehWide = n.VehWide,
    VehHigh = n.VehHigh,
    VIN = n.VIN,
    ServiceLife = n.ServiceLife,
    MaintainKM = n.MaintainKM,
    MaintainDate = n.MaintainDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    MaintainMonth = n.MaintainMonth,
    ExistVehTailBoard = n.ExistVehTailBoard,
    VehTailBoardBrand = n.VehTailBoardBrand,
    VehTailBoardFactory = n.VehTailBoardFactory,
    VehTailBoardLife = n.VehTailBoardLife,
    VehTailBoardAmount = n.VehTailBoardAmount,
    VehTailBoardGPSDeviceId = n.VehTailBoardGPSDeviceId,
    DrLicenseModel = n.DrLicenseModel,
    DrLicenseUseNature = n.DrLicenseUseNature,
    DrLicenseBrand = n.DrLicenseBrand,
    DrLicenseDevId = n.DrLicenseDevId,
    DrLicenseEngineId = n.DrLicenseEngineId,
    DrLicenseRegistrationDate = n.DrLicenseRegistrationDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    DrLicensePubDate = n.DrLicensePubDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    DrLicenseRatedUsers = n.DrLicenseRatedUsers,
    DrLicenseVehWeight = n.DrLicenseVehWeight,
    DrLicenseDevWeight = n.DrLicenseDevWeight,
    DrLicenseNetWeight = n.DrLicenseNetWeight,
    DrLicenseNetVolume = n.DrLicenseNetVolume,
    DrLicenseVehWide = n.DrLicenseVehWide,
    DrLicenseVehHigh = n.DrLicenseVehHigh,
    DrLicenseVehLong = n.DrLicenseVehLong,
    DrLicenseScrapedDate = n.DrLicenseScrapedDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    LoLicenseManageId = n.LoLicenseManageId,
    LoLicenseId = n.LoLicenseId,
    LoLicenseBusinessScope = n.LoLicenseBusinessScope,
    LoLicensePubDate = n.LoLicensePubDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    LoLicenseValidDate = n.LoLicenseValidDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    LoLicenseCheckDate = n.LoLicenseCheckDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    LoLicensePlace = n.LoLicensePlace,
    InsTrafficPolicyId = n.InsTrafficPolicyId,
    InsTrafficPolicyCompany = n.InsTrafficPolicyCompany,
    InsTrafficPolicyVaildateDate = n.InsTrafficPolicyVaildateDate,
    InsTrafficPolicyAmount = n.InsTrafficPolicyAmount,
    InsThirdPartyId = n.InsThirdPartyId,
    InsThirdPartyVaildateDate = n.InsThirdPartyVaildateDate?.ToString("yyyy-MM-dd HH:mm:ss"),
    InsThirdPartyAmount = n.InsThirdPartyAmount,
    InsThirdPartyLogisticsAmount = n.InsThirdPartyLogisticsAmount,
    InsThirdPartyLogisticsVaildateDate = n.InsThirdPartyLogisticsVaildateDate?.ToString("yyyy-MM-dd HH:mm:ss")
}).ToList();
			var pagelist = new { total = totalCount, rows = pagerows };
			return Json(pagelist, JsonRequestBehavior.AllowGet);
		}
        //easyui datagrid post acceptChanges 
		[HttpPost]
		public async Task<JsonResult> SaveDataAsync(Vehicle[] vehicles)
		{
            if (vehicles == null)
            {
                throw new ArgumentNullException(nameof(vehicles));
            }
            if (ModelState.IsValid)
			{
            try{
               foreach (var item in vehicles)
               {
                 this.vehicleService.ApplyChanges(item);
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
						//GET: Vehicles/Details/:id
		public ActionResult Details(int id)
		{
			
			var vehicle = this.vehicleService.Find(id);
			if (vehicle == null)
			{
				return HttpNotFound();
			}
			return View(vehicle);
		}
        //GET: Vehicles/GetItemAsync/:id
        [HttpGet]
        public async Task<JsonResult> GetItemAsync(int id) {
            var  vehicle = await this.vehicleService.FindAsync(id);
            return Json(vehicle,JsonRequestBehavior.AllowGet);
        }
		//GET: Vehicles/Create
        		public ActionResult Create()
				{
			var vehicle = new Vehicle();
			//set default value
			return View(vehicle);
		}
		//POST: Vehicles/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(Vehicle vehicle)
		{
			if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            } 
            if (ModelState.IsValid)
			{
                try{ 
				this.vehicleService.Insert(vehicle);
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
			    //DisplaySuccessMessage("Has update a vehicle record");
			}
			else {
			   var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			   return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			   //DisplayErrorMessage(modelStateErrors);
			}
			//return View(vehicle);
		}

        //新增对象初始化
        [HttpGet]
        public async Task<JsonResult> NewItemAsync() {
            var vehicle = await Task.Run(() => {
                return new Vehicle();
                });
            return Json(vehicle, JsonRequestBehavior.AllowGet);
        }

         
		//GET: Vehicles/Edit/:id
		public ActionResult Edit(int id)
		{
			var vehicle = this.vehicleService.Find(id);
			if (vehicle == null)
			{
				return HttpNotFound();
			}
			return View(vehicle);
		}
		//POST: Vehicles/Edit/:id
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(Vehicle vehicle)
		{
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
			if (ModelState.IsValid)
			{
				vehicle.TrackingState = TrackingState.Modified;
				                try{
				this.vehicleService.Update(vehicle);
				                
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
				
				//DisplaySuccessMessage("Has update a Vehicle record");
				//return RedirectToAction("Index");
			}
			else {
			var modelStateErrors =string.Join(",", this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(n=>n.ErrorMessage)));
			return Json(new { success = false, err = modelStateErrors }, JsonRequestBehavior.AllowGet);
			//DisplayErrorMessage(modelStateErrors);
			}
						//return View(vehicle);
		}
        //删除当前记录
		//GET: Vehicles/Delete/:id
        [HttpGet]
		public async Task<ActionResult> DeleteAsync(int id)
		{
          try{
               await this.vehicleService.Queryable().Where(x => x.Id == id).DeleteAsync();
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
               await this.vehicleService.Queryable().Where(x => id.Contains(x.Id)).DeleteAsync();
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
			var fileName = "vehicles_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
			var stream=  this.vehicleService.ExportExcel(filterRules,sort, order );
			return File(stream, "application/vnd.ms-excel", fileName);
		}
		private void DisplaySuccessMessage(string msgText) => TempData["SuccessMessage"] = msgText;
        private void DisplayErrorMessage(string msgText) => TempData["ErrorMessage"] = msgText;
		 
	}
}
