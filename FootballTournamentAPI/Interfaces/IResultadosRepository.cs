using FootballTournamentAPI.Model;

namespace FootballTournamentAPI.Interfaces
{
    public interface IResultadosRepository
    {
        Task<IEnumerable<Resultado>> GetAllResultadosAsync();
        Task<Resultado> GetResultadoByIdAsync(int id);
        Task<Resultado> GetResultadoByPartidoIdAsync(int partidoId);
        Task<Resultado> CreateResultadoAsync(Resultado resultado);
        Task UpdateResultadoAsync(Resultado resultado);
        Task DeleteResultadoAsync(int id);
        Task<bool> ResultadoExistsAsync(int id);
    }
}
