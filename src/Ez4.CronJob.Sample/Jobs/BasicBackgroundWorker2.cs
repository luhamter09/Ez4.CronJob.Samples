
namespace Ez4.CronJob.Sample.Jobs;

public class BasicBackgroundWorker2 : BackgroundService
{
    private ILogger<BasicBackgroundWorker2> logger;
    public BasicBackgroundWorker2(ILogger<BasicBackgroundWorker2> logger)
    {
        this.logger = logger;
        logger.LogInformation("BasicBackgroundWorker2 created");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("BasicBackgroundWorker2 Executed");
        while (true)
        {
            if (stoppingToken.IsCancellationRequested)
                stoppingToken.ThrowIfCancellationRequested();

            logger.LogInformation("BasicBackgroundWorker2 runing at {0}", DateTime.Now);
            await Task.Delay(5000);
        }
    }
}