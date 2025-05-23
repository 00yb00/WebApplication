using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeesDTO>> GetAllAsync();
        Task<EmployeesDTO?> GetByIdAsync(int id);
        Task AddAsync(EmployeesDTO dto);
        Task UpdateAsync(EmployeesDTO dto);
        Task DeleteAsync(int id);
    }
}
