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
                    await ShowListTournaments();
                    break;
                case '2':
                    Console.Clear();
                    await ShowDeleteTournament();
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

        var name = AnsiConsole.Ask<string>("[blue]Nombre del torneo:[/]");
        var startDate = AnsiConsole.Ask<DateTime>("[blue]Fecha de inicio:[/]");
        var endDate = AnsiConsole.Ask<DateTime>("[blue]Fecha de fin:[/]");
        var tournament = new Tournament(name, startDate, endDate);
        
        try
        {
            await _tournamentService.CreateTournamentAsync(tournament);
            AnsiConsole.MarkupLine("[green]Torneo creado correctamente[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al crear el torneo: {ex.Message}[/]");
        }
        
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowListTournaments()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(
            new FigletText("Lista de Torneos")
            .Centered()
            .Color(Color.Yellow));
        
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Como desea buscar el torneo?")
                .AddChoices(new[]
                {
                    "1. Por ID",
                    "2. Mostrar todos",
                    "3. Regresar al menu principal"
                })
            );

            switch (selection[0])
            {
                case '1':
                    var id = AnsiConsole.Ask<int>("[blue]ID del torneo:[/]");
                    try
                    {
                        var tournament = await _tournamentService.GetTournamentByIdAsync(id);

                        if (tournament == null)
                        {
                            AnsiConsole.MarkupLine("[red]Torneo no encontrado[/]");
                            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                            Console.ReadKey();
                            break;
                        }

                        var table = new Table();
                        table.AddColumn("ID");
                        table.AddColumn("Nombre");
                        table.AddColumn("Fecha de inicio");
                        table.AddColumn("Fecha de fin");
                        table.AddRow(tournament.Id.ToString(), tournament.Name, tournament.StartDate.Date.ToString("dd/MM/yyyy"), tournament.EndDate.Date.ToString("dd/MM/yyyy"));

                        AnsiConsole.Write(table);
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.MarkupLine($"[red]Error al buscar el torneo: {ex.Message}[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                        Console.ReadKey();
                    }
                    break;
                case '2':
                    try
                    {
                        var tournaments = await _tournamentService.GetAllTournamentsAsync();

                        if (tournaments.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[red]No hay torneos registrados[/]");
                            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                            Console.ReadKey();
                            break;
                        }

                        var table = new Table();
                        table.AddColumn("ID");
                        table.AddColumn("Nombre");
                        table.AddColumn("Fecha de inicio");
                        table.AddColumn("Fecha de fin");

                        foreach (var tournament in tournaments)
                        {
                            table.AddRow(tournament.Id.ToString(), tournament.Name, tournament.StartDate.Date.ToString("dd/MM/yyyy"), tournament.EndDate.Date.ToString("dd/MM/yyyy"));
                        }

                        AnsiConsole.Write(table);
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.MarkupLine($"[red]Error al mostrar la lista de torneos: {ex.Message}[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                        Console.ReadKey();
                    }
                    break;
                case '3':
                    return;
                }
        }
    }

    public async Task ShowDeleteTournament()
    {
        AnsiConsole.Write(
            new FigletText("Eliminar Torneo")
            .Centered()
            .Color(Color.Yellow));

        var id = AnsiConsole.Ask<int>("[blue]ID del torneo:[/]");

        try
        {
            await _tournamentService.DeleteTournamentAsync(id);
            AnsiConsole.MarkupLine("[green]Torneo eliminado correctamente[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al eliminar el torneo: {ex.Message}[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowUpdateTournament()
    {
        throw new NotImplementedException();
    }
}