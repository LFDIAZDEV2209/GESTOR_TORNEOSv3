using GESTOR_TORNEOS.src.Modules.Application.Interfaces;
using GESTOR_TORNEOS.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOS.src.Modules.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task CreateTeamAsync(Team team)
    {
        _teamRepository.CreateTeam(team);
        await _teamRepository.SaveAsync();
    }

    public async Task UpdateTeamAsync(Team team)
    {
        _teamRepository.UpdateTeam(team);
        await _teamRepository.SaveAsync();
    }

    public async Task DeleteTeamAsync(int id)
    {
        _teamRepository.DeleteTeam(id);
        await _teamRepository.SaveAsync();
    }

    public async Task<Team> GetTeamByIdAsync(int id)
    {
        return await _teamRepository.GetTeamById(id);
    }

    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        return await _teamRepository.GetAllTeams();
    }

    public async Task InscribeTeamAsync(int tournamentId, int teamId)
    {
        var tournamentTeam = new TournamentTeam(tournamentId, teamId);
        _teamRepository.InscribeTeam(tournamentTeam);
        await _teamRepository.SaveAsync();
    }

    public async Task UnsubscribeTeamAsync(int tournamentId, int teamId)
    {
        var tournamentTeam = new TournamentTeam(tournamentId, teamId);
        _teamRepository.UnsubscribeTeam(tournamentTeam);
        await _teamRepository.SaveAsync();
    }

    // public async Task NotifyTransferAsync(Transfer transfer) => throw new NotImplementedException();

    // public async Task AddTechnicalStaffAsync(TechnicalStaff technicalStaff) => throw new NotImplementedException();

    // public async Task AddMedicalStaffAsync(MedicalStaff medicalStaff) => throw new NotImplementedException();
    
    public async Task<IEnumerable<City>> GetAllCitiesAsync()
    {
        return await _teamRepository.GetAllCitiesAsync();
    }
}