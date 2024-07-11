using Cronos;
using Ez4.CronJob.Abstractions;

namespace Ez4.CronJob.Sample.Jobs;

/// <summary>
/// Test func each 2 second
/// </summary>
[CronExpression(cronExpression: "*/20 * * * * *", cronFormat: CronFormat.IncludeSeconds)]
public class BasicCronJobAuto : Ez4CronJobBase, ICronJobAutoConfig
{
    private readonly ILogger<BasicCronJobAuto> logger;

    public BasicCronJobAuto(ILogger<BasicCronJobAuto> logger, ICronConfiguration<BasicCronJobAuto> cronConfiguration)
        : base(logger, cronConfiguration)
    {
        this.logger = logger;
        logger.LogInformation("BasicCronJobAuto created {0} {1} {2}", cronConfiguration.CronExpression, cronConfiguration.TimeZoneInfo, cronConfiguration.CronFormat);
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogError("Working BasicCronJobAuto" + " Start Time : " + DateTime.UtcNow);
        return Task.CompletedTask;
    }
}