using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using poc.cloud.azurefunction.Entities;

namespace poc.cloud.azurefunction.Functions;

public sealed class TimerFunction
{
    private readonly ILogger _logger;

    public TimerFunction(ILoggerFactory loggerFactory) =>
        _logger = loggerFactory.CreateLogger<TimerFunction>();

    [Function("TimerProcessing")]
    public async Task RunAsync([TimerTrigger("0/10 * * * * *")] TimerInfo myTimer, CancellationToken ct)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        string connectionString = Environment.GetEnvironmentVariable("connection-azure-function").ToString();

        IList<Customer> customers = await GetCustomersFromDatabaseAsync(connectionString, ct);

        foreach (var customer in customers)
        {
            _logger.LogInformation($"Customer Id: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
        }
    }

    private async Task<IList<Customer>> GetCustomersFromDatabaseAsync(string connectionString, CancellationToken ct)
    {
        IList<Customer> customers = new List<Customer>();

        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync(ct);
                string query = "SELECT Id, Name, Email FROM Customer";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = await cmd.ExecuteReaderAsync(ct))
                    {
                        while (await reader.ReadAsync(ct))
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while accessing the database: {ex.Message}");
        }

        return customers;
    }
}