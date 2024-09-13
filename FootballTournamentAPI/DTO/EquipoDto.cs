using System.ComponentModel.DataAnnotations;

namespace FootballTournamentAPI.DTO
{
    public class EquipoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
    }

    public class CreateEquipoDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
    }

    public class UpdateEquipoDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
    }
}
