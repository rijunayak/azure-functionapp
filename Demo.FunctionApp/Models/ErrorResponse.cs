using System.Collections.Generic;

namespace Demo.FunctionApp.Models
{
    public class ErrorResponse
    {
        public string Data { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
