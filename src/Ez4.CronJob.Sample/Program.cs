using Cronos;
using Ez4.CronJob.Core;
using Ez4.CronJob.Sample.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//Jobs
builder.Services.ApplyEz4CronJob<BasicCronJob>(op =>
{
    op.CronExpression = "*/10 * * * * *";
    op.CronFormat = CronFormat.IncludeSeconds;
    op.TimeZoneInfo = TimeZoneInfo.Local;
});

//builder.Services.AddEz4LeaderConfig(op =>
//{
//    op.Namespace = "default";
//    op.Lock = "my-lock";

//    op.OnError += (Exception ex) =>
//    {
//        Console.WriteLine(ex.Message);
//    };
//});

//kubuilder.Services.AddHostedService<BasicBackgroundWorker>();
//builder.Services.ApplyEz4CronJob<BasicLeaderCronJob>(op =>
//{
//    op.CronExpression = "*/5 * * * * *";
//    op.CronFormat = CronFormat.IncludeSeconds;
//    op.TimeZoneInfo = TimeZoneInfo.Local;
//});
//builder.Services.AddHostedService<BasicBackgroundWorker2>();

//builder.Services.AutoApplyEz4CronJob();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();