using AutoMapper;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class CustomersService: ICustomersService
    {
        private readonly IRepository<CustomersEntity> _repository;
        private readonly IMapper _mapper;

        public CustomersService(IRepository<CustomersEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomersDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomersDTO>>(entities);
        }

        public async Task<CustomersDTO?> GetByIdAsync(string customerId)
        {
            var entity = await _repository.GetByIdAsync(customerId);
            return entity == null ? null : _mapper.Map<CustomersDTO>(entity);
        }

        public async Task AddAsync(CustomersDTO dto)
        {
            var entity = _mapper.Map<CustomersEntity>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(CustomersDTO dto)
        {
            var entity = _mapper.Map<CustomersEntity>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string customerId)
        {
            await _repository.DeleteAsync(customerId);
        }
    }
}
