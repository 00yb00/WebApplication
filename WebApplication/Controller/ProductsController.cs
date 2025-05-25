using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BLL.Services.Interfaces;
using Models.Dtos;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductsService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductsDTO dto)
    {
        await _productService.AddProductAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.ProductID }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductsDTO dto)
    {
        if (id != dto.ProductID) return BadRequest();
        await _productService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);
        return NoContent();
    }
}
