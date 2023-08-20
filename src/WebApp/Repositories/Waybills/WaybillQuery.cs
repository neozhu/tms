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
/// File: WaybillQuery.cs
/// Purpose: easyui datagrid filter query 
/// Created Date: 2020/6/24 16:53:50
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
   public class WaybillQuery:QueryObject<Waybill>
   {
		public WaybillQuery Withfilter(IEnumerable<filterRule> filters)
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
						if (rule.field == "OrderNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderNo.Contains(rule.value));
						}
						if (rule.field == "Status"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Status.Contains(rule.value));
						}
						if (rule.field == "CustomerId"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CustomerId.Contains(rule.value));
						}
						if (rule.field == "CustomerName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CustomerName.Contains(rule.value));
						}
						if (rule.field == "ProjectNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ProjectNo.Contains(rule.value));
						}
						if (rule.field == "PickNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PickNo.Contains(rule.value));
						}
						if (rule.field == "ShippedDate" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.ShippedDate) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.ShippedDate) <= 0);
						    }
						}
						if (rule.field == "Original"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Original.Contains(rule.value));
						}
						if (rule.field == "Destination"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Destination.Contains(rule.value));
						}
						if (rule.field == "Remark"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark.Contains(rule.value));
						}
						if (rule.field == "ProductNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ProductNo.Contains(rule.value));
						}
						if (rule.field == "LotNo"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LotNo.Contains(rule.value));
						}
						if (rule.field == "Qty" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Qty == val);
                                break;
                            case "notequal":
                                And(x => x.Qty != val);
                                break;
                            case "less":
                                And(x => x.Qty < val);
                                break;
                            case "lessorequal":
                                And(x => x.Qty <= val);
                                break;
                            case "greater":
                                And(x => x.Qty > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Qty >= val);
                                break;
                            default:
                                And(x => x.Qty == val);
                                break;
                        }
						}
						if (rule.field == "Weight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Weight == val);
                                break;
                            case "notequal":
                                And(x => x.Weight != val);
                                break;
                            case "less":
                                And(x => x.Weight < val);
                                break;
                            case "lessorequal":
                                And(x => x.Weight <= val);
                                break;
                            case "greater":
                                And(x => x.Weight > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Weight >= val);
                                break;
                            default:
                                And(x => x.Weight == val);
                                break;
                        }
						}
						if (rule.field == "Cube" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Cube == val);
                                break;
                            case "notequal":
                                And(x => x.Cube != val);
                                break;
                            case "less":
                                And(x => x.Cube < val);
                                break;
                            case "lessorequal":
                                And(x => x.Cube <= val);
                                break;
                            case "greater":
                                And(x => x.Cube > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Cube >= val);
                                break;
                            default:
                                And(x => x.Cube == val);
                                break;
                        }
						}
						if (rule.field == "SPrice" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.SPrice == val);
                                break;
                            case "notequal":
                                And(x => x.SPrice != val);
                                break;
                            case "less":
                                And(x => x.SPrice < val);
                                break;
                            case "lessorequal":
                                And(x => x.SPrice <= val);
                                break;
                            case "greater":
                                And(x => x.SPrice > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.SPrice >= val);
                                break;
                            default:
                                And(x => x.SPrice == val);
                                break;
                        }
						}
						if (rule.field == "SAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.SAmount == val);
                                break;
                            case "notequal":
                                And(x => x.SAmount != val);
                                break;
                            case "less":
                                And(x => x.SAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.SAmount <= val);
                                break;
                            case "greater":
                                And(x => x.SAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.SAmount >= val);
                                break;
                            default:
                                And(x => x.SAmount == val);
                                break;
                        }
						}
						if (rule.field == "CPrice" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CPrice == val);
                                break;
                            case "notequal":
                                And(x => x.CPrice != val);
                                break;
                            case "less":
                                And(x => x.CPrice < val);
                                break;
                            case "lessorequal":
                                And(x => x.CPrice <= val);
                                break;
                            case "greater":
                                And(x => x.CPrice > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CPrice >= val);
                                break;
                            default:
                                And(x => x.CPrice == val);
                                break;
                        }
						}
						if (rule.field == "CAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CAmount == val);
                                break;
                            case "notequal":
                                And(x => x.CAmount != val);
                                break;
                            case "less":
                                And(x => x.CAmount < val);
                                break;
                            case "lessorequal":
                                And(x => x.CAmount <= val);
                                break;
                            case "greater":
                                And(x => x.CAmount > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CAmount >= val);
                                break;
                            default:
                                And(x => x.CAmount == val);
                                break;
                        }
						}
						if (rule.field == "Way"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Way.Contains(rule.value));
						}
						if (rule.field == "Sales"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Sales.Contains(rule.value));
						}
						if (rule.field == "SalesGroup"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SalesGroup.Contains(rule.value));
						}
						if (rule.field == "Remark1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark1.Contains(rule.value));
						}
						if (rule.field == "Remark2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Remark2.Contains(rule.value));
						}
						if (rule.field == "Flag" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.Flag == boolval);
						}
						if (rule.field == "Driver"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Driver.Contains(rule.value));
						}
						if (rule.field == "Transport"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Transport.Contains(rule.value));
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
