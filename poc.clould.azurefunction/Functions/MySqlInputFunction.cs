using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.MySql;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace poc.clould.azurefunction.Functions;

public sealed class MySqlInputFunction
{
    private readonly ILogger _logger;

    public MySqlInputFunction(ILoggerFactory loggerFactory) =>
        _logger = loggerFactory.CreateLogger<MySqlInputFunction>();

    [Function("all-customers")]
    public async Task<IActionResult> Run
    (
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequestData req,
        [MySqlInput("SELECT * FROM Customer", "connection-azure-function")] IEnumerable<dynamic> result
    )
    {
        _logger.LogInformation("C# HTTP trigger with MySQL Input Binding function processed a request.");

        return new OkObjectResult(result);
    }
}