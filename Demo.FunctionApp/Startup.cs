using System;
using System.Reflection;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using Demo.FunctionApp;
using Demo.FunctionApp.Config;
using Demo.FunctionApp.Greet;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Demo.FunctionApp
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            InitSwaggerSpec(builder);

            InitConfig(builder);

            InitDependencies(builder);
        }

        private static void InitSwaggerSpec(IFunctionsHostBuilder functionsHostBuilder)
        {
            functionsHostBuilder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
            {
                opts.SpecVersion = OpenApiSpecVersion.OpenApi3_0;
                opts.PrependOperationWithRoutePrefix = true;
                opts.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Name = "v1",
                        Title = "Swagger document",
                        Description = "Swagger test document",
                        Version = "v2"
                    }
                };
                opts.Title = "Swagger Test";
            });
        }

        private static void InitConfig(IFunctionsHostBuilder builder)
        {
            var appEnv = Environment.GetEnvironmentVariable("APP_ENV");

            var isLocal = appEnv == null || appEnv.Equals("local", StringComparison.OrdinalIgnoreCase);

            var appDirectory = isLocal
                ? Environment.CurrentDirectory
                : $"{Environment.GetEnvironmentVariable("SITE_FOLDER")}/site/wwwroot";

            var config = new ConfigurationBuilder()
                .SetBasePath($"{appDirectory}/ConfigFiles")
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{appEnv}.json", true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.Configure<GreetingsConfig>(config.GetSection(nameof(GreetingsConfig)));

            builder.Services.AddOptions();
        }

        private static void InitDependencies(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ISecrets>(s =>
            {
                var secrets = new Secrets();
                secrets.Initialize();
                return secrets;
            });

            builder.Services.AddSingleton<IGreetService, GreetService>();
            builder.Services.AddSingleton<IGreetRepository, GreetRepository>();
        }
    }
}
