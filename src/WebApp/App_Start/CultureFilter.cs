using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApp 
{
  public class CultureFilter : IAuthorizationFilter
  {
    private readonly string defaultCulture;

    public CultureFilter() => this.defaultCulture = "cn";

    public void OnAuthorization(AuthorizationContext filterContext)
    {
      var culture = filterContext.HttpContext.Request.Cookies["culture"];
      var lang = defaultCulture;
      if (culture != null && culture.Value != null)
      {
        lang = culture.Value;
        filterContext.HttpContext.Response.Cookies.Set(culture);
      }
      switch (lang.Trim())
      {
        case "en":
          CultureInfo.CurrentCulture = new CultureInfo("en-US");
          CultureInfo.CurrentUICulture = new CultureInfo("en-US");
          //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
          //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
          break;
        case "cn":
          CultureInfo.CurrentCulture = new CultureInfo("zh-CN");
          CultureInfo.CurrentUICulture = new CultureInfo("zh-CN");
          //Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
          //Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
          break;
        case "tw":
          CultureInfo.CurrentCulture = new CultureInfo("zh-TW");
          CultureInfo.CurrentUICulture = new CultureInfo("zh-TW");
          //Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-TW");
          //Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-TW");
          break;
      }
    }
  }
}