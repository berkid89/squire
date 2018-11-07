using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Squire.DataAccess;
using Squire.Common;
using System.Text;

namespace Squire.Functions
{
    public static class RequestWidget
    {
        [FunctionName("RequestWidget")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
        {
            //var repo = await InitDb.GetRepoAsync();

            //var product = await repo.GetProductInfo(req.Query["productId"]);

            //if (product == null)
            //    return new NotFoundResult();

            return new JsonResult(new
            {
                //productId = product.Id,
                widget = getEmbeddableCode(Guid.NewGuid().ToString())
            });
        }

        private static string getEmbeddableCode(string productId)
        {
            var sb = new StringBuilder();

            sb.Append($"<object width='92' height='32' data='https://www.linkedin.com/feed/?trk=nav_logo&productId={productId}'");

            return sb.ToString();
        }
    }
}
