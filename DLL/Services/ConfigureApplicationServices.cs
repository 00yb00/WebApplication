using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AutoMapper.Configuration;
using DAL.Context;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace BLL.Services
{
    public static class ConfigureApplicationServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IMessageBusService, RabbitMessageBusService>();
            services.AddScoped<RabbitMqConsumerService>();
            //services.AddScoped<DockerService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<OrdersRepository, OrdersRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppDbContext>(sp =>
            new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
