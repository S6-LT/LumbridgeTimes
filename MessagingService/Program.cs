using MessagingService.Model;
using MessagingService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddCors();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddDbContext<MessagingDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
var serviceName = "MessagingService";
builder.Services.AddOpenTelemetry()
    .ConfigureResource(builder => builder.AddService(serviceName))
    .WithTracing(builder => builder.AddConsoleExporter()
    .AddSource(serviceName)
    .SetResourceBuilder(
        ResourceBuilder.CreateDefault().AddService(serviceName, serviceVersion: "1.0.0"))
    .AddAspNetCoreInstrumentation()
    .AddSqlClientInstrumentation()
    .AddJaegerExporter()
    .AddHttpClientInstrumentation()); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapGet("HealthCheck", () =>
{
    return "Health is fine.";
});

app.MapPost("/message/add", ([FromServices] IDataRepository db, Message message) =>
{
    return db.AddMessage(message);
});

app.MapGet("/message/{id}", ([FromServices] IDataRepository db, int id) =>
{
    return db.GetById(id);
});

app.MapGet("/message/getall", ([FromServices] IDataRepository db) =>
{
    return db.GetAll();
});

app.MapGet("/message/delete", ([FromServices] IDataRepository db, int id) =>
{
    return db.DeleteById(id);
});

app.Run();
