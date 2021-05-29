using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                var result = await _context.Eventos.ToListAsync();

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"blabla - {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"blabla - {e.Message}");
            }
             
        }

        [HttpPost]
        public void Post([FromBody] string value) {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {

        }

        [HttpDelete("{id}")]
        public void Delete(int id) {

        }
    }
}