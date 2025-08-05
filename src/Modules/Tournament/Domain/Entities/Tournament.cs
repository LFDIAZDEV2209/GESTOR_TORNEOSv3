namespace GESTOR_TORNEOS.src.Modules.Domain.Entities;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    // Propiedades de navegación
    public List<TournamentTeam> TournamentTeams { get; set; } = new();
    // public List<Match> Matches { get; set; } = new();

    public Tournament(string name, DateTime startDate, DateTime endDate)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        TournamentTeams = new List<TournamentTeam>();
        // Matches = new List<Match>();
    }

    public Tournament() 
    {
        TournamentTeams = new List<TournamentTeam>();
        // Matches = new List<Match>();
    }

    public override string ToString()
    {
        return $"Torneo: {Name} - Fecha de inicio: {StartDate.ToShortDateString()} - Fecha de fin: {EndDate.ToShortDateString()}";
    }
}