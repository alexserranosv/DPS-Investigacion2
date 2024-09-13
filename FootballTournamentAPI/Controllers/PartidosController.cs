using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FootballTournamentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidosController : ControllerBase
    {
        private readonly IPartidosRepository _partidosRepository;

        public PartidosController(IPartidosRepository partidosRepository)
        {
            _partidosRepository = partidosRepository;
        }

        // GET: api/Partidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partido>>> GetAllPartidos()
        {
            var partidos = await _partidosRepository.GetAllPartidosAsync();
            return Ok(partidos);
        }

        // GET: api/Partidos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Partido>> GetPartidoById(int id)
        {
            var partido = await _partidosRepository.GetPartidoByIdAsync(id);
            if (partido == null)
            {
                return NotFound();
            }
            return Ok(partido);
        }

        // GET: api/Partidos/Equipo/{equipoId}
        [HttpGet("Equipo/{equipoId}")]
        public async Task<ActionResult<IEnumerable<Partido>>> GetPartidosByEquipoId(int equipoId)
        {
            var partidos = await _partidosRepository.GetPartidosByEquipoIdAsync(equipoId);
            return Ok(partidos);
        }

        // POST: api/Partidos
        [HttpPost]
        public async Task<ActionResult<Partido>> CreatePartido(Partido partido)
        {
            var createdPartido = await _partidosRepository.CreatePartidoAsync(partido);
            return CreatedAtAction(nameof(GetPartidoById), new { id = createdPartido.Id }, createdPartido);
        }

        // PUT: api/Partidos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartido(int id, Partido partido)
        {
            if (id != partido.Id)
            {
                return BadRequest();
            }

            if (!await _partidosRepository.PartidoExistsAsync(id))
            {
                return NotFound();
            }

            await _partidosRepository.UpdatePartidoAsync(partido);
            return NoContent();
        }

        // DELETE: api/Partidos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartido(int id)
        {
            if (!await _partidosRepository.PartidoExistsAsync(id))
            {
                return NotFound();
            }

            await _partidosRepository.DeletePartidoAsync(id);
            return NoContent();
        }
    }
}
