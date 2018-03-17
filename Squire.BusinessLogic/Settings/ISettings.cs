using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Settings
{
    public interface ISettings
    {
        string ConnectionString { get; }

        string Database { get; }

        LoggerSettings Logging { get; }
    }
}
