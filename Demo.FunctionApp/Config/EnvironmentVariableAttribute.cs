using System;

namespace Demo.FunctionApp.Config
{
    public class EnvironmentVariableAttribute : Attribute
    {
        public string Value { get; }

        public EnvironmentVariableAttribute(string value)
        {
            Value = value;
        }
    }
}
