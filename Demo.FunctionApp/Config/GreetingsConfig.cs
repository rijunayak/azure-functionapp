// ReSharper disable ClassNeverInstantiated.Global - Warning disabled for config

namespace Demo.FunctionApp.Config
{
    public class GreetingsConfig
    {
        public Displays Displays { get; set; }
        public Toggles Toggles { get; set; }
    }

    public class Displays
    {
        public string GreetPrefix { get; set; }

        public string GreetSuffix { get; set; }
    }

    public class Toggles
    {
        public bool ShowSecret { get; set; }
    }
}
