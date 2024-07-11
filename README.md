<!-- @format -->

<!-- GETTING STARTED -->

## Getting Started

Cron expression

```text
                                       Allowed values    Allowed special characters   Comment

┌───────────── second (optional)       0-59              * , - /
│ ┌───────────── minute                0-59              * , - /
│ │ ┌───────────── hour                0-23              * , - /
│ │ │ ┌───────────── day of month      1-31              * , - / L W ?
│ │ │ │ ┌───────────── month           1-12 or JAN-DEC   * , - /
│ │ │ │ │ ┌───────────── day of week   0-6  or SUN-SAT   * , - / # L ?                Both 0 and 7 means SUN
│ │ │ │ │ │
* * * * * *
```

<!-- USAGE EXAMPLES -->

## Usage

### With Base

MyJob.cs

```CSHARP
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
```

Program.cs Local test with each 5 second

```csharp
 builder.Services.ApplyEz4CronJob<BasicCronJob>(op =>
 {
    op.CronExpression = "*/5 * * * * *";
    op.CronFormat = CronFormat.IncludeSeconds;
    op.TimeZoneInfo = TimeZoneInfo.Local;
 });
```

### With CronExpressionAttribute

```csharp
[CronExpression(cronExpression: "*/2 * * * * *", cronFormat: CronFormat.IncludeSeconds)]
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
        logger.LogWarning("Working BasicCronJobAuto" + " Start Time : " + DateTime.UtcNow);
        return Task.CompletedTask;
    }
}
```

Program.cs

```csharp
builder.Services.AutoApplyEz4CronJob();
```

### With k8s Cluster

```csharp
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
```

Program.cs

```csharp
builder.Services.AddEz4LeaderConfig(op =>
{
    op.Namespace = "default";
    op.Lock = "my-lock";
});

builder.Services.AutoApplyEz4CronJob();
```

## Example with local k8s & minikube

### Prerequisites

Run k8s on Docker Desktop.

Start minikube and run demo test

```sh
   minikube start
   helm_deploy.sh
```

[helm_ex]: /img/helm_ex.png
[kube_get_pod]: /img/kube_get_pod.png
[kube_get_lease]: /img/kube_get_lease.png
[kube_logs_lease]: /img/kube_logs_lease.png
[kube_logs_lease_another]: /img/kube_logs_lease_another.png

![Image description][helm_ex]

```sh
    kubectl -n ns-demo2024 get pod
```

![Image description][kube_get_pod]

```sh
    kubectl -n ns-demo2024 get lease
```

![Image description][kube_get_lease]

```sh
    kubectl -n ns-demo2024 logs replace_your_lease_pod
```

![Image description][kube_logs_lease]

![Image description][kube_logs_lease_another]
