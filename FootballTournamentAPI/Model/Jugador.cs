using System.ComponentModel.DataAnnotations;

namespace FootballTournamentAPI.Model
{
    public class Jugador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public int Numero { get; set; }

        public string Posicion { get; set; }

        public int EquipoId { get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}
