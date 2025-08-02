using GESTOR_TORNEOS.src.Shared.Helpers;
using GESTOR_TORNEOS.src.Modules.MainMenu;

namespace GESTOR_TORNEOS;

class Program 
{
    private static void Main(string[] args)
    {
        try
        {
            var dbContext = DbContextFactory.Create();

            var MainMenu = new MainMenu(dbContext);
            MainMenu.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}

