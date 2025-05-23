using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BLL.Services;
using DAL.Mapper;
using DAL.Repositories;
using System.Diagnostics;


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


// Register IDbConnection for Dapper (replace with your actual connection string)
ConfigureApplicationServices.ConfigureServices(builder.Services);
ConfigureApplicationServices.ConfigureRepositories(builder.Services, configuration);
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
