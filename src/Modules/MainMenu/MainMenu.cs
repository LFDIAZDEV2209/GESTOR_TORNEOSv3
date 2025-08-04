using GESTOR_TORNEOS.src.Modules.Application.Interfaces;
using GESTOR_TORNEOS.src.Modules.Application.Services;
using GESTOR_TORNEOS.src.Modules.Application.UI;
using GESTOR_TORNEOS.src.Modules.Infrastructure;
using GESTOR_TORNEOS.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace GESTOR_TORNEOS.src.Modules.MainMenu;

// Responsabilidad: Mostrar el menu principal y gestionar las opciones
public class MainMenu
{
    private readonly AppDbContext _dbContext;
    private readonly ITournamentUI _tournamentUI;

    public MainMenu(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        
        // Crear el repositorio usando Entity Framework
        var tournamentRepository = new TournamentRepository(_dbContext);
        
        // Crear el servicio
        var tournamentService = new TournamentService(tournamentRepository);
        
        // Crear la UI
        _tournamentUI = new TournamentUI(tournamentService);
    }

    public async Task Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Gestor de Torneos")
                .Centered()
                .Color(Color.Red)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Gestión de Torneos",
                    "1. Registro Equipos",
                    "2. Registro Jugadores",
                    "3. Transferencias (Compra, Préstamo)",
                    "4. Estadísticas",
                    "5. Partidos",
                    "6. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    await _tournamentUI.ShowMenu();
                    break;
                case '1':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de equipos en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '2':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de jugadores en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de transferencias en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '4':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de estadísticas en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '5':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de partidos en desarrollo...[/]");
                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                    Console.ReadKey();
                    break;
                case '6':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[red]Saliendo del programa...[/]");
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    break;
            }
        }
    }
}