using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.MySql;
using Microsoft.Extensions.Logging;
using poc.cloud.azurefunction.Entities;
using System.Text.Json;

namespace poc.cloud.azurefunction.Functions;

public sealed class MySqlChangesFunction
{
    private readonly ILogger _logger;

    public MySqlChangesFunction(ILoggerFactory loggerFactory) =>
        _logger = loggerFactory.CreateLogger<MySqlChangesFunction>();

    [Function("MySQLChangesFunction")]
    public async Task RunAsync
    (
        [MySqlTrigger("Customer", "connection-azure-function")] IReadOnlyList<MySqlChange<Customer>> changes,
        FunctionContext context,
        CancellationToken ct
    )
    {
        _logger.LogInformation($"Table Customer changes: {JsonSerializer.Serialize(changes)}");

        foreach (var change in changes)
        {
            var customer = change.Item;
            var operationType = change.Operation;

            if (operationType == MySqlChangeOperation.Update)
            { 
                // .. do something here
            }

            _logger.LogInformation($"Operation: {operationType}");
            _logger.LogInformation($"Customer Id: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
        }
    }
}