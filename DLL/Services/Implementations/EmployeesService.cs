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
    public class EmployeesService: IEmployeesService
    {
        private readonly IRepository<EmployeesEntity> _repository;
        private readonly IMapper _mapper;

        public EmployeesService(IRepository<EmployeesEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeesDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeesDTO>>(entities);
        }

        public async Task<EmployeesDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<EmployeesDTO>(entity);
        }

        public async Task AddAsync(EmployeesDTO dto)
        {
            var entity = _mapper.Map<EmployeesEntity>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(EmployeesDTO dto)
        {
            var entity = _mapper.Map<EmployeesEntity>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
