using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace GESTOR_TORNEOS.src.Modules.MainMenu;

// Responsabilidad: Mostrar el menu principal y gestionar las opciones
public class MainMenu
{
    private readonly DbContext _dbContext;

    public MainMenu(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Show()
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
                .Title("Seleccione una opcion")
                .AddChoices(new[]
                {
                    "0. Registro Torneos",
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
                        AnsiConsole.MarkupLine("[yellow]Modulo en desarrollo...[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                        Console.ReadKey();
                        break;
                    case '1':
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]Modulo en desarrollo...[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]Modulo en desarrollo...[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]Modulo en desarrollo...[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]Modulo en desarrollo...[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]Modulo en desarrollo...[/]");
                        AnsiConsole.MarkupLine("[yellow]Presione cualquier tecla para continuar...[/]");
                        Console.ReadKey();
                        break;
                    case '6':
                        Console.Clear();
                        AnsiConsole.MarkupLine("[red]Saliendo del programa...[/]");
                        return;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
        }
    }
}