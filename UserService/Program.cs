using UserService.Model;
using UserService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");

builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(connectionString));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("HealthCheck", () =>
{
    return "Health is fine.";
});

app.MapPost("/user/add", ([FromServices] IDataRepository db, User user) =>
{
    return db.AddUser(user);
});

app.MapGet("/user/{id}", ([FromServices] IDataRepository db, int id) =>
{
    return db.GetById(id);
});

app.MapGet("/user/getall", ([FromServices] IDataRepository db) =>
{
    return db.GetAll();
});

app.MapGet("/user/delete", ([FromServices] IDataRepository db, int id) =>
{
    return db.DeleteById(id);
});


app.Run();
