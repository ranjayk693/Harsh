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
            _context = context;
        }

        [HttpGet("guide")]
        public async Task<ActionResult<List<guide>>> Get()
        {
            var data = await _context.guides.ToListAsync();
            return Ok(data);
        }

        [HttpPost("guide/registration")]
        public async Task<IActionResult> PostAsync([FromBody] guide value)
        {
            await _context.guides.AddAsync(value);
            await _context.SaveChangesAsync();
            return Ok("data is created sucess");
        }

        [HttpGet("user")]
        public async Task<ActionResult<List<Registration>>> GetUser()
        {
            var data = await _context.Registrations.ToListAsync();
            return Ok(data);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] Registration value)
        {
            await _context.Registrations.AddAsync(value);
            await _context.SaveChangesAsync();
            return Ok("user is registration");
        }



    }
}
