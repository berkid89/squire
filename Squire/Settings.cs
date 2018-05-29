using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Squire.BusinessLogic.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squire
{
    public class Settings : ISettings
    {
        public LoggerSettings Logging { get; }

        public string ConnectionString { get; }

        public string Database { get; }

        public int PerformaceWarningMinimumInMS { get; }

        public Settings(IConfiguration config)
        {
            if (!string.IsNullOrEmpty(config["Logging:LogLevel"]))
            {
                Logging = new LoggerSettings()
                {
                    LogLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), config["Logging:LogLevel"]),
                };
            }

            PerformaceWarningMinimumInMS = config.GetValue<int>("PerformaceWarningMinimumInMS");

            ConnectionString = config["ConnectionString"];
            Database = config["Database"];
        }
    }
}
