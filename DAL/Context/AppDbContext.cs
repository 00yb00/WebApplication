using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace DAL.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<ProductsEntity> Products;
        public DbSet<OrdersEntity> Orders;
        public DbSet<CustomersEntity> Customers;
        public DbSet<EmployeesEntity> Employees;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and constraints here if needed
        }
    }
}
