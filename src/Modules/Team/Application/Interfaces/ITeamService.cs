using GESTOR_TORNEOS.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOS.src.Modules.Application.Interfaces;

public interface ITeamService
{
    Task CreateTeamAsync(Team team);
    Task UpdateTeamAsync(Team team);
    Task DeleteTeamAsync(int id);
    Task<Team> GetTeamByIdAsync(int id);
    Task<IEnumerable<Team>> GetAllTeamsAsync();
    Task InscribeTeamAsync(int tournamentId, int teamId);
    Task UnsubscribeTeamAsync(int tournamentId, int teamId);
    // Task NotifyTransferAsync(Transfer transfer);
    // Task AddTechnicalStaffAsync(TechnicalStaff technicalStaff);
    // Task AddMedicalStaffAsync(MedicalStaff medicalStaff);
    Task<IEnumerable<City>> GetAllCitiesAsync();
}