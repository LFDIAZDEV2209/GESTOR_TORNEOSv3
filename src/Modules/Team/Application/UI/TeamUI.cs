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
        Console.Clear();

        AnsiConsole.Write(
            new FigletText("Actualizar Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        var teams = await _teamService.GetAllTeamsAsync();

        if (!teams.Any())
        {
            AnsiConsole.MarkupLine("[red]No hay equipos disponibles. Debe registrar equipos primero.[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
            return;
        }

        var teamChoices = teams.Select(t => $"{t.Id} - {t.Name}").ToArray();

        var selectedTeamOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold green]Seleccione el equipo a actualizar:[/]")
            .AddChoices(teamChoices)
        );

        var selectedTeamId = int.Parse(selectedTeamOption.Split('-')[0].Trim());

        var team = teams.FirstOrDefault(t => t.Id == selectedTeamId);

        if (team == null)
        {
            AnsiConsole.MarkupLine("[red]Equipo no encontrado.[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
            return;
        }

        var newName = AnsiConsole.Ask<string>("[bold green]Nuevo nombre del equipo:[/]");

        var cities = await _teamService.GetAllCitiesAsync();

        var cityChoices = cities.Select(c => $"{c.Id} - {c.Name}").ToArray();

        var selectedCityOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold green]Seleccione la ciudad del equipo:[/]")
            .AddChoices(cityChoices)
        );

        var cityId = int.Parse(selectedCityOption.Split('-')[0].Trim());

        team.Name = newName;
        team.CityId = cityId;

        await _teamService.UpdateTeamAsync(team);

        AnsiConsole.MarkupLine("[green]Equipo actualizado correctamente[/]");

        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowDeleteTeam()
    {
        Console.Clear();

        AnsiConsole.Write(
            new FigletText("Eliminar Equipo")
            .Centered()
            .Color(Color.Yellow)
        );

        var teams = await _teamService.GetAllTeamsAsync();

        if (!teams.Any())
        {
            AnsiConsole.MarkupLine("[red]No hay equipos disponibles. Debe registrar equipos primero.[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
            return;
        }

        var teamChoices = teams.Select(t => $"{t.Id} - {t.Name}").ToArray();

        var selectedTeamOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[bold green]Seleccione el equipo a eliminar:[/]")
            .AddChoices(teamChoices)
        );

        var selectedTeamId = int.Parse(selectedTeamOption.Split('-')[0].Trim());

        var team = teams.FirstOrDefault(t => t.Id == selectedTeamId);

        if (team == null)
        {
            AnsiConsole.MarkupLine("[red]Equipo no encontrado.[/]");
            AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
            Console.ReadKey();
            return;
        }

        await _teamService.DeleteTeamAsync(team.Id);

        AnsiConsole.MarkupLine("[green]Equipo eliminado correctamente[/]");

        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
        Console.ReadKey();
    }

    public async Task ShowListTeams()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Buscar Equipos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Como desea buscar los equipos?[/]")
                .AddChoices(new[]
                {
                    "0. Por ID",
                    "1. Mostrar todos",
                    "2. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    var id = AnsiConsole.Ask<int>("[bold green]Ingrese el ID del equipo:[/]");
                    var team = await _teamService.GetTeamByIdAsync(id);
                    if (team == null)
                    {
                        AnsiConsole.MarkupLine("[red]Equipo no encontrado.[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                        Console.ReadKey();
                        return;
                    }

                    var table = new Table();
                    table.AddColumn("ID");
                    table.AddColumn("Nombre");
                    table.AddColumn("Ciudad");
                    table.AddRow(team.Id.ToString(), team.Name, team.City?.Name ?? "Sin ciudad");
                    
                    AnsiConsole.Write(table);

                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                    Console.ReadKey();
                    break;
                case '1':
                    Console.Clear();

                    AnsiConsole.Write(
                        new FigletText("Todos los Equipos")
                        .Centered()
                        .Color(Color.Yellow)
                    );

                    var teams = await _teamService.GetAllTeamsAsync();
                    
                    var teamTable = new Table();
                    teamTable.AddColumn("ID");
                    teamTable.AddColumn("Nombre");
                    teamTable.AddColumn("Ciudad");
                    
                    foreach (var t in teams)
                    {
                        teamTable.AddRow(t.Id.ToString(), t.Name, t.City?.Name ?? "Sin ciudad");
                    }

                    AnsiConsole.Write(teamTable);

                    AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar[/]");
                    Console.ReadKey();
                    break;
                case '2':
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Opción no válida[/]");
                    break;
            }
        }
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