using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Lib.Helpers;

namespace ByteFriend_Lib.UI.Menu;

public static class AnimalPickerMenu
{
    private static int _selectedIndex;
    private static readonly string[] Options = [ "Majom", "Aranyhal", "Macska", "Vissza" ];
    private static readonly CustomColors SelectedColor = new CustomColors("#00FF7F");
    private static readonly CustomColors NormalColor = new CustomColors("#FFFFFF");
    private static readonly CustomColors WarningColor = new CustomColors("#FF0000");
    private static readonly CustomColors AsciiArtColor = new CustomColors("#00BFFF");

    private static readonly IAnimal[] PreviewAnimals = [ new Monkey(), new Goldfish(), new Cat() ];
    private static readonly int MaxAsciiArtHeight = PreviewAnimals.Max(a => a.AsciiArt.Length);

    private static IAnimal? GetPreviewAnimal(int index) =>
        index >= 0 && index < PreviewAnimals.Length ? PreviewAnimals[index] : null;

    public static void Show()
    {
        Console.CursorVisible = false;
        bool running = true;

        while (running)
        {
            DisplayMenu();

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedIndex = _selectedIndex > 0 ? _selectedIndex - 1 : Options.Length - 1;
                    break;
                case ConsoleKey.DownArrow:
                    _selectedIndex = _selectedIndex < Options.Length - 1 ? _selectedIndex + 1 : 0;
                    break;
                case ConsoleKey.Enter:
                    if (_selectedIndex == Options.Length - 1)
                    {
                        running = false;
                    }
                    else
                    {
                        HandleNameInput(_selectedIndex);
                        return; 
                    }
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Render.ClearScreen();

        int titleTop = Console.WindowHeight / 2 - 10;
        Render.WriteLineCenter("Válassz egy állatot!", customTop: titleTop);

        IAnimal? previewAnimal = GetPreviewAnimal(_selectedIndex);
        int asciiStartTop = titleTop + 2;

        if (previewAnimal != null)
        {
            string[] art = previewAnimal.AsciiArt;

            for (int i = 0; i < art.Length; i++)
            {
                string colorizedLine = AsciiArtColor.Colorize(art[i]);
                Render.WriteAtCenter(asciiStartTop + i, colorizedLine);
            }
        }

        int startTop = asciiStartTop + MaxAsciiArtHeight + 1;
        int maxLength = Options.Max(o => o.Length);
        int leftPadding = (Console.WindowWidth - maxLength - 3) / 2;

        for (int i = 0; i < Options.Length; i++)
        {
            string indicator = i == _selectedIndex ? ">" : " ";
            string option = Options[i];
            CustomColors color = i == _selectedIndex ? SelectedColor : NormalColor;
            
            string colorizedLine = $"{color.Colorize(indicator)} {color.Colorize("|")} {color.Colorize(option)}";
            
            Console.SetCursorPosition(leftPadding, startTop + i);
            Console.Write(colorizedLine);
        }
    }

    private static void HandleNameInput(int animalIndex)
    {
        string animalType = Options[animalIndex];
        string errorMessage = string.Empty;
        
        while (true)
        {
            Render.ClearScreen();
            Render.WriteLineCenter($"Választott állat: {animalType}", customTop: Console.WindowHeight / 2 - 4);
            
            if (!string.IsNullOrEmpty(errorMessage))
            {
                 Render.WriteLineCenter(WarningColor.Colorize(errorMessage), customTop: Console.WindowHeight / 2 - 2);
            }

            Render.WriteLineCenter("Kérlek add meg a nevét:", customTop: Console.WindowHeight / 2);

            Console.CursorVisible = true;
            int inputLeft = Console.WindowWidth / 2 - 10;
            Console.SetCursorPosition(inputLeft, Console.WindowHeight / 2 + 2);
            
            string? name = Console.ReadLine()?.Trim();
            Console.CursorVisible = false;

            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "A név nem lehet üres!";
                continue;
            }

            if (SaveManager.IsNameTaken(name))
            {
                errorMessage = $"A(z) '{name}' név már foglalt! Válassz másikat.";
                continue;
            }

            IAnimal animal = animalIndex switch
            {
                0 => new Monkey(),
                1 => new Goldfish(),
                2 => new Cat(),
                _ => throw new InvalidOperationException("Ismeretlen állat típus.")
            };

            animal.Name = name;
            animal.Age = 0;
            animal.IsHealthy = true;

            Interactions.Start(animal);
            return;
        }
    }
}