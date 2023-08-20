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
/// File: StandardCostQuery.cs
/// Purpose: easyui datagrid filter query 
/// Created Date: 9/12/2019 1:48:26 PM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
   public class StandardCostQuery:QueryObject<StandardCost>
   {
		public StandardCostQuery Withfilter(IEnumerable<filterRule> filters)
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
						if (rule.field == "ORIGINAL"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORIGINAL.Contains(rule.value));
						}
						if (rule.field == "DESTINATION"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DESTINATION.Contains(rule.value));
						}
						if (rule.field == "STDKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.STDKM == val);
                                break;
                            case "notequal":
                                And(x => x.STDKM != val);
                                break;
                            case "less":
                                And(x => x.STDKM < val);
                                break;
                            case "lessorequal":
                                And(x => x.STDKM <= val);
                                break;
                            case "greater":
                                And(x => x.STDKM > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.STDKM >= val);
                                break;
                            default:
                                And(x => x.STDKM == val);
                                break;
                        }
						}
						if (rule.field == "CarType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CarType.Contains(rule.value));
						}
						if (rule.field == "STDLOADWEIGHT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.STDLOADWEIGHT == val);
                                break;
                            case "notequal":
                                And(x => x.STDLOADWEIGHT != val);
                                break;
                            case "less":
                                And(x => x.STDLOADWEIGHT < val);
                                break;
                            case "lessorequal":
                                And(x => x.STDLOADWEIGHT <= val);
                                break;
                            case "greater":
                                And(x => x.STDLOADWEIGHT > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.STDLOADWEIGHT >= val);
                                break;
                            default:
                                And(x => x.STDLOADWEIGHT == val);
                                break;
                        }
						}
						if (rule.field == "STDOIL" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.STDOIL == val);
                                break;
                            case "notequal":
                                And(x => x.STDOIL != val);
                                break;
                            case "less":
                                And(x => x.STDOIL < val);
                                break;
                            case "lessorequal":
                                And(x => x.STDOIL <= val);
                                break;
                            case "greater":
                                And(x => x.STDOIL > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.STDOIL >= val);
                                break;
                            default:
                                And(x => x.STDOIL == val);
                                break;
                        }
						}
						if (rule.field == "STDCOST" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.STDCOST == val);
                                break;
                            case "notequal":
                                And(x => x.STDCOST != val);
                                break;
                            case "less":
                                And(x => x.STDCOST < val);
                                break;
                            case "lessorequal":
                                And(x => x.STDCOST <= val);
                                break;
                            case "greater":
                                And(x => x.STDCOST > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.STDCOST >= val);
                                break;
                            default:
                                And(x => x.STDCOST == val);
                                break;
                        }
						}
						if (rule.field == "DESCRIPTION"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DESCRIPTION.Contains(rule.value));
						}
						if (rule.field == "Notes"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Notes.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE1.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE2.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LOTTABLE3 == val);
                                break;
                            case "notequal":
                                And(x => x.LOTTABLE3 != val);
                                break;
                            case "less":
                                And(x => x.LOTTABLE3 < val);
                                break;
                            case "lessorequal":
                                And(x => x.LOTTABLE3 <= val);
                                break;
                            case "greater":
                                And(x => x.LOTTABLE3 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LOTTABLE3 >= val);
                                break;
                            default:
                                And(x => x.LOTTABLE3 == val);
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
						if (rule.field == "TenantId" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							var val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.TenantId == val);
                                break;
                            case "notequal":
                                And(x => x.TenantId != val);
                                break;
                            case "less":
                                And(x => x.TenantId < val);
                                break;
                            case "lessorequal":
                                And(x => x.TenantId <= val);
                                break;
                            case "greater":
                                And(x => x.TenantId > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.TenantId >= val);
                                break;
                            default:
                                And(x => x.TenantId == val);
                                break;
                        }
						}
     
               }
           }
            return this;
        }
    }
}
