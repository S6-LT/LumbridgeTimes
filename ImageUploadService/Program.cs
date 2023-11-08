using ImageUploadService.Model;
using ImageUploadService.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ImageDbSettings>(
    builder.Configuration.GetSection(nameof(ImageDbSettings)));

builder.Services.AddSingleton<IImageDbSettings>(sp =>
    sp.GetRequiredService<IOptions<ImageDbSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("ImageDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IImageService, ImageService>();


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
