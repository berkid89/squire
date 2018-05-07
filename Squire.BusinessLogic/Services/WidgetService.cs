using MongoDB.Bson;
using Squire.BusinessLogic.Models;
using Squire.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Services
{
    public class WidgetService : IWidgetService
    {
        private readonly IDataAccess da;

        public WidgetService(IDataAccess da)
        {
            this.da = da;
        }

        public WidgetSoftware Get(string id, string envName)
        {
            var original = da.Get(id);
            return new WidgetSoftware(original, envName);
        }
    }
}
