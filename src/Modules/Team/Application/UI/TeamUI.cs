using GESTOR_TORNEOS.src.Modules.Application.Interfaces;
using GESTOR_TORNEOS.src.Modules.Domain.Entities;
using Spectre.Console;

namespace GESTOR_TORNEOS.src.Modules.Application.UI;

public class TeamUI : ITeamUI
{
    private readonly ITeamService _teamService;

    public TeamUI(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Equipos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .AddChoices(new[]
                {
                    "0. Gestión de Equipos",
                    "1. Registrar Cuerpo Técnico",
                    "2. Registrar Cuerpo Médico",
                    "3. Inscribir Equipo en Torneo",
                    "4. Desinscribir Equipo en Torneo",
                    "5. Notificaciones de Transferencia",
                    "6. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    await ShowTeamManagement();
                    break;
                case '1':
                    // await ShowAddTechnicalStaff();
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
                    break;
                case '2':
                    // await ShowAddMedicalStaff();
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
                    break;
                case '3':
                    // await ShowInscribeTeam();
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
                    break;
                case '4':
                    // await ShowUnsubscribeTeam();
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
                    break;
                case '5':
                    // await ShowNotifyTransfer();
                    AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
                    break;
                case '6':
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }
        }
    }

    public async Task ShowTeamManagement()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Gestión de Equipos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .AddChoices(new[]
                {
                    "0. Registrar Equipo",
                    "1. Actualizar Equipo",
                    "2. Eliminar Equipo",
                    "3. Buscar Equipo",
                    "4. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    await ShowAddTeam();
                    break;
                case '1':
                    await ShowUpdateTeam();
                    break;
                case '2':
                    await ShowDeleteTeam();
                    break;
                case '3':
                    await ShowListTeams();
                    break;
                case '4':
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }

        }
    }

    public async Task ShowAddTeam()
    {
        Console.Clear();

        AnsiConsole.Write(
            new FigletText("Registrar Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        try
        {
            // Obtener las ciudades disponibles
            var cities = await _teamService.GetAllCitiesAsync();
            
            if (!cities.Any())
            {
                AnsiConsole.MarkupLine("[red]No hay ciudades disponibles. Debe crear ciudades primero.[/]");
                AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                Console.ReadKey();
                return;
            }

            var name = AnsiConsole.Ask<string>("[bold green]Nombre del equipo:[/]");
            
            // Crear opciones para el SelectionPrompt
            var cityChoices = cities.Select(c => $"{c.Id} - {c.Name}").ToArray();
            
            var selectedCityOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione la ciudad del equipo:[/]")
                .AddChoices(cityChoices)
            );

            // Extraer el ID de la ciudad seleccionada
            var cityId = int.Parse(selectedCityOption.Split('-')[0].Trim());

            var team = new Team(name, cityId);

            await _teamService.CreateTeamAsync(team);
            
            AnsiConsole.MarkupLine("[green]Equipo registrado correctamente[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error al registrar el equipo: {ex.Message}[/]");
        }
        
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowUpdateTeam()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowDeleteTeam()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowListTeams()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowInscribeTeam()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowUnsubscribeTeam()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowNotifyTransfer()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowAddTechnicalStaff()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowAddMedicalStaff()
    {
        AnsiConsole.MarkupLine("[yellow]Funcionalidad en desarrollo[/]");
        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }
}