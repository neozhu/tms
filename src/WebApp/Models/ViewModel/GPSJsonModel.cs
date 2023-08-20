using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModel
{
  public class Result
  {
    public int userid { get; set; }
    public string userCode { get; set; }
    public string username { get; set; }
    public string avatar { get; set; }
    public string mobile { get; set; }
    public string company { get; set; }
    public string userTitle { get; set; }
    public string authtoken { get; set; }
    public string unionid { get; set; }
    public int logincount { get; set; }
    public string logindate { get; set; }
    public int isdata { get; set; }
    public List<string> objectid { get; set; }
    public List<string> sim { get; set; }
    public string ssvid { get; set; }
    public string shareurl { get; set; }
    public string qrcode { get; set; }
    public int passwordtip { get; set; }
    public int holdid { get; set; }
    public string holdname { get; set; }
    public int logintype { get; set; }
    public string posshareurl { get; set; }
    public string buyurl { get; set; }
    public string userType { get; set; }
    public string holdLastUpdateTime { get; set; }
    public string funIDS { get; set; }
    public int loginflag { get; set; }
  }

  public class LoginState
  {
    public int error { get; set; }
    public string reason { get; set; }
    public Result result { get; set; }
  }







  public class Loc
  {
    public int objectId { get; set; }
    public string objectName { get; set; }
    public string sim { get; set; }
    public string imei { get; set; }
    public string transType { get; set; }
    public string gpsTime { get; set; }
    public string rcvTime { get; set; }
    public decimal lon { get; set; }
    public decimal lat { get; set; }
    public string BDLon { get; set; }
    public string BDLat { get; set; }
    public string speed { get; set; }
    public string direct { get; set; }
    public string gpsFlag { get; set; }
    public string Posmode { get; set; }
    public string statusDes { get; set; }
    public string dayMileage { get; set; }
    public string mileage { get; set; }
    public string gpsLocatinAddr { get; set; }
    public string state { get; set; }
    public string isstopState { get; set; }
    public string startTime { get; set; }
    public string stopTime { get; set; }
    public int DeviceState { get; set; }
    public int MDTTypeStatus { get; set; }
    public bool SupportNVR { get; set; }
  }

  public class LocState
  {
    public int error { get; set; }
    public string reason { get; set; }
    public Loc result { get; set; }
  }

  public class RtmpState
  {
    public int error { get; set; }
    public string reason { get; set; }
    public string result { get; set; }
  }

  public class VehVideo {
    public string PlateNumber { get; set; }
    public string Driver { get; set; }
    public string DriverPhone { get; set; }
    public string RtmpUrl { get; set; }
    }
}