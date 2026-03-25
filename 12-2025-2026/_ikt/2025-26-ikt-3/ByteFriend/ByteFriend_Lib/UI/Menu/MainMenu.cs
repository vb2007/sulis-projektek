using ByteFriend_Lib.Helpers;

namespace ByteFriend_Lib.UI.Menu;

public static class MainMenu
{
    private static int _selectedIndex;
    private static readonly string[] MenuOptions =
    [
        "Állat Létrehozása",
        "Állat Betöltése",
        "Segítség",
        "Kilépés"
    ];

    private static readonly string[] AsciiTitle =
    [
        "______       _        ______    _                _ ", 
        "| ___ \\     | |       |  ___|  (_)              | |",
        "| |_/ /_   _| |_ ___  | |_ _ __ _  ___ _ __   __| |",
        "| ___ \\ | | | __/ _ \\ |  _| '__| |/ _ \\ '_ \\ / _` |",
        "| |_/ / |_| | ||  __/ | | | |  | |  __/ | | | (_| |",
        "\\____/ \\__, |\\__\\___| \\_| |_|  |_|\\___|_| |_|\\__,_|",
        "        __/ |                                      ",
        "       |___/                                       "
    ];

    private static readonly CustomColors TitleColor = new CustomColors("#00D9FF");
    private static readonly CustomColors SelectedColor = new CustomColors("#00FF7F");
    private static readonly CustomColors NormalColor = new CustomColors("#FFFFFF");
    private static readonly CustomColors WarningColor = new CustomColors("#FF4444");

    private const int MaxSaves = 10;
    private static string? _warningMessage;
    private static int _warningTicks;

    public static void Show()
    {
        Console.CursorVisible = false;

        while (true)
        {
            DisplayMenu();

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedIndex = _selectedIndex > 0 ? _selectedIndex - 1 : MenuOptions.Length - 1;
                    break;

                case ConsoleKey.DownArrow:
                    _selectedIndex = _selectedIndex < MenuOptions.Length - 1 ? _selectedIndex + 1 : 0;
                    break;

                case ConsoleKey.Enter:
                    HandleSelection();
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Render.ClearScreen();

        int windowHeight = Console.WindowHeight;
        int totalMenuHeight = AsciiTitle.Length + 1 + MenuOptions.Length;
        int startTop = Math.Max(0, (windowHeight - totalMenuHeight) / 2);

        for (int i = 0; i < AsciiTitle.Length; i++)
        {
            string colorizedLine = TitleColor.Colorize(AsciiTitle[i]);
            Render.WriteLineCenter(AsciiTitle[i], startTop + i, colorizedLine);
        }

        if (_warningMessage != null && _warningTicks > 0)
        {
            Render.WriteLineCenter(
                WarningColor.Colorize(_warningMessage),
                customTop: startTop + AsciiTitle.Length
            );
            _warningTicks--;
            if (_warningTicks <= 0)
                _warningMessage = null;
        }

        int maxLength = MenuOptions.Max(o => o.Length);
        int leftPadding = (Console.WindowWidth - maxLength - 3) / 2;

        for (int i = 0; i < MenuOptions.Length; i++)
        {
            string indicator = i == _selectedIndex ? ">" : " ";
            string option = MenuOptions[i];
            CustomColors color = i == _selectedIndex ? SelectedColor : NormalColor;
            
            string colorizedLine = $"{color.Colorize(indicator)} {color.Colorize("|")} {color.Colorize(option)}";
            
            Console.SetCursorPosition(leftPadding, startTop + AsciiTitle.Length + 1 + i);
            Console.Write(colorizedLine);
        }
    }

    private static void HandleSelection()
    {
        switch (_selectedIndex)
        {
            case 0:
                if (SaveManager.GetSaveCount() >= MaxSaves)
                {
                    _warningMessage = $"Nem hozhatsz létre több állatot! (Maximum: {MaxSaves})";
                    _warningTicks = 3;
                    return;
                }
                AnimalPickerMenu.Show();
                break;

            case 1:
                LoadMenu.Show();
                break;

            case 2:
                HelpMenu.Show();
                break;

            case 3:
                Environment.Exit(0);
                break;
        }
    }
}
