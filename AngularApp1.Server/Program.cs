using AngularApp1.Server.Service;
using AngularApp1.Server.Settings;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var mongoSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSetting>()!;

//builder.Services.AddSingleton(mongoSettings);

builder.Services.AddDbContext<GalleryDbContext>(options =>
    options.UseMongoDB(mongoSettings.ConnectionString, mongoSettings.DatabaseName));

builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddSingleton<IProcessImagService, ProcessImagService>();


var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
