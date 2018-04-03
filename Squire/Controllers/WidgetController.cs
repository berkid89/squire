using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Squire.BusinessLogic.Services.Interfaces;

namespace Squire.Controllers
{
    public class WidgetController : Controller
    {
        private IDataAccess da;

        public WidgetController(IDataAccess da)
        {
            this.da = da;
        }

        public IActionResult Show([FromQuery] string id)
        {
            return Json(da.Get(id));
        }
    }
}
