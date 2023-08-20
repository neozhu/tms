using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.WebPages;
using Repository.Pattern.Ef6;
using WebApp.Models;
namespace WebApp.Repositories
{
  /// <summary>
  /// File: SHIPORDERQuery.cs
  /// Purpose: easyui datagrid filter query 
  /// Created Date: 8/12/2019 9:08:14 AM
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class SHIPORDERQuery : QueryObject<SHIPORDER>
  {
    public SHIPORDERQuery WithBillDatafilter(IEnumerable<filterRule> filters)
    {
      var status = new string[] { "170","180","190" };
      this.And(x => status.Contains(x.STATUS));
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
          if (rule.field == "SHIPORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPORDERKEY.Contains(rule.value));
          }
          if (rule.field == "EXTERNSHIPORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.EXTERNSHIPORDERKEY.Contains(rule.value));
          }
          if (rule.field == "SHIPORDERDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.SHIPORDERDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.SHIPORDERDATE) <= 0);
            }
          }
          if (rule.field == "STATUS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.STATUS.Contains(rule.value));
          }
          if (rule.field == "TYPE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.TYPE.Contains(rule.value));
          }
          if (rule.field == "ORIGINAL" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ORIGINAL.Contains(rule.value));
          }
          if (rule.field == "DESTINATION" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DESTINATION.Contains(rule.value));
          }
          if (rule.field == "PLATENUMBER" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.PLATENUMBER.Contains(rule.value));
          }
          if (rule.field == "DRIVERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERNAME.Contains(rule.value));
          }
          if (rule.field == "DRIVERPHONE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERPHONE.Contains(rule.value));
          }
          if (rule.field == "CARRIERCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERCODE.Contains(rule.value));
          }
          if (rule.field == "CARRIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERNAME.Contains(rule.value));
          }
          if (rule.field == "SHIPPERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERKEY.Contains(rule.value));
          }
          if (rule.field == "SHIPPERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERNAME.Contains(rule.value));
          }
          if (rule.field == "SHIPPERADDRESS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERADDRESS.Contains(rule.value));
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
          if (rule.field == "STDKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDKM == val);
                break;
              case "notequal":
                this.And(x => x.STDKM != val);
                break;
              case "less":
                this.And(x => x.STDKM < val);
                break;
              case "lessorequal":
                this.And(x => x.STDKM <= val);
                break;
              case "greater":
                this.And(x => x.STDKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDKM >= val);
                break;
              default:
                this.And(x => x.STDKM == val);
                break;
            }
          }
          if (rule.field == "KM1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.KM1 == val);
                break;
              case "notequal":
                this.And(x => x.KM1 != val);
                break;
              case "less":
                this.And(x => x.KM1 < val);
                break;
              case "lessorequal":
                this.And(x => x.KM1 <= val);
                break;
              case "greater":
                this.And(x => x.KM1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.KM1 >= val);
                break;
              default:
                this.And(x => x.KM1 == val);
                break;
            }
          }
          if (rule.field == "KM2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.KM2 == val);
                break;
              case "notequal":
                this.And(x => x.KM2 != val);
                break;
              case "less":
                this.And(x => x.KM2 < val);
                break;
              case "lessorequal":
                this.And(x => x.KM2 <= val);
                break;
              case "greater":
                this.And(x => x.KM2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.KM2 >= val);
                break;
              default:
                this.And(x => x.KM2 == val);
                break;
            }
          }
          if (rule.field == "ACTKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ACTKM == val);
                break;
              case "notequal":
                this.And(x => x.ACTKM != val);
                break;
              case "less":
                this.And(x => x.ACTKM < val);
                break;
              case "lessorequal":
                this.And(x => x.ACTKM <= val);
                break;
              case "greater":
                this.And(x => x.ACTKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.ACTKM >= val);
                break;
              default:
                this.And(x => x.ACTKM == val);
                break;
            }
          }
          if (rule.field == "STDOIL" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDOIL == val);
                break;
              case "notequal":
                this.And(x => x.STDOIL != val);
                break;
              case "less":
                this.And(x => x.STDOIL < val);
                break;
              case "lessorequal":
                this.And(x => x.STDOIL <= val);
                break;
              case "greater":
                this.And(x => x.STDOIL > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDOIL >= val);
                break;
              default:
                this.And(x => x.STDOIL == val);
                break;
            }
          }
          if (rule.field == "OIL1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.OIL1 == val);
                break;
              case "notequal":
                this.And(x => x.OIL1 != val);
                break;
              case "less":
                this.And(x => x.OIL1 < val);
                break;
              case "lessorequal":
                this.And(x => x.OIL1 <= val);
                break;
              case "greater":
                this.And(x => x.OIL1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.OIL1 >= val);
                break;
              default:
                this.And(x => x.OIL1 == val);
                break;
            }
          }
          if (rule.field == "OIL2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.OIL2 == val);
                break;
              case "notequal":
                this.And(x => x.OIL2 != val);
                break;
              case "less":
                this.And(x => x.OIL2 < val);
                break;
              case "lessorequal":
                this.And(x => x.OIL2 <= val);
                break;
              case "greater":
                this.And(x => x.OIL2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.OIL2 >= val);
                break;
              default:
                this.And(x => x.OIL2 == val);
                break;
            }
          }
          if (rule.field == "ACTOIL" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ACTOIL == val);
                break;
              case "notequal":
                this.And(x => x.ACTOIL != val);
                break;
              case "less":
                this.And(x => x.ACTOIL < val);
                break;
              case "lessorequal":
                this.And(x => x.ACTOIL <= val);
                break;
              case "greater":
                this.And(x => x.ACTOIL > val);
                break;
              case "greaterorequal":
                this.And(x => x.ACTOIL >= val);
                break;
              default:
                this.And(x => x.ACTOIL == val);
                break;
            }
          }
          if (rule.field == "STDLOADWEIGHT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDLOADWEIGHT == val);
                break;
              case "notequal":
                this.And(x => x.STDLOADWEIGHT != val);
                break;
              case "less":
                this.And(x => x.STDLOADWEIGHT < val);
                break;
              case "lessorequal":
                this.And(x => x.STDLOADWEIGHT <= val);
                break;
              case "greater":
                this.And(x => x.STDLOADWEIGHT > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDLOADWEIGHT >= val);
                break;
              default:
                this.And(x => x.STDLOADWEIGHT == val);
                break;
            }
          }
          if (rule.field == "STDLOADVOLUME" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDLOADVOLUME == val);
                break;
              case "notequal":
                this.And(x => x.STDLOADVOLUME != val);
                break;
              case "less":
                this.And(x => x.STDLOADVOLUME < val);
                break;
              case "lessorequal":
                this.And(x => x.STDLOADVOLUME <= val);
                break;
              case "greater":
                this.And(x => x.STDLOADVOLUME > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDLOADVOLUME >= val);
                break;
              default:
                this.And(x => x.STDLOADVOLUME == val);
                break;
            }
          }
          if (rule.field == "FEELOADWEIGHT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.FEELOADWEIGHT == val);
                break;
              case "notequal":
                this.And(x => x.FEELOADWEIGHT != val);
                break;
              case "less":
                this.And(x => x.FEELOADWEIGHT < val);
                break;
              case "lessorequal":
                this.And(x => x.FEELOADWEIGHT <= val);
                break;
              case "greater":
                this.And(x => x.FEELOADWEIGHT > val);
                break;
              case "greaterorequal":
                this.And(x => x.FEELOADWEIGHT >= val);
                break;
              default:
                this.And(x => x.FEELOADWEIGHT == val);
                break;
            }
          }
          if (rule.field == "LOADFACTOR1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOADFACTOR1 == val);
                break;
              case "notequal":
                this.And(x => x.LOADFACTOR1 != val);
                break;
              case "less":
                this.And(x => x.LOADFACTOR1 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOADFACTOR1 <= val);
                break;
              case "greater":
                this.And(x => x.LOADFACTOR1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOADFACTOR1 >= val);
                break;
              default:
                this.And(x => x.LOADFACTOR1 == val);
                break;
            }
          }
          if (rule.field == "LOADFACTOR2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOADFACTOR2 == val);
                break;
              case "notequal":
                this.And(x => x.LOADFACTOR2 != val);
                break;
              case "less":
                this.And(x => x.LOADFACTOR2 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOADFACTOR2 <= val);
                break;
              case "greater":
                this.And(x => x.LOADFACTOR2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOADFACTOR2 >= val);
                break;
              default:
                this.And(x => x.LOADFACTOR2 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST1 == boolval);
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
          if (rule.field == "NOTES" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES.Contains(rule.value));
          }
          if (rule.field == "COMPANYCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.COMPANYCODE.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE1.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE2" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE2.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE3" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE3.Contains(rule.value));
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
    public SHIPORDERQuery Withfilter(IEnumerable<filterRule> filters)
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
          if (rule.field == "SHIPORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPORDERKEY.Contains(rule.value));
          }
          if (rule.field == "EXTERNSHIPORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.EXTERNSHIPORDERKEY.Contains(rule.value));
          }
          if (rule.field == "SHIPORDERDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.SHIPORDERDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.SHIPORDERDATE) <= 0);
            }
          }
          if (rule.field == "STATUS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.STATUS.Contains(rule.value));
          }
          if (rule.field == "TYPE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.TYPE.Contains(rule.value));
          }
          if (rule.field == "ORIGINAL" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ORIGINAL.Contains(rule.value));
          }
          if (rule.field == "DESTINATION" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DESTINATION.Contains(rule.value));
          }
          if (rule.field == "PLATENUMBER" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.PLATENUMBER.Contains(rule.value));
          }
          if (rule.field == "DRIVERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERNAME.Contains(rule.value));
          }
          if (rule.field == "DRIVERPHONE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERPHONE.Contains(rule.value));
          }
          if (rule.field == "CARRIERCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERCODE.Contains(rule.value));
          }
          if (rule.field == "CARRIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERNAME.Contains(rule.value));
          }
          if (rule.field == "SHIPPERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERKEY.Contains(rule.value));
          }
          if (rule.field == "SHIPPERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERNAME.Contains(rule.value));
          }
          if (rule.field == "SHIPPERADDRESS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERADDRESS.Contains(rule.value));
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
          if (rule.field == "STDKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDKM == val);
                break;
              case "notequal":
                this.And(x => x.STDKM != val);
                break;
              case "less":
                this.And(x => x.STDKM < val);
                break;
              case "lessorequal":
                this.And(x => x.STDKM <= val);
                break;
              case "greater":
                this.And(x => x.STDKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDKM >= val);
                break;
              default:
                this.And(x => x.STDKM == val);
                break;
            }
          }
          if (rule.field == "KM1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.KM1 == val);
                break;
              case "notequal":
                this.And(x => x.KM1 != val);
                break;
              case "less":
                this.And(x => x.KM1 < val);
                break;
              case "lessorequal":
                this.And(x => x.KM1 <= val);
                break;
              case "greater":
                this.And(x => x.KM1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.KM1 >= val);
                break;
              default:
                this.And(x => x.KM1 == val);
                break;
            }
          }
          if (rule.field == "KM2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.KM2 == val);
                break;
              case "notequal":
                this.And(x => x.KM2 != val);
                break;
              case "less":
                this.And(x => x.KM2 < val);
                break;
              case "lessorequal":
                this.And(x => x.KM2 <= val);
                break;
              case "greater":
                this.And(x => x.KM2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.KM2 >= val);
                break;
              default:
                this.And(x => x.KM2 == val);
                break;
            }
          }
          if (rule.field == "ACTKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ACTKM == val);
                break;
              case "notequal":
                this.And(x => x.ACTKM != val);
                break;
              case "less":
                this.And(x => x.ACTKM < val);
                break;
              case "lessorequal":
                this.And(x => x.ACTKM <= val);
                break;
              case "greater":
                this.And(x => x.ACTKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.ACTKM >= val);
                break;
              default:
                this.And(x => x.ACTKM == val);
                break;
            }
          }
          if (rule.field == "STDOIL" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDOIL == val);
                break;
              case "notequal":
                this.And(x => x.STDOIL != val);
                break;
              case "less":
                this.And(x => x.STDOIL < val);
                break;
              case "lessorequal":
                this.And(x => x.STDOIL <= val);
                break;
              case "greater":
                this.And(x => x.STDOIL > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDOIL >= val);
                break;
              default:
                this.And(x => x.STDOIL == val);
                break;
            }
          }
          if (rule.field == "OIL1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.OIL1 == val);
                break;
              case "notequal":
                this.And(x => x.OIL1 != val);
                break;
              case "less":
                this.And(x => x.OIL1 < val);
                break;
              case "lessorequal":
                this.And(x => x.OIL1 <= val);
                break;
              case "greater":
                this.And(x => x.OIL1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.OIL1 >= val);
                break;
              default:
                this.And(x => x.OIL1 == val);
                break;
            }
          }
          if (rule.field == "OIL2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.OIL2 == val);
                break;
              case "notequal":
                this.And(x => x.OIL2 != val);
                break;
              case "less":
                this.And(x => x.OIL2 < val);
                break;
              case "lessorequal":
                this.And(x => x.OIL2 <= val);
                break;
              case "greater":
                this.And(x => x.OIL2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.OIL2 >= val);
                break;
              default:
                this.And(x => x.OIL2 == val);
                break;
            }
          }
          if (rule.field == "ACTOIL" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ACTOIL == val);
                break;
              case "notequal":
                this.And(x => x.ACTOIL != val);
                break;
              case "less":
                this.And(x => x.ACTOIL < val);
                break;
              case "lessorequal":
                this.And(x => x.ACTOIL <= val);
                break;
              case "greater":
                this.And(x => x.ACTOIL > val);
                break;
              case "greaterorequal":
                this.And(x => x.ACTOIL >= val);
                break;
              default:
                this.And(x => x.ACTOIL == val);
                break;
            }
          }
          if (rule.field == "STDLOADWEIGHT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDLOADWEIGHT == val);
                break;
              case "notequal":
                this.And(x => x.STDLOADWEIGHT != val);
                break;
              case "less":
                this.And(x => x.STDLOADWEIGHT < val);
                break;
              case "lessorequal":
                this.And(x => x.STDLOADWEIGHT <= val);
                break;
              case "greater":
                this.And(x => x.STDLOADWEIGHT > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDLOADWEIGHT >= val);
                break;
              default:
                this.And(x => x.STDLOADWEIGHT == val);
                break;
            }
          }
          if (rule.field == "STDLOADVOLUME" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDLOADVOLUME == val);
                break;
              case "notequal":
                this.And(x => x.STDLOADVOLUME != val);
                break;
              case "less":
                this.And(x => x.STDLOADVOLUME < val);
                break;
              case "lessorequal":
                this.And(x => x.STDLOADVOLUME <= val);
                break;
              case "greater":
                this.And(x => x.STDLOADVOLUME > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDLOADVOLUME >= val);
                break;
              default:
                this.And(x => x.STDLOADVOLUME == val);
                break;
            }
          }
          if (rule.field == "FEELOADWEIGHT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.FEELOADWEIGHT == val);
                break;
              case "notequal":
                this.And(x => x.FEELOADWEIGHT != val);
                break;
              case "less":
                this.And(x => x.FEELOADWEIGHT < val);
                break;
              case "lessorequal":
                this.And(x => x.FEELOADWEIGHT <= val);
                break;
              case "greater":
                this.And(x => x.FEELOADWEIGHT > val);
                break;
              case "greaterorequal":
                this.And(x => x.FEELOADWEIGHT >= val);
                break;
              default:
                this.And(x => x.FEELOADWEIGHT == val);
                break;
            }
          }
          if (rule.field == "LOADFACTOR1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOADFACTOR1 == val);
                break;
              case "notequal":
                this.And(x => x.LOADFACTOR1 != val);
                break;
              case "less":
                this.And(x => x.LOADFACTOR1 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOADFACTOR1 <= val);
                break;
              case "greater":
                this.And(x => x.LOADFACTOR1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOADFACTOR1 >= val);
                break;
              default:
                this.And(x => x.LOADFACTOR1 == val);
                break;
            }
          }
          if (rule.field == "LOADFACTOR2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOADFACTOR2 == val);
                break;
              case "notequal":
                this.And(x => x.LOADFACTOR2 != val);
                break;
              case "less":
                this.And(x => x.LOADFACTOR2 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOADFACTOR2 <= val);
                break;
              case "greater":
                this.And(x => x.LOADFACTOR2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOADFACTOR2 >= val);
                break;
              default:
                this.And(x => x.LOADFACTOR2 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST1 == boolval);
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
          if (rule.field == "NOTES" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES.Contains(rule.value));
          }
          if (rule.field == "COMPANYCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.COMPANYCODE.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE1.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE2" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE2.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE3" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE3.Contains(rule.value));
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
    public SHIPORDERQuery WithfilterWithDriverPhone(string phonenumber,string status,IEnumerable<filterRule> filters)
    {
      And(x => x.DRIVERPHONE == phonenumber);
      And(x => x.STATUS == status);
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
          if (rule.field == "SHIPORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPORDERKEY.Contains(rule.value));
          }
          if (rule.field == "EXTERNSHIPORDERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.EXTERNSHIPORDERKEY.Contains(rule.value));
          }
          if (rule.field == "SHIPORDERDATE" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.SHIPORDERDATE) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.SHIPORDERDATE) <= 0);
            }
          }
          if (rule.field == "STATUS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.STATUS.Contains(rule.value));
          }
          if (rule.field == "TYPE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.TYPE.Contains(rule.value));
          }
          if (rule.field == "ORIGINAL" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ORIGINAL.Contains(rule.value));
          }
          if (rule.field == "DESTINATION" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DESTINATION.Contains(rule.value));
          }
          if (rule.field == "PLATENUMBER" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.PLATENUMBER.Contains(rule.value));
          }
          if (rule.field == "DRIVERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERNAME.Contains(rule.value));
          }
          if (rule.field == "DRIVERPHONE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DRIVERPHONE.Contains(rule.value));
          }
          if (rule.field == "CARRIERCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERCODE.Contains(rule.value));
          }
          if (rule.field == "CARRIERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CARRIERNAME.Contains(rule.value));
          }
          if (rule.field == "SHIPPERKEY" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERKEY.Contains(rule.value));
          }
          if (rule.field == "SHIPPERNAME" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERNAME.Contains(rule.value));
          }
          if (rule.field == "SHIPPERADDRESS" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.SHIPPERADDRESS.Contains(rule.value));
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
          if (rule.field == "STDKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDKM == val);
                break;
              case "notequal":
                this.And(x => x.STDKM != val);
                break;
              case "less":
                this.And(x => x.STDKM < val);
                break;
              case "lessorequal":
                this.And(x => x.STDKM <= val);
                break;
              case "greater":
                this.And(x => x.STDKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDKM >= val);
                break;
              default:
                this.And(x => x.STDKM == val);
                break;
            }
          }
          if (rule.field == "KM1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.KM1 == val);
                break;
              case "notequal":
                this.And(x => x.KM1 != val);
                break;
              case "less":
                this.And(x => x.KM1 < val);
                break;
              case "lessorequal":
                this.And(x => x.KM1 <= val);
                break;
              case "greater":
                this.And(x => x.KM1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.KM1 >= val);
                break;
              default:
                this.And(x => x.KM1 == val);
                break;
            }
          }
          if (rule.field == "KM2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.KM2 == val);
                break;
              case "notequal":
                this.And(x => x.KM2 != val);
                break;
              case "less":
                this.And(x => x.KM2 < val);
                break;
              case "lessorequal":
                this.And(x => x.KM2 <= val);
                break;
              case "greater":
                this.And(x => x.KM2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.KM2 >= val);
                break;
              default:
                this.And(x => x.KM2 == val);
                break;
            }
          }
          if (rule.field == "ACTKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ACTKM == val);
                break;
              case "notequal":
                this.And(x => x.ACTKM != val);
                break;
              case "less":
                this.And(x => x.ACTKM < val);
                break;
              case "lessorequal":
                this.And(x => x.ACTKM <= val);
                break;
              case "greater":
                this.And(x => x.ACTKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.ACTKM >= val);
                break;
              default:
                this.And(x => x.ACTKM == val);
                break;
            }
          }
          if (rule.field == "STDOIL" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDOIL == val);
                break;
              case "notequal":
                this.And(x => x.STDOIL != val);
                break;
              case "less":
                this.And(x => x.STDOIL < val);
                break;
              case "lessorequal":
                this.And(x => x.STDOIL <= val);
                break;
              case "greater":
                this.And(x => x.STDOIL > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDOIL >= val);
                break;
              default:
                this.And(x => x.STDOIL == val);
                break;
            }
          }
          if (rule.field == "OIL1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.OIL1 == val);
                break;
              case "notequal":
                this.And(x => x.OIL1 != val);
                break;
              case "less":
                this.And(x => x.OIL1 < val);
                break;
              case "lessorequal":
                this.And(x => x.OIL1 <= val);
                break;
              case "greater":
                this.And(x => x.OIL1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.OIL1 >= val);
                break;
              default:
                this.And(x => x.OIL1 == val);
                break;
            }
          }
          if (rule.field == "OIL2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.OIL2 == val);
                break;
              case "notequal":
                this.And(x => x.OIL2 != val);
                break;
              case "less":
                this.And(x => x.OIL2 < val);
                break;
              case "lessorequal":
                this.And(x => x.OIL2 <= val);
                break;
              case "greater":
                this.And(x => x.OIL2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.OIL2 >= val);
                break;
              default:
                this.And(x => x.OIL2 == val);
                break;
            }
          }
          if (rule.field == "ACTOIL" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ACTOIL == val);
                break;
              case "notequal":
                this.And(x => x.ACTOIL != val);
                break;
              case "less":
                this.And(x => x.ACTOIL < val);
                break;
              case "lessorequal":
                this.And(x => x.ACTOIL <= val);
                break;
              case "greater":
                this.And(x => x.ACTOIL > val);
                break;
              case "greaterorequal":
                this.And(x => x.ACTOIL >= val);
                break;
              default:
                this.And(x => x.ACTOIL == val);
                break;
            }
          }
          if (rule.field == "STDLOADWEIGHT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDLOADWEIGHT == val);
                break;
              case "notequal":
                this.And(x => x.STDLOADWEIGHT != val);
                break;
              case "less":
                this.And(x => x.STDLOADWEIGHT < val);
                break;
              case "lessorequal":
                this.And(x => x.STDLOADWEIGHT <= val);
                break;
              case "greater":
                this.And(x => x.STDLOADWEIGHT > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDLOADWEIGHT >= val);
                break;
              default:
                this.And(x => x.STDLOADWEIGHT == val);
                break;
            }
          }
          if (rule.field == "STDLOADVOLUME" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.STDLOADVOLUME == val);
                break;
              case "notequal":
                this.And(x => x.STDLOADVOLUME != val);
                break;
              case "less":
                this.And(x => x.STDLOADVOLUME < val);
                break;
              case "lessorequal":
                this.And(x => x.STDLOADVOLUME <= val);
                break;
              case "greater":
                this.And(x => x.STDLOADVOLUME > val);
                break;
              case "greaterorequal":
                this.And(x => x.STDLOADVOLUME >= val);
                break;
              default:
                this.And(x => x.STDLOADVOLUME == val);
                break;
            }
          }
          if (rule.field == "FEELOADWEIGHT" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.FEELOADWEIGHT == val);
                break;
              case "notequal":
                this.And(x => x.FEELOADWEIGHT != val);
                break;
              case "less":
                this.And(x => x.FEELOADWEIGHT < val);
                break;
              case "lessorequal":
                this.And(x => x.FEELOADWEIGHT <= val);
                break;
              case "greater":
                this.And(x => x.FEELOADWEIGHT > val);
                break;
              case "greaterorequal":
                this.And(x => x.FEELOADWEIGHT >= val);
                break;
              default:
                this.And(x => x.FEELOADWEIGHT == val);
                break;
            }
          }
          if (rule.field == "LOADFACTOR1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOADFACTOR1 == val);
                break;
              case "notequal":
                this.And(x => x.LOADFACTOR1 != val);
                break;
              case "less":
                this.And(x => x.LOADFACTOR1 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOADFACTOR1 <= val);
                break;
              case "greater":
                this.And(x => x.LOADFACTOR1 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOADFACTOR1 >= val);
                break;
              default:
                this.And(x => x.LOADFACTOR1 == val);
                break;
            }
          }
          if (rule.field == "LOADFACTOR2" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.LOADFACTOR2 == val);
                break;
              case "notequal":
                this.And(x => x.LOADFACTOR2 != val);
                break;
              case "less":
                this.And(x => x.LOADFACTOR2 < val);
                break;
              case "lessorequal":
                this.And(x => x.LOADFACTOR2 <= val);
                break;
              case "greater":
                this.And(x => x.LOADFACTOR2 > val);
                break;
              case "greaterorequal":
                this.And(x => x.LOADFACTOR2 >= val);
                break;
              default:
                this.And(x => x.LOADFACTOR2 == val);
                break;
            }
          }
          if (rule.field == "CHECKEDCOST1" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.CHECKEDCOST1 == boolval);
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
          if (rule.field == "NOTES" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.NOTES.Contains(rule.value));
          }
          if (rule.field == "COMPANYCODE" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.COMPANYCODE.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE1" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE1.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE2" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE2.Contains(rule.value));
          }
          if (rule.field == "LOTTABLE3" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LOTTABLE3.Contains(rule.value));
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
