using DAL.Context;
using DAL.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class ProductsRepository : Repository<ProductsEntity>, IProductsRepository
    {
        private readonly IDbConnection _connection;

        public ProductsRepository(IDbConnection connection) : base(connection) 
        {
            _connection = connection;
        }
        public async Task AddProductAsync(ProductsEntity product)
        {
            try
            {
            var sql = @"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, 
                      UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                    VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, 
                      @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
            await _connection.ExecuteAsync(sql, product);
            }
            catch(Exception ex)
            {
                Console.WriteLine();
            }

        }

        public async Task UpdateProductAsync(ProductsEntity product)
        {
            var sql = @"UPDATE Products SET
                      ProductName = @ProductName,
                      SupplierID = @SupplierID,
                      CategoryID = @CategoryID,
                      QuantityPerUnit = @QuantityPerUnit,
                      UnitPrice = @UnitPrice,
                      UnitsInStock = @UnitsInStock,
                      UnitsOnOrder = @UnitsOnOrder,
                      ReorderLevel = @ReorderLevel,
                      Discontinued = @Discontinued
                    WHERE ProductID = @ProductID";
            await _connection.ExecuteAsync(sql, product);
        }
    }
}
