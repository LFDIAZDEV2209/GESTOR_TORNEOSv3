namespace GESTOR_TORNEOS.src.Modules.Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Propiedades de navegación
    public List<Team> Teams { get; set; } = new();
    
    // Constructor
    public City() { }
    
    public City(string name)
    {
        Name = name;
        Teams = new List<Team>();
    }
} 