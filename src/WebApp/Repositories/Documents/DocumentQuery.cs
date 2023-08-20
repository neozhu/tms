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
/// File: DocumentQuery.cs
/// Purpose: easyui datagrid filter query 
/// Created Date: 9/26/2019 8:14:58 AM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
   public class DocumentQuery:QueryObject<Document>
   {
		public DocumentQuery Withfilter(IEnumerable<filterRule> filters)
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
						if (rule.field == "OrderKey"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.OrderKey.Contains(rule.value));
						}
						if (rule.field == "FileName"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.FileName.Contains(rule.value));
						}
						if (rule.field == "FileType"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.FileType.Contains(rule.value));
						}
						if (rule.field == "Path"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Path.Contains(rule.value));
						}
						if (rule.field == "Url"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Url.Contains(rule.value));
						}
						if (rule.field == "MD5"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.MD5.Contains(rule.value));
						}
						if (rule.field == "Size" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Size == val);
                                break;
                            case "notequal":
                                And(x => x.Size != val);
                                break;
                            case "less":
                                And(x => x.Size < val);
                                break;
                            case "lessorequal":
                                And(x => x.Size <= val);
                                break;
                            case "greater":
                                And(x => x.Size > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Size >= val);
                                break;
                            default:
                                And(x => x.Size == val);
                                break;
                        }
						}
						if (rule.field == "Width" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Width == val);
                                break;
                            case "notequal":
                                And(x => x.Width != val);
                                break;
                            case "less":
                                And(x => x.Width < val);
                                break;
                            case "lessorequal":
                                And(x => x.Width <= val);
                                break;
                            case "greater":
                                And(x => x.Width > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Width >= val);
                                break;
                            default:
                                And(x => x.Width == val);
                                break;
                        }
						}
						if (rule.field == "Height" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
						{
							var val = Convert.ToDecimal(rule.value);
							switch (rule.op) {
                            case "equal":
                                And(x => x.Height == val);
                                break;
                            case "notequal":
                                And(x => x.Height != val);
                                break;
                            case "less":
                                And(x => x.Height < val);
                                break;
                            case "lessorequal":
                                And(x => x.Height <= val);
                                break;
                            case "greater":
                                And(x => x.Height > val);
                                break;
                            case "greaterorequal" :
                                And(x => x.Height >= val);
                                break;
                            default:
                                And(x => x.Height == val);
                                break;
                        }
						}
						if (rule.field == "Description"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.Description.Contains(rule.value));
						}
						if (rule.field == "User"  && !string.IsNullOrEmpty(rule.value))
						{
							And(x => x.User.Contains(rule.value));
						}
						if (rule.field == "UploadDateTime" && !string.IsNullOrEmpty(rule.value) )
						{	
							if (rule.op == "between")
                            {
                                var datearray = rule.value.Split(new char[] { '-' });
                                var start = Convert.ToDateTime(datearray[0]);
                                var end = Convert.ToDateTime(datearray[1]);
 
							    And(x => SqlFunctions.DateDiff("d", start, x.UploadDateTime) >= 0);
                                And(x => SqlFunctions.DateDiff("d", end, x.UploadDateTime) <= 0);
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
