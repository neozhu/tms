using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModel
{
  public class PoolsViewModel
  {
    public string Status { get; set; }
    public string[] PlateNumbers { get; set; }
  }

  public class VehiclesViewModel
  {
    public string ShipOrderNo { get; set; }
    public string ZCPH { get; set; }
    public string ZQSDMS { get; set; }
    public string ZMDDMS { get; set; }
    public decimal? lng { get; set; }
    public decimal? lat { get; set; }


  }
}