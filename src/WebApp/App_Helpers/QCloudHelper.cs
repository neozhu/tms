using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using qcloudsms_csharp;
using qcloudsms_csharp.httpclient;
using qcloudsms_csharp.json;

namespace WebApp.App_Helpers
{
  /// <summary>
  /// 腾讯云SDK
  /// </summary>
  public static class QCloudHelper
  {
    public const int APPID = 1400256501;
    // 短信应用 SDK AppKey
    public const string APPKEY = "2ac1455261310cb9c0f32919c3b9cb40";
    public const string SMSSIGN = "广州时卓供应链";
    public static void SendSMS(string to, string msg) {
      try
      {
        var ssender = new SmsSingleSender(APPID, APPKEY);
        var result = ssender.send(0, "86", to,
            msg, "", "");
        Console.WriteLine(result);
      }
      catch (JSONException e)
      {
        Console.WriteLine(e);
      }
      catch (HTTPException e)
      {
        Console.WriteLine(e);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }


    public static void SendSMSWithTPL(string to,int templateId, params string[] paras)
    {
      try
      {
        var ssender = new SmsSingleSender(APPID, APPKEY);
        var result = ssender.sendWithParam("86", to,
           templateId, paras , SMSSIGN, "", "");
        Console.WriteLine(result);
      }
      catch (JSONException e)
      {
        Console.WriteLine(e);
      }
      catch (HTTPException e)
      {
        Console.WriteLine(e);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}