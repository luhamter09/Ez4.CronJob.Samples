using Ez4.CronJob.Abstractions;

namespace Ez4.CronJob.Sample.Jobs;

public class BasicCronJob : Ez4CronJobBase
{
    private readonly ILogger<BasicCronJob> logger;

    public BasicCronJob(ILogger<BasicCronJob> logger, ICronConfiguration<BasicCronJob> cronConfiguration)
        : base(logger, cronConfiguration)
    {
        this.logger = logger;
        logger.LogInformation("BasicCronJob created");
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogWarning("Working BasicCronJob" + " Start Time : " + DateTime.UtcNow);
        return Task.CompletedTask;
    }
}
