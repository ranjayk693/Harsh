using Microsoft.AspNetCore.Mvc;
using Guide.Model;
using Guide.Data;
using Microsoft.EntityFrameworkCore;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Guide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            context = _context;
        }

        [HttpGet("guide")]
        public async Task<ActionResult<List<guide>>> Get()
        {
            var data=await _context.Guides.ToListAsync();
            return Ok(data);
        }

        [HttpPost("guide/registration")]
        public async Task<IActionResult> PostAsync([FromBody] guide value)
        {
            var data = await _context.Guides.AddAsync(value);
            return Ok("data is created sucess");
        }

        [HttpGet("registration")]
        public async Task<ActionResult<List<Registration>>> GetRegistration()
        {
            var data = await _context.Registrations.ToListAsync();
            return Ok(data);
        }

        [HttpPost("guide/registration")]
        public async Task<IActionResult> PostAsync([FromBody] Registration value)
        {
            var data = await _context.Registrations.AddAsync(value);
            return Ok("registration is created sucess");
        }



    }
}
