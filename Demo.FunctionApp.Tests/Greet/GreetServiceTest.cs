using Demo.FunctionApp.Config;
using Demo.FunctionApp.Greet;
using Demo.FunctionApp.Tests.Helpers.Logger;
using FakeItEasy;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Demo.FunctionApp.Tests.Greet
{
    [TestFixture]
    public class GreetServiceTest
    {
        private const string TestName = "John";
        private GreetService greetService;
        private IGreetRepository greetRepository;
        private ListLogger<GreetService> log;
        private IOptions<GreetingsConfig> greetingsConfigOptions;
        private Secrets secrets;

        [SetUp]
        public void SetUp()
        {
            var greetingsConfig = new GreetingsConfig
            {
                Displays = new Displays
                {
                    GreetPrefix = "Hello",
                    GreetSuffix = "Bye"
                },
                Toggles = new Toggles
                {
                    ShowSecret = true
                }
            };
            greetingsConfigOptions = A.Fake<IOptions<GreetingsConfig>>();
            secrets = new Secrets
            {
                MySecret = "My Secret"
            };
            A.CallTo(() => greetingsConfigOptions.Value).Returns(greetingsConfig);
            greetRepository = A.Fake<IGreetRepository>();
            A.CallTo(() => greetRepository.PersonalInfo(TestName)).Returns("Personal Info");
            log = new ListLogger<GreetService>();
            greetService = new GreetService(greetRepository, greetingsConfigOptions, secrets, log);
        }

        [Test]
        public void should_greet_with_correct_parameters()
        {
            var actualGreeting = greetService.Greet(TestName);

            const string expectedGreeting =
                "Hello, John!\nMy secret is - My Secret\nYour Personal info - Personal Info\nBye";

            Assert.That(actualGreeting, Is.EqualTo(expectedGreeting));
        }
    }
}
