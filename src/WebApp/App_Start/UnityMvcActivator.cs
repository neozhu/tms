using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.UnityMvcActivator), nameof(WebApp.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebApp.UnityMvcActivator), nameof(WebApp.UnityMvcActivator.Shutdown))]

namespace WebApp
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(MvcUnityConfig.Container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(MvcUnityConfig.Container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
             Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

    /// <summary>
    /// Disposes the Unity container when the application is shut down.
    /// </summary>
    public static void Shutdown() => MvcUnityConfig.Container.Dispose();
  }
}