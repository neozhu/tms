using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModel
{
  public class ShipOrderTrackViewModel
  {
    public int ID { get; set; }
    public string SHIPORDERKEY { get; set; }
    public string STATUS { get; set; }
    public string PLATENUMBER { get; set; }
    public string DRIVERNAME { get; set; }
    public string DRIVERPHONE { get; set; }
    public string CARRIERNAME { get; set; }
    public string ORIGINAL { get; set; }
    public string DESTINATION { get; set; }
    public DateTime SHIPORDERDATE { get; set; }
    public DateTime? DELIVERYDATE { get; set; }
    public DateTime? ACTUALSHIPDATE { get; set; }
    public DateTime? ACTUALDELIVERYDATE { get; set; }
    public decimal TOTALCASECNT { get; set; }
    public decimal? TOTALGROSSWGT { get; set; }
    public decimal LONGITUDE { get; set; }
    public decimal LATITUDE { get; set; }
    public string devIdno { get; set; }
    public string location { get; set; }
    public string Speed { get; set; }
    public string dayMileage { get; set; }
    public string mileage { get; set; }
    public string isstopState { get; set; }
    public ICollection<StatusHistory> StatusHistories { get; set; }
    
  }
}