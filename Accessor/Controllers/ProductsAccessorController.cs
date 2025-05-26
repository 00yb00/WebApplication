using AutoMapper;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace Accessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsAccessorController : ControllerBase
    {
        private readonly IProductsService _productService;
        private readonly IMapper _mapper;

        public ProductsAccessorController(IProductsService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("allProducts")]
        public async Task<ActionResult<List<ProductsDTO>>> GetAllProductsAsync()
        {
            try
            {
                var result = await _productService.GetAllAsync();

                if (result is null)
                {
                    return NotFound("products not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
