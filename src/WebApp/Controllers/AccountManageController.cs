using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using Repository.Pattern.Infrastructure;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
  [Authorize]
  [RoutePrefix("AccountManage")]
  public class AccountManageController : Controller
  {
    private ApplicationUserManager _userManager;
    private readonly ICompanyService _companyService;
    public AccountManageController(
                               ICompanyService companyService
                               ) => this._companyService = companyService;
    public ApplicationUserManager UserManager
    {
      get => this._userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
      private set => this._userManager = value;
    }
    private ApplicationSignInManager _signInManager;

    public ApplicationSignInManager SignInManager
    {
      get => this._signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
      private set => this._signInManager = value;
    }
    [Route("Index", Name = "系统账号管理", Order = 1)]
    public ActionResult Index() => this.View();

    //解锁，加锁账号
    public async Task<JsonResult> SetLockout(string[] userid)
    {
      foreach (var id in userid)
      {
        await this.UserManager.SetLockoutEndDateAsync(id, new DateTimeOffset(DateTime.Now.AddYears(1)));
      }
      return Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }
    public async Task<JsonResult> SetUnLockout(string[] userid)
    {
      foreach (var id in userid)
      {
        await this.UserManager.SetLockoutEndDateAsync(id, DateTime.Now);
      }
      return Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }
    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult ResetPassword(string id, string newPassword)
    {
      var code = this.UserManager.GeneratePasswordResetToken(id);
      var result = this.UserManager.ResetPassword(id, code, newPassword);
      if (result.Succeeded)
      {
        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
      }
      else
      {
        return Json(new { success = false, err = string.Join(",", result.Errors) }, JsonRequestBehavior.AllowGet);
      }

    }
    [HttpGet]
    public ActionResult GetData(int page = 1, int rows = 10, string sort = "Id", string order = "desc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var totalCount = 0;

      var users = this.UserManager.Users.OrderByName(sort, order);
      if (filters != null)
      {
        foreach (var filter in filters)
        {
          if (filter.field == "UserName")
          {
            users = users.Where(x => x.UserName.Contains(filter.value));
          }
          if (filter.field == "FullName")
          {
            users = users.Where(x => x.FullName.Contains(filter.value));
          }
          if (filter.field == "Email")
          {
            users = users.Where(x => x.Email.Contains(filter.value));
          }
          if (filter.field == "PhoneNumber")
          {
            users = users.Where(x => x.PhoneNumber.Contains(filter.value));
          }
          if (filter.field == "TenantId")
          {
            var tenantid = Convert.ToInt32(filter.value);
            users = users.Where(x => x.TenantId == tenantid);
          }
        }
      }
      totalCount = users.Count();
      var datalist = users.Skip(( page - 1 ) * rows).Take(rows);
      var datarows = datalist.Select(n => new
      {
        Id = n.Id,
        UserName = n.UserName,
        FullName = n.FullName,
        Gender = n.Gender,
        CompanyCode = n.CompanyCode,
        CompanyName = n.CompanyName,
        AccountType = n.AccountType,
        Email = n.Email,
        TenantId = n.TenantId,
        PhoneNumber = n.PhoneNumber,
        AvatarsX50 = n.AvatarsX50,
        AvatarsX120 = n.AvatarsX120,
        AccessFailedCount = n.AccessFailedCount,
        LockoutEnabled = n.LockoutEnabled,
        LockoutEndDateUtc = n.LockoutEndDateUtc,
        IsOnline = n.IsOnline,
        EnabledChat = n.EnabledChat
      }).ToList();
      var pagelist = new { total = totalCount, rows = datarows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }
    [HttpGet]
    public JsonResult GetAvatarsX50()
    {
      var list = new List<dynamic>();
      for (var i = 1; i <= 8; i++)
      {
        list.Add(new { name = "femal" + i.ToString() });
        list.Add(new { name = "male" + i.ToString() });
      }
      return this.Json(list.ToArray(), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public async Task<JsonResult> DeleteCheckedAsync(string[] id)
    {
      foreach (var key in id)
      {
        var user = await this.UserManager.FindByIdAsync(key);
        await this.UserManager.DeleteAsync(user);
      }
      return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }
    [HttpPost]
    public ActionResult SaveData(UserChangeViewModel users)
    {
      if (users.updated != null)
      {
        foreach (var item in users.updated)
        {
          var user = this.UserManager.FindById(item.Id);
          user.UserName = item.UserName;
          user.Email = item.Email;
          user.FullName = item.FullName;
          user.CompanyCode = item.CompanyCode;
          user.CompanyName = item.CompanyName;
          user.AccountType = item.AccountType;
          user.PhoneNumber = item.PhoneNumber;
          user.EnabledChat = item.EnabledChat;
          user.AvatarsX50 = string.IsNullOrEmpty(item.AvatarsX50) ? "male1" : item.AvatarsX50;
          user.AvatarsX120 = string.IsNullOrEmpty(item.AvatarsX50) ? "male1" : item.AvatarsX50 + "_big";
          user.TenantId = item.TenantId;
          user.Gender = item.Gender;
          var result = this.UserManager.Update(user);
          if (result.Succeeded)
          {
            var claims = this.UserManager.GetClaims(user.Id);
            foreach (var calim in claims)
            {
              this.UserManager.RemoveClaim(user.Id, calim);
            }
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("http://schemas.microsoft.com/identity/claims/tenantid", user.TenantId.ToString()));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("FullName", string.IsNullOrEmpty(user.FullName) ? "" : user.FullName));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("CompanyName", string.IsNullOrEmpty(user.CompanyName) ? "" : user.CompanyName));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("AvatarsX50", user.AvatarsX50));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("AvatarsX120", user.AvatarsX120));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("PhoneNumber", string.IsNullOrEmpty(user.PhoneNumber) ? "" : user.PhoneNumber));
          }

        }
      }
      if (users.deleted != null)
      {
        foreach (var item in users.deleted)
        {
          var user = this.UserManager.FindByEmail(item.Email);
          var result = this.UserManager.Delete(user);
        }
      }
      if (users.inserted != null)
      {
        foreach (var item in users.inserted)
        {
          var user = new ApplicationUser
          {
            UserName = item.UserName,
            Email = item.Email,
            FullName = item.FullName,
            Gender = item.Gender,
            TenantId = item.TenantId,
            CompanyCode = item.CompanyCode,
            CompanyName = item.CompanyName,
            PhoneNumber = item.PhoneNumber,
            AccountType = item.AccountType,
            AvatarsX50 = item.AvatarsX50,
            AvatarsX120 = item.AvatarsX50 + "_big"
          };
          var result = this.UserManager.Create(user, "123456");
          if (result.Succeeded)
          {
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("http://schemas.microsoft.com/identity/claims/tenantid", user.TenantId.ToString()));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("FullName", string.IsNullOrEmpty(user.FullName) ? "" : user.FullName));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("CompanyName", string.IsNullOrEmpty(user.CompanyName) ? "" : user.CompanyName));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("AvatarsX50", user.AvatarsX50));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("AvatarsX120", user.AvatarsX120));
            this.UserManager.AddClaim(user.Id, new System.Security.Claims.Claim("PhoneNumber", string.IsNullOrEmpty(user.PhoneNumber) ? "" : user.PhoneNumber));
          }
        }
      }


      return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }

    [HttpGet]
    public ActionResult Create() => this.View();

    [HttpPost]
    public async Task<ActionResult> Create(RegisterViewModel model)
    {
      if (this.ModelState.IsValid)
      {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await this.UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

          // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
          // Send an email with this link
          // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
          // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
          // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

          return this.RedirectToAction("Index", "AccountManager");
        }
        this.AddErrors(result);
      }

      // If we got this far, something failed, redisplay form
      return this.View(model);
    }
    [HttpGet]
    public async Task<ActionResult> Edit(string id)
    {

      var user = await this.UserManager.FindByIdAsync(id);
      if (user == null)
      {
        return this.View("Error");
      }

      return this.View(user);

    }

    [HttpPost]
    public async Task<ActionResult> Edit(ApplicationUser user)
    {
      if (this.ModelState.IsValid)
      {
        var item = await this.UserManager.FindByIdAsync(user.Id);
        item.UserName = user.UserName;
        item.PhoneNumber = user.PhoneNumber;
        item.Email = user.Email;
        var result = await this.UserManager.UpdateAsync(item);
        if (result.Succeeded)
        {
          return this.RedirectToAction("Index", "AccountManager");
        }
        this.AddErrors(result);
      }
      return this.View(user);

    }

    [HttpPost]
    public async Task<ActionResult> Delete(string id)
    {
      if (this.ModelState.IsValid)
      {
        var user = await this.UserManager.FindByIdAsync(id);
        var result = await this.UserManager.DeleteAsync(user);
        if (result.Succeeded)
        {
          if (this.Request.IsAjaxRequest())
          {
            return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
          }
          return this.RedirectToAction("Index", "AccountManager");
        }
        this.AddErrors(result);
      }
      return this.View();
    }

    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        this.ModelState.AddModelError("", error);
      }
    }

    private ActionResult RedirectToLocal(string returnUrl)
    {
      if (this.Url.IsLocalUrl(returnUrl))
      {
        return this.Redirect(returnUrl);
      }
      return this.RedirectToAction("Index", "Home");
    }
  }
}