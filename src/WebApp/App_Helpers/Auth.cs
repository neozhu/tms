using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LazyCache;
using WebApp.Models;

namespace WebApp
{
  public static class Auth
  {
    private static IAppCache cache = new CachingService();
    /// <summary>
    /// 获取当前登录用户名
    /// </summary>
    public static string CurrentUserName
    {

      get
      {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
          return HttpContext.Current.User.Identity.Name;
        }
        else
        {
          return "Unauthenticated";
        }
      }
    }

    public static ApplicationUser CurrentApplicationUser
    {
      get
      {
        var username = HttpContext.Current.User.Identity.Name;
        var db = SqlHelper2.DatabaseFactory.CreateDatabase();
        var user = db.ExecuteDataReader<ApplicationUser>("select * from [dbo].[AspNetUsers] where [username]=@username", new { username },
            dr =>
            {
              return new ApplicationUser()
              {
                AvatarsX120 = dr["AvatarsX120"].ToString(),
                AvatarsX50 = dr["AvatarsX50"].ToString(),
                AccountType = Convert.ToInt32(dr["AccountType"]),
                CompanyCode = dr["CompanyCode"].ToString(),
                CompanyName = dr["CompanyName"].ToString(),
                Email = dr["Email"].ToString(),
                FullName = dr["FullName"].ToString(),
                Gender = Convert.ToInt32(dr["Gender"].ToString()),
                PhoneNumber = dr["PhoneNumber"].ToString(),
                UserName = dr["UserName"].ToString(),
                TenantId = Convert.ToInt32(dr["TenantId"])

              };
            });
        return user.FirstOrDefault();
      }
    }
    public static int GetCompanyId(string username = null) => cache.GetOrAdd($"Identity.CompanyId.{username ?? HttpContext.Current.User.Identity.Name}", () =>
    {
      username = string.IsNullOrEmpty(username) ? HttpContext.Current.User.Identity.Name : username;
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      var companyId = db.ExecuteScalar<int>("select top 1 t1.Id  from Companies as t1,AspNetUsers t2 where t1.Name = t2.CompanyName and [username]=@username", new { username });
      return companyId;
    });
    public static string GetCompanyCode(string username = null) => cache.GetOrAdd($"Identity.CompanyCode.{username ?? HttpContext.Current.User.Identity.Name}", () =>
    {
      username = string.IsNullOrEmpty(username) ? HttpContext.Current.User.Identity.Name : username;
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      var companyCode = db.ExecuteScalar<string>("select [CompanyCode] from [dbo].[AspNetUsers] where [username]=@username", new { username });
      return companyCode;
    });
    public static string GetFullName(string username = null) => cache.GetOrAdd($"Identity.FullName.{username ?? HttpContext.Current.User.Identity.Name}", () =>
    {
      username = string.IsNullOrEmpty(username) ? HttpContext.Current.User.Identity.Name : username;
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      var userid = db.ExecuteScalar<string>("select [fullname] from [dbo].[AspNetUsers] where [username]=@username", new { username });
      return userid;
    });
    public static int GetTenantId(string username = null) => cache.GetOrAdd($"Identity.TenantId.{username ?? HttpContext.Current.User.Identity.Name}", () =>
    {
      username = string.IsNullOrEmpty(username) ? HttpContext.Current.User.Identity.Name : username;
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      var tenantid = db.ExecuteScalar<int>("select [TenantId] from [dbo].[AspNetUsers] where [username]=@username", new { username });
      return tenantid;
    });
    public static string GetUserIdByName(string username = null) => cache.GetOrAdd($"Identity.Id.{username ?? HttpContext.Current.User.Identity.Name}", () =>
    {
      username = string.IsNullOrEmpty(username) ? HttpContext.Current.User.Identity.Name : username;
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      var userid = db.ExecuteScalar<string>("select [id] from [dbo].[AspNetUsers] where [username]=@username", new { username });
      return userid;
    });
    public static async Task SetOnlineAsync(string id)
    {
      var sql = "update [dbo].[AspNetUsers]  set [IsOnline]=1 where [Id]=@id";
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      await db.ExecuteNonQueryAsync(sql, new { id = id });
    }
    public static async Task SetOfflineAsync(string id)
    {
      var sql = "update [dbo].[AspNetUsers]  set [IsOnline]=0 where [Id]=@id";
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      await db.ExecuteNonQueryAsync(sql, new { id = id });
    }
    public static string GetAvatarsByName(string username = null, int size = 50) => cache.GetOrAdd($"Identity.Avatar.{username}", () =>
    {
      username = string.IsNullOrEmpty(username) ? HttpContext.Current.User.Identity.Name : username;
      var db = SqlHelper2.DatabaseFactory.CreateDatabase();
      var photopath = "";
      if (size == 50)
      {
        photopath = db.ExecuteScalar<string>("select [AvatarsX50] from [dbo].[AspNetUsers] where [username]=@username", new { username });
      }
      else
      {
        photopath = db.ExecuteScalar<string>("select [AvatarsX120] from [dbo].[AspNetUsers] where [username]=@username", new { username });
      }

      return "/content/img/avatars/" + ( string.IsNullOrEmpty(photopath) ? "sunny" : photopath ) + ".png";
    });
  }
}