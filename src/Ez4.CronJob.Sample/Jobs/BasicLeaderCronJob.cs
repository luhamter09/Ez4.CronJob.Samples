using Ez4.CronJob.Abstractions;

namespace Ez4.CronJob.Sample.Jobs;

public class BasicLeaderCronJob : Ez4CronJobLeader
{
    private readonly ILogger<BasicLeaderCronJob> logger;

    public BasicLeaderCronJob(ILogger<BasicLeaderCronJob> logger, IEz4LeaderConfiguration Ez4CronJobLeaderOption, ICronConfiguration<BasicLeaderCronJob> cronConfiguration)
        : base(logger, Ez4CronJobLeaderOption, cronConfiguration)
    {
        this.logger = logger;
        logger.LogInformation("BasicLeaderCronJob created");
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogError("Working BasicLeaderCronJob" + " Start Time : " + DateTime.UtcNow);
        return Task.CompletedTask;
    }
}
