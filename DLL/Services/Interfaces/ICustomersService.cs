﻿using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomersDTO>> GetAllAsync();
        Task<CustomersDTO?> GetByIdAsync(string customerId);
        Task AddAsync(CustomersDTO dto);
        Task UpdateAsync(CustomersDTO dto);
        Task DeleteAsync(string customerId);
    }
}
