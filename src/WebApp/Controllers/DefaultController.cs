using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net;
using System.IO;
using WebApp.Models;

namespace WebApp.Controllers
{
  public class DefaultController : ApiController
  {
    //private readonly ICompanyService _companyService;
    //public DefaultController(ICompanyService companyService)
    //{
    //    this._companyService = companyService;
    //}
    // GET: api/Default

    public static List<string> smscode = new List<string>();
    public Random rand = new Random();
    // GET: api/Default/5
    public void SendSMS(string phonenumber)
    {
      var code = this.rand.Next(100, 999);
      smscode.Add(code.ToString());
      App_Helpers.QCloudHelper.SendSMSWithTPL(phonenumber, 428065, code.ToString(), "5");
    }

    public bool Vaildate(string phonenumber, string code) {

      return smscode.Where(x => x == code).Any();

    }
    public HttpResponseMessage UploadFile()
    {
      HttpResponseMessage result = null;
      var httpRequest = HttpContext.Current.Request;
      if (httpRequest.Files.Count > 0)
      {
        var docfiles = new List<string>();
        foreach (string f in httpRequest.Files)
        {
          var file = httpRequest.Files[f];
          var filename = file.FileName;
          var contenttype = file.ContentType;
          var size = file.ContentLength;
          var ext = System.IO.Path.GetExtension(filename);
          
          var folder = HttpContext.Current.Server.MapPath("~/UploadFiles");
          if (!Directory.Exists(folder))
          {
            Directory.CreateDirectory(folder);
          }
          var newfilename = $"{filename.Replace(ext, "")}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{ext}";
          var virtualPath = Path.Combine(folder, newfilename
            );
          // 文件系统不能使用虚拟路径
          //string path = this.Server.MapPath(virtualPath);
          file.SaveAs(virtualPath);
          var doc = new Document();
          doc.OrderKey = httpRequest.Form["OrderKey"];
          doc.Description = httpRequest.Form["Description"];
          doc.UploadDateTime = DateTime.Now;
          doc.User = httpRequest.Form["User"];
          doc.FileName = filename;
          doc.ContentType = contenttype;
          doc.FileType = ext;
          doc.Size = size;
          doc.Path = virtualPath;
          doc.Url = $"/UploadFiles/{newfilename}";
          var db = new StoreContext();
          db.Documents.Add(doc);
          db.SaveChanges();
          docfiles.Add(doc.Url);
        }
        result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
      }
      else
      {
        result = Request.CreateResponse(HttpStatusCode.BadRequest);
      }
      return result;
    
  }

}

}
