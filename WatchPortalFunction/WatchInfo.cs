using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace WatchPortalFunction
{
    public class WatchInfo
    {
        private readonly ILogger<WatchInfo> _logger;

        public WatchInfo(ILogger<WatchInfo> logger)
        {
             _logger = logger;
        }

        [Function("WatchInfo")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Retrieve the model id from the query string
            string model = req.Query["model"];

            // If the user specified a model id, find the details of the model of watch
            if (model != null)
            {
                // Use dummy data for this example
                dynamic watchinfo = new { Manufacturer = "abc", CaseType = "Solid", Bezel = "Titanium", Dial = "Roman", CaseFinish = "Silver", Jewels = 15 };

                return (ActionResult)new OkObjectResult($"Watch Details: {watchinfo.Manufacturer}, {watchinfo.CaseType}, {watchinfo.Bezel}, {watchinfo.Dial}, {watchinfo.CaseFinish}, {watchinfo.Jewels}");
            }
            return new BadRequestObjectResult("Please provide a watch model in the query string");
        }
    }
}
