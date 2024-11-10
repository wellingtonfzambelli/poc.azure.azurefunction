using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace poc.clould.azurefunction.Functions;

public sealed class TimerFunction
{
    private readonly ILogger _logger;

    public TimerFunction(ILoggerFactory loggerFactory) =>
        _logger = loggerFactory.CreateLogger<TimerFunction>();

    [Function("TimerProcessing")]
    public void Run([TimerTrigger("0/10 * * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        if (myTimer.ScheduleStatus is not null)
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
    }
}