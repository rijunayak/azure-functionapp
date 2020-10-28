using Demo.FunctionApp.Functions;
using Demo.FunctionApp.Tests.Helpers;
using Demo.FunctionApp.Tests.Helpers.Logger;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Demo.FunctionApp.Tests.Functions
{
    public class GreetFunctionsTest
    {
        [Test]
        public void should_greet_with_name_given()
        {
            var request = TestFactory.CreateHttpRequest("name", "John");
            var log = new ListLogger();

            var response = (OkObjectResult) GreetFunctions.Greet(request, log);

            Assert.That(log.Logs[0], Is.EqualTo("C# HTTP trigger function processed a request."));
            Assert.That(response.Value, Is.EqualTo("Hello, John!"));
        }
    }
}
