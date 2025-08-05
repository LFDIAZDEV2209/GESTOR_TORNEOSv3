namespace GESTOR_TORNEOS.src.Modules.Domain.Entities;

public class TournamentTeam
{
    public int TournamentId { get; set; }
    public int TeamId { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    // Propiedades de navegación
    public Tournament Tournament { get; set; } = null!;
    public Team Team { get; set; } = null!;
    
    // Constructor
    public TournamentTeam() { }
    
    public TournamentTeam(int tournamentId, int teamId, DateTime registrationDate)
    {
        TournamentId = tournamentId;
        TeamId = teamId;
        RegistrationDate = registrationDate;
    }
} 