using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersDTO>> GetAllAsync();
        Task<OrdersDTO?> GetByIdAsync(int id);
        Task AddAsync(OrdersDTO dto);
        Task UpdateAsync(OrdersDTO dto);
        Task DeleteAsync(int id);
    }
}
