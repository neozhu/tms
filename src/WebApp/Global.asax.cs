using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SqlHelper2;
using WebApp.Models;


namespace WebApp
{
  public class MvcApplication : System.Web.HttpApplication
  {
    private readonly NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();
    protected void Application_Start()
    {
      //ViewEngines.Engines.Clear();
      //IViewEngine razorEngine = new RazorViewEngine() { FileExtensions = new string[] { "cshtml" } };
      //ViewEngines.Engines.Add(razorEngine);

      //AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      this.logger.Info("网站启动");
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
   
    }

    protected void Application_Error()
    {
      var exception = this.Server.GetLastError();

      if (EFMigrationsManagerConfig.HandleEFMigrationException(exception, this.Server, this.Response, this.Context))
      {
        return;
      }
      this.logger.Error(exception, exception.GetBaseException().Message);

    }
  }
}
