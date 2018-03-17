using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Squire.BusinessLogic.Models;
using Squire.BusinessLogic.Services.Interfaces;

namespace Squire.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        public SampleDataController(IDataAccess da)
        {
            var sw = new Software()
            {
                Name = "test sw",
                Description = "this is the desc.",
            };

            var devEnv = new Env()
            {
                Name = "DEV",
            };

            devEnv.ReleaseNotes.Add(new ReleaseNote()
            {
                Summary = "this is the summary!",
                VersionNumber = "1.5.678",
                Bugfixes = new List<Bugfix>() { new Bugfix() { Description = "Timeout in task list was fixed" } }
            });

            var prodEnv = new Env()
            {
                Name = "PROD"
            };

            sw.Envs.Add(devEnv);
            sw.Envs.Add(prodEnv);

            da.Insert(sw);
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
