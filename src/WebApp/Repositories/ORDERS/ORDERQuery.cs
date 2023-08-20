using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Web.WebPages;
using Repository.Pattern.Ef6;
using WebApp.Models;
using System.Linq;
using System.Data.Entity;
namespace WebApp.Repositories
{
  /// <summary>
  /// File: ORDERQuery.cs
  /// Purpose: easyui datagrid filter query 
  /// Created Date: 2019/8/8 7:24:59
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class ORDERQuery : QueryObject<ORDER>
  {
    public ORDERQuery Withfilter(IEnumerable<filterRule> filters)
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
          if (rule.field == "ORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ORDERKEY.Contains(rule.value));
          }
          if (rule.field == "EXTERNORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.EXTERNORDERKEY.Contains(rule.value));
          }
          if (rule.field == "WHSEID" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.WHSEID.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE2" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE2.Contains(rule.value));
          }
          if (rule.field == "ORIGINAL" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ORIGINAL.Contains(rule.value));
          }
          if (rule.field == "DESTINATION" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DESTINATION.Contains(rule.value));
          }
          if (rule.field == "TYPE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.TYPE.Contains(rule.value));
          }
          if (rule.field == "SHPTYPE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHPTYPE.Contains(rule.value));
          }
          if (rule.field == "STATUS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.STATUS.Contains(rule.value));
          }
          if (rule.field == "STORERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.STORERKEY.Contains(rule.value));
          }
          if (rule.field == "SUPPLIERCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SUPPLIERCODE.Contains(rule.value));
          }
          if (rule.field == "SUPPLIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SUPPLIERNAME.Contains(rule.value));
          }
          if (rule.field == "ORDERDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.ORDERDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.ORDERDATE) <= 0);
            }
          }
          if (rule.field == "REQUESTEDSHIPDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.REQUESTEDSHIPDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.REQUESTEDSHIPDATE) <= 0);
            }
          }
          if (rule.field == "DELIVERYDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.DELIVERYDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.DELIVERYDATE) <= 0);
            }
          }
          if (rule.field == "LOTTABLE3" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE3.Contains(rule.value));
          }
          if (rule.field == "CONSIGNEEKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CONSIGNEEKEY.Contains(rule.value));
          }
          if (rule.field == "CONSIGNEENAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CONSIGNEENAME.Contains(rule.value));
          }
          if (rule.field == "CONSIGNEEADDRESS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CONSIGNEEADDRESS.Contains(rule.value));
          }
          if (rule.field == "CARRIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERNAME.Contains(rule.value));
          }
          if (rule.field == "DRIVERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERNAME.Contains(rule.value));
          }
          if (rule.field == "CARRIERPHONE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERPHONE.Contains(rule.value));
          }
          if (rule.field == "TRAILERNUMBER" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.TRAILERNUMBER.Contains(rule.value));
          }
          if (rule.field == "ACTUALSHIPDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.ACTUALSHIPDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.ACTUALSHIPDATE) <= 0);
            }
          }
          if (rule.field == "ACTUALDELIVERYDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.ACTUALDELIVERYDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.ACTUALDELIVERYDATE) <= 0);
            }
          }
          if (rule.field == "CLOSEDDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.CLOSEDDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.CLOSEDDATE) <= 0);
            }
          }
          if (rule.field == "TOTALQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALQTY == val);
                break;
              case "notequal":
                this.And(x => x.TOTALQTY != val);
                break;
              case "less":
                this.And(x => x.TOTALQTY < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALQTY <= val);
                break;
              case "greater":
                this.And(x => x.TOTALQTY > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALQTY >= val);
                break;
              default:
                this.And(x => x.TOTALQTY == val);
                break;
            }
          }
          if (rule.field == "TOTALSHIPPEDQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALSHIPPEDQTY == val);
                break;
              case "notequal":
                this.And(x => x.TOTALSHIPPEDQTY != val);
                break;
              case "less":
                this.And(x => x.TOTALSHIPPEDQTY < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALSHIPPEDQTY <= val);
                break;
              case "greater":
                this.And(x => x.TOTALSHIPPEDQTY > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALSHIPPEDQTY >= val);
                break;
              default:
                this.And(x => x.TOTALSHIPPEDQTY == val);
                break;
            }
          }
          if (rule.field == "TOTALCASECNT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCASECNT == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCASECNT != val);
                break;
              case "less":
                this.And(x => x.TOTALCASECNT < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCASECNT <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCASECNT > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCASECNT >= val);
                break;
              default:
                this.And(x => x.TOTALCASECNT == val);
                break;
            }
          }
          if (rule.field == "TOTALGROSSWGT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALGROSSWGT == val);
                break;
              case "notequal":
                this.And(x => x.TOTALGROSSWGT != val);
                break;
              case "less":
                this.And(x => x.TOTALGROSSWGT < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALGROSSWGT <= val);
                break;
              case "greater":
                this.And(x => x.TOTALGROSSWGT > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALGROSSWGT >= val);
                break;
              default:
                this.And(x => x.TOTALGROSSWGT == val);
                break;
            }
          }
          if (rule.field == "TOTALCUBE" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCUBE == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCUBE != val);
                break;
              case "less":
                this.And(x => x.TOTALCUBE < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCUBE <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCUBE > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCUBE >= val);
                break;
              default:
                this.And(x => x.TOTALCUBE == val);
                break;
            }
          }
          if (rule.field == "TOTALCOST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST1 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST1 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST1 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST1 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST1 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST1 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST2 == boolval);
          }
          if (rule.field == "TOTALCOST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST2 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST2 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST2 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST2 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST2 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST2 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST3 == boolval);
          }
          if (rule.field == "FLOOR" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.FLOOR == val);
                break;
              case "notequal":
                this.And(x => x.FLOOR != val);
                break;
              case "less":
                this.And(x => x.FLOOR < val);
                break;
              case "lessorequal":
                this.And(x => x.FLOOR <= val);
                break;
              case "greater":
                this.And(x => x.FLOOR > val);
                break;
              case "greaterorequal":
                this.And(x => x.FLOOR >= val);
                break;
              default:
                this.And(x => x.FLOOR == val);
                break;
            }
          }
          if (rule.field == "TOTALCOST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST3 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST3 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST3 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST3 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST3 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST3 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST3 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST4 == boolval);
          }
          if (rule.field == "TOTALCOST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST4 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST4 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST4 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST4 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST4 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST4 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST4 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST5 == boolval);
          }
          if (rule.field == "TOTALCOST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST5 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST5 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST5 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST5 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST5 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST5 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST5 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST6 == boolval);
          }
          if (rule.field == "TOTALCOST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST6 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST6 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST6 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST6 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST6 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST6 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST6 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST7 == boolval);
          }
          if (rule.field == "TOTALCOST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST7 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST7 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST7 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST7 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST7 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST7 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST7 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST8 == boolval);
          }
          if (rule.field == "TOTALCOST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST8 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST8 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST8 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST8 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST8 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST8 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST8 == val);
                break;
            }
          }
          if (rule.field == "NOTES" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES.Contains(rule.value));
          }
          if (rule.field == "FLAG1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.FLAG1 == boolval);
          }
          if (rule.field == "NOTES1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES1.Contains(rule.value));
          }
          if (rule.field == "FLAG2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.FLAG2 == boolval);
          }
          if (rule.field == "COMPANYCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.COMPANYCODE == rule.value);
          }
          if (rule.field == "LOTTABLE1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE1.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE4" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE4.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE5" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE5.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOTTABLE6 == val);
                break;
              case "notequal":
                this.And(x => x.LOTTABLE6 != val);
                break;
              case "less":
                this.And(x => x.LOTTABLE6 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOTTABLE6 <= val);
                break;
              case "greater":
                this.And(x => x.LOTTABLE6 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOTTABLE6 >= val);
                break;
              default:
                this.And(x => x.LOTTABLE6 == val);
                break;
            }
          }
          if (rule.field == "LOTTABLE7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOTTABLE7 == val);
                break;
              case "notequal":
                this.And(x => x.LOTTABLE7 != val);
                break;
              case "less":
                this.And(x => x.LOTTABLE7 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOTTABLE7 <= val);
                break;
              case "greater":
                this.And(x => x.LOTTABLE7 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOTTABLE7 >= val);
                break;
              default:
                this.And(x => x.LOTTABLE7 == val);
                break;
            }
          }
          if (rule.field == "LOTTABLE8" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.LOTTABLE8) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.LOTTABLE8) <= 0);
            }
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

    public ORDERQuery Withfilter170(IEnumerable<filterRule> filters)
    {
      var status = new string[] { "170", "180", "190" };
      And(x => status.Contains(x.STATUS));
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
          if (rule.field == "ORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ORDERKEY.Contains(rule.value));
          }
          if (rule.field == "EXTERNORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.EXTERNORDERKEY.Contains(rule.value));
          }
          if (rule.field == "WHSEID" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.WHSEID.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE2" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE2.Contains(rule.value));
          }
          if (rule.field == "ORIGINAL" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ORIGINAL.Contains(rule.value));
          }
          if (rule.field == "DESTINATION" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DESTINATION.Contains(rule.value));
          }
          if (rule.field == "TYPE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.TYPE.Contains(rule.value));
          }
          if (rule.field == "SHPTYPE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHPTYPE.Contains(rule.value));
          }
          if (rule.field == "STATUS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.STATUS.Contains(rule.value));
          }
          if (rule.field == "STORERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.STORERKEY.Contains(rule.value));
          }
          if (rule.field == "SUPPLIERCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SUPPLIERCODE.Contains(rule.value));
          }
          if (rule.field == "SUPPLIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SUPPLIERNAME.Contains(rule.value));
          }
          if (rule.field == "ORDERDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.ORDERDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.ORDERDATE) <= 0);
            }
          }
          if (rule.field == "REQUESTEDSHIPDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.REQUESTEDSHIPDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.REQUESTEDSHIPDATE) <= 0);
            }
          }
          if (rule.field == "DELIVERYDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.DELIVERYDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.DELIVERYDATE) <= 0);
            }
          }
          if (rule.field == "LOTTABLE3" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE3.Contains(rule.value));
          }
          if (rule.field == "CONSIGNEEKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CONSIGNEEKEY.Contains(rule.value));
          }
          if (rule.field == "CONSIGNEENAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CONSIGNEENAME.Contains(rule.value));
          }
          if (rule.field == "CONSIGNEEADDRESS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CONSIGNEEADDRESS.Contains(rule.value));
          }
          if (rule.field == "CARRIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERNAME.Contains(rule.value));
          }
          if (rule.field == "DRIVERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERNAME.Contains(rule.value));
          }
          if (rule.field == "CARRIERPHONE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERPHONE.Contains(rule.value));
          }
          if (rule.field == "TRAILERNUMBER" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.TRAILERNUMBER.Contains(rule.value));
          }
          if (rule.field == "ACTUALSHIPDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.ACTUALSHIPDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.ACTUALSHIPDATE) <= 0);
            }
          }
          if (rule.field == "ACTUALDELIVERYDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.ACTUALDELIVERYDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.ACTUALDELIVERYDATE) <= 0);
            }
          }
          if (rule.field == "CLOSEDDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.CLOSEDDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.CLOSEDDATE) <= 0);
            }
          }
          if (rule.field == "TOTALQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALQTY == val);
                break;
              case "notequal":
                this.And(x => x.TOTALQTY != val);
                break;
              case "less":
                this.And(x => x.TOTALQTY < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALQTY <= val);
                break;
              case "greater":
                this.And(x => x.TOTALQTY > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALQTY >= val);
                break;
              default:
                this.And(x => x.TOTALQTY == val);
                break;
            }
          }
          if (rule.field == "TOTALSHIPPEDQTY" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALSHIPPEDQTY == val);
                break;
              case "notequal":
                this.And(x => x.TOTALSHIPPEDQTY != val);
                break;
              case "less":
                this.And(x => x.TOTALSHIPPEDQTY < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALSHIPPEDQTY <= val);
                break;
              case "greater":
                this.And(x => x.TOTALSHIPPEDQTY > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALSHIPPEDQTY >= val);
                break;
              default:
                this.And(x => x.TOTALSHIPPEDQTY == val);
                break;
            }
          }
          if (rule.field == "TOTALCASECNT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCASECNT == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCASECNT != val);
                break;
              case "less":
                this.And(x => x.TOTALCASECNT < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCASECNT <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCASECNT > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCASECNT >= val);
                break;
              default:
                this.And(x => x.TOTALCASECNT == val);
                break;
            }
          }
          if (rule.field == "TOTALGROSSWGT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALGROSSWGT == val);
                break;
              case "notequal":
                this.And(x => x.TOTALGROSSWGT != val);
                break;
              case "less":
                this.And(x => x.TOTALGROSSWGT < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALGROSSWGT <= val);
                break;
              case "greater":
                this.And(x => x.TOTALGROSSWGT > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALGROSSWGT >= val);
                break;
              default:
                this.And(x => x.TOTALGROSSWGT == val);
                break;
            }
          }
          if (rule.field == "TOTALCUBE" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCUBE == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCUBE != val);
                break;
              case "less":
                this.And(x => x.TOTALCUBE < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCUBE <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCUBE > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCUBE >= val);
                break;
              default:
                this.And(x => x.TOTALCUBE == val);
                break;
            }
          }
          if (rule.field == "TOTALCOST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST1 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST1 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST1 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST1 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST1 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST1 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST2 == boolval);
          }
          if (rule.field == "TOTALCOST2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST2 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST2 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST2 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST2 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST2 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST2 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST3 == boolval);
          }
          if (rule.field == "FLOOR" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.FLOOR == val);
                break;
              case "notequal":
                this.And(x => x.FLOOR != val);
                break;
              case "less":
                this.And(x => x.FLOOR < val);
                break;
              case "lessorequal":
                this.And(x => x.FLOOR <= val);
                break;
              case "greater":
                this.And(x => x.FLOOR > val);
                break;
              case "greaterorequal":
                this.And(x => x.FLOOR >= val);
                break;
              default:
                this.And(x => x.FLOOR == val);
                break;
            }
          }
          if (rule.field == "TOTALCOST3" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST3 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST3 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST3 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST3 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST3 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST3 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST3 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST4 == boolval);
          }
          if (rule.field == "TOTALCOST4" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST4 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST4 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST4 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST4 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST4 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST4 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST4 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST5 == boolval);
          }
          if (rule.field == "TOTALCOST5" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST5 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST5 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST5 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST5 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST5 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST5 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST5 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST6 == boolval);
          }
          if (rule.field == "TOTALCOST6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST6 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST6 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST6 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST6 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST6 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST6 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST6 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST7 == boolval);
          }
          if (rule.field == "TOTALCOST7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST7 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST7 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST7 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST7 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST7 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST7 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST7 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST8 == boolval);
          }
          if (rule.field == "TOTALCOST8" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.TOTALCOST8 == val);
                break;
              case "notequal":
                this.And(x => x.TOTALCOST8 != val);
                break;
              case "less":
                this.And(x => x.TOTALCOST8 < val);
                break;
              case "lessorequal":
                this.And(x => x.TOTALCOST8 <= val);
                break;
              case "greater":
                this.And(x => x.TOTALCOST8 > val);
                break;
              case "greaterorequal":
                this.And(x => x.TOTALCOST8 >= val);
                break;
              default:
                this.And(x => x.TOTALCOST8 == val);
                break;
            }
          }
          if (rule.field == "NOTES" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES.Contains(rule.value));
          }
          if (rule.field == "FLAG1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.FLAG1 == boolval);
          }
          if (rule.field == "NOTES1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES1.Contains(rule.value));
          }
          if (rule.field == "FLAG2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.FLAG2 == boolval);
          }
          if (rule.field == "COMPANYCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.COMPANYCODE == rule.value);
          }
          if (rule.field == "LOTTABLE1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE1.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE4" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE4.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE5" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE5.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE6" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOTTABLE6 == val);
                break;
              case "notequal":
                this.And(x => x.LOTTABLE6 != val);
                break;
              case "less":
                this.And(x => x.LOTTABLE6 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOTTABLE6 <= val);
                break;
              case "greater":
                this.And(x => x.LOTTABLE6 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOTTABLE6 >= val);
                break;
              default:
                this.And(x => x.LOTTABLE6 == val);
                break;
            }
          }
          if (rule.field == "LOTTABLE7" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOTTABLE7 == val);
                break;
              case "notequal":
                this.And(x => x.LOTTABLE7 != val);
                break;
              case "less":
                this.And(x => x.LOTTABLE7 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOTTABLE7 <= val);
                break;
              case "greater":
                this.And(x => x.LOTTABLE7 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOTTABLE7 >= val);
                break;
              default:
                this.And(x => x.LOTTABLE7 == val);
                break;
            }
          }
          if (rule.field == "LOTTABLE8" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.LOTTABLE8) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.LOTTABLE8) <= 0);
            }
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
  }
}
