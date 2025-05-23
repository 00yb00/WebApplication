using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductsDTO>> GetAllAsync();
        Task<ProductsDTO?> GetByIdAsync(int id);
        Task AddAsync(ProductsDTO dto);
        Task AddProductAsync(ProductsDTO dto);
        Task UpdateAsync(ProductsDTO dto);
        Task DeleteAsync(int id);
    }
}
