using System.Runtime.InteropServices.JavaScript;
using Hangfire;
using Hangfire.PostgreSql;
using JobTracker;
using JobTracker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Hangfire
builder.Services.AddHangfire(config => 
    config.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

builder.Services.AddLogging();

// Add worker
builder.Services.AddScoped<Worker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHangfireDashboard("/hangfire");

// Add Hangfire jobs
RecurringJob.AddOrUpdate<Worker>
("CheckTime",
    worker => worker.CheckTime(),
    Cron.Minutely
    );

RecurringJob.AddOrUpdate<Worker>(
    "CheckTimeDaily",
    worker => worker.CheckTimeDaily(),
    Cron.Daily()
    );

RecurringJob.AddOrUpdate<Worker>(
    "TypeSomething",
    worker => worker.TypeSomething("This is an minutely automated message!"),
    Cron.Minutely);

RecurringJob.AddOrUpdate<Worker>(
    "TimeIs12",
    worker => worker.TimeIs12(),
    "0 12 * * *");

BackgroundJob.Enqueue<Worker>(
    sayHello => sayHello.SayHello());

BackgroundJob.Enqueue<Worker>(
    worker=> worker.TypeSomething(
        "I typed this manually!"));
BackgroundJob.Enqueue<Worker>(
    worker => worker.Multiply(
            5, 10));
BackgroundJob.Enqueue<Worker>(worker => worker.ErrorTest());

app.Run();
