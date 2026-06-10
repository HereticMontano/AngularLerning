using AngularApp1.Server.Service;
using AngularApp1.Server.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var mongoSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSetting>()!;
builder.Services.AddDbContext<GalleryDbContext>(options => options.UseMongoDB(mongoSettings.ConnectionString, mongoSettings.DatabaseName));

var storageSetting = builder.Configuration.GetSection("StorageSettings").Get<StorageSettings>()!;
builder.Services.AddSingleton(Options.Create(storageSetting));

var adminCredentials = builder.Configuration.GetSection("AdminCredentials").Get<AdminCredentials>()!;
builder.Services.AddSingleton(Options.Create(adminCredentials));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(adminCredentials.JwtSecret))
        };
    });

builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddSingleton<IProcessImagService, ProcessImagService>();


var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

if (!Directory.Exists(storageSetting.RootPictures))
{
    Directory.CreateDirectory(storageSetting.RootPictures);
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(storageSetting.RootPictures),
    RequestPath = storageSetting.RequestPath
});




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
