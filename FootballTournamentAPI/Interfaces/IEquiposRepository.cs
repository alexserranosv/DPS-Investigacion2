using FootballTournamentAPI.Model;

namespace FootballTournamentAPI.Interfaces
{
    public interface IEquiposRepository
    {
        public Task<IEnumerable<Equipo>> GetAllEquiposAsync();
        public Task<Equipo> GetEquipoByIdAsync(int id);
        public Task<Equipo> CreateEquipoAsync(Equipo equipo);
        public Task UpdateEquipoAsync(Equipo equipo);
        public Task DeleteEquipoAsync(int id);
        public Task<bool> EquipoExistsAsync(int id);
    }
}
