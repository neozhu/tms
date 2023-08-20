using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Repository.Pattern.UnitOfWork;
using WebApp.Services;

namespace WebApp.Controllers
{
  public class FileUploadController : Controller
  {

    private readonly ICodeItemService _codeService;
    private readonly ISalesmanService salesmanservice;
    private readonly ISUPPLIERService supplierservice;
    private readonly IORDERService orderservice;
    private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly ILocBaseService locservice;
    private readonly IVehicleService vehicleService;
    private readonly IFreightRuleService freightRuleService;
    private readonly IWaybillService waybillService;
    public FileUploadController(
      IFreightRuleService freightRuleService,
    IVehicleService vehicleService,
      ISalesmanService salesmanservice,
      ISUPPLIERService supplierservice,
    IORDERService orderservice,
      ILocBaseService locservice,
      IWaybillService waybillService,
        ICodeItemService _codeService, IUnitOfWorkAsync unitOfWork)
    {
      this.locservice = locservice;
      this.orderservice = orderservice;
      this._unitOfWork = unitOfWork;
      this.salesmanservice = salesmanservice;
      this._codeService = _codeService;
      this.supplierservice = supplierservice;
      this.vehicleService = vehicleService;
      this.freightRuleService = freightRuleService;
      this.waybillService = waybillService;
    }
    //Excel上传导入接口
    [HttpPost]
    public async Task<ActionResult> Upload()
    {
      var fileType = "";
      //string date = "";
      //string filename = "";
      //string Lastfilename = "";
      var request = this.Request;
    
      var uploadfilename = string.Empty;
      var newfileName = string.Empty;
      var watch = new Stopwatch();

      try
      {

        watch.Start();
        // 如果没有上传文件
        if (this.Request.Files.Count == 0)
        {
          return this.Json(new { success = false, message = "没有上传文件" }, JsonRequestBehavior.AllowGet);
        }
        var filedata = this.Request.Files[0];
        var model = this.Request.Form["FileType"];
        fileType = this.Request.Form["FileType"];
        uploadfilename = System.IO.Path.GetFileName(filedata.FileName);
        var ext = System.IO.Path.GetExtension(filedata.FileName);
        var folder = this.Server.MapPath("~/UploadFiles");
        newfileName = $"{filedata.FileName.Replace(ext, "")}_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}{ext}";//重组成新的文件名
        if (!Directory.Exists(folder))
        {
          Directory.CreateDirectory(folder);
        }
        var virtualPath = Path.Combine(folder, newfileName);
        var stream = new MemoryStream();
        await filedata.InputStream.CopyToAsync(stream);
        // 文件系统不能使用虚拟路径
        filedata.InputStream.Seek(0, SeekOrigin.Begin);
        stream.Seek(0, SeekOrigin.Begin);
        var datatable = await NPOIHelper.GetDataTableFromExcelAsync(stream, ext);

        if (fileType == "CodeItem")
        {
          this._unitOfWork.SetAutoDetectChangesEnabled(false);
          this._codeService.ImportDataTable(datatable);
          this._unitOfWork.BulkSaveChanges();

          //_unitOfWork.SaveChanges();
          this._unitOfWork.SetAutoDetectChangesEnabled(true);
        }
        if (fileType == "Waybill")
        {
          await this.waybillService.ImportDataTableAsync(datatable);
          await _unitOfWork.SaveChangesAsync();
        }
        if (fileType == "ORDER")
        {
          this.orderservice.ImportDataTable(datatable,this.User.Identity.Name,Auth.GetCompanyCode());
          _unitOfWork.SaveChanges();
        }
        
          if (fileType == "FreightRule")
        {
          this.freightRuleService.ImportDataTable(datatable);
          _unitOfWork.SaveChanges();
        }
        if (fileType == "LocBase")
        {
          this.locservice.ImportDataTable(datatable);
          _unitOfWork.SaveChanges();
        }
        if (fileType == "Vehicle")
        {
          this.vehicleService.ImportDataTable(datatable);
          _unitOfWork.SaveChanges();
        }
        if (fileType == "Salesman")
        {
          this.salesmanservice.ImportDataTable(datatable);
          _unitOfWork.SaveChanges();
        }
        if (fileType == "SUPPLIER")
        {
          this.supplierservice.ImportDataTable(datatable);
          _unitOfWork.SaveChanges();
        }



        watch.Stop();
        //获取当前实例测量得出的总运行时间（以毫秒为单位）
         var elapsedTime = watch.ElapsedMilliseconds.ToString();
        filedata.SaveAs(virtualPath);
        return this.Json(new { success = true, filename = newfileName, elapsedTime = elapsedTime }, JsonRequestBehavior.AllowGet);
      }
      catch (System.Data.SqlClient.SqlException e)
      {
        Logger.Error(uploadfilename, "FileUpload", e.GetBaseException().Message, fileType, e.Source, e.StackTrace);
        return this.Json(new { success = false, filename = newfileName, message = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
      catch (System.Data.Entity.Infrastructure.DbUpdateException e)
      {
        Logger.Error(uploadfilename, "FileUpload", e.GetBaseException().Message, fileType, e.Source, e.StackTrace);
        return this.Json(new { success = false, filename = newfileName, message = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException e)
      {
        var errormessage = string.Join(",", e.EntityValidationErrors.Select(x => x.ValidationErrors.FirstOrDefault()?.PropertyName + ":" + x.ValidationErrors.FirstOrDefault()?.ErrorMessage).Distinct());
        Logger.Error(uploadfilename, "FileUpload", errormessage, fileType, e.Source, e.StackTrace);
        return this.Json(new { success = false, filename = newfileName, message = errormessage }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        Logger.Error(uploadfilename, "FileUpload", e.GetBaseException().Message, fileType, e.Source, e.StackTrace);
        return this.Json(new { success = false, filename = newfileName, message = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }
    }


    [FileDownload]
    public FileContentResult Download(string file = "")
    {
      if (string.IsNullOrEmpty(file))
      {
        throw new ArgumentNullException($"input file name is empty!");
      }
      byte[] fileContent = null;
      var fileName = "";
      var mimeType = "";

      var downloadFile = new FileInfo(this.Server.MapPath(file));
      if (downloadFile.Exists)
      {
        fileName = downloadFile.Name;
        mimeType = this.GetMimeType(downloadFile.Extension);
        fileContent = new byte[Convert.ToInt32(downloadFile.Length)];
        var fs = downloadFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
        fs.Read(fileContent, 0, Convert.ToInt32(downloadFile.Length));
        fs.Close();
        fs.Dispose();
        return this.File(fileContent, mimeType, fileName);
      }
      else
      {
        throw new FileNotFoundException($"not found file {file}!");
      }



    }
    [HttpPost]
    public JsonResult Remove(string filename = "")
    {
      if (!string.IsNullOrEmpty(filename))
      {
        var folder = this.Server.MapPath("~/UploadFiles");
        var path = Path.Combine(folder, filename);
        if (System.IO.File.Exists(path))
        {
          System.IO.File.Delete(path);
        }
      }
      return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }

    private string GetMimeType(string fileExtensionStr)
    {
      var ContentTypeStr = "application/octet-stream";
      var fileExtension = fileExtensionStr.ToLower();
      switch (fileExtension)
      {
        case ".mp3":
          ContentTypeStr = "audio/mpeg3";
          break;
        case ".mpeg":
          ContentTypeStr = "video/mpeg";
          break;
        case ".jpg":
          ContentTypeStr = "image/jpeg";
          break;
        case ".bmp":
          ContentTypeStr = "image/bmp";
          break;
        case ".gif":
          ContentTypeStr = "image/gif";
          break;
        case ".doc":
          ContentTypeStr = "application/msword";
          break;
        case ".css":
          ContentTypeStr = "text/css";
          break;
        case ".html":
          ContentTypeStr = "text/html";
          break;
        case ".htm":
          ContentTypeStr = "text/html";
          break;
        case ".swf":
          ContentTypeStr = "application/x-shockwave-flash";
          break;
        case ".exe":
          ContentTypeStr = "application/octet-stream";
          break;
        case ".inf":
          ContentTypeStr = "application/x-texinfo";
          break;
        case ".xls":
        case ".xlsx":
          ContentTypeStr = "application/vnd.ms-excel";
          break;
        default:
          ContentTypeStr = "application/octet-stream";
          break;
      }
      return ContentTypeStr;
    }
  }
}
