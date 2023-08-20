using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;
using SqlHelper2;
using WebApp.Models;

namespace WebApp.Extensions.Logging
{
  public class DbLoggerProvider : ILoggerProvider
  {
    private readonly Func<string, LogLevel, bool> filter;
    public DbLoggerProvider(Func<string, LogLevel, bool> filter) => this.filter = filter;
    public ILogger CreateLogger(string categoryName) => new DbLogger(categoryName, this.filter);
    public void Dispose() { }
  }

  public class DbLogger : ILogger
  {
    private readonly Func<string, LogLevel, bool> filter;
    private readonly string categoryName;
    public DbLogger(string categoryName, Func<string, LogLevel, bool> filter)
    {
      this.categoryName = categoryName;
      this.filter = filter;
    }
    
    public IDisposable BeginScope<TState>(TState state) => null;
    public bool IsEnabled(LogLevel logLevel) => ( this.filter == null || this.filter(this.categoryName, logLevel) );
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
      if (this.IsEnabled(logLevel))
      {
        
        if (exception != null)
        {
          var message = exception.GetBaseException()?.Message;
          var trace = exception.StackTrace;
          DatabaseFactory.CreateDatabase().ExecuteSPNonQuery("[dbo].[SP_InsertMessages]",
            new
            {
              Group = MessageGroup.System,
              ExtensionKey1 = "",
              Type = MessageType.Error,
              Content = message,
              Tags = "",
              Method = "",
              StackTrace = trace,
              ExtensionKey2 = "",
              User = Auth.CurrentUserName

            }
            );
        }
        else
        {
          var message = formatter(state, exception);
          DatabaseFactory.CreateDatabase().ExecuteSPNonQuery("[dbo].[SP_InsertMessages]",
                new
                {
                  Group = MessageGroup.System,
                  ExtensionKey1 = "",
                  Type = MessageType.Information,
                  Content = message,
                  Tags = "",
                  Method = "",
                  User = Auth.CurrentUserName

                }
                );
        }
                
      }
     
    }
  }
}