namespace GESTOR_TORNEOS.src.Modules.Application.Interfaces;

public interface ITournamentUI
{
    Task ShowMenu();
    Task ShowAddTournament();
    Task ShowUpdateTournament();
    Task ShowDeleteTournament();
    Task ShowListTournaments();
}