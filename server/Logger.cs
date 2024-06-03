using System;

using Microsoft.Extensions.Logging;

// Server.Logger
// abstraction for create loggers. very basic. made for convinience
namespace Server.Logger 
{
    public class LoggerCreater
    {
        private ILoggerFactory logggerFactory;
        public LoggerCreater() 
        {
                logggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace);
                });
        }

        public ILogger CreateLogger(string name)
        {
            return logggerFactory.CreateLogger(name);
        }
    }

}