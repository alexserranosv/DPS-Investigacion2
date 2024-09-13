namespace FootballTournamentAPI.Model
{
    public class Resultado
    {
        public int Id { get; set; }

        public int PartidoId { get; set; }
        public virtual Partido Partido { get; set; }

        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
    }
}
