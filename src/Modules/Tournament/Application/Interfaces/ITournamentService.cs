using GESTOR_TORNEOS.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOS.src.Modules.Application.Interfaces;

public interface ITournamentService
{
    Task CreateTournamentAsync(Tournament tournament);
    Task UpdateTournamentAsync(Tournament tournament);
    Task DeleteTournamentAsync(int id);
    Task<Tournament?> GetTournamentByIdAsync(int id);
    Task<IEnumerable<Tournament>> GetAllTournamentsAsync();
}