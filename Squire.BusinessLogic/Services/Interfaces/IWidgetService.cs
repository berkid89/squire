using Squire.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Services.Interfaces
{
    public interface IWidgetService
    {
        WidgetSoftware Get(string id, string envName);
    }
}
