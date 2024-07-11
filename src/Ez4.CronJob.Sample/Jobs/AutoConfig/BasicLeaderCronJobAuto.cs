using Cronos;
using Ez4.CronJob.Abstractions;

namespace Ez4.CronJob.Sample.Jobs;

/// <summary>
/// Test func each 2 second
/// </summary>
[CronExpression(cronExpression: "*/20 * * * * *", cronFormat: CronFormat.IncludeSeconds)]
public class BasicLeaderCronJobAuto : Ez4CronJobLeader, ICronJobAutoConfig
{
    private readonly ILogger<BasicLeaderCronJobAuto> logger;

    public BasicLeaderCronJobAuto(ILogger<BasicLeaderCronJobAuto> logger, IEz4LeaderConfiguration Ez4CronJobLeaderOption, ICronConfiguration<BasicLeaderCronJobAuto> cronConfiguration)
        : base(logger, Ez4CronJobLeaderOption, cronConfiguration)
    {
        this.logger = logger;
        logger.LogInformation("BasicLeaderCronJobAuto created");
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogError("Working BasicLeaderCronJobAuto" + " Start Time : " + DateTime.UtcNow);
        return Task.CompletedTask;
    }
}