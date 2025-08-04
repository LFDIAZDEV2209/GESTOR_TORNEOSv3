using GESTOR_TORNEOS.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOS.src.Modules.Application.Interfaces;

public interface ITournamentRepository
{
    Task<Tournament?> GetByIdAsync(int id);
    Task<IEnumerable<Tournament>> GetAllAsync();
    void Add(Tournament tournament);
    void Update(Tournament tournament);
    Task Delete(int id);
    Task SaveAsync();
}