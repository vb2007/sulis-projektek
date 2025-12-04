using KobolduldozokLib.UI;
using KobolduldozokLib.UI.Simulation;
using KobolduldozokLib.UI.Menu;

namespace Kobolduldozok;

class Program
{
    static void Main(string[] args)
    {
        var mainMenu = new MainMenu();
        var settings = mainMenu.Show();

        var matrix = new Matrix();
        var renderer = new Renderer();

        Console.CursorVisible = false;

        matrix.Initialize();
        matrix.UpdateStatistics();
        renderer.RenderAll(matrix.GetGrid(), matrix.Statistics, matrix.ActivityLog, matrix.IsRunning());

        matrix.ActivityLog.Log($"Indul a buli a telepen!");
        matrix.ActivityLog.Log($"Sebesség: {settings.Speed} / Késleltetés: {settings.GetDelayMilliseconds()} ms");
        matrix.ActivityLog.Log($"Manuális mód: {(settings.IsManualMode ? "BE" : "KI")}");

        if (settings.IsManualMode)
        {
            while (matrix.IsRunning())
            {
                var key = Console.ReadKey(true);
                if (key.KeyChar == 'q' || key.KeyChar == 'Q')
                {
                    matrix.ActivityLog.Log("Felhasználó leállította a szimulációt.");
                    break;
                }

                matrix.UpdateFrame();
                matrix.UpdateStatistics();
                renderer.RenderAll(matrix.GetGrid(), matrix.Statistics, matrix.ActivityLog, matrix.IsRunning());
            }
        }
        else
        {
            while (matrix.IsRunning())
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == 'q' || key.KeyChar == 'Q')
                    {
                        matrix.ActivityLog.Log("Felhasználó leállította a szimulációt.");
                        break;
                    }
                }

                Thread.Sleep(settings.GetDelayMilliseconds());
                matrix.UpdateFrame();
                matrix.UpdateStatistics();
                renderer.RenderAll(matrix.GetGrid(), matrix.Statistics, matrix.ActivityLog, matrix.IsRunning());
            }
        }

        renderer.RenderAll(matrix.GetGrid(), matrix.Statistics, matrix.ActivityLog, matrix.IsRunning());

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'q' || key.KeyChar == 'Q')
            {
                break;
            }
        }
    }
}
