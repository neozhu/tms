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
/// File: LocBaseQuery.cs
/// Purpose: easyui datagrid filter query 
/// Created Date: 2019/8/5 8:57:49
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
   public class LocBaseQuery:QueryObject<LocBase>
   {
		public LocBaseQuery Withfilter(IEnumerable<filterRule> filters)
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
						if (rule.field == "Name"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Name.Contains(rule.value));
						}
						if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
						if (rule.field == "Longitude" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Longitude == val);
                                break;
                            case "notequal":
                                And(x => x.Longitude != val);
                                break;
                            case "less":
                                And(x => x.Longitude < val);
                                break;
                            case "lessorequal":
                                And(x => x.Longitude <= val);
                                break;
                            case "greater":
                                And(x => x.Longitude > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Longitude >= val);
                                break;
                            default:
                                And(x => x.Longitude == val);
                                break;
                        }
						}
						if (rule.field == "Latitude" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Latitude == val);
                                break;
                            case "notequal":
                                And(x => x.Latitude != val);
                                break;
                            case "less":
                                And(x => x.Latitude < val);
                                break;
                            case "lessorequal":
                                And(x => x.Latitude <= val);
                                break;
                            case "greater":
                                And(x => x.Latitude > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Latitude >= val);
                                break;
                            default:
                                And(x => x.Latitude == val);
                                break;
                        }
						}
						if (rule.field == "Radius" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Radius == val);
                                break;
                            case "notequal":
                                And(x => x.Radius != val);
                                break;
                            case "less":
                                And(x => x.Radius < val);
                                break;
                            case "lessorequal":
                                And(x => x.Radius <= val);
                                break;
                            case "greater":
                                And(x => x.Radius > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Radius >= val);
                                break;
                            default:
                                And(x => x.Radius == val);
                                break;
                        }
						}
						if (rule.field == "Gid"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Gid.Contains(rule.value));
						}
						if (rule.field == "Enable" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.Enable == boolval);
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
