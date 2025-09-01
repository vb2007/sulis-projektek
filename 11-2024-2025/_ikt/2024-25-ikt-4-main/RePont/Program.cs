using RePontGame.Services;
using RePontGame.Models;
using RePontGame.UI;

namespace RePontGame;

public class Program
{
    public static void Main(string[] args)
    {
        if (!Renderer.InitializeConsole())
        {
            Console.WriteLine("\nA program leáll. Nyomj meg egy gombot...");
            Console.ReadKey();
            return;
        }

        RpcService.Initialize();

        PlayerData playerData = GetInitialPlayerData();
        RpcService.UpdateMenuPresence(playerData);
        MenuRenderer.MainMenuSelection choice;

        try
        {
            do
            {
                choice = MenuRenderer.ShowMainMenu(playerData);
                    RpcService.UpdateMenuPresence(playerData);

                switch (choice)
                {
                    case MenuRenderer.MainMenuSelection.StartGame:
                        GameLoopService.RunGame(playerData);
                            RpcService.UpdateMenuPresence(playerData);
                        break;
                    case MenuRenderer.MainMenuSelection.Upgrades:
                        MenuRenderer.ShowUpgradeMenu(playerData);
                            RpcService.UpdateMenuPresence(playerData);
                        break;
                    case MenuRenderer.MainMenuSelection.Help:
                        MenuRenderer.ShowHelpScreen();
                        break;
                    case MenuRenderer.MainMenuSelection.Quit:
                        break;
                }
            } while (choice != MenuRenderer.MainMenuSelection.Quit);
        }
        finally
        {
            RpcService.Shutdown();
            Console.CursorVisible = true;
            Console.ResetColor();
            Console.Clear();

            if (playerData != null && !string.IsNullOrEmpty(playerData.Name))
            {
                Console.WriteLine($"Viszlát, {playerData.Name}!");
            }
            else
            {
                Console.WriteLine("Viszlát!");
            }

            Thread.Sleep(800);
        }
    }

    private static PlayerData GetInitialPlayerData()
    {
        Console.Clear();
        int artTop = 3;
        MenuRenderer.DisplayAsciiArt(AsciiArt.RePontLogo, artTop, ConsoleColor.Cyan);

        int promptTop = artTop + AsciiArt.RePontLogo.Length + 3;
        Console.SetCursorPosition(0, promptTop);
        string prompt = "Add meg a neved: ";
        int promptLeft = (Console.WindowWidth - prompt.Length) / 2;
        if (promptLeft < 0) promptLeft = 0;

        Console.SetCursorPosition(promptLeft, promptTop);
        Console.Write(prompt);
        Console.CursorVisible = true;

        string? name = null;
        while (string.IsNullOrWhiteSpace(name))
        {
            try
            {
                Console.SetCursorPosition(promptLeft + prompt.Length, promptTop);
                Console.Write(new string(' ', Console.WindowWidth - (promptLeft + prompt.Length) - 1));
                Console.SetCursorPosition(promptLeft + prompt.Length, promptTop);
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.SetCursorPosition(promptLeft, promptTop);
                    Console.Write(prompt);
                }
            }
            catch(Exception) { }
        }

        Console.CursorVisible = false;
        Console.Clear();

        return SaveManager.LoadPlayerData(name.Trim());
    }
}