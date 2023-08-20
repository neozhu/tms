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
/// File: IORDERService.cs
/// Purpose: Service interfaces. Services expose a service interface
/// to which all inbound messages are sent. You can think of a service interface
/// as a façade that exposes the business logic implemented in the application
/// Created Date: 2019/8/8 7:25:02
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
    public interface IORDERService:IService<ORDER>
    {
                          IEnumerable<ORDERDETAIL>   GetORDERDETAILSByORDERID (int orderid);
         
		void ImportDataTable(DataTable datatable ,string username = "", string companycode = "");
    Stream ExportExcel(string filterRules = "", string sort = "ID", string order = "asc");
    Stream ExportFinanceExcel( string filterRules = "",string sort = "ID", string order = "asc");
    void Delete(int[] id);
    void Confirm(int[] id);
    void CancelConfirm(int id);
    void CreateOrder(ORDER entity);


    void SyncUpdate(int id);
  }
}