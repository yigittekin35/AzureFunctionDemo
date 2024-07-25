using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo
{
    public class Functions
    {
        private readonly ILogger _logger;

        public Functions(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Functions>();
        }

        [Function("HttpFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "walktrough")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse();
            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            //response.WriteString("Welcome to Azure Functions!");

            await response.WriteAsJsonAsync(new
            {
                Name = "Azure Function",
                CurrentTime = DateTime.UtcNow
            });

            return response;
        }
    }
}
