using Demo.FunctionApp.Config;
using Demo.FunctionApp.Functions;
using Demo.FunctionApp.Tests.Helpers;
using Demo.FunctionApp.Tests.Helpers.Logger;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Demo.FunctionApp.Tests.Functions
{
    [TestFixture]
    public class GreetFunctionsTest
    {
        private const string TestSecret = "Test Secret";
        private const string GreetPrefix = "Hello";
        private const string GreetSuffix = "Welcome";
        private IOptions<GreetingsConfig> greetingsConfigOptions;
        private Secrets secrets;

        [SetUp]
        public void SetUp()
        {
            var greetingsConfig = new GreetingsConfig
            {
                GreetPrefix = GreetPrefix,
                GreetSuffix = GreetSuffix
            };
            greetingsConfigOptions = A.Fake<IOptions<GreetingsConfig>>();
            A.CallTo(() => greetingsConfigOptions.Value).Returns(greetingsConfig);
            secrets = new Secrets
            {
                MySecret = TestSecret
            };
        }


        [Test]
        public void should_greet_with_name_given()
        {
            var request = TestFactory.CreateHttpRequest("name", "John");
            var log = new ListLogger();
            var greetFunctions = new GreetFunctions(greetingsConfigOptions, secrets);

            var response = (OkObjectResult) greetFunctions.Greet(request, log);

            Assert.That(log.Logs[0], Is.EqualTo("C# HTTP trigger function processed a request."));
            Assert.That(response.Value, Is.EqualTo($"{GreetPrefix}, John! Secret - {TestSecret}! {GreetSuffix}"));
        }
    }
}
