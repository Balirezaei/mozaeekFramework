using System;
using System.Text;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace LogManagement
{
    public class SeiLogManager : ILogger
    {
        public SeiLogManager()
        {
            Log.Logger = (Serilog.ILogger)new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log-.txt", LogEventLevel.Verbose, "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", (IFormatProvider)null, new long?(1073741824L), (LoggingLevelSwitch)null, false, false, new TimeSpan?(), RollingInterval.Day, false, new int?(31), (Encoding)null).MinimumLevel.Information().CreateLogger();
        }

        public void DoLog(string message)
        {
            Log.Information(message);
        }

        public void DoLogInsideApp(string message)
        {
            Log.Information("InsideApp:" + message);
        }
    }
}