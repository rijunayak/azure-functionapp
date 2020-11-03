using Demo.FunctionApp.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo.FunctionApp.Greet
{
    public class GreetService : IGreetService
    {
        private readonly IGreetRepository greetRepository;
        private readonly GreetingsConfig greetingsConfig;
        private readonly ISecrets secrets;
        private readonly ILogger<GreetService> log;

        public GreetService(IGreetRepository greetRepository, IOptions<GreetingsConfig> greetingsConfig,
            ISecrets secrets, ILogger<GreetService> log)
        {
            this.greetRepository = greetRepository;
            this.greetingsConfig = greetingsConfig.Value;
            this.secrets = secrets;
            this.log = log;
        }

        public string Greet(string name)
        {
            log.LogInformation($"Greeting {name}");
            log.LogTrace("Time pass log");
            log.LogDebug("Debug log");

            var personalInfo = greetRepository.PersonalInfo(name);
            var secretSection = greetingsConfig.Toggles.ShowSecret
                ? $"My secret is - {secrets.MySecret}\n"
                : string.Empty;

            return
                $"{greetingsConfig.Displays.GreetPrefix}, {name}!\n" +
                secretSection +
                $"Your Personal info - {personalInfo}\n" +
                greetingsConfig.Displays.GreetSuffix;
        }
    }
}
