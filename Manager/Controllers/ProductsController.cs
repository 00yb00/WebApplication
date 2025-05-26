using BLL.Services.Implementations;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace Manager.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly DaprClient _daprClient;

        public ProductsController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        [HttpGet("allProducts")]
        public async Task<ActionResult<List<ProductsDTO>>> GetAllProductsAsync()
        {
            try
            {
                var result = await _daprClient.InvokeMethodAsync<List<ProductsDTO>>(HttpMethod.Get, "accessor", "allProducts");

                if (result is null)
                {
                    return Ok(new List<ProductsDTO>());
                }
                return Ok(result);
            }
            catch (InvocationException ie) when (ie.InnerException is HttpRequestException { StatusCode: System.Net.HttpStatusCode.NotFound })
            {
                return Ok(new List<ProductsDTO>());
            }
            catch (Exception ex)
            {
                return Problem("Failed to get products");
            }
        }

    }
}
