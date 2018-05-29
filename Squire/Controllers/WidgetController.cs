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
        private IWidgetService ws;

        public WidgetController(IWidgetService ws)
        {
            this.ws = ws;
        }

        [HttpGet]
        public IActionResult Show([FromQuery] string id, [FromQuery] string envName)
        {
            return Json(ws.Get(id, envName));
        }
    }
}
