using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApp.Models;
using WebApp.Models.ViewModel;

namespace WebApp
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<ORDER, ORDERDETAIL>();
      CreateMap<ORDERDETAIL,ORDER>();
      CreateMap<ORDERDETAIL, SHIPORDERDETAIL>();
      CreateMap<SHIPORDERDETAIL, ORDERDETAIL>();
      CreateMap<ORDER, SHIPORDER>();
      CreateMap<SHIPORDER, ORDER>();
      CreateMap<SHIPORDER, ShipOrderTrackViewModel>();

    }
  }
   
}