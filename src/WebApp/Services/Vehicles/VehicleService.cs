using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;
namespace WebApp.Services
{
  /// <summary>
  /// File: VehicleService.cs
  /// Purpose: Within the service layer, you define and implement 
  /// the service interface and the data contracts (or message types).
  /// One of the more important concepts to keep in mind is that a service
  /// should never expose details of the internal processes or 
  /// the business entities used within the application. 
  /// Created Date: 2019/8/2 7:50:36
  /// Author: neo.zhu
  /// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
  /// Copyright (c) 2012-2018 All Rights Reserved
  /// </summary>
  public class VehicleService : Service<Vehicle>, IVehicleService
  {
    private readonly IRepositoryAsync<Vehicle> repository;
    private readonly IDataTableImportMappingService mappingservice;
    public VehicleService(IRepositoryAsync<Vehicle> repository, IDataTableImportMappingService mappingservice)
        : base(repository)
    {
      this.repository = repository;
      this.mappingservice = mappingservice;
    }



    public void ImportDataTable(System.Data.DataTable datatable)
    {
      var mapping = this.mappingservice.Queryable().Where(x => x.EntitySetName == "Vehicle" && ( ( x.IsEnabled == true ) || ( x.IsEnabled == false && !( x.DefaultValue == null || x.DefaultValue.Equals(string.Empty) ) ) )).ToList();
      if (mapping == null || mapping.Count == 0)
      {
        throw new KeyNotFoundException("没有找到Vehicle对象的Excel导入配置信息，请执行[系统管理/Excel导入配置]");
      }
      foreach (DataRow row in datatable.Rows)
      {
        var item = new Vehicle();
        var requiredfield = mapping.Where(x => x.IsRequired == true).FirstOrDefault()?.SourceFieldName;
        if (requiredfield != null && !row.IsNull(requiredfield) && row[requiredfield] != DBNull.Value && Convert.ToString(row[requiredfield]).Trim() != string.Empty)
        {
          foreach (var field in mapping)
          {
            var defval = field.DefaultValue;
            var contain = datatable.Columns.Contains(field.SourceFieldName ?? "");
            if (contain && !row.IsNull(field.SourceFieldName) && row[field.SourceFieldName] != DBNull.Value && row[field.SourceFieldName].ToString() != string.Empty)
            {
              var vehicletype = item.GetType();
              var propertyInfo = vehicletype.GetProperty(field.FieldName);
              var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
              var safeValue = ( row[field.SourceFieldName] == null ) ? null : Convert.ChangeType(row[field.SourceFieldName], safetype);
              propertyInfo.SetValue(item, safeValue, null);
            }
            else if (!string.IsNullOrEmpty(defval))
            {
              var vehicletype = item.GetType();
              var propertyInfo = vehicletype.GetProperty(field.FieldName);
              if (string.Equals(defval, "now", StringComparison.OrdinalIgnoreCase) && ( propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(Nullable<DateTime>) ))
              {
                var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var safeValue = Convert.ChangeType(DateTime.Now, safetype);
                propertyInfo.SetValue(item, safeValue, null);
              }
              else if (string.Equals(defval, "guid", StringComparison.OrdinalIgnoreCase))
              {
                propertyInfo.SetValue(item, Guid.NewGuid().ToString(), null);
              }
              else
              {
                var safetype = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var safeValue = Convert.ChangeType(defval, safetype);
                propertyInfo.SetValue(item, safeValue, null);
              }
            }
          }
          this.Insert(item);
        }
      }
    }
    public Stream ExportExcel(string filterRules = "", string sort = "Id", string order = "asc")
    {
      var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
      var ignoredColumns = this.mappingservice.Queryable().Where(x => x.EntitySetName == "Vehicle" && x.IgnoredColumn).Select(x => x.FieldName).ToArray();
      var vehicles = this.Query(new VehicleQuery().Withfilter(filters)).OrderBy(n => n.OrderBy(sort, order)).Select().ToList();
      var datarows = vehicles.Select(n => new
      {

        Id = n.Id,
        PlateNumber = n.PlateNumber,
        ShipOrderNo = n.ShipOrderNo,
        InputUser = n.InputUser,
        Status = n.Status,
        CarType = n.CarType,
        CarrierCode = n.CarrierCode,
        CarrierName = n.CarrierName,
        VehLongSize = n.VehLongSize,
        StdLoadWeight = n.StdLoadWeight,
        FeeLoadWeight = n.FeeLoadWeight,
        StdLoadVolume = n.StdLoadVolume,
        CarriageSize = n.CarriageSize,
        GPSDeviceId = n.GPSDeviceId,
        Driver = n.Driver,
        DriverPhone = n.DriverPhone,
        AssistantDriver = n.AssistantDriver,
        AssistantDriverPhone = n.AssistantDriverPhone,
        CustomsNo = n.CustomsNo,
        RoadKM = n.RoadKM,
        RoadHours = n.RoadHours,
        Owner = n.Owner,
        OwnerContactPhone = n.OwnerContactPhone,
        Brand = n.Brand,
        RPM = n.RPM,
        PurchasedDate = n.PurchasedDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        PurchasedAmount = n.PurchasedAmount,
        VehLong = n.VehLong,
        VehWide = n.VehWide,
        VehHigh = n.VehHigh,
        VIN = n.VIN,
        ServiceLife = n.ServiceLife,
        MaintainKM = n.MaintainKM,
        MaintainDate = n.MaintainDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        MaintainMonth = n.MaintainMonth,
        ExistVehTailBoard = n.ExistVehTailBoard,
        VehTailBoardBrand = n.VehTailBoardBrand,
        VehTailBoardFactory = n.VehTailBoardFactory,
        VehTailBoardLife = n.VehTailBoardLife,
        VehTailBoardAmount = n.VehTailBoardAmount,
        VehTailBoardGPSDeviceId = n.VehTailBoardGPSDeviceId,
        DrLicenseModel = n.DrLicenseModel,
        DrLicenseUseNature = n.DrLicenseUseNature,
        DrLicenseBrand = n.DrLicenseBrand,
        DrLicenseDevId = n.DrLicenseDevId,
        DrLicenseEngineId = n.DrLicenseEngineId,
        DrLicenseRegistrationDate = n.DrLicenseRegistrationDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        DrLicensePubDate = n.DrLicensePubDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        DrLicenseRatedUsers = n.DrLicenseRatedUsers,
        DrLicenseVehWeight = n.DrLicenseVehWeight,
        DrLicenseDevWeight = n.DrLicenseDevWeight,
        DrLicenseNetWeight = n.DrLicenseNetWeight,
        DrLicenseNetVolume = n.DrLicenseNetVolume,
        DrLicenseVehWide = n.DrLicenseVehWide,
        DrLicenseVehHigh = n.DrLicenseVehHigh,
        DrLicenseVehLong = n.DrLicenseVehLong,
        DrLicenseScrapedDate = n.DrLicenseScrapedDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        LoLicenseManageId = n.LoLicenseManageId,
        LoLicenseId = n.LoLicenseId,
        LoLicenseBusinessScope = n.LoLicenseBusinessScope,
        LoLicensePubDate = n.LoLicensePubDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        LoLicenseValidDate = n.LoLicenseValidDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        LoLicenseCheckDate = n.LoLicenseCheckDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        LoLicensePlace = n.LoLicensePlace,
        InsTrafficPolicyId = n.InsTrafficPolicyId,
        InsTrafficPolicyCompany = n.InsTrafficPolicyCompany,
        InsTrafficPolicyVaildateDate = n.InsTrafficPolicyVaildateDate,
        InsTrafficPolicyAmount = n.InsTrafficPolicyAmount,
        InsThirdPartyId = n.InsThirdPartyId,
        InsThirdPartyVaildateDate = n.InsThirdPartyVaildateDate?.ToString("yyyy-MM-dd HH:mm:ss"),
        InsThirdPartyAmount = n.InsThirdPartyAmount,
        InsThirdPartyLogisticsAmount = n.InsThirdPartyLogisticsAmount,
        InsThirdPartyLogisticsVaildateDate = n.InsThirdPartyLogisticsVaildateDate?.ToString("yyyy-MM-dd HH:mm:ss")
      }).ToList();
      return ExcelHelper.ExportExcel(typeof(Vehicle), datarows, ignoredColumns);
    }

    public void UpdateStatus(string platenumber, string status, string shiporderno, string user)
    {
      var item = this.Queryable().Where(x => x.PlateNumber == platenumber).First();
      item.ShipOrderNo = shiporderno;
      item.Status = status;
      this.Update(item);

    }

    public string GetDevId(string platenumber) {
      return this.Queryable().Where(x => x.PlateNumber == platenumber).FirstOrDefault()?.GPSDeviceId;
      }
  }
}



