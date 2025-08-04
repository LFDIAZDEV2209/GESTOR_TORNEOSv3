// using GESTOR_TORNEOS.src.Modules.Team.Domain.Entities;

namespace GESTOR_TORNEOS.src.Modules.Domain.Entities;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    // public List<Team> Teams { get; set; }

    public Tournament(string name, DateTime startDate, DateTime endDate)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        // Teams = new List<Team>();
    }

    public Tournament() { }

    public override string ToString()
    {
        return $"Torneo: {Name} - Fecha de inicio: {StartDate.ToShortDateString()} - Fecha de fin: {EndDate.ToShortDateString()}";
    }
}