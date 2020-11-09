using System.Collections.Generic;

namespace Demo.FunctionApp.Errors
{
    public class ErrorResponse
    {
        public string Data { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
