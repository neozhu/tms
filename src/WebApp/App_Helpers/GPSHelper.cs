using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using WebApp.Models.ViewModel;

namespace WebApp.App_Helpers
{
  public static class GPSHelper
  {
    public static string GetAddress(decimal lng,decimal lat) {
      var client = new HttpClient();
      var url = $"https://restapi.amap.com/v3/geocode/regeo?location={lng},{lat}&key={Settings.MapKey}&radius=1000&extensions=all";
      var res = client.GetAsync($"https://restapi.amap.com/v3/geocode/regeo?location={lng},{lat}&key={Settings.MapKey}&radius=1000&extensions=all").Result;
      var json = JsonConvert.DeserializeObject<dynamic>(res.Content.ReadAsStringAsync().Result);
      return "";
      }
    public static  LocState GetLocState(string objectid) {
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
      var result =   client.PostAsync(url, content).Result;
      if (result.StatusCode == HttpStatusCode.OK)
      {
        var jsonstr =   result.Content.ReadAsStringAsync().Result;
        var loginstate = JsonConvert.DeserializeObject<LoginState>(jsonstr);
        if (loginstate.error == 0)
        {
          var token = loginstate.result.authtoken;
          //var sim = loginstate.result.sim;
          //var objectid = loginstate.result.objectid;
          var client2 = new HttpClient();
          client2.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
          client2.DefaultRequestHeaders.TryAddWithoutValidation("AppKey", appkey);
          client2.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
          var result2 =   client2.GetStringAsync($"{Settings.GpsApiURL}/GetSimpleObjectTracks?objectid={objectid}").Result;
          var locstate = JsonConvert.DeserializeObject<LocState>(result2);
          if (locstate.error == 0)
          {

            return locstate;
          }
          else
          {
            return null;
          }
        }
        else
        {
          return null;
        }
      }
      return null;

    }
    public static gps_location GetLocation(string devIdno) {
      try
      {
        var account = Settings.GpsAccount;
        var password = Settings.GpsPassword;
        var baseUrl = Settings.GpsApiURL;
        var client = new RestClient(baseUrl);
        var request = new RestRequest($"StandardApiAction_login.action?account={account}&password={password}");
        var response = client.Get(request);
        var session = SimpleJson.DeserializeObject<gps_session>(response.Content);
        if (session.result > 0)
        {
          return new gps_location() { result = session.result, message = session.message };
        }
        var jsession = session.jsession;
        request = new RestRequest($"StandardApiAction_getDeviceStatus.action?jsession={jsession}&devIdno=${devIdno}&toMap=1&geoaddress=1&language=zh");
        response = client.Get(request);
        var result = SimpleJson.DeserializeObject<gps_location>(response.Content);
        return result;
      }
      catch (Exception e) {
        return new gps_location() { result = 99, message = e.Message };
      }
    }
    public static gps_status GetStatus(string devIno) {
      try
      {
        var account = Settings.GpsAccount;
      var password = Settings.GpsPassword;
      var baseUrl = Settings.GpsApiURL;
      var client = new RestClient(baseUrl);
      var request = new RestRequest($"StandardApiAction_login.action?account={account}&password={password}");
      var response = client.Get(request);
      var session = SimpleJson.DeserializeObject<gps_session>(response.Content);
      if (session.result > 0)
      {
        return new gps_status() { result = session.result, message = session.message };
      }
        var jsession = session.jsession;
        request = new RestRequest($"StandardApiAction_vehicleStatus.action?jsession={session.jsession}&vehiIdno={devIno}&toMap=1");
        response = client.Get(request);
        var result = SimpleJson.DeserializeObject<gps_status>(response.Content);
        return result;
      }
      catch (Exception e)
      {
        return new gps_status() { result = 99, message = e.Message };
      }
    }
    public static gps_tracks GetTracks(string devIdno, DateTime dt1, DateTime dt2) {
      try
      {
        var account = Settings.GpsAccount;
        var password = Settings.GpsPassword;
        var baseUrl = Settings.GpsApiURL;
        var client = new RestClient(baseUrl);
      var request = new RestRequest($"StandardApiAction_login.action?account={account}&password={password}");
      var response = client.Get(request);
      var session = SimpleJson.DeserializeObject<gps_session>(response.Content);
      if (session.result > 0)
      {
        return new gps_tracks() { result = session.result, message = session.message };
      }
      var jsession = session.jsession;

      request = new RestRequest($"StandardApiAction_queryTrackDetail.action?jsession={jsession}&devIdno={devIdno}&begintime={dt1.ToString("yyyy-MM-dd HH:mm:ss")}&endtime={dt2.ToString("yyyy-MM-dd HH:mm:ss")}&distance=0&parkTime=0&currentPage=1&pageRecords=500&toMap=1");
      response = client.Get(request);
      var result = SimpleJson.DeserializeObject<gps_tracks>(response.Content);
      return result;
      }
      catch (Exception e)
      {
        return new gps_tracks() { result = 99, message = e.Message };
      }
    }
  }

  public class gps_status {
    public int result { get; set; }
    public string message { get; set; }
    public List<info> infos { get; set; }
    public pagination pagination { get; set; }
  }
  public class info
  {
    public string vi { get; set; }
    public long tm { get; set; }
    public int jd { get; set; }
    public int wd { get; set; }
    public string pos { get; set; }
  }
  public class gps_session
  {
    public int result { get; set; }
    public string message { get; set; }
    public string jsession { get; set; }
    public string account_name { get; set; }
    public string JSESSIONID { get; set; }
  }

  public class status
  {
    public string id { get; set; }
    public object vid { get; set; }
    public int lng { get; set; }
    public int lat { get; set; }
    public int ft { get; set; }
    public int sp { get; set; }
    public int ol { get; set; }
    public string gt { get; set; }
    public int pt { get; set; }
    public int dt { get; set; }
    public int ac { get; set; }
    public int fdt { get; set; }
    public int net { get; set; }
    public string gw { get; set; }
    public int s1 { get; set; }
    public int s2 { get; set; }
    public int s3 { get; set; }
    public int s4 { get; set; }
    public int t1 { get; set; }
    public int t2 { get; set; }
    public int t3 { get; set; }
    public int t4 { get; set; }
    public int hx { get; set; }
    public decimal mlng { get; set; }
    public decimal mlat { get; set; }
    public int pk { get; set; }
    public int lc { get; set; }
    public int yl { get; set; }
    public object jn { get; set; }
    public object dn { get; set; }
    public string ps { get; set; }
  }

  public class gps_location
  {
    public int result { get; set; }
    public string message { get; set; }
    public IEnumerable<status> status { get; set; }
  }


  public class track
  {
    public string id { get; set; }
    public int lng { get; set; }
    public int lat { get; set; }
    public int ft { get; set; }
    public int sp { get; set; }
    public int ol { get; set; }
    public string gt { get; set; }
    public int pt { get; set; }
    public int dt { get; set; }
    public int ac { get; set; }
    public int fdt { get; set; }
    public int net { get; set; }
    public string gw { get; set; }
    public int s1 { get; set; }
    public int s2 { get; set; }
    public int s3 { get; set; }
    public int s4 { get; set; }
    public int t1 { get; set; }
    public int t2 { get; set; }
    public int t3 { get; set; }
    public int t4 { get; set; }
    public int hx { get; set; }
    public string mlng { get; set; }
    public string mlat { get; set; }
    public int pk { get; set; }
    public int lc { get; set; }
    public int yl { get; set; }
  }

  public class SortParams
  {
  }
  public class pagination
  {
    public int totalPages { get; set; }
    public int currentPage { get; set; }
    public int pageRecords { get; set; }
    public int totalRecords { get; set; }
    public SortParams sortParams { get; set; }
    public bool hasNextPage { get; set; }
    public bool hasPreviousPage { get; set; }
    public int nextPage { get; set; }
    public int previousPage { get; set; }
    public int startRecord { get; set; }
  }

  public class gps_tracks
  {
    public int result { get; set; }
    public List<track> tracks { get; set; }
    public pagination pagination { get; set; }
    public string message { get; set; }
  }

}