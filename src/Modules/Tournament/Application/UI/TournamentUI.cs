using GESTOR_TORNEOS.src.Modules.Application.Interfaces;
using GESTOR_TORNEOS.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOS.src.Modules.Application.UI;

public class TournamentUI : ITournamentUI
{
    private readonly ITournamentService _tournamentService;

    public TournamentUI(ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    public async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Torneos")
                .Centered()
                .Color(Color.Yellow));

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Seleccione una opción")
                .AddChoices(new[] 
                { 
                    "0. Crear Torneo", 
                    "1. Buscar Torneo", 
                    "2. Eliminar Torneo",
                    "3. Actualizar Torneo",
                    "4. Regresar al menu principal"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    await ShowAddTournament();
                    break;
                case '1':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Opción no implementada[/]");
                    break;
                case '2':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Opción no implementada[/]");
                    break;
                case '3':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Opción no implementada[/]");
                    break;
                case '4':
                    Console.WriteLine("Regresando al menu principal...");
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }
        }
    }

    public async Task ShowAddTournament()
    {
        AnsiConsole.Write(
            new FigletText("Crear Torneo")
            .Centered()
            .Color(Color.Yellow));

        var name = AnsiConsole.Ask<string>("[yellow]Nombre del torneo:[/]");
        var startDate = AnsiConsole.Ask<DateTime>("[yellow]Fecha de inicio:[/]");
        var endDate = AnsiConsole.Ask<DateTime>("[yellow]Fecha de fin:[/]");
        var tournament = new Tournament(name, startDate, endDate);
        
        try
        {
            await _tournamentService.CreateTournamentAsync(tournament);
            AnsiConsole.MarkupLine("[green]Torneo creado correctamente[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al crear el torneo: {ex.Message}[/]");
            
            // Mostrar más detalles del error interno
            if (ex.InnerException != null)
            {
                AnsiConsole.MarkupLine($"[red]Detalles internos: {ex.InnerException.Message}[/]");
            }
            
            // Mostrar el stack trace para debugging
            AnsiConsole.MarkupLine($"[yellow]Stack trace: {ex.StackTrace}[/]");
        }
        
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowListTournaments()
    {
        throw new NotImplementedException();
    }

    public async Task ShowDeleteTournament()
    {
        throw new NotImplementedException();
    }

    public async Task ShowUpdateTournament()
    {
        throw new NotImplementedException();
    }
}