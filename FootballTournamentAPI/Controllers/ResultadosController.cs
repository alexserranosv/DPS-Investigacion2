using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FootballTournamentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadosController : ControllerBase
    {
        private readonly IResultadosRepository _resultadosRepository;

        public ResultadosController(IResultadosRepository resultadosRepository)
        {
            _resultadosRepository = resultadosRepository;
        }

        // GET: api/Resultados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resultado>>> GetAllResultados()
        {
            var resultados = await _resultadosRepository.GetAllResultadosAsync();
            return Ok(resultados);
        }

        // GET: api/Resultados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resultado>> GetResultadoById(int id)
        {
            var resultado = await _resultadosRepository.GetResultadoByIdAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET: api/Resultados/Partido/5
        [HttpGet("Partido/{partidoId}")]
        public async Task<ActionResult<Resultado>> GetResultadoByPartidoId(int partidoId)
        {
            var resultado = await _resultadosRepository.GetResultadoByPartidoIdAsync(partidoId);
            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // POST: api/Resultados
        [HttpPost]
        public async Task<ActionResult<Resultado>> CreateResultado(Resultado resultado)
        {
            var createdResultado = await _resultadosRepository.CreateResultadoAsync(resultado);
            return CreatedAtAction(nameof(GetResultadoById), new { id = createdResultado.Id }, createdResultado);
        }

        // PUT: api/Resultados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResultado(int id, Resultado resultado)
        {
            if (id != resultado.Id)
            {
                return BadRequest();
            }

            var resultadoExists = await _resultadosRepository.ResultadoExistsAsync(id);
            if (!resultadoExists)
            {
                return NotFound();
            }

            await _resultadosRepository.UpdateResultadoAsync(resultado);
            return NoContent();
        }

        // DELETE: api/Resultados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultado(int id)
        {
            var resultadoExists = await _resultadosRepository.ResultadoExistsAsync(id);
            if (!resultadoExists)
            {
                return NotFound();
            }

            await _resultadosRepository.DeleteResultadoAsync(id);
            return NoContent();
        }
    }
}
