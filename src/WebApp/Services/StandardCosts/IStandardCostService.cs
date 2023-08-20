using System.Data;
using System.IO;
using Service.Pattern;
using WebApp.Models;
namespace WebApp.Services
{
  /// <summary>
  /// File: IStandardCostService.cs
  /// Purpose: Service interfaces. Services expose a service interface
  /// to which all inbound messages are sent. You can think of a service interface
  /// as a façade that exposes the business logic implemented in the application
  /// Created Date: 9/12/2019 1:48:30 PM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public interface IStandardCostService : IService<StandardCost>
  {

    void ImportDataTable(DataTable datatable);
    Stream ExportExcel(string filterRules = "", string sort = "Id", string order = "asc");
    void Delete(int[] id);
    StandardCost GetDataRule(string original, string destination, decimal stdloadweight);
  }
}