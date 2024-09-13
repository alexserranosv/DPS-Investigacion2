namespace FootballTournamentAPI.Model
{
    public class Partido
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int EquipoLocalId { get; set; }
        public virtual Equipo EquipoLocal { get; set; }

        public int EquipoVisitanteId { get; set; }
        public virtual Equipo EquipoVisitante { get; set; }

        public virtual Resultado Resultado { get; set; }
    }
}
