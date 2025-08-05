using System.ComponentModel.DataAnnotations;

namespace GESTOR_TORNEOS.src.Modules.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? CityId { get; set; }
    
    // Propiedades de navegación
    public City? City { get; set; }
    public List<TournamentTeam> TournamentTeams { get; set; } = new();
    // public List<Player> Players { get; set; } = new();
    // public List<Staff> Staff { get; set; } = new();
    
    // Constructor
    public Team(string name, int? cityId = null)
    {
        Name = name;
        CityId = cityId ?? null;
        TournamentTeams = new List<TournamentTeam>();
        // Players = new List<Player>();
        // Staff = new List<Staff>();
    }

    public Team() { }
    
}