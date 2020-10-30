using System.Net;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Demo.FunctionApp.Config;
using Demo.FunctionApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo.FunctionApp.Functions
{
    [ApiExplorerSettings(GroupName = "Greet APIs")]
    public class GreetFunctions
    {
        private readonly ISecrets secrets;
        private readonly GreetingsConfig greetingsConfig;

        public GreetFunctions(IOptions<GreetingsConfig> greetingsConfig, ISecrets secrets)
        {
            this.secrets = secrets;
            this.greetingsConfig = greetingsConfig.Value;
        }

        [ProducesResponseType(typeof(ErrorResponse), (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [FunctionName("greet")]
        [QueryStringParameter("name", "The name to greet", DataType = typeof(string), Required = true)]
        public IActionResult Greet(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            return name != null
                ? (ActionResult) new OkObjectResult(
                    $"{greetingsConfig.GreetPrefix}, {name}! Secret - {secrets.MySecret}! {greetingsConfig.GreetSuffix}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
