namespace FootballTournamentAPI.DTO
{
    public class PartidoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EquipoLocalId { get; set; }
        public string EquipoLocalNombre { get; set; }
        public int EquipoVisitanteId { get; set; }
        public string EquipoVisitanteNombre { get; set; }
        public ResultadoDto Resultado { get; set; }
    }

    public class CreatePartidoDto
    {
        public DateTime Fecha { get; set; }
        public int EquipoLocalId { get; set; }
        public int EquipoVisitanteId { get; set; }
    }

    public class UpdatePartidoDto
    {
        public DateTime Fecha { get; set; }
        public int EquipoLocalId { get; set; }
        public int EquipoVisitanteId { get; set; }
    }
}
