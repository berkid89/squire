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

        public Settings(IConfiguration config)
        {
            if (!string.IsNullOrEmpty(config["Logging:LogLevel"]))
            {
                Logging = new LoggerSettings()
                {
                    LogLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), config["Logging:LogLevel"]),
                };
            }

            ConnectionString = config["ConnectionString"];
            Database = config["Database"];
        }
    }
}
