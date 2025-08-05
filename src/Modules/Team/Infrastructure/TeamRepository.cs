using GESTOR_TORNEOS.src.Modules.Application.Interfaces;
using GESTOR_TORNEOS.src.Modules.Domain.Entities;
using GESTOR_TORNEOS.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOS.src.Modules.Infrastructure;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateTeam(Team team) => _context.Teams.Add(team);

    public void UpdateTeam(Team team) => _context.Teams.Update(team);

    public void DeleteTeam(int id)
    {
        var team = _context.Teams.Find(id);
        if (team != null)
            _context.Teams.Remove(team);
    }

    public async Task<Team> GetTeamById(int id) => await _context.Teams.FindAsync(id);

    public async Task<IEnumerable<Team>> GetAllTeams() => await _context.Teams.ToListAsync();

    public void InscribeTeam(TournamentTeam tournamentTeam) => _context.TournamentTeams.Add(tournamentTeam);

    public void UnsubscribeTeam(TournamentTeam tournamentTeam) => _context.TournamentTeams.Remove(tournamentTeam);

    // public void NotifyTransfer(Transfer transfer) => throw new NotImplementedException();

    // public void AddTechnicalStaff(TechnicalStaff technicalStaff) => throw new NotImplementedException();

    // public void AddMedicalStaff(MedicalStaff medicalStaff) => throw new NotImplementedException();

    public async Task SaveAsync() => await _context.SaveChangesAsync();
    
    public async Task<IEnumerable<City>> GetAllCitiesAsync()
    {
        return await _context.Cities
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}