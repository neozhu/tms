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
/// File: SHIPORDERDETAILQuery.cs
/// Purpose: easyui datagrid filter query 
/// Created Date: 8/12/2019 8:47:25 AM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
   public class SHIPORDERDETAILQuery:QueryObject<SHIPORDERDETAIL>
   {
		public SHIPORDERDETAILQuery Withfilter(IEnumerable<filterRule> filters)
        {
           if (filters != null)
           {
               foreach (var rule in filters)
               {
						if (rule.field == "ID" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							var val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ID == val);
                                break;
                            case "notequal":
                                And(x => x.ID != val);
                                break;
                            case "less":
                                And(x => x.ID < val);
                                break;
                            case "lessorequal":
                                And(x => x.ID <= val);
                                break;
                            case "greater":
                                And(x => x.ID > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ID >= val);
                                break;
                            default:
                                And(x => x.ID == val);
                                break;
                        }
						}
						if (rule.field == "SHIPORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SHIPORDERKEY.Contains(rule.value));
						}
						if (rule.field == "EXTERNSHIPORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.EXTERNSHIPORDERKEY.Contains(rule.value));
						}
						if (rule.field == "ORDERLINENUMBER"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORDERLINENUMBER.Contains(rule.value));
						}
						if (rule.field == "STATUS"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.STATUS.Contains(rule.value));
						}
						if (rule.field == "SUPPLIERCODE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SUPPLIERCODE.Contains(rule.value));
						}
						if (rule.field == "SUPPLIERNAME"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SUPPLIERNAME.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE3"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE3.Contains(rule.value));
						}
						if (rule.field == "CONSIGNEEADDRESS"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CONSIGNEEADDRESS.Contains(rule.value));
						}
						if (rule.field == "SKU"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SKU.Contains(rule.value));
						}
						if (rule.field == "SKUTYPE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SKUTYPE.Contains(rule.value));
						}
						if (rule.field == "SKUNAME"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SKUNAME.Contains(rule.value));
						}
						if (rule.field == "ORIGINALQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ORIGINALQTY == val);
                                break;
                            case "notequal":
                                And(x => x.ORIGINALQTY != val);
                                break;
                            case "less":
                                And(x => x.ORIGINALQTY < val);
                                break;
                            case "lessorequal":
                                And(x => x.ORIGINALQTY <= val);
                                break;
                            case "greater":
                                And(x => x.ORIGINALQTY > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ORIGINALQTY >= val);
                                break;
                            default:
                                And(x => x.ORIGINALQTY == val);
                                break;
                        }
						}
						if (rule.field == "SHIPPEDQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.SHIPPEDQTY == val);
                                break;
                            case "notequal":
                                And(x => x.SHIPPEDQTY != val);
                                break;
                            case "less":
                                And(x => x.SHIPPEDQTY < val);
                                break;
                            case "lessorequal":
                                And(x => x.SHIPPEDQTY <= val);
                                break;
                            case "greater":
                                And(x => x.SHIPPEDQTY > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.SHIPPEDQTY >= val);
                                break;
                            default:
                                And(x => x.SHIPPEDQTY == val);
                                break;
                        }
						}
						if (rule.field == "UMO"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.UMO.Contains(rule.value));
						}
						if (rule.field == "PACKKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PACKKEY.Contains(rule.value));
						}
						if (rule.field == "CASECNT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CASECNT == val);
                                break;
                            case "notequal":
                                And(x => x.CASECNT != val);
                                break;
                            case "less":
                                And(x => x.CASECNT < val);
                                break;
                            case "lessorequal":
                                And(x => x.CASECNT <= val);
                                break;
                            case "greater":
                                And(x => x.CASECNT > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CASECNT >= val);
                                break;
                            default:
                                And(x => x.CASECNT == val);
                                break;
                        }
						}
						if (rule.field == "GROSSWGT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.GROSSWGT == val);
                                break;
                            case "notequal":
                                And(x => x.GROSSWGT != val);
                                break;
                            case "less":
                                And(x => x.GROSSWGT < val);
                                break;
                            case "lessorequal":
                                And(x => x.GROSSWGT <= val);
                                break;
                            case "greater":
                                And(x => x.GROSSWGT > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.GROSSWGT >= val);
                                break;
                            default:
                                And(x => x.GROSSWGT == val);
                                break;
                        }
						}
						if (rule.field == "NETWGT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.NETWGT == val);
                                break;
                            case "notequal":
                                And(x => x.NETWGT != val);
                                break;
                            case "less":
                                And(x => x.NETWGT < val);
                                break;
                            case "lessorequal":
                                And(x => x.NETWGT <= val);
                                break;
                            case "greater":
                                And(x => x.NETWGT > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.NETWGT >= val);
                                break;
                            default:
                                And(x => x.NETWGT == val);
                                break;
                        }
						}
						if (rule.field == "CUBE" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CUBE == val);
                                break;
                            case "notequal":
                                And(x => x.CUBE != val);
                                break;
                            case "less":
                                And(x => x.CUBE < val);
                                break;
                            case "lessorequal":
                                And(x => x.CUBE <= val);
                                break;
                            case "greater":
                                And(x => x.CUBE > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CUBE >= val);
                                break;
                            default:
                                And(x => x.CUBE == val);
                                break;
                        }
						}
						if (rule.field == "NOTES"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.NOTES.Contains(rule.value));
						}
						if (rule.field == "SALER"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SALER.Contains(rule.value));
						}
						if (rule.field == "SALESORG"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SALESORG.Contains(rule.value));
						}
						if (rule.field == "CHECKEDCOST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST1 == boolval);
						}
						if (rule.field == "COST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST1 == val);
                                break;
                            case "notequal":
                                And(x => x.COST1 != val);
                                break;
                            case "less":
                                And(x => x.COST1 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST1 <= val);
                                break;
                            case "greater":
                                And(x => x.COST1 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST1 >= val);
                                break;
                            default:
                                And(x => x.COST1 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST2 == boolval);
						}
						if (rule.field == "COST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST2 == val);
                                break;
                            case "notequal":
                                And(x => x.COST2 != val);
                                break;
                            case "less":
                                And(x => x.COST2 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST2 <= val);
                                break;
                            case "greater":
                                And(x => x.COST2 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST2 >= val);
                                break;
                            default:
                                And(x => x.COST2 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST3 == boolval);
						}
						if (rule.field == "FLOOR" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							var val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.FLOOR == val);
                                break;
                            case "notequal":
                                And(x => x.FLOOR != val);
                                break;
                            case "less":
                                And(x => x.FLOOR < val);
                                break;
                            case "lessorequal":
                                And(x => x.FLOOR <= val);
                                break;
                            case "greater":
                                And(x => x.FLOOR > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.FLOOR >= val);
                                break;
                            default:
                                And(x => x.FLOOR == val);
                                break;
                        }
						}
						if (rule.field == "COST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST3 == val);
                                break;
                            case "notequal":
                                And(x => x.COST3 != val);
                                break;
                            case "less":
                                And(x => x.COST3 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST3 <= val);
                                break;
                            case "greater":
                                And(x => x.COST3 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST3 >= val);
                                break;
                            default:
                                And(x => x.COST3 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST4 == boolval);
						}
						if (rule.field == "COST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST4 == val);
                                break;
                            case "notequal":
                                And(x => x.COST4 != val);
                                break;
                            case "less":
                                And(x => x.COST4 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST4 <= val);
                                break;
                            case "greater":
                                And(x => x.COST4 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST4 >= val);
                                break;
                            default:
                                And(x => x.COST4 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST5 == boolval);
						}
						if (rule.field == "COST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST5 == val);
                                break;
                            case "notequal":
                                And(x => x.COST5 != val);
                                break;
                            case "less":
                                And(x => x.COST5 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST5 <= val);
                                break;
                            case "greater":
                                And(x => x.COST5 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST5 >= val);
                                break;
                            default:
                                And(x => x.COST5 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST6 == boolval);
						}
						if (rule.field == "COST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST6 == val);
                                break;
                            case "notequal":
                                And(x => x.COST6 != val);
                                break;
                            case "less":
                                And(x => x.COST6 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST6 <= val);
                                break;
                            case "greater":
                                And(x => x.COST6 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST6 >= val);
                                break;
                            default:
                                And(x => x.COST6 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST7 == boolval);
						}
						if (rule.field == "COST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST7 == val);
                                break;
                            case "notequal":
                                And(x => x.COST7 != val);
                                break;
                            case "less":
                                And(x => x.COST7 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST7 <= val);
                                break;
                            case "greater":
                                And(x => x.COST7 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST7 >= val);
                                break;
                            default:
                                And(x => x.COST7 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST8 == boolval);
						}
						if (rule.field == "COST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST8 == val);
                                break;
                            case "notequal":
                                And(x => x.COST8 != val);
                                break;
                            case "less":
                                And(x => x.COST8 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST8 <= val);
                                break;
                            case "greater":
                                And(x => x.COST8 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST8 >= val);
                                break;
                            default:
                                And(x => x.COST8 == val);
                                break;
                        }
						}
						if (rule.field == "ORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORDERKEY.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE2.Contains(rule.value));
						}
						if (rule.field == "EXTERNORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.EXTERNORDERKEY.Contains(rule.value));
						}
						if (rule.field == "FLAG1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.FLAG1 == boolval);
						}
						if (rule.field == "FLAG2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.FLAG2 == boolval);
						}
						if (rule.field == "NOTES1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.NOTES1.Contains(rule.value));
						}
						if (rule.field == "REQUESTEDSHIPDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.REQUESTEDSHIPDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.REQUESTEDSHIPDATE) <= 0);
						    }
						}
						if (rule.field == "DELIVERYDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DELIVERYDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DELIVERYDATE) <= 0);
						    }
						}
						if (rule.field == "ACTUALSHIPDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.ACTUALSHIPDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.ACTUALSHIPDATE) <= 0);
						    }
						}
						if (rule.field == "ACTUALDELIVERYDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.ACTUALDELIVERYDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.ACTUALDELIVERYDATE) <= 0);
						    }
						}
						if (rule.field == "WHSEID"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.WHSEID.Contains(rule.value));
						}
						if (rule.field == "STORERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.STORERKEY.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE1.Contains(rule.value));
						}
						if (rule.field == "EXTERNLINENO"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.EXTERNLINENO.Contains(rule.value));
						}
						if (rule.field == "TYPE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TYPE.Contains(rule.value));
						}
						if (rule.field == "ORIGINAL"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORIGINAL.Contains(rule.value));
						}
						if (rule.field == "DESTINATION"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DESTINATION.Contains(rule.value));
						}
						if (rule.field == "SHPTYPE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SHPTYPE.Contains(rule.value));
						}
						if (rule.field == "COMPANYCODE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.COMPANYCODE.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE4"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE4.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE5"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE5.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LOTTABLE6 == val);
                                break;
                            case "notequal":
                                And(x => x.LOTTABLE6 != val);
                                break;
                            case "less":
                                And(x => x.LOTTABLE6 < val);
                                break;
                            case "lessorequal":
                                And(x => x.LOTTABLE6 <= val);
                                break;
                            case "greater":
                                And(x => x.LOTTABLE6 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LOTTABLE6 >= val);
                                break;
                            default:
                                And(x => x.LOTTABLE6 == val);
                                break;
                        }
						}
						if (rule.field == "LOTTABLE7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LOTTABLE7 == val);
                                break;
                            case "notequal":
                                And(x => x.LOTTABLE7 != val);
                                break;
                            case "less":
                                And(x => x.LOTTABLE7 < val);
                                break;
                            case "lessorequal":
                                And(x => x.LOTTABLE7 <= val);
                                break;
                            case "greater":
                                And(x => x.LOTTABLE7 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LOTTABLE7 >= val);
                                break;
                            default:
                                And(x => x.LOTTABLE7 == val);
                                break;
                        }
						}
						if (rule.field == "LOTTABLE8" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LOTTABLE8) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LOTTABLE8) <= 0);
						    }
						}
						if (rule.field == "LOTTABLE9" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LOTTABLE9) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LOTTABLE9) <= 0);
						    }
						}
						if (rule.field == "LOTTABLE10"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE10.Contains(rule.value));
						}
						if (rule.field == "SHIPORDERID" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							var val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.SHIPORDERID == val);
                                break;
                            case "notequal":
                                And(x => x.SHIPORDERID != val);
                                break;
                            case "less":
                                And(x => x.SHIPORDERID < val);
                                break;
                            case "lessorequal":
                                And(x => x.SHIPORDERID <= val);
                                break;
                            case "greater":
                                And(x => x.SHIPORDERID > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.SHIPORDERID >= val);
                                break;
                            default:
                                And(x => x.SHIPORDERID == val);
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
         public  SHIPORDERDETAILQuery BySHIPORDERIDWithfilter(int shiporderid, IEnumerable<filterRule> filters)
         {
            And(x => x.SHIPORDERID == shiporderid);
            if (filters != null)
           {
               foreach (var rule in filters)
               {     
						if (rule.field == "ID" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ID == val);
                                break;
                            case "notequal":
                                And(x => x.ID != val);
                                break;
                            case "less":
                                And(x => x.ID < val);
                                break;
                            case "lessorequal":
                                And(x => x.ID <= val);
                                break;
                            case "greater":
                                And(x => x.ID > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ID >= val);
                                break;
                            default:
                                And(x => x.ID == val);
                                break;
                        }
						}
						if (rule.field == "SHIPORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SHIPORDERKEY.Contains(rule.value));
						}
						if (rule.field == "EXTERNSHIPORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.EXTERNSHIPORDERKEY.Contains(rule.value));
						}
						if (rule.field == "ORDERLINENUMBER"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORDERLINENUMBER.Contains(rule.value));
						}
						if (rule.field == "STATUS"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.STATUS.Contains(rule.value));
						}
						if (rule.field == "SUPPLIERCODE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SUPPLIERCODE.Contains(rule.value));
						}
						if (rule.field == "SUPPLIERNAME"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SUPPLIERNAME.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE3"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE3.Contains(rule.value));
						}
						if (rule.field == "CONSIGNEEADDRESS"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.CONSIGNEEADDRESS.Contains(rule.value));
						}
						if (rule.field == "SKU"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SKU.Contains(rule.value));
						}
						if (rule.field == "SKUTYPE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SKUTYPE.Contains(rule.value));
						}
						if (rule.field == "SKUNAME"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SKUNAME.Contains(rule.value));
						}
						if (rule.field == "ORIGINALQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.ORIGINALQTY == val);
                                break;
                            case "notequal":
                                And(x => x.ORIGINALQTY != val);
                                break;
                            case "less":
                                And(x => x.ORIGINALQTY < val);
                                break;
                            case "lessorequal":
                                And(x => x.ORIGINALQTY <= val);
                                break;
                            case "greater":
                                And(x => x.ORIGINALQTY > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.ORIGINALQTY >= val);
                                break;
                            default:
                                And(x => x.ORIGINALQTY == val);
                                break;
                        }
						}
						if (rule.field == "SHIPPEDQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.SHIPPEDQTY == val);
                                break;
                            case "notequal":
                                And(x => x.SHIPPEDQTY != val);
                                break;
                            case "less":
                                And(x => x.SHIPPEDQTY < val);
                                break;
                            case "lessorequal":
                                And(x => x.SHIPPEDQTY <= val);
                                break;
                            case "greater":
                                And(x => x.SHIPPEDQTY > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.SHIPPEDQTY >= val);
                                break;
                            default:
                                And(x => x.SHIPPEDQTY == val);
                                break;
                        }
						}
						if (rule.field == "UMO"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.UMO.Contains(rule.value));
						}
						if (rule.field == "PACKKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.PACKKEY.Contains(rule.value));
						}
						if (rule.field == "CASECNT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CASECNT == val);
                                break;
                            case "notequal":
                                And(x => x.CASECNT != val);
                                break;
                            case "less":
                                And(x => x.CASECNT < val);
                                break;
                            case "lessorequal":
                                And(x => x.CASECNT <= val);
                                break;
                            case "greater":
                                And(x => x.CASECNT > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CASECNT >= val);
                                break;
                            default:
                                And(x => x.CASECNT == val);
                                break;
                        }
						}
						if (rule.field == "GROSSWGT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.GROSSWGT == val);
                                break;
                            case "notequal":
                                And(x => x.GROSSWGT != val);
                                break;
                            case "less":
                                And(x => x.GROSSWGT < val);
                                break;
                            case "lessorequal":
                                And(x => x.GROSSWGT <= val);
                                break;
                            case "greater":
                                And(x => x.GROSSWGT > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.GROSSWGT >= val);
                                break;
                            default:
                                And(x => x.GROSSWGT == val);
                                break;
                        }
						}
						if (rule.field == "NETWGT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.NETWGT == val);
                                break;
                            case "notequal":
                                And(x => x.NETWGT != val);
                                break;
                            case "less":
                                And(x => x.NETWGT < val);
                                break;
                            case "lessorequal":
                                And(x => x.NETWGT <= val);
                                break;
                            case "greater":
                                And(x => x.NETWGT > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.NETWGT >= val);
                                break;
                            default:
                                And(x => x.NETWGT == val);
                                break;
                        }
						}
						if (rule.field == "CUBE" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.CUBE == val);
                                break;
                            case "notequal":
                                And(x => x.CUBE != val);
                                break;
                            case "less":
                                And(x => x.CUBE < val);
                                break;
                            case "lessorequal":
                                And(x => x.CUBE <= val);
                                break;
                            case "greater":
                                And(x => x.CUBE > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.CUBE >= val);
                                break;
                            default:
                                And(x => x.CUBE == val);
                                break;
                        }
						}
						if (rule.field == "NOTES"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.NOTES.Contains(rule.value));
						}
						if (rule.field == "SALER"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SALER.Contains(rule.value));
						}
						if (rule.field == "SALESORG"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SALESORG.Contains(rule.value));
						}
						if (rule.field == "CHECKEDCOST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST1 == boolval);
						}
						if (rule.field == "COST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST1 == val);
                                break;
                            case "notequal":
                                And(x => x.COST1 != val);
                                break;
                            case "less":
                                And(x => x.COST1 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST1 <= val);
                                break;
                            case "greater":
                                And(x => x.COST1 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST1 >= val);
                                break;
                            default:
                                And(x => x.COST1 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST2 == boolval);
						}
						if (rule.field == "COST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST2 == val);
                                break;
                            case "notequal":
                                And(x => x.COST2 != val);
                                break;
                            case "less":
                                And(x => x.COST2 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST2 <= val);
                                break;
                            case "greater":
                                And(x => x.COST2 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST2 >= val);
                                break;
                            default:
                                And(x => x.COST2 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST3 == boolval);
						}
						if (rule.field == "FLOOR" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.FLOOR == val);
                                break;
                            case "notequal":
                                And(x => x.FLOOR != val);
                                break;
                            case "less":
                                And(x => x.FLOOR < val);
                                break;
                            case "lessorequal":
                                And(x => x.FLOOR <= val);
                                break;
                            case "greater":
                                And(x => x.FLOOR > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.FLOOR >= val);
                                break;
                            default:
                                And(x => x.FLOOR == val);
                                break;
                        }
						}
						if (rule.field == "COST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST3 == val);
                                break;
                            case "notequal":
                                And(x => x.COST3 != val);
                                break;
                            case "less":
                                And(x => x.COST3 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST3 <= val);
                                break;
                            case "greater":
                                And(x => x.COST3 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST3 >= val);
                                break;
                            default:
                                And(x => x.COST3 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST4 == boolval);
						}
						if (rule.field == "COST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST4 == val);
                                break;
                            case "notequal":
                                And(x => x.COST4 != val);
                                break;
                            case "less":
                                And(x => x.COST4 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST4 <= val);
                                break;
                            case "greater":
                                And(x => x.COST4 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST4 >= val);
                                break;
                            default:
                                And(x => x.COST4 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST5 == boolval);
						}
						if (rule.field == "COST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST5 == val);
                                break;
                            case "notequal":
                                And(x => x.COST5 != val);
                                break;
                            case "less":
                                And(x => x.COST5 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST5 <= val);
                                break;
                            case "greater":
                                And(x => x.COST5 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST5 >= val);
                                break;
                            default:
                                And(x => x.COST5 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST6 == boolval);
						}
						if (rule.field == "COST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST6 == val);
                                break;
                            case "notequal":
                                And(x => x.COST6 != val);
                                break;
                            case "less":
                                And(x => x.COST6 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST6 <= val);
                                break;
                            case "greater":
                                And(x => x.COST6 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST6 >= val);
                                break;
                            default:
                                And(x => x.COST6 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST7 == boolval);
						}
						if (rule.field == "COST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST7 == val);
                                break;
                            case "notequal":
                                And(x => x.COST7 != val);
                                break;
                            case "less":
                                And(x => x.COST7 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST7 <= val);
                                break;
                            case "greater":
                                And(x => x.COST7 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST7 >= val);
                                break;
                            default:
                                And(x => x.COST7 == val);
                                break;
                        }
						}
						if (rule.field == "CHECKEDCOST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.CHECKEDCOST8 == boolval);
						}
						if (rule.field == "COST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.COST8 == val);
                                break;
                            case "notequal":
                                And(x => x.COST8 != val);
                                break;
                            case "less":
                                And(x => x.COST8 < val);
                                break;
                            case "lessorequal":
                                And(x => x.COST8 <= val);
                                break;
                            case "greater":
                                And(x => x.COST8 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.COST8 >= val);
                                break;
                            default:
                                And(x => x.COST8 == val);
                                break;
                        }
						}
						if (rule.field == "ORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORDERKEY.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE2"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE2.Contains(rule.value));
						}
						if (rule.field == "EXTERNORDERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.EXTERNORDERKEY.Contains(rule.value));
						}
						if (rule.field == "FLAG1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.FLAG1 == boolval);
						}
						if (rule.field == "FLAG2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
						{	
							 var boolval=Convert.ToBoolean(rule.value);
							 And(x => x.FLAG2 == boolval);
						}
						if (rule.field == "NOTES1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.NOTES1.Contains(rule.value));
						}
						if (rule.field == "REQUESTEDSHIPDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.REQUESTEDSHIPDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.REQUESTEDSHIPDATE) <= 0);
						    }
                        }
						if (rule.field == "DELIVERYDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.DELIVERYDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.DELIVERYDATE) <= 0);
						    }
                        }
						if (rule.field == "ACTUALSHIPDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.ACTUALSHIPDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.ACTUALSHIPDATE) <= 0);
						    }
                        }
						if (rule.field == "ACTUALDELIVERYDATE" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.ACTUALDELIVERYDATE) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.ACTUALDELIVERYDATE) <= 0);
						    }
                        }
						if (rule.field == "WHSEID"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.WHSEID.Contains(rule.value));
						}
						if (rule.field == "STORERKEY"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.STORERKEY.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE1"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE1.Contains(rule.value));
						}
						if (rule.field == "EXTERNLINENO"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.EXTERNLINENO.Contains(rule.value));
						}
						if (rule.field == "TYPE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.TYPE.Contains(rule.value));
						}
						if (rule.field == "ORIGINAL"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.ORIGINAL.Contains(rule.value));
						}
						if (rule.field == "DESTINATION"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.DESTINATION.Contains(rule.value));
						}
						if (rule.field == "SHPTYPE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.SHPTYPE.Contains(rule.value));
						}
						if (rule.field == "COMPANYCODE"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.COMPANYCODE.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE4"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE4.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE5"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE5.Contains(rule.value));
						}
						if (rule.field == "LOTTABLE6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LOTTABLE6 == val);
                                break;
                            case "notequal":
                                And(x => x.LOTTABLE6 != val);
                                break;
                            case "less":
                                And(x => x.LOTTABLE6 < val);
                                break;
                            case "lessorequal":
                                And(x => x.LOTTABLE6 <= val);
                                break;
                            case "greater":
                                And(x => x.LOTTABLE6 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LOTTABLE6 >= val);
                                break;
                            default:
                                And(x => x.LOTTABLE6 == val);
                                break;
                        }
						}
						if (rule.field == "LOTTABLE7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.LOTTABLE7 == val);
                                break;
                            case "notequal":
                                And(x => x.LOTTABLE7 != val);
                                break;
                            case "less":
                                And(x => x.LOTTABLE7 < val);
                                break;
                            case "lessorequal":
                                And(x => x.LOTTABLE7 <= val);
                                break;
                            case "greater":
                                And(x => x.LOTTABLE7 > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.LOTTABLE7 >= val);
                                break;
                            default:
                                And(x => x.LOTTABLE7 == val);
                                break;
                        }
						}
						if (rule.field == "LOTTABLE8" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LOTTABLE8) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LOTTABLE8) <= 0);
						    }
                        }
						if (rule.field == "LOTTABLE9" && !string.IsNullOrEmpty(rule.value) )
						{	
                            if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.LOTTABLE9) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.LOTTABLE9) <= 0);
						    }
                        }
						if (rule.field == "LOTTABLE10"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.LOTTABLE10.Contains(rule.value));
						}
						if (rule.field == "SHIPORDERID" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
						{
							int val = Convert.ToInt32(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.SHIPORDERID == val);
                                break;
                            case "notequal":
                                And(x => x.SHIPORDERID != val);
                                break;
                            case "less":
                                And(x => x.SHIPORDERID < val);
                                break;
                            case "lessorequal":
                                And(x => x.SHIPORDERID <= val);
                                break;
                            case "greater":
                                And(x => x.SHIPORDERID > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.SHIPORDERID >= val);
                                break;
                            default:
                                And(x => x.SHIPORDERID == val);
                                break;
                        }
						}
               }
            }
            return this;
         }    
    }
}
