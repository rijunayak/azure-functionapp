using System.Net;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Demo.FunctionApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Demo.FunctionApp.Greet
{
    [ApiExplorerSettings(GroupName = "Greet APIs")]
    public class GreetFunctions
    {
        private readonly IGreetService greetService;
        private readonly ILogger<GreetFunctions> log;

        public GreetFunctions(IGreetService greetService, ILogger<GreetFunctions> log)
        {
            this.greetService = greetService;
            this.log = log;
        }

        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [FunctionName("greet")]
        [QueryStringParameter("name", "The name to greet", DataType = typeof(string), Required = true)]
        public IActionResult Greet(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            return name != null
                ? (ActionResult) new OkObjectResult(greetService.Greet(name))
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
