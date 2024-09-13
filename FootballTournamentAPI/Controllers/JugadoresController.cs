using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FootballTournamentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JugadoresController : ControllerBase
    {
        private readonly IJugadoresRepository _jugadoresRepository;

        public JugadoresController(IJugadoresRepository jugadoresRepository)
        {
            _jugadoresRepository = jugadoresRepository;
        }

        // GET: api/Jugadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetAllJugadores()
        {
            var jugadores = await _jugadoresRepository.GetAllJugadoresAsync();
            return Ok(jugadores);
        }

        // GET: api/Jugadores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Jugador>> GetJugadorById(int id)
        {
            var jugador = await _jugadoresRepository.GetJugadorByIdAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            return Ok(jugador);
        }

        // GET: api/Jugadores/Equipo/{equipoId}
        [HttpGet("Equipo/{equipoId}")]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetJugadoresByEquipoId(int equipoId)
        {
            var jugadores = await _jugadoresRepository.GetJugadoresByEquipoIdAsync(equipoId);
            return Ok(jugadores);
        }

        // POST: api/Jugadores
        [HttpPost]
        public async Task<ActionResult<Jugador>> CreateJugador(Jugador jugador)
        {
            var createdJugador = await _jugadoresRepository.CreateJugadorAsync(jugador);
            return CreatedAtAction(nameof(GetJugadorById), new { id = createdJugador.Id }, createdJugador);
        }

        // PUT: api/Jugadores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJugador(int id, Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return BadRequest();
            }

            if (!await _jugadoresRepository.JugadorExistsAsync(id))
            {
                return NotFound();
            }

            await _jugadoresRepository.UpdateJugadorAsync(jugador);
            return NoContent();
        }

        // DELETE: api/Jugadores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJugador(int id)
        {
            if (!await _jugadoresRepository.JugadorExistsAsync(id))
            {
                return NotFound();
            }

            await _jugadoresRepository.DeleteJugadorAsync(id);
            return NoContent();
        }
    }
}
