using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using LazyCache;
using SqlHelper2;
using WebApp.App_Helpers;
using WebApp.Models;
using WebApp.Models.ViewModel;
using System.Text.RegularExpressions;
using WebApp.Services;
using System.Linq;
using System.Data.Entity;
using System.Net.Http;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
  [Authorize]
  [RoutePrefix("Home")]
  public class HomeController : Controller
  {
    private readonly IAppCache cache;
    private readonly IMapper mapper;
    private readonly IDatabaseAsync db;
    private readonly IVehicleService vehicleService;

    public HomeController(
      IDatabaseAsync db,
      IVehicleService vehicleService,
      IAppCache cache, IMapper mapper) {

      this.cache = cache;
      this.mapper = mapper;
      this.db = db;
      this.vehicleService = vehicleService;
    }

    //[Route("MainView", Name = "实时监控 ", Order = 2)]
    public ActionResult MainView() => View();

    public async Task<ActionResult> Video()
    {
      var items = await this.vehicleService.Queryable().Where(x => x.GPSDeviceId != null).ToListAsync();
      var token = await getToken();
      var list = new List<VehVideo>();
      foreach (var item in items)
      {
        var vehvideo = new VehVideo
        {
          PlateNumber = item.PlateNumber,
          Driver = item.Driver,
          DriverPhone = item.DriverPhone
        };
        var appkey = Settings.GpsAppKey;
        var client2 = new HttpClient();
        client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        client2.DefaultRequestHeaders.TryAddWithoutValidation("AppKey", appkey);
        client2.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
        var url = $"{Settings.GpsApiURL}/startlive?objectid={item.GPSDeviceId}";
        var result2 = await client2.GetAsync(url);
        if (result2.StatusCode == HttpStatusCode.OK)
        {
          var rtmpstate = JsonConvert.DeserializeObject<RtmpState>(await result2.Content.ReadAsStringAsync());
          if (rtmpstate.error == 0)
          {
            vehvideo.RtmpUrl = rtmpstate.result;
            
          }
         
        }
        list.Add(vehvideo);
      }

      return View(list);
    }

    private   async Task<string> getToken()
    {
      var token = "";
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
           token = loginstate.result.authtoken;
          var sim = loginstate.result.sim;
          var objectid = loginstate.result.objectid;
        }
      }
      return token;
    }

    //[Route("Index", Name = "首页 ", Order = 1)]
    public  ActionResult Index()
    {

      //var str = "9月3日与561725一起送天河区六运小区二街31栋501胡先生13302408398限高2米,有5级台阶,平移100米,无电梯上5楼,003490";
      //var re = new Regex(@"[\u0391-\uFFE5]([1-9])[\u4e00-\u9fa5]");
      //var result = re.Matches(str);
      //foreach (Match item in result)
      //{
      //  if (item.Value.IndexOf("楼") > 0)
      //  {
      //    var re1 = new Regex(@"([\u0391-\uFFE5]+)(\d+)");
      //    var result1 = re.Match(item.Value);
      //    var num = result1.Groups[1].Value;
      //  }
      //}

      


      //QCloudHelper.SendSMS("15951108101", "Hello");
      //QCloudHelper.SendSMSWithTPL("15951108101", 424707, "9000000", DateTime.Now.ToString("MM-dd HH:mm:ss"));

      var sql = @"select distinct
                   Case
                     when Status='170' or status='140' then N'空车'
                     when status='110' then N'预定'
                     when status='120' then N'在途'
                     when status='0' then N'禁用'
                     when status='1' then N'新车'
                     when status='5' then N'维修中'
                   end as Status,
 stuff((select distinct ',' + t.PlateNumber from dbo.vehicle t where t.Status = t1.Status  for xml path('')) , 1 , 1 , '')  PlateNumber from dbo.vehicle t1
 order by status  ";

      ViewBag.Pools = SqlHelper2.DatabaseFactory.CreateDatabase().ExecuteDataReader<PoolsViewModel>(sql, null, (r) => {
        return new PoolsViewModel { Status = r[0].ToString(), PlateNumbers = r[1].ToString().Split(',') };
      });

      var list = new List<VehiclesViewModel>();
      //禅城区、顺德区、南海区、三水区、高明区
      var add = new string[] { "禅城区", "顺德区" ,"南海区","三水区","高明区"};
      var r1 = new Random();
      var r2 = new Random();
      var r3 = new Random();
      for (var i = 0; i < 10; i++)
      {
        var q1= add[r1.Next(0, 4)];
        var q2 = add[r2.Next(0, 4)];
        list.Add(new VehiclesViewModel()
        {
           ZCPH=$"粤E{r3.Next(20000,90000)}",
            ShipOrderNo=i.ToString("8000000"),
             ZMDDMS=q1,
              ZQSDMS=q2
        });
        }
      ViewBag.Vehicles = list;
      return this.View();
    }
    [HttpGet]
    public async Task<JsonResult> GetTitleNum() {
      var num1 = await this.cache.GetOrAddAsync<int>("num1",()=>{
        return Task.Run(() =>
        {
          var sql = "select count(*) from [dbo].[ORDERs]";
          var result = db.ExecuteScalar<int>(sql);
          return result;
        });
        });
      var num2 = await this.cache.GetOrAddAsync<int>("num2", () => {
        return Task.Run(() =>
        {
          var sql = "select count(*) from [dbo].[SHIPORDERs]";
          var result = db.ExecuteScalar<int>(sql);
          return result;
        });
      });
      var num3 = await this.cache.GetOrAddAsync<int>("num3", () => {
        return Task.Run(() =>
        {
          var sql = "select count(*) from [dbo].[ORDERs] where (DELIVERYDATE <= GETDATE() and ACTUALDELIVERYDATE is null) or (DELIVERYDATE < ACTUALDELIVERYDATE )";
          var result = db.ExecuteScalar<int>(sql);
          return result;
        });
      });
      var num4 = await this.cache.GetOrAddAsync<int>("num4", () => {
        return Task.Run(() =>
        {
          var sql = "select sum(case [STATUS] when '170' then 1 else 0 end) *100 / count(1) from [dbo].[SHIPORDERs]";
          var result = db.ExecuteScalar<int>(sql);
          return result;
        });
      });
      return Json(new { success = true, num1, num2, num3, num4 }, JsonRequestBehavior.AllowGet);
    }

    [HttpGet]
    public async Task<JsonResult> GetTackTitle()
    {
      var num1 = await Task.Run(() =>
        {
          var sql = "select count(*) from [dbo].[Vehicle]";
          var result = db.ExecuteScalar<int>(sql);
          return result;
        });
      
      var num2 =  await      Task.Run(() =>
        {
          var sql = "select count(*) from [dbo].[SHIPORDERs] where status in('120','130','140','150','150') ";
          var result = db.ExecuteScalar<int>(sql);
          return result;
        });
      var num3 = await Task.Run(() =>
      {
        var sql = "select count(*) from [dbo].[ORDERs] where status = '100' ";
        var result = db.ExecuteScalar<int>(sql);
        return result;
      });
     
      var num4 = await Task.Run(() =>
        {
          var sql = "select count(*) from [dbo].[ORDERs] where (DELIVERYDATE <= GETDATE() and ACTUALDELIVERYDATE is null) ";
          var result = db.ExecuteScalar<int>(sql);
          return result;
        });
      
      
      return Json(new { success = true, num1, num2, num3, num4 }, JsonRequestBehavior.AllowGet);
    }
    public ActionResult About()
    {
      this.ViewBag.Message = "Your application description page.";

      return this.View();
    }

    public ActionResult GetTime() =>
        //ViewBag.Message = "Your application description page.";

        this.View();
    public ActionResult BlankPage() => this.View();
    public ActionResult AgileBoard() => this.View();


    public ActionResult Contact()
    {
      this.ViewBag.Message = "Your contact page.";

      return this.View();
    }
    public ActionResult Chat() => this.View();




  }
}