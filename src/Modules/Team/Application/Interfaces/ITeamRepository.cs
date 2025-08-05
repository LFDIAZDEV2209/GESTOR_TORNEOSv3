using GESTOR_TORNEOS.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOS.src.Modules.Application.Interfaces;

public interface ITeamRepository
{
    void CreateTeam(Team team);
    void UpdateTeam(Team team);
    void DeleteTeam(int id);
    Task<Team> GetTeamById(int id);
    Task<IEnumerable<Team>> GetAllTeams();
    void InscribeTeam(TournamentTeam tournamentTeam);
    void UnsubscribeTeam(TournamentTeam tournamentTeam);
    // void NotifyTransfer(Transfer transfer);
    // void AddTechnicalStaff(TechnicalStaff technicalStaff);
    // void AddMedicalStaff(MedicalStaff medicalStaff);
    Task SaveAsync();
    Task<IEnumerable<City>> GetAllCitiesAsync();
}