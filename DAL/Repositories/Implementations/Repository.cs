using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DAL.Context;

namespace DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbConnection _connection;
        protected readonly string _tableName;

        public Repository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _tableName = typeof(T).Name.Replace("Entity", ""); // e.g., ProductsEntity -> Products
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            return await _connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {_tableName}";
            return await _connection.QueryAsync<T>(sql);
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException("Implement insert logic for T or use specialized repository");
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException("Implement update logic for T or use specialized repository");
        }

        public async Task DeleteAsync(object id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
