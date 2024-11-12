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
    public void Run([TimerTrigger("0/10 * * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        
        string connectionString = Environment.GetEnvironmentVariable("connection-azure-function").ToString();

        IList<Customer> customers = GetCustomersFromDatabase(connectionString);

        foreach (var customer in customers)
        {
            _logger.LogInformation($"Customer Id: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
        }
    }

    private List<Customer> GetCustomersFromDatabase(string connectionString)
    {
        List<Customer> customers = new List<Customer>();

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, Email FROM Customer";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Email = reader.GetString("Email")
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