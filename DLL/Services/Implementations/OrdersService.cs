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
    public class OrdersService: IOrdersService
    {
        private readonly IRepository<OrdersEntity> _repository;
        private readonly IMapper _mapper;

        public OrdersService(IRepository<OrdersEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrdersDTO>>(entities);
        }

        public async Task<OrdersDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<OrdersDTO>(entity);
        }

        public async Task AddAsync(OrdersDTO dto)
        {
            var entity = _mapper.Map<OrdersEntity>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(OrdersDTO dto)
        {
            var entity = _mapper.Map<OrdersEntity>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
