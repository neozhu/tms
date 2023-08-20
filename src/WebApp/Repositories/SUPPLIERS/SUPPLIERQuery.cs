using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Web.WebPages;
using Repository.Pattern.Ef6;
using WebApp.Models;

namespace WebApp.Repositories
{
  /// <summary>
  /// File: SUPPLIERQuery.cs
  /// Purpose: easyui datagrid filter query 
  /// Created Date: 2019/8/1 7:41:13
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class SUPPLIERQuery : QueryObject<SUPPLIER>
  {
    public SUPPLIERQuery Withfilter(IEnumerable<filterRule> filters)
    {
      if (filters != null)
      {
        foreach (var rule in filters)
        {
          if (rule.field == "ID" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ID == val);
                break;
              case "notequal":
                this.And(x => x.ID != val);
                break;
              case "less":
                this.And(x => x.ID < val);
                break;
              case "lessorequal":
                this.And(x => x.ID <= val);
                break;
              case "greater":
                this.And(x => x.ID > val);
                break;
              case "greaterorequal":
                this.And(x => x.ID >= val);
                break;
              default:
                this.And(x => x.ID == val);
                break;
            }
          }
          if (rule.field == "SUPPLIERCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SUPPLIERCODE.Contains(rule.value));
          }
          if (rule.field == "SUPPLIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SUPPLIERNAME.Contains(rule.value));
          }
          if (rule.field == "ISDISABLED" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.ISDISABLED == boolval);
          }
          if (rule.field == "ADDRESS1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ADDRESS1.Contains(rule.value));
          }
          if (rule.field == "ADDRESS2" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ADDRESS2.Contains(rule.value));
          }
          if (rule.field == "CONTACT" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CONTACT.Contains(rule.value));
          }
          if (rule.field == "PHONENUMBER" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.PHONENUMBER.Contains(rule.value));
          }
          if (rule.field == "EMAIL" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.EMAIL.Contains(rule.value));
          }
          if (rule.field == "NOTES" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES.Contains(rule.value));
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

        }
      }
      return this;
    }

    public SUPPLIERQuery WithfilterQ(string q)
    {
      if (string.IsNullOrEmpty(q))
      {


        Or(x => x.SUPPLIERCODE.Contains(q));

        Or(x => x.SUPPLIERNAME.Contains(q));




      }
      return this;
    }
  }
}
