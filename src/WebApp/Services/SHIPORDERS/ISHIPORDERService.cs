using System.Collections.Generic;
using System.Data;
using System.IO;
using Service.Pattern;
using WebApp.Models;
using WebApp.Models.ViewModel;

namespace WebApp.Services
{
  /// <summary>
  /// File: ISHIPORDERService.cs
  /// Purpose: Service interfaces. Services expose a service interface
  /// to which all inbound messages are sent. You can think of a service interface
  /// as a façade that exposes the business logic implemented in the application
  /// Created Date: 8/12/2019 9:08:17 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public interface ISHIPORDERService : IService<SHIPORDER>
  {
    IEnumerable<SHIPORDERDETAIL> GetSHIPORDERDETAILSBySHIPORDERID(int shiporderid);

    void ImportDataTable(DataTable datatable);
    Stream ExportExcel(string filterRules = "", string sort = "ID", string order = "asc");
    CalTotalCostViewModel CalTotalCost(string original, string destination, decimal stdloadwt, string shptype, int[] orderdetailsid);
    void PostCreateShipOrder(SHIPORDER header, int[] orderdetailsid,string user);
    void DoPrint(int id, string user);
    void DoCompleted(int id, string user);
    ShipOrderTrackViewModel GetTracks(int id);
    IEnumerable<ShipOrderTrackViewModel> GetTrackList();
    void NotifyLocToCustom(int id,string loc);
    void Cancle(int[] id,string user);

    void DoClosed(int id, string user);
  }
}