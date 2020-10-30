using System;
using System.Linq;

namespace Demo.FunctionApp.Config
{
    public class Secrets : ISecrets
    {
        [EnvironmentVariable("MY_SECRET")] public string MySecret { get; set; }

        public void Initialize()
        {
            var properties = GetType().GetProperties();
            var configProperties = properties.Where(property =>
                Attribute.IsDefined(property, typeof(EnvironmentVariableAttribute)));

            foreach (var configProperty in configProperties)
            {
                var envVarKey =
                    ((EnvironmentVariableAttribute[]) configProperty.GetCustomAttributes(
                        typeof(EnvironmentVariableAttribute), false))[0].Value;

                var envVarValue = Environment.GetEnvironmentVariable(envVarKey);

                configProperty.SetValue(this, envVarValue);
            }
        }
    }
}
