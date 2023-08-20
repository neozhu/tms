using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using Repository.Pattern.Repositories;
using Repository.Pattern.Ef6;
using System.Web.WebPages;
using WebApp.Models;

namespace WebApp.Repositories
{
/// <summary>
/// File: StatusHistoryQuery.cs
/// Purpose: easyui datagrid filter query 
/// Created Date: 8/13/2019 3:05:03 PM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
   public class StatusHistoryQuery:QueryObject<StatusHistory>
   {
		public StatusHistoryQuery Withfilter(IEnumerable<filterRule> filters)
        {
           if (filters != null)
           {
               foreach (var rule in filters)
               {
						if (rule.field == "Id" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							var val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Id == val);
                                break;
                            case "notequal":
                                And(x => x.Id != val);
                                break;
                            case "less":
                                And(x => x.Id < val);
                                break;
                            case "lessorequal":
                                And(x => x.Id <= val);
                                break;
                            case "greater":
                                And(x => x.Id > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Id >= val);
                                break;
                            default:
                                And(x => x.Id == val);
                                break;
                        }
						}
						if (rule.field == "ORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORDERKEY.Contains(rule.value));
						}
						if (rule.field == "SHIPORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SHIPORDERKEY.Contains(rule.value));
						}
						if (rule.field == "STATUS"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.STATUS.Contains(rule.value));
						}
						if (rule.field == "DESCRIPTION"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DESCRIPTION.Contains(rule.value));
						}
						if (rule.field == "REMARK"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.REMARK.Contains(rule.value));
						}
						if (rule.field == "TRANSACTIONDATETIME" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.TRANSACTIONDATETIME) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.TRANSACTIONDATETIME) <= 0);
						    }
						}
						if (rule.field == "USER"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.USER.Contains(rule.value));
						}
						if (rule.field == "LONGITUDE" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LONGITUDE == val);
                                break;
                            case "notequal":
                                And(x => x.LONGITUDE != val);
                                break;
                            case "less":
                                And(x => x.LONGITUDE < val);
                                break;
                            case "lessorequal":
                                And(x => x.LONGITUDE <= val);
                                break;
                            case "greater":
                                And(x => x.LONGITUDE > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LONGITUDE >= val);
                                break;
                            default:
                                And(x => x.LONGITUDE == val);
                                break;
                        }
						}
						if (rule.field == "LATITUDE" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LATITUDE == val);
                                break;
                            case "notequal":
                                And(x => x.LATITUDE != val);
                                break;
                            case "less":
                                And(x => x.LATITUDE < val);
                                break;
                            case "lessorequal":
                                And(x => x.LATITUDE <= val);
                                break;
                            case "greater":
                                And(x => x.LATITUDE > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LATITUDE >= val);
                                break;
                            default:
                                And(x => x.LATITUDE == val);
                                break;
                        }
						}
						if (rule.field == "CreatedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.CreatedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.CreatedDate) <= 0);
						    }
						}
						if (rule.field == "CreatedBy"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CreatedBy.Contains(rule.value));
						}
						if (rule.field == "LastModifiedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LastModifiedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LastModifiedDate) <= 0);
						    }
						}
						if (rule.field == "LastModifiedBy"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LastModifiedBy.Contains(rule.value));
						}
     
               }
           }
            return this;
        }
    }
}
