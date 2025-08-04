using GESTOR_TORNEOS.src.Modules.Domain.Entities;
using GESTOR_TORNEOS.src.Modules.Application.Interfaces;
using GESTOR_TORNEOS.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOS.src.Modules.Infrastructure;

public class TournamentRepository : ITournamentRepository
{
    private readonly AppDbContext _context;

    public TournamentRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Tournament tournament) => _context.Tournaments.Add(tournament);

    public async Task Delete(int id)
    {
        var tournament = await GetByIdAsync(id);
        if (tournament != null)
        {
            _context.Tournaments.Remove(tournament);
        }
    }

    public async Task<IEnumerable<Tournament>> GetAllAsync() => await _context.Tournaments.ToListAsync();

    public async Task<Tournament?> GetByIdAsync(int id) => await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);

    public void Update(Tournament tournament) => _context.Tournaments.Update(tournament);

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
