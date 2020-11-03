using Demo.FunctionApp.Greet;
using Demo.FunctionApp.Tests.Helpers;
using Demo.FunctionApp.Tests.Helpers.Logger;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Demo.FunctionApp.Tests.Greet
{
    [TestFixture]
    public class GreetFunctionsTest
    {
        private const string TestName = "John";
        private IGreetService greetService;
        private ListLogger<GreetFunctions> log;

        [SetUp]
        public void SetUp()
        {
            greetService = A.Fake<IGreetService>();
            log = new ListLogger<GreetFunctions>();
        }

        [Test]
        public void should_greet_with_name_given()
        {
            var httpRequest = TestFactory.CreateHttpRequest("name", TestName);
            A.CallTo(() => greetService.Greet(TestName)).Returns("Welcome!");
            var greetFunctions = new GreetFunctions(greetService, log);

            var response = (OkObjectResult) greetFunctions.Greet(httpRequest);

            Assert.That(log.Logs[0], Is.EqualTo("C# HTTP trigger function processed a request."));
            Assert.That(response.Value, Is.EqualTo("Welcome!"));
        }
    }
}
