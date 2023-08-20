using System;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
//[assembly: OwinStartup(typeof(WebApp.Startup))]
namespace WebApp
{
  public partial class Startup
  {
    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    public void ConfigureHangfire(IAppBuilder app)
    {
      GlobalConfiguration.Configuration
         .UseSimpleAssemblyNameTypeSerializer()
         .UseRecommendedSerializerSettings()
         .UseSqlServerStorage(
              "DefaultConnection",
              new SqlServerStorageOptions
              {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                UsePageLocksOnDequeue = true,
                DisableGlobalLocks = true
              });



      app.UseHangfireDashboard();
      app.UseHangfireServer();
      //每10分钟执行一个方法
      RecurringJob.AddOrUpdate(() => this.ExecuteProcess(), Cron.Minutely);


      //Fire - and - forget jobs are executed only once and almost immediately after creation.
      var jobId1 = BackgroundJob.Enqueue(
              () => Console.WriteLine("Fire-and-forget!"));


      //Delayed jobs are executed only once too, but not immediately, after a certain time interval.
      var jobId2 = BackgroundJob.Schedule(
              () => Console.WriteLine("Delayed!"),
          TimeSpan.FromDays(7));
      //Recurring jobs fire many times on the specified CRON schedule.
      RecurringJob.AddOrUpdate(
              () => Console.WriteLine("Recurring!"),
          Cron.Daily);
      //Continuations are executed when its parent job has been finished.
      BackgroundJob.ContinueJobWith(
          jobId2,
          () => Console.WriteLine("Continuation!"));
    }

    public void ExecuteProcess() => Console.WriteLine("{ DateTime.Now }:do something......");
  }
}