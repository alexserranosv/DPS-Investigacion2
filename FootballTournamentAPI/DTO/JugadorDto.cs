using System.ComponentModel.DataAnnotations;

namespace FootballTournamentAPI.DTO
{
    public class JugadorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Posicion { get; set; }
        public int EquipoId { get; set; }
        public string EquipoNombre { get; set; }
    }

    public class CreateJugadorDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Posicion { get; set; }
        public int EquipoId { get; set; }
    }

    public class UpdateJugadorDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Posicion { get; set; }
        public int EquipoId { get; set; }
    }
}
