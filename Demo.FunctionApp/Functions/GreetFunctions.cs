using System.Net;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Demo.FunctionApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Demo.FunctionApp.Functions
{
    [ApiExplorerSettings(GroupName = "Greet APIs")]
    public static class GreetFunctions
    {
        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [FunctionName("greet")]
        [QueryStringParameter("name", "The name to greet", DataType = typeof(string), Required = true)]
        public static IActionResult Greet(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            return name != null
                ? (ActionResult) new OkObjectResult($"Hello, {name}!")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
