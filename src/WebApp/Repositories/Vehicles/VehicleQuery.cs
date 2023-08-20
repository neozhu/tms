using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Web.WebPages;
using Repository.Pattern.Ef6;
using WebApp.Models;
using System.Linq;
namespace WebApp.Repositories
{
  /// <summary>
  /// File: VehicleQuery.cs
  /// Purpose: easyui datagrid filter query 
  /// Created Date: 2019/8/2 7:47:02
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class VehicleQuery : QueryObject<Vehicle>
  {
    public VehicleQuery WithfilterQ(string q)
    {
      var status = new string[] {"1","2","4","170","140"};
      if (string.IsNullOrEmpty(q))
      {
        this.And(x => x.PlateNumber.Contains(q));
      }
      //允许重复派车
      //this.And(x => status.Contains(x.Status));
      return this;
    }

    public VehicleQuery Withfilter(IEnumerable<filterRule> filters)
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
          if (rule.field == "PlateNumber" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.PlateNumber.Contains(rule.value));
          }
          if (rule.field == "ShipOrderNo" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.ShipOrderNo.Contains(rule.value));
          }
          if (rule.field == "InputUser" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.InputUser.Contains(rule.value));
          }
          if (rule.field == "Status" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Status.Contains(rule.value));
          }
          if (rule.field == "CarType" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CarType.Contains(rule.value));
          }
          if (rule.field == "CarrierCode" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CarrierCode.Contains(rule.value));
          }
          if (rule.field == "CarrierName" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CarrierName.Contains(rule.value));
          }
          if (rule.field == "VehLongSize" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.VehLongSize == val);
                break;
              case "notequal":
                this.And(x => x.VehLongSize != val);
                break;
              case "less":
                this.And(x => x.VehLongSize < val);
                break;
              case "lessorequal":
                this.And(x => x.VehLongSize <= val);
                break;
              case "greater":
                this.And(x => x.VehLongSize > val);
                break;
              case "greaterorequal":
                this.And(x => x.VehLongSize >= val);
                break;
              default:
                this.And(x => x.VehLongSize == val);
                break;
            }
          }
          if (rule.field == "StdLoadWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.StdLoadWeight == val);
                break;
              case "notequal":
                this.And(x => x.StdLoadWeight != val);
                break;
              case "less":
                this.And(x => x.StdLoadWeight < val);
                break;
              case "lessorequal":
                this.And(x => x.StdLoadWeight <= val);
                break;
              case "greater":
                this.And(x => x.StdLoadWeight > val);
                break;
              case "greaterorequal":
                this.And(x => x.StdLoadWeight >= val);
                break;
              default:
                this.And(x => x.StdLoadWeight == val);
                break;
            }
          }
          if (rule.field == "FeeLoadWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.FeeLoadWeight == val);
                break;
              case "notequal":
                this.And(x => x.FeeLoadWeight != val);
                break;
              case "less":
                this.And(x => x.FeeLoadWeight < val);
                break;
              case "lessorequal":
                this.And(x => x.FeeLoadWeight <= val);
                break;
              case "greater":
                this.And(x => x.FeeLoadWeight > val);
                break;
              case "greaterorequal":
                this.And(x => x.FeeLoadWeight >= val);
                break;
              default:
                this.And(x => x.FeeLoadWeight == val);
                break;
            }
          }
          if (rule.field == "StdLoadVolume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.StdLoadVolume == val);
                break;
              case "notequal":
                this.And(x => x.StdLoadVolume != val);
                break;
              case "less":
                this.And(x => x.StdLoadVolume < val);
                break;
              case "lessorequal":
                this.And(x => x.StdLoadVolume <= val);
                break;
              case "greater":
                this.And(x => x.StdLoadVolume > val);
                break;
              case "greaterorequal":
                this.And(x => x.StdLoadVolume >= val);
                break;
              default:
                this.And(x => x.StdLoadVolume == val);
                break;
            }
          }
          if (rule.field == "CarriageSize" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.CarriageSize == val);
                break;
              case "notequal":
                this.And(x => x.CarriageSize != val);
                break;
              case "less":
                this.And(x => x.CarriageSize < val);
                break;
              case "lessorequal":
                this.And(x => x.CarriageSize <= val);
                break;
              case "greater":
                this.And(x => x.CarriageSize > val);
                break;
              case "greaterorequal":
                this.And(x => x.CarriageSize >= val);
                break;
              default:
                this.And(x => x.CarriageSize == val);
                break;
            }
          }
          if (rule.field == "GPSDeviceId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.GPSDeviceId.Contains(rule.value));
          }
          if (rule.field == "Driver" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Driver.Contains(rule.value));
          }
          if (rule.field == "DriverPhone" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DriverPhone.Contains(rule.value));
          }
          if (rule.field == "AssistantDriver" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.AssistantDriver.Contains(rule.value));
          }
          if (rule.field == "AssistantDriverPhone" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.AssistantDriverPhone.Contains(rule.value));
          }
          if (rule.field == "CustomsNo" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.CustomsNo.Contains(rule.value));
          }
          if (rule.field == "RoadKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.RoadKM == val);
                break;
              case "notequal":
                this.And(x => x.RoadKM != val);
                break;
              case "less":
                this.And(x => x.RoadKM < val);
                break;
              case "lessorequal":
                this.And(x => x.RoadKM <= val);
                break;
              case "greater":
                this.And(x => x.RoadKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.RoadKM >= val);
                break;
              default:
                this.And(x => x.RoadKM == val);
                break;
            }
          }
          if (rule.field == "RoadHours" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.RoadHours == val);
                break;
              case "notequal":
                this.And(x => x.RoadHours != val);
                break;
              case "less":
                this.And(x => x.RoadHours < val);
                break;
              case "lessorequal":
                this.And(x => x.RoadHours <= val);
                break;
              case "greater":
                this.And(x => x.RoadHours > val);
                break;
              case "greaterorequal":
                this.And(x => x.RoadHours >= val);
                break;
              default:
                this.And(x => x.RoadHours == val);
                break;
            }
          }
          if (rule.field == "Owner" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Owner.Contains(rule.value));
          }
          if (rule.field == "OwnerContactPhone" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.OwnerContactPhone.Contains(rule.value));
          }
          if (rule.field == "Brand" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.Brand.Contains(rule.value));
          }
          if (rule.field == "RPM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.RPM == val);
                break;
              case "notequal":
                this.And(x => x.RPM != val);
                break;
              case "less":
                this.And(x => x.RPM < val);
                break;
              case "lessorequal":
                this.And(x => x.RPM <= val);
                break;
              case "greater":
                this.And(x => x.RPM > val);
                break;
              case "greaterorequal":
                this.And(x => x.RPM >= val);
                break;
              default:
                this.And(x => x.RPM == val);
                break;
            }
          }
          if (rule.field == "PurchasedDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.PurchasedDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.PurchasedDate) <= 0);
            }
          }
          if (rule.field == "PurchasedAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.PurchasedAmount == val);
                break;
              case "notequal":
                this.And(x => x.PurchasedAmount != val);
                break;
              case "less":
                this.And(x => x.PurchasedAmount < val);
                break;
              case "lessorequal":
                this.And(x => x.PurchasedAmount <= val);
                break;
              case "greater":
                this.And(x => x.PurchasedAmount > val);
                break;
              case "greaterorequal":
                this.And(x => x.PurchasedAmount >= val);
                break;
              default:
                this.And(x => x.PurchasedAmount == val);
                break;
            }
          }
          if (rule.field == "VehLong" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.VehLong == val);
                break;
              case "notequal":
                this.And(x => x.VehLong != val);
                break;
              case "less":
                this.And(x => x.VehLong < val);
                break;
              case "lessorequal":
                this.And(x => x.VehLong <= val);
                break;
              case "greater":
                this.And(x => x.VehLong > val);
                break;
              case "greaterorequal":
                this.And(x => x.VehLong >= val);
                break;
              default:
                this.And(x => x.VehLong == val);
                break;
            }
          }
          if (rule.field == "VehWide" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.VehWide == val);
                break;
              case "notequal":
                this.And(x => x.VehWide != val);
                break;
              case "less":
                this.And(x => x.VehWide < val);
                break;
              case "lessorequal":
                this.And(x => x.VehWide <= val);
                break;
              case "greater":
                this.And(x => x.VehWide > val);
                break;
              case "greaterorequal":
                this.And(x => x.VehWide >= val);
                break;
              default:
                this.And(x => x.VehWide == val);
                break;
            }
          }
          if (rule.field == "VehHigh" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.VehHigh == val);
                break;
              case "notequal":
                this.And(x => x.VehHigh != val);
                break;
              case "less":
                this.And(x => x.VehHigh < val);
                break;
              case "lessorequal":
                this.And(x => x.VehHigh <= val);
                break;
              case "greater":
                this.And(x => x.VehHigh > val);
                break;
              case "greaterorequal":
                this.And(x => x.VehHigh >= val);
                break;
              default:
                this.And(x => x.VehHigh == val);
                break;
            }
          }
          if (rule.field == "VIN" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.VIN.Contains(rule.value));
          }
          if (rule.field == "ServiceLife" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.ServiceLife == val);
                break;
              case "notequal":
                this.And(x => x.ServiceLife != val);
                break;
              case "less":
                this.And(x => x.ServiceLife < val);
                break;
              case "lessorequal":
                this.And(x => x.ServiceLife <= val);
                break;
              case "greater":
                this.And(x => x.ServiceLife > val);
                break;
              case "greaterorequal":
                this.And(x => x.ServiceLife >= val);
                break;
              default:
                this.And(x => x.ServiceLife == val);
                break;
            }
          }
          if (rule.field == "MaintainKM" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.MaintainKM == val);
                break;
              case "notequal":
                this.And(x => x.MaintainKM != val);
                break;
              case "less":
                this.And(x => x.MaintainKM < val);
                break;
              case "lessorequal":
                this.And(x => x.MaintainKM <= val);
                break;
              case "greater":
                this.And(x => x.MaintainKM > val);
                break;
              case "greaterorequal":
                this.And(x => x.MaintainKM >= val);
                break;
              default:
                this.And(x => x.MaintainKM == val);
                break;
            }
          }
          if (rule.field == "MaintainDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.MaintainDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.MaintainDate) <= 0);
            }
          }
          if (rule.field == "MaintainMonth" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.MaintainMonth == val);
                break;
              case "notequal":
                this.And(x => x.MaintainMonth != val);
                break;
              case "less":
                this.And(x => x.MaintainMonth < val);
                break;
              case "lessorequal":
                this.And(x => x.MaintainMonth <= val);
                break;
              case "greater":
                this.And(x => x.MaintainMonth > val);
                break;
              case "greaterorequal":
                this.And(x => x.MaintainMonth >= val);
                break;
              default:
                this.And(x => x.MaintainMonth == val);
                break;
            }
          }
          if (rule.field == "ExistVehTailBoard" && !string.IsNullOrEmpty(rule.value) && rule.value.IsBool())
          {
            var boolval = Convert.ToBoolean(rule.value);
            this.And(x => x.ExistVehTailBoard == boolval);
          }
          if (rule.field == "VehTailBoardBrand" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.VehTailBoardBrand.Contains(rule.value));
          }
          if (rule.field == "VehTailBoardFactory" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.VehTailBoardFactory.Contains(rule.value));
          }
          if (rule.field == "VehTailBoardLife" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.VehTailBoardLife == val);
                break;
              case "notequal":
                this.And(x => x.VehTailBoardLife != val);
                break;
              case "less":
                this.And(x => x.VehTailBoardLife < val);
                break;
              case "lessorequal":
                this.And(x => x.VehTailBoardLife <= val);
                break;
              case "greater":
                this.And(x => x.VehTailBoardLife > val);
                break;
              case "greaterorequal":
                this.And(x => x.VehTailBoardLife >= val);
                break;
              default:
                this.And(x => x.VehTailBoardLife == val);
                break;
            }
          }
          if (rule.field == "VehTailBoardAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.VehTailBoardAmount == val);
                break;
              case "notequal":
                this.And(x => x.VehTailBoardAmount != val);
                break;
              case "less":
                this.And(x => x.VehTailBoardAmount < val);
                break;
              case "lessorequal":
                this.And(x => x.VehTailBoardAmount <= val);
                break;
              case "greater":
                this.And(x => x.VehTailBoardAmount > val);
                break;
              case "greaterorequal":
                this.And(x => x.VehTailBoardAmount >= val);
                break;
              default:
                this.And(x => x.VehTailBoardAmount == val);
                break;
            }
          }
          if (rule.field == "VehTailBoardGPSDeviceId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.VehTailBoardGPSDeviceId.Contains(rule.value));
          }
          if (rule.field == "DrLicenseModel" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DrLicenseModel.Contains(rule.value));
          }
          if (rule.field == "DrLicenseUseNature" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DrLicenseUseNature.Contains(rule.value));
          }
          if (rule.field == "DrLicenseBrand" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DrLicenseBrand.Contains(rule.value));
          }
          if (rule.field == "DrLicenseDevId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DrLicenseDevId.Contains(rule.value));
          }
          if (rule.field == "DrLicenseEngineId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.DrLicenseEngineId.Contains(rule.value));
          }
          if (rule.field == "DrLicenseRegistrationDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.DrLicenseRegistrationDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.DrLicenseRegistrationDate) <= 0);
            }
          }
          if (rule.field == "DrLicensePubDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.DrLicensePubDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.DrLicensePubDate) <= 0);
            }
          }
          if (rule.field == "DrLicenseRatedUsers" && !string.IsNullOrEmpty(rule.value) && rule.value.IsInt())
          {
            var val = Convert.ToInt32(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseRatedUsers == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseRatedUsers != val);
                break;
              case "less":
                this.And(x => x.DrLicenseRatedUsers < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseRatedUsers <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseRatedUsers > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseRatedUsers >= val);
                break;
              default:
                this.And(x => x.DrLicenseRatedUsers == val);
                break;
            }
          }
          if (rule.field == "DrLicenseVehWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseVehWeight == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseVehWeight != val);
                break;
              case "less":
                this.And(x => x.DrLicenseVehWeight < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseVehWeight <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseVehWeight > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseVehWeight >= val);
                break;
              default:
                this.And(x => x.DrLicenseVehWeight == val);
                break;
            }
          }
          if (rule.field == "DrLicenseDevWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseDevWeight == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseDevWeight != val);
                break;
              case "less":
                this.And(x => x.DrLicenseDevWeight < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseDevWeight <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseDevWeight > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseDevWeight >= val);
                break;
              default:
                this.And(x => x.DrLicenseDevWeight == val);
                break;
            }
          }
          if (rule.field == "DrLicenseNetWeight" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseNetWeight == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseNetWeight != val);
                break;
              case "less":
                this.And(x => x.DrLicenseNetWeight < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseNetWeight <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseNetWeight > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseNetWeight >= val);
                break;
              default:
                this.And(x => x.DrLicenseNetWeight == val);
                break;
            }
          }
          if (rule.field == "DrLicenseNetVolume" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseNetVolume == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseNetVolume != val);
                break;
              case "less":
                this.And(x => x.DrLicenseNetVolume < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseNetVolume <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseNetVolume > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseNetVolume >= val);
                break;
              default:
                this.And(x => x.DrLicenseNetVolume == val);
                break;
            }
          }
          if (rule.field == "DrLicenseVehWide" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseVehWide == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseVehWide != val);
                break;
              case "less":
                this.And(x => x.DrLicenseVehWide < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseVehWide <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseVehWide > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseVehWide >= val);
                break;
              default:
                this.And(x => x.DrLicenseVehWide == val);
                break;
            }
          }
          if (rule.field == "DrLicenseVehHigh" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseVehHigh == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseVehHigh != val);
                break;
              case "less":
                this.And(x => x.DrLicenseVehHigh < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseVehHigh <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseVehHigh > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseVehHigh >= val);
                break;
              default:
                this.And(x => x.DrLicenseVehHigh == val);
                break;
            }
          }
          if (rule.field == "DrLicenseVehLong" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.DrLicenseVehLong == val);
                break;
              case "notequal":
                this.And(x => x.DrLicenseVehLong != val);
                break;
              case "less":
                this.And(x => x.DrLicenseVehLong < val);
                break;
              case "lessorequal":
                this.And(x => x.DrLicenseVehLong <= val);
                break;
              case "greater":
                this.And(x => x.DrLicenseVehLong > val);
                break;
              case "greaterorequal":
                this.And(x => x.DrLicenseVehLong >= val);
                break;
              default:
                this.And(x => x.DrLicenseVehLong == val);
                break;
            }
          }
          if (rule.field == "DrLicenseScrapedDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.DrLicenseScrapedDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.DrLicenseScrapedDate) <= 0);
            }
          }
          if (rule.field == "LoLicenseManageId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LoLicenseManageId.Contains(rule.value));
          }
          if (rule.field == "LoLicenseId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LoLicenseId.Contains(rule.value));
          }
          if (rule.field == "LoLicenseBusinessScope" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LoLicenseBusinessScope.Contains(rule.value));
          }
          if (rule.field == "LoLicensePubDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.LoLicensePubDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.LoLicensePubDate) <= 0);
            }
          }
          if (rule.field == "LoLicenseValidDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.LoLicenseValidDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.LoLicenseValidDate) <= 0);
            }
          }
          if (rule.field == "LoLicenseCheckDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.LoLicenseCheckDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.LoLicenseCheckDate) <= 0);
            }
          }
          if (rule.field == "LoLicensePlace" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.LoLicensePlace.Contains(rule.value));
          }
          if (rule.field == "InsTrafficPolicyId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.InsTrafficPolicyId.Contains(rule.value));
          }
          if (rule.field == "InsTrafficPolicyCompany" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.InsTrafficPolicyCompany.Contains(rule.value));
          }
          if (rule.field == "InsTrafficPolicyVaildateDate" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.InsTrafficPolicyVaildateDate.Contains(rule.value));
          }
          if (rule.field == "InsTrafficPolicyAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.InsTrafficPolicyAmount == val);
                break;
              case "notequal":
                this.And(x => x.InsTrafficPolicyAmount != val);
                break;
              case "less":
                this.And(x => x.InsTrafficPolicyAmount < val);
                break;
              case "lessorequal":
                this.And(x => x.InsTrafficPolicyAmount <= val);
                break;
              case "greater":
                this.And(x => x.InsTrafficPolicyAmount > val);
                break;
              case "greaterorequal":
                this.And(x => x.InsTrafficPolicyAmount >= val);
                break;
              default:
                this.And(x => x.InsTrafficPolicyAmount == val);
                break;
            }
          }
          if (rule.field == "InsThirdPartyId" && !string.IsNullOrEmpty(rule.value))
          {
            this.And(x => x.InsThirdPartyId.Contains(rule.value));
          }
          if (rule.field == "InsThirdPartyVaildateDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.InsThirdPartyVaildateDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.InsThirdPartyVaildateDate) <= 0);
            }
          }
          if (rule.field == "InsThirdPartyAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.InsThirdPartyAmount == val);
                break;
              case "notequal":
                this.And(x => x.InsThirdPartyAmount != val);
                break;
              case "less":
                this.And(x => x.InsThirdPartyAmount < val);
                break;
              case "lessorequal":
                this.And(x => x.InsThirdPartyAmount <= val);
                break;
              case "greater":
                this.And(x => x.InsThirdPartyAmount > val);
                break;
              case "greaterorequal":
                this.And(x => x.InsThirdPartyAmount >= val);
                break;
              default:
                this.And(x => x.InsThirdPartyAmount == val);
                break;
            }
          }
          if (rule.field == "InsThirdPartyLogisticsAmount" && !string.IsNullOrEmpty(rule.value) && rule.value.IsDecimal())
          {
            var val = Convert.ToDecimal(rule.value);
            switch (rule.op)
            {
              case "equal":
                this.And(x => x.InsThirdPartyLogisticsAmount == val);
                break;
              case "notequal":
                this.And(x => x.InsThirdPartyLogisticsAmount != val);
                break;
              case "less":
                this.And(x => x.InsThirdPartyLogisticsAmount < val);
                break;
              case "lessorequal":
                this.And(x => x.InsThirdPartyLogisticsAmount <= val);
                break;
              case "greater":
                this.And(x => x.InsThirdPartyLogisticsAmount > val);
                break;
              case "greaterorequal":
                this.And(x => x.InsThirdPartyLogisticsAmount >= val);
                break;
              default:
                this.And(x => x.InsThirdPartyLogisticsAmount == val);
                break;
            }
          }
          if (rule.field == "InsThirdPartyLogisticsVaildateDate" && !string.IsNullOrEmpty(rule.value))
          {
            if (rule.op == "between")
            {
              var datearray = rule.value.Split(new char[] { '-' });
              var start = Convert.ToDateTime(datearray[0]);
              var end = Convert.ToDateTime(datearray[1]);

              this.And(x => SqlFunctions.DateDiff("d", start, x.InsThirdPartyLogisticsVaildateDate) >= 0);
              this.And(x => SqlFunctions.DateDiff("d", end, x.InsThirdPartyLogisticsVaildateDate) <= 0);
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
