using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Web.WebPages;
using Repository.Pattern.Ef6;
using WebApp.Models;

namespace WebApp.Repositories
{
  /// <summary>
  /// File: SalesmanQuery.cs
  /// Purpose: easyui datagrid filter query 
  /// Created Date: 9/12/2019 1:26:05 PM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class SalesmanQuery : QueryObject<Salesman>
  {
    public SalesmanQuery Withfilter(IEnumerable<filterRule> filters)
    {
      if (filters != null)
      {
        foreach (var rule in filters)
        {
          if (rule.field == "Id" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.Id == val);
                break;
              case "notequal":
                this.And(x => x.Id != val);
                break;
              case "less":
                this.And(x => x.Id < val);
                break;
              case "lessorequal":
                this.And(x => x.Id <= val);
                break;
              case "greater":
                this.And(x => x.Id > val);
                break;
              case "greaterorequal":
                this.And(x => x.Id >= val);
                break;
              default:
                this.And(x => x.Id == val);
                break;
            }
          }
          if (rule.field == "Name" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Name.Contains(rule.value));
          }
          if (rule.field == "Org" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Org.Contains(rule.value));
          }
          if (rule.field == "Dep" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Dep.Contains(rule.value));
          }
          if (rule.field == "CompanyName" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CompanyName.Contains(rule.value));
          }
          if (rule.field == "Title" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Title.Contains(rule.value));
          }
          if (rule.field == "IsPushNotification" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.IsPushNotification == boolval);
          }
          if (rule.field == "PhoneNumber" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.PhoneNumber.Contains(rule.value));
          }
          if (rule.field == "Email" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Email.Contains(rule.value));
          }
          if (rule.field == "Notes" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Notes.Contains(rule.value));
          }
          if (rule.field == "CreatedDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.CreatedDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.CreatedDate) <= 0);
            }
          }
          if (rule.field == "CreatedBy" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CreatedBy.Contains(rule.value));
          }
          if (rule.field == "LastModifiedDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.LastModifiedDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.LastModifiedDate) <= 0);
            }
          }
          if (rule.field == "LastModifiedBy" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LastModifiedBy.Contains(rule.value));
          }
          if (rule.field == "TenantId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TenantId == val);
                break;
              case "notequal":
                this.And(x => x.TenantId != val);
                break;
              case "less":
                this.And(x => x.TenantId < val);
                break;
              case "lessorequal":
                this.And(x => x.TenantId <= val);
                break;
              case "greater":
                this.And(x => x.TenantId > val);
                break;
              case "greaterorequal":
                this.And(x => x.TenantId >= val);
                break;
              default:
                this.And(x => x.TenantId == val);
                break;
            }
          }

        }
      }
      return this;
    }
  }
}
