using System.ComponentModel.DataAnnotations;

namespace FootballTournamentAPI.Model
{
    public class Equipo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Ciudad { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}
