using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Entity;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController: ControllerBase
    {
        public readonly IProAgilRepository _repo;

        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                var result = await _repo.GetAllEventoAsync(true);

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro - {e.Message}");
            }
        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId) {
            try
            {
                var result = await _repo.GetAllEventoAsyncById(EventoId, true);

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro - {e.Message}");
            }
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema) {
            try
            {
                var result = await _repo.GetAllEventoAsyncByTema(tema, true);

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro - {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model) {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) {
                    return Created($"/apoi/evento/{model.Id}", model);
                }
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro - {e.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, Evento model) {
            try
            {
                var evento = await _repo.GetAllEventoAsyncById(EventoId, false);
                if (evento == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync()) {
                    return Created($"/apoi/evento/{model.Id}", model);
                }
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro - {e.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId) {
            try
            {
                var evento = await _repo.GetAllEventoAsyncById(EventoId, false);
                if (evento == null) return NotFound();

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync()) {
                    return Ok();
                }
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro - {e.Message}");
            }

            return BadRequest();
        }
    }
}