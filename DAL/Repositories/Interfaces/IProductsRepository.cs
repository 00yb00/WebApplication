using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IProductsRepository : IRepository<ProductsEntity>
    {
        Task AddProductAsync(ProductsEntity product);
        Task UpdateProductAsync(ProductsEntity product);
    }
}
