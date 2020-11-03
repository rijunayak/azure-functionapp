namespace Demo.FunctionApp.Greet
{
    public class GreetRepository : IGreetRepository
    {
        public string PersonalInfo(string name)
        {
            // Hardcoded for POC
            return "This is my personal info";
        }
    }
}
