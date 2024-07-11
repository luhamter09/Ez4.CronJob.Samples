
namespace Ez4.CronJob.Sample.Jobs;

public class BasicBackgroundWorker : BackgroundService
{
    private ILogger<BasicBackgroundWorker> logger;
    public BasicBackgroundWorker(ILogger<BasicBackgroundWorker> logger)
    {
        this.logger = logger;
        logger.LogInformation("BasicBackgroundWorker created");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("BasicBackgroundWorker Executed");
        while (true)
        {
            if (stoppingToken.IsCancellationRequested)
                stoppingToken.ThrowIfCancellationRequested();

            logger.LogInformation("BasicBackgroundWorker runing at {0}", DateTime.Now);
            await Task.Delay(5000);
        }
    }
}