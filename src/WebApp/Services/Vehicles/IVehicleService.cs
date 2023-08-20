using System;
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
/// File: IVehicleService.cs
/// Purpose: Service interfaces. Services expose a service interface
/// to which all inbound messages are sent. You can think of a service interface
/// as a façade that exposes the business logic implemented in the application
/// Created Date: 2019/8/2 7:48:50
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    public interface IVehicleService:IService<Vehicle>
    {
                  
		void ImportDataTable(DataTable datatable);
		Stream ExportExcel( string filterRules = "",string sort = "Id", string order = "asc");

    void UpdateStatus(string platenumber, string status, string shiporderno, string user);
    string GetDevId(string platenumber);

    }
}