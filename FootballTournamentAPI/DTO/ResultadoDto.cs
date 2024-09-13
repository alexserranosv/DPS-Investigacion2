namespace FootballTournamentAPI.DTO
{
    public class ResultadoDto
    {
        public int Id { get; set; }
        public int PartidoId { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
    }

    public class CreateResultadoDto
    {
        public int PartidoId { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
    }

    public class UpdateResultadoDto
    {
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
    }
}
