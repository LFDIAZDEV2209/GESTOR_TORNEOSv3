using GESTOR_TORNEOS.src.Modules.Application.Interfaces;
using GESTOR_TORNEOS.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOS.src.Modules.Application.Services;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;

    public TournamentService(ITournamentRepository tournamentRepository)
    {
        _tournamentRepository = tournamentRepository;
    }

    public async Task CreateTournamentAsync(Tournament tournament)
    {
        _tournamentRepository.Add(tournament);
        await _tournamentRepository.SaveAsync();
    }

    public async Task DeleteTournamentAsync(int id)
    {
        await _tournamentRepository.Delete(id);
        await _tournamentRepository.SaveAsync();
    }

    public async Task<IEnumerable<Tournament>> GetAllTournamentsAsync()
    {
        return await _tournamentRepository.GetAllAsync();
    }

    public async Task<Tournament?> GetTournamentByIdAsync(int id)
    {
        return await _tournamentRepository.GetByIdAsync(id);
    }

    public async Task UpdateTournamentAsync(Tournament tournament)
    {
        var existingTournament = await _tournamentRepository.GetByIdAsync(tournament.Id);
        if (existingTournament == null)
        {
            throw new Exception("Tournament not found");
        }

        existingTournament.Name = tournament.Name;
        existingTournament.StartDate = tournament.StartDate;
        existingTournament.EndDate = tournament.EndDate;

        _tournamentRepository.Update(existingTournament);
        await _tournamentRepository.SaveAsync();
    }
}