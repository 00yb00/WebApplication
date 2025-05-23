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
    public class ProductsService: IProductsService
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllAsync()
        {
            try
            {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductsDTO>>(entities);
            }
            catch(Exception ex)
            {
                Console.WriteLine();
            }
            return null;    
        }

        public async Task<ProductsDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ProductsDTO>(entity);
        }

        public async Task AddAsync(ProductsDTO dto)
        {
            var entity = _mapper.Map<ProductsEntity>(dto);
            await _repository.AddAsync(entity);

        }

        public async Task UpdateAsync(ProductsDTO dto)
        {
            var entity = _mapper.Map<ProductsEntity>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task AddProductAsync(ProductsDTO dto)
        {
            var entity = _mapper.Map<ProductsEntity>(dto);
            await _repository.AddProductAsync(entity);
        }
    }
}
