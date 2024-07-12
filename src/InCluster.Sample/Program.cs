using Ez4.CronJob.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEz4LeaderConfig(op =>
{
    op.Lock = "my-lock";
});

builder.Services.AutoApplyEz4CronJob();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
