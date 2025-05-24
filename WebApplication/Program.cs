using BLL.Services;
using DAL.Mapper;
using Microsoft.Extensions.Caching.StackExchangeRedis;


using AspWebApp = Microsoft.AspNetCore.Builder.WebApplication;

var builder = AspWebApp.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

// Register services
ConfigureApplicationServices.ConfigureServices(builder.Services);
ConfigureApplicationServices.ConfigureRepositories(builder.Services, configuration);
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// Add Redis for sessions
builder.Services.AddDistributedRedisCache(options =>
{
    options.Configuration = "redis:6379"; // Docker service name or localhost
});
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".MyApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseSession(); // <-- important: must be before UseAuthorization
app.UseAuthorization();
app.MapControllers();

app.Run();
