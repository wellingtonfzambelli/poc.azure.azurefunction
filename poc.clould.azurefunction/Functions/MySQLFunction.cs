using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.MySql;
using Microsoft.Extensions.Logging;
using poc.clould.azurefunction.Entities;
using System.Text.Json;

namespace poc.clould.azurefunction.Functions;

public sealed class MySQLFunction
{
    private readonly ILogger _logger;

    public MySQLFunction(ILoggerFactory loggerFactory) =>
        _logger = loggerFactory.CreateLogger<MySQLFunction>();

    [Function("MySQLFunction")]
    public void Run
    (
        [MySqlTrigger("Customer", "connection-azure-function")] IReadOnlyList<MySqlChange<Customer>> changes,
        FunctionContext context
    )
    {
        _logger.LogInformation($"Table Customer changes: {JsonSerializer.Serialize(changes)}");

        foreach (var change in changes)
        {
            var customer = change.Item;
            var operationType = change.Operation;

            if (operationType == MySqlChangeOperation.Update)
            { }            

            _logger.LogInformation($"Operation: {operationType}");
            _logger.LogInformation($"Customer Id: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
        }
    }
}