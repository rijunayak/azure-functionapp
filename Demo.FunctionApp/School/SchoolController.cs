using System.Threading.Tasks;
using Demo.FunctionApp.EntityFrameworkContext;
using Demo.FunctionApp.School.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Demo.FunctionApp.School
{
    public class SchoolController
    {
        private readonly SchoolContext schoolContext;

        public SchoolController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        [FunctionName("CreateStudent")]
        public async Task<IActionResult> CreateStudent(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "students")]
            HttpRequest req, ILogger log)
        {
            await using (schoolContext)
            {
                var student = new Student
                {
                    Name = "Jane",
                    Age = 27,
                    Budget = 67.5m,
                    Gender = "Male"
                };

                await schoolContext.Students.AddAsync(student);
                await schoolContext.SaveChangesAsync();
            }

            return new OkResult();
        }
    }
}
