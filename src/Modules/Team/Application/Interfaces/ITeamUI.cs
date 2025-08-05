namespace GESTOR_TORNEOS.src.Modules.Application.Interfaces;

public interface ITeamUI
{
    Task ShowMenu();
    Task ShowTeamManagement();
    Task ShowAddTeam();
    Task ShowUpdateTeam();
    Task ShowDeleteTeam();
    Task ShowListTeams();
    Task ShowInscribeTeam();
    Task ShowUnsubscribeTeam();
    Task ShowNotifyTransfer();
    Task ShowAddTechnicalStaff();
    Task ShowAddMedicalStaff();
}
