using FootballTournamentAPI.DTO;
using FootballTournamentAPI.Interfaces;
using FootballTournamentAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FootballTournamentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IEquiposRepository _equiposRepository;

        public EquiposController(IEquiposRepository equiposRepository)
        {
            _equiposRepository = equiposRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipoDto>>> GetEquipos()
        {
            var equipos = await _equiposRepository.GetAllEquiposAsync();
            var equiposDto = equipos.Select(e => new EquipoDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Ciudad = e.Ciudad
            });
            return Ok(equiposDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipoDto>> GetEquipo(int id)
        {
            var equipo = await _equiposRepository.GetEquipoByIdAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            var equipoDto = new EquipoDto
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre,
                Ciudad = equipo.Ciudad
            };

            return Ok(equipoDto);
        }

        [HttpPost]
        public async Task<ActionResult<EquipoDto>> CreateEquipo(CreateEquipoDto createEquipoDto)
        {
            var equipo = new Equipo
            {
                Nombre = createEquipoDto.Nombre,
                Ciudad = createEquipoDto.Ciudad
            };

            await _equiposRepository.CreateEquipoAsync(equipo);

            var equipoDto = new EquipoDto
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre,
                Ciudad = equipo.Ciudad
            };

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, equipoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipo(int id, UpdateEquipoDto updateEquipoDto)
        {
            var equipo = await _equiposRepository.GetEquipoByIdAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            equipo.Nombre = updateEquipoDto.Nombre;
            equipo.Ciudad = updateEquipoDto.Ciudad;

            await _equiposRepository.UpdateEquipoAsync(equipo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var equipo = await _equiposRepository.GetEquipoByIdAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            await _equiposRepository.DeleteEquipoAsync(id);

            return NoContent();
        }
    }
}
