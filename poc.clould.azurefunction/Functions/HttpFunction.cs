
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace poc.clould.azurefunction.Functions;

public sealed class HttpFunction
{
    private readonly ILogger<HttpFunction> _logger;

    public HttpFunction(ILogger<HttpFunction> logger) =>
        _logger = logger;

    [Function("extract-name-from-querystring")]
    public async Task<IActionResult> Run
    (
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req
    )
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        string name = req.Query["name"];

        if (string.IsNullOrEmpty(name))
            return new BadRequestObjectResult("Please provide a name in the query string with ?name=yourname");

        string responseMessage = $"Welcome to Azure Functions, {name}!";
        return new OkObjectResult(responseMessage);
    }
}