using ByteFriend_Lib.Helpers;

namespace ByteFriend_Lib.UI.Menu;

public static class LoadMenu
{
    private static int _selectedIndex;
    private static readonly CustomColors SelectedColor = new("#00FF7F");
    private static readonly CustomColors NormalColor = new("#FFFFFF");
    private static readonly CustomColors WarningColor = new("#FF4444");
    private static readonly CustomColors InfoColor = new("#00D9FF");
    private static readonly CustomColors HintColor = new("#AAAAAA");
    private static readonly CustomColors SuccessColor = new("#00FF7F");

    public static void Show()
    {
        _selectedIndex = 0;
        Console.CursorVisible = false;

        while (true)
        {
            var saves = SaveManager.GetAllSaves();

            if (saves.Count == 0)
            {
                ShowEmptyState();
                return;
            }

            saves.Add("Vissza");

            if (_selectedIndex >= saves.Count)
                _selectedIndex = saves.Count - 1;

            DisplayMenu(saves);

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedIndex = _selectedIndex > 0 ? _selectedIndex - 1 : saves.Count - 1;
                    break;

                case ConsoleKey.DownArrow:
                    _selectedIndex = _selectedIndex < saves.Count - 1 ? _selectedIndex + 1 : 0;
                    break;

                case ConsoleKey.Enter:
                    if (_selectedIndex == saves.Count - 1)
                    {
                        return;
                    }
                    LoadAndStart(saves[_selectedIndex]);
                    return;

                case ConsoleKey.Delete:
                    if (_selectedIndex < saves.Count - 1)
                    {
                        HandleDelete(saves[_selectedIndex]);
                    }
                    break;

                case ConsoleKey.Spacebar:
                    if (_selectedIndex < saves.Count - 1)
                    {
                        HandleRename(saves[_selectedIndex]);
                    }
                    break;

                case ConsoleKey.Escape:
                    return;
            }
        }
    }

    private static void DisplayMenu(List<string> saves)
    {
        Render.ClearScreen();

        Render.WriteLineCenter(
            InfoColor.Colorize("Mentett állatok betöltése"),
            customTop: Console.WindowHeight / 2 - saves.Count / 2 - 5
        );

        Render.WriteLineCenter(
            HintColor.Colorize("[SPACE] Átnevezés  |  [DEL] Törlés  |  [ENTER] Betöltés  |  [ESC] Vissza"),
            customTop: Console.WindowHeight / 2 - saves.Count / 2 - 3
        );

        int startTop = Console.WindowHeight / 2 - saves.Count / 2;
        int maxLength = saves.Max(s => s.Length);
        int leftPadding = (Console.WindowWidth - maxLength - 3) / 2;

        for (int i = 0; i < saves.Count; i++)
        {
            string indicator = i == _selectedIndex ? ">" : " ";
            string option = saves[i];
            CustomColors color = i == _selectedIndex ? SelectedColor : NormalColor;

            string colorizedLine = $"{color.Colorize(indicator)} {color.Colorize("|")} {color.Colorize(option)}";

            Console.SetCursorPosition(leftPadding, startTop + i);
            Console.Write(colorizedLine);
        }
    }

    private static void ShowEmptyState()
    {
        Render.ClearScreen();
        Render.WriteLineCenter(
            WarningColor.Colorize("Nincsenek mentett állatok."),
            customTop: Console.WindowHeight / 2 - 1
        );
        Render.WriteLineCenter(
            NormalColor.Colorize("Nyomj meg egy gombot a visszalépéshez..."),
            customTop: Console.WindowHeight / 2 + 1
        );
        Console.ReadKey(true);
    }

    private static void HandleDelete(string name)
    {
        Render.ClearScreen();
        Render.WriteLineCenter(
            WarningColor.Colorize($"Biztosan törölni szeretnéd \"{name}\"-t?"),
            customTop: Console.WindowHeight / 2 - 1
        );
        Render.WriteLineCenter(
            NormalColor.Colorize("[I] Igen  |  [N] Nem"),
            customTop: Console.WindowHeight / 2 + 1
        );

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.I)
            {
                SaveManager.Delete(name);
                ShowTemporaryMessage(SuccessColor.Colorize($"\"{name}\" sikeresen törölve!"));
                break;
            }
            if (key.Key == ConsoleKey.N || key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    private static void HandleRename(string oldName)
    {
        string errorMessage = string.Empty;

        while (true)
        {
            Render.ClearScreen();
            Render.WriteLineCenter(
                InfoColor.Colorize($"\"{oldName}\" átnevezése"),
                customTop: Console.WindowHeight / 2 - 4
            );

            if (!string.IsNullOrEmpty(errorMessage))
            {
                Render.WriteLineCenter(
                    WarningColor.Colorize(errorMessage),
                    customTop: Console.WindowHeight / 2 - 2
                );
            }

            Render.WriteLineCenter(
                NormalColor.Colorize("Add meg az új nevet (ESC a visszalépéshez):"),
                customTop: Console.WindowHeight / 2
            );

            Console.CursorVisible = true;
            int inputLeft = Console.WindowWidth / 2 - 10;
            Console.SetCursorPosition(inputLeft, Console.WindowHeight / 2 + 2);

            string? newName = ReadLineWithEscape();
            Console.CursorVisible = false;

            if (newName == null)
            {
                return;
            }

            newName = newName.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                errorMessage = "A név nem lehet üres!";
                continue;
            }

            if (newName == oldName)
            {
                errorMessage = "Az új név nem egyezhet a régivel!";
                continue;
            }

            if (SaveManager.IsNameTaken(newName))
            {
                errorMessage = $"A(z) \"{newName}\" név már foglalt!";
                continue;
            }

            ShowTemporaryMessage(SaveManager.Rename(oldName, newName)
                ? SuccessColor.Colorize($"\"{oldName}\" sikeresen átnevezve \"{newName}\"-ra!")
                : WarningColor.Colorize("Hiba történt az átnevezés során!"));

            return;
        }
    }

    private static string? ReadLineWithEscape()
    {
        string input = string.Empty;
        while (true)
        {
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
                return null;

            if (keyInfo.Key == ConsoleKey.Enter)
                return input;

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input = input[..^1];
                    int curLeft = Console.CursorLeft;
                    if (curLeft > 0)
                    {
                        Console.SetCursorPosition(curLeft - 1, Console.CursorTop);
                        Console.Write(' ');
                        Console.SetCursorPosition(curLeft - 1, Console.CursorTop);
                    }
                }
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                input += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar);
            }
        }
    }

    private static void ShowTemporaryMessage(string message)
    {
        Render.ClearScreen();
        Render.WriteLineCenter(message, customTop: Console.WindowHeight / 2);
        Thread.Sleep(1500);
    }

    private static void LoadAndStart(string name)
    {
        var allat = SaveManager.Load(name);

        if (allat == null)
        {
            Render.ClearScreen();
            Render.WriteLineCenter(
                WarningColor.Colorize("Hiba a mentés betöltésekor!"),
                customTop: Console.WindowHeight / 2
            );
            Console.ReadKey(true);
            return;
        }

        Interactions.Start(allat);
    }
}
