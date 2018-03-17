using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Squire.Controllers
{
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
