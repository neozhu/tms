using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using AutoMapper;
using LazyCache;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using SqlHelper2;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;
using WebApp.Models;
using WebApp.Services;

namespace WebApp
{
  /// <summary>
  /// Specifies the Unity configuration for the main container.
  /// </summary>
  public static class WebApiUnityConfig
  {
    #region Unity Container
    private static Lazy<IUnityContainer> container =
      new Lazy<IUnityContainer>(() =>
      {
        var container = new UnityContainer();
        RegisterTypes(container);
        return container;
      });

    /// <summary>
    /// Configured Unity Container.
    /// </summary>
    public static IUnityContainer Container => container.Value;
    #endregion

    /// <summary>
    /// Registers the type mappings with the Unity container.
    /// </summary>
    /// <param name="container">The unity container to configure.</param>
    /// <remarks>
    /// There is no need to register concrete types such as controllers or
    /// API controllers (unless you want to change the defaults), as Unity
    /// allows resolving a concrete type even if it was not previously
    /// registered.
    /// </remarks>
    public static void RegisterTypes(IUnityContainer container)
    {
      // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
      // container.LoadConfiguration();

      // TODO: Register your types here
      //container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new HierarchicalLifetimeManager());
      //container.RegisterType<IDataContextAsync, StoreContext>(new HierarchicalLifetimeManager());

      //添加cache功能
      container.RegisterType<IAppCache, CachingService>(new HierarchicalLifetimeManager(), new InjectionConstructor(CachingService.DefaultCacheProvider));
      //注册Nlog功能
      container.AddNewExtension<Unity.NLog.NLogExtension>();
      container.RegisterInstance<IDatabaseAsync>(DatabaseFactory.CreateDatabase(), InstanceLifetime.Singleton);
      //注册automapper
      var config = new MapperConfiguration(cfg =>
      {
        //Create all maps here
        cfg.AddProfile(new AutoMapperProfile());
      });
      container.RegisterInstance(config.CreateMapper());
      //注册EF
      container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager());
      container.RegisterType<DbContext, StoreContext>(new PerRequestLifetimeManager());
      container.RegisterType<IRepositoryAsync<DataTableImportMapping>, Repository<DataTableImportMapping>>();
      container.RegisterType<IDataTableImportMappingService, DataTableImportMappingService>();

      //container.RegisterType<IRepositoryAsync<Order>, Repository<Order>>();
      //container.RegisterType<IOrderService, OrderService>();

      container.RegisterType<IRepositoryAsync<Company>, Repository<Company>>();
      container.RegisterType<ICompanyService, CompanyService>();



      container.RegisterType<IRepositoryAsync<BaseCode>, Repository<BaseCode>>();
      container.RegisterType<IBaseCodeService, BaseCodeService>();
      container.RegisterType<IRepositoryAsync<CodeItem>, Repository<CodeItem>>();



      container.RegisterType<IRepositoryAsync<MenuItem>, Repository<MenuItem>>();
      container.RegisterType<IMenuItemService, MenuItemService>();
      container.RegisterType<IRepositoryAsync<MenuItem>, Repository<MenuItem>>();

      container.RegisterType<IRepositoryAsync<RoleMenu>, Repository<RoleMenu>>();
      container.RegisterType<IRoleMenuService, RoleMenuService>();
      container.RegisterType<IRepositoryAsync<RoleMenu>, Repository<RoleMenu>>();



      container.RegisterType<IRepositoryAsync<DataTableImportMapping>, Repository<DataTableImportMapping>>();
      container.RegisterType<IDataTableImportMappingService, DataTableImportMappingService>();

      container.RegisterType<IRepositoryAsync<Notification>, Repository<Notification>>();
      container.RegisterType<INotificationService, NotificationService>();
      container.RegisterType<IRepositoryAsync<Message>, Repository<Message>>();
      container.RegisterType<IMessageService, MessageService>();


      container.RegisterType<IRepositoryAsync<CodeItem>, Repository<CodeItem>>();
      container.RegisterType<ICodeItemService, CodeItemService>();

      container.RegisterType<IRepositoryAsync<SUPPLIER>, Repository<SUPPLIER>>();
      container.RegisterType<ISUPPLIERService, SUPPLIERService>();
      container.RegisterType<IRepositoryAsync<ORDER>, Repository<ORDER>>();
      container.RegisterType<IORDERService, ORDERService>();
      container.RegisterType<IRepositoryAsync<ORDERDETAIL>, Repository<ORDERDETAIL>>();
      container.RegisterType<IORDERDETAILService, ORDERDETAILService>();
      container.RegisterType<IRepositoryAsync<Vehicle>, Repository<Vehicle>>();
      container.RegisterType<IVehicleService, VehicleService>();
      container.RegisterType<IRepositoryAsync<LocBase>, Repository<LocBase>>();
      container.RegisterType<ILocBaseService, LocBaseService>();

      container.RegisterType<IRepositoryAsync<FreightRule>, Repository<FreightRule>>();
      container.RegisterType<IFreightRuleService, FreightRuleService>();
      container.RegisterType<IRepositoryAsync<ServiceRule>, Repository<ServiceRule>>();
      container.RegisterType<IServiceRuleService, ServiceRuleService>();

      container.RegisterType<IRepositoryAsync<SHIPORDERDETAIL>, Repository<SHIPORDERDETAIL>>();
      container.RegisterType<ISHIPORDERDETAILService, SHIPORDERDETAILService>();
      container.RegisterType<IRepositoryAsync<SHIPORDER>, Repository<SHIPORDER>>();
      container.RegisterType<ISHIPORDERService, SHIPORDERService>();
      container.RegisterType<IRepositoryAsync<StatusHistory>, Repository<StatusHistory>>();
      container.RegisterType<IStatusHistoryService, StatusHistoryService>();
      container.RegisterType<IRepositoryAsync<Salesman>, Repository<Salesman>>();
      container.RegisterType<ISalesmanService, SalesmanService>();
      container.RegisterType<IRepositoryAsync<StandardCost>, Repository<StandardCost>>();
      container.RegisterType<IStandardCostService, StandardCostService>();
      container.RegisterType<IRepositoryAsync<Log>, Repository<Log>>();
      container.RegisterType<ILogService, LogService>();
      container.RegisterType<IRepositoryAsync<Document>, Repository<Document>>();
      container.RegisterType<IDocumentService, DocumentService>();
    }
  }
}