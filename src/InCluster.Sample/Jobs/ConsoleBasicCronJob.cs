using Cronos;
using Ez4.CronJob.Abstractions;

namespace InCluster.Sample.Jobs;

[CronExpression(cronExpression: "*/5 * * * * *", cronFormat: CronFormat.IncludeSeconds)]
public class ConsoleBasicCronJob : Ez4CronJobLeader, ICronJobAutoConfig
{
    private ILogger<ConsoleBasicCronJob> _logger;
    public ConsoleBasicCronJob(ILogger<ConsoleBasicCronJob> logger, IEz4LeaderConfiguration Ez4CronJobLeaderOption, ICronConfiguration<ConsoleBasicCronJob> cronConfig) : base(logger, Ez4CronJobLeaderOption, cronConfig)
    {
        _logger = logger;
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogWarning("ok at {0}", DateTime.Now);
        return Task.CompletedTask;
    }
}
