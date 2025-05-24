using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using BLL.Services.Interfaces;
using Models.Dtos;
namespace WebApplication.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        [HttpGet("set")]
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("TestKey", "SessionValue");
            return Ok("Session set!");
        }

        [HttpGet("get")]
        public IActionResult GetSession()
        {
            var value = HttpContext.Session.GetString("TestKey");
            return Ok($"Session value: {value}");
        }
    }
}
