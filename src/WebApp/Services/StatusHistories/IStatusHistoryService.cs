using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
using System.Data;
using System.IO;
namespace WebApp.Services
{
/// <summary>
/// File: IStatusHistoryService.cs
/// Purpose: Service interfaces. Services expose a service interface
/// to which all inbound messages are sent. You can think of a service interface
/// as a façade that exposes the business logic implemented in the application
/// Created Date: 8/13/2019 3:05:11 PM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    public interface IStatusHistoryService:IService<StatusHistory>
    {
                  
		void ImportDataTable(DataTable datatable);
		Stream ExportExcel( string filterRules = "",string sort = "Id", string order = "asc");
    void Append(string orderkey, string shiporderkey, string status, string description, string user,string remark="", decimal? longitude = 0, decimal? latitude = 0);
	}
}