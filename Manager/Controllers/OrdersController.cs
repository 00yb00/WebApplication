using Dapr;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace Manager.Controllers
{
    public class OrdersController:ControllerBase
    {
        [Topic("pubsub", "orders")]
        [HttpPost("process-order")]
        public async Task<IActionResult> ProcessOrder([FromBody] OrdersDTO order)
        {
            Console.WriteLine($"📦 Processing Order: {order.OrderID}");

            var client = new Dapr.Client.DaprClientBuilder().Build();

            await client.InvokeBindingAsync("webhook", "create", new
            {
                Message = $"✅ Order {order.OrderID} with {order.CustomerID} processed"
            });

            return Ok();
        }
        public record Order(int Id, string Product);
    }
}
