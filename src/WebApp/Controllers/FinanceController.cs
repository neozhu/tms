using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Infrastructure;
using Z.EntityFramework.Plus;
using WebApp.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class FinanceController : Controller
    {
    private readonly ISHIPORDERService shiporderservice;
    private readonly IUnitOfWorkAsync unitOfWork;
    private readonly IORDERService orderservice;
    private readonly IORDERDETAILService orderdetailservice;
    private readonly IMapper mapper;
    // GET: Finance
    public FinanceController(
      IMapper mapper,
      IORDERService orderservice,
      IORDERDETAILService orderdetailservice,
      ISHIPORDERService shiporderservice, IUnitOfWorkAsync unitOfWork)
    {
      this.mapper = mapper;
      this.orderdetailservice = orderdetailservice;
      this.orderservice = orderservice;
      this.shiporderservice = shiporderservice;
      this.unitOfWork = unitOfWork;
    }
    //对账单
    public ActionResult BillsByOrder() => View();
    //运单毛利统计
    public ActionResult BillsByShipOrder() => View();
    //Get :ORDERs/GetData
    //For Index View datagrid datasource url
    [HttpGet]
    public async Task<JsonResult> GetDataAsync(int page = 1, int rows = 10, string sort = "ID", string order = "asc", string filterRules = "")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);

      if (!string.IsNullOrEmpty(Auth.GetCompanyCode()))
      {
        if (filters == null)
        {
          filters = new List<filterRule>().ToArray();
        }
        filters = filters.Concat(new filterRule[] {
          new filterRule(){
             field="COMPANYCODE",
             value=Auth.GetCompanyCode()
          }
        });
      }
      var pagerows = ( await this.orderservice
                                 .Query(new ORDERQuery().Withfilter170(filters))
                                 .OrderBy(n => n.OrderBy(sort, order))
                                 .SelectPageAsync(page, rows, out var totalCount) )
                                 .Select(n => new
                                 {

                                   ID = n.ID,
                                   SALER = n.SALER,
                                   ORDERKEY = n.ORDERKEY,
                                   EXTERNORDERKEY = n.EXTERNORDERKEY,
                                   WHSEID = n.WHSEID,
                                   LOTTABLE2 = n.LOTTABLE2,
                                   ORIGINAL = n.ORIGINAL,
                                   DESTINATION = n.DESTINATION,
                                   TYPE = n.TYPE,
                                   SHPTYPE = n.SHPTYPE,
                                   STATUS = n.STATUS,
                                   COST3NOTE = n.COST3NOTE,
                                   STORERKEY = n.STORERKEY,
                                   SUPPLIERCODE = n.SUPPLIERCODE,
                                   SUPPLIERNAME = n.SUPPLIERNAME,
                                   ORDERDATE = n.ORDERDATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                   REQUESTEDSHIPDATE = n.REQUESTEDSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
                                   DELIVERYDATE = n.DELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
                                   LOTTABLE3 = n.LOTTABLE3,
                                   CONSIGNEEKEY = n.CONSIGNEEKEY,
                                   CONSIGNEENAME = n.CONSIGNEENAME,
                                   CONSIGNEEADDRESS = n.CONSIGNEEADDRESS,
                                   CARRIERNAME = n.CARRIERNAME,
                                   DRIVERNAME = n.DRIVERNAME,
                                   CARRIERPHONE = n.CARRIERPHONE,
                                   TRAILERNUMBER = n.TRAILERNUMBER,
                                   ACTUALSHIPDATE = n.ACTUALSHIPDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
                                   ACTUALDELIVERYDATE = n.ACTUALDELIVERYDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
                                   CLOSEDDATE = n.CLOSEDDATE?.ToString("yyyy-MM-dd HH:mm:ss"),
                                   TOTALQTY = n.TOTALQTY,
                                   TOTALSHIPPEDQTY = n.TOTALSHIPPEDQTY,
                                   TOTALCASECNT = n.TOTALCASECNT,
                                   TOTALGROSSWGT = n.TOTALGROSSWGT,
                                   TOTALCUBE = n.TOTALCUBE,
                                   CHECKEDCOST1 = n.CHECKEDCOST1,
                                   TOTALCOST1 = n.TOTALCOST1,
                                   CHECKEDCOST2 = n.CHECKEDCOST2,
                                   TOTALCOST2 = n.TOTALCOST2,
                                   CHECKEDCOST3 = n.CHECKEDCOST3,
                                   FLOOR = n.FLOOR,
                                   TOTALCOST3 = n.TOTALCOST3,
                                   CHECKEDCOST4 = n.CHECKEDCOST4,
                                   TOTALCOST4 = n.TOTALCOST4,
                                   CHECKEDCOST5 = n.CHECKEDCOST5,
                                   TOTALCOST5 = n.TOTALCOST5,
                                   CHECKEDCOST6 = n.CHECKEDCOST6,
                                   TOTALCOST6 = n.TOTALCOST6,
                                   TOTALCOST6NOTES = n.TOTALCOST6NOTES,
                                   CHECKEDCOST7 = n.CHECKEDCOST7,
                                   TOTALCOST7 = n.TOTALCOST7,
                                   CHECKEDCOST8 = n.CHECKEDCOST8,
                                   TOTALCOST8 = n.TOTALCOST8,
                                   NOTES = n.NOTES,
                                   FLAG1 = n.FLAG1,
                                   NOTES1 = n.NOTES1,
                                   FLAG2 = n.FLAG2,
                                   COMPANYCODE = n.COMPANYCODE,
                                   CONTACTINFO = n.CONTACTINFO,
                                   REQUIREMENTS = n.REQUIREMENTS,
                                   EXTERNORDERKEY1 = n.EXTERNORDERKEY1,
                                   FACTORY = n.FACTORY,
                                   SHOP = n.SHOP,
                                   CHANNEL = n.CHANNEL,
                                   DELIVERYVOUCHER = n.DELIVERYVOUCHER,
                                   SALESDEP = n.SALESDEP,
                                   SALESORG = n.SALESORG,
                                   LOTTABLE1 = n.LOTTABLE1,
                                   LOTTABLE4 = n.LOTTABLE4,
                                   LOTTABLE5 = n.LOTTABLE5,
                                   LOTTABLE6 = n.LOTTABLE6,
                                   LOTTABLE7 = n.LOTTABLE7,
                                   LOTTABLE8 = n.LOTTABLE8?.ToString("yyyy-MM-dd HH:mm:ss")
                                 }).ToList();
      var pagelist = new { total = totalCount, rows = pagerows };
      return this.Json(pagelist, JsonRequestBehavior.AllowGet);
    }

    //费用确认
    [HttpPost]
    public async Task<JsonResult> ConfirmCheckedAsync(int[] id) {

      try
      {
        this.orderservice.Confirm(id);
        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }

    }

    //取消确认
    [HttpPost]
    public async Task<JsonResult> CancelConfirm(int id)
    {

      try
      {
        this.orderservice.CancelConfirm(id);
        var result = await this.unitOfWork.SaveChangesAsync();
        return this.Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception e)
      {
        return this.Json(new { success = false, err = e.GetBaseException().Message }, JsonRequestBehavior.AllowGet);
      }

    }

    //导出Excel
    [HttpPost]
    public ActionResult ExportExcel(string filterRules = "", string sort = "ID", string order = "asc")
    {
      var fileName = "订单结算单" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
      var stream = this.orderservice.ExportFinanceExcel(filterRules, sort, order);
      return this.File(stream, "application/vnd.ms-excel", fileName);
    }

  }
}