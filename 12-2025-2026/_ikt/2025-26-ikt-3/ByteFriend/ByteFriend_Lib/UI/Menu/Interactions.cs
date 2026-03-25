using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Entities.Animals;
using ByteFriend_Lib.Helpers;

namespace ByteFriend_Lib.UI.Menu;

public static class Interactions
{
    private static readonly CustomColors StatLabelColor = new("#00D9FF");
    private static readonly CustomColors HealthyColor = new("#00FF7F");
    private static readonly CustomColors WarningColor = new("#FFD700");
    private static readonly CustomColors DangerColor = new("#FF4444");
    private static readonly CustomColors EmptyBarColor = new("#555555");
    private static readonly CustomColors ActionColor = new("#FFFFFF");
    private static readonly CustomColors SelectedActionColor = new("#00FF7F");
    private static readonly CustomColors EventColor = new("#FF8C00");

    private static int _selectedAction;
    private static string? _eventMessage;
    private static int _eventMessageTicks;

    public static void Start(IAnimal animal)
    {
        _selectedAction = 0;
        _eventMessage = null;
        _eventMessageTicks = 0;

        SaveManager.Save(animal);

        Console.CursorVisible = false;
        bool running = true;

        while (running)
        {
            if (CheckDeath(animal)) return;

            var actions = BuildActionList(animal);
            DrawScreen(animal, actions);

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    _selectedAction = _selectedAction > 0 ? _selectedAction - 1 : actions.Count - 1;
                    break;

                case ConsoleKey.RightArrow:
                    _selectedAction = _selectedAction < actions.Count - 1 ? _selectedAction + 1 : 0;
                    break;

                case ConsoleKey.Enter:
                    running = ExecuteAction(animal, actions);
                    break;

                case ConsoleKey.Escape:
                    SaveManager.Save(animal);
                    running = false;
                    break;
            }
        }
    }

    private static List<(string Nev, Action<IAnimal>? Akcio)> BuildActionList(IAnimal animal)
    {
        var actions = new List<(string Nev, Action<IAnimal>? Akcio)>();

        foreach (var interaction in animal.GetInteractions())
        {
            actions.Add(interaction);
        }

        actions.Add(("Etetés", a =>
        {
            a.Hunger = Math.Clamp(a.Hunger - 20, 0, 100);
            a.Happiness = Math.Clamp(a.Happiness + 5, 0, 100);
        }));

        if (!animal.IsHealthy)
        {
            actions.Add(("Gyógyítás", a =>
            {
                a.IsHealthy = true;
                a.Happiness = Math.Clamp(a.Happiness + 10, 0, 100);
            }));
        }

        actions.Add(("Mentés", null));
        actions.Add(("Kilépés", null));

        return actions;
    }

    private static bool ExecuteAction(IAnimal animal, List<(string Nev, Action<IAnimal>? Akcio)> actions)
    {
        if (_selectedAction >= actions.Count) return true;

        var (nev, akcio) = actions[_selectedAction];

        if (nev == "Kilépés")
        {
            SaveManager.Save(animal);
            return false;
        }

        if (nev == "Mentés")
        {
            SaveManager.Save(animal);
            _eventMessage = "Játék mentve!";
            _eventMessageTicks = 3;
            return true;
        }

        akcio?.Invoke(animal);
        TimeManager.Tick(animal);

        string? randomEvent = RandomEventManager.ProcessRandomEvent(animal);
        if (randomEvent != null)
        {
            _eventMessage = randomEvent;
            _eventMessageTicks = 3;
        }

        SaveManager.Save(animal);

        _selectedAction = Math.Clamp(_selectedAction, 0, BuildActionList(animal).Count - 1);

        return true;
    }

    private static bool CheckDeath(IAnimal animal)
    {
        if (animal is Goldfish { AquariumSmashed: true })
        {
            SaveManager.Delete(animal.Name);
            DeathScreen.Show(animal, "Az akvárium földhöz vágva... Ennek annyi.");
            return true;
        }

        if (TimeManager.IsStarvationDeath(animal))
        {
            SaveManager.Delete(animal.Name);
            DeathScreen.Show(animal, $"{animal.Name} éhen halt...");
            return true;
        }

        if (TimeManager.IsNaturalDeath(animal))
        {
            SaveManager.Delete(animal.Name);
            DeathScreen.Show(animal, $"{animal.Name} megöregedett és békében elaludt örökre...");
            return true;
        }

        return false;
    }

    private static void DrawScreen(IAnimal animal, List<(string Nev, Action<IAnimal>? Akcio)> actions)
    {
        Render.ClearScreen();

        DrawStats(animal);
        DrawAsciiArt(animal);
        DrawEventMessage();
        DrawActions(actions);
    }

    private static void DrawStats(IAnimal animal)
    {
        int top = 1;

        string nameInfo = StatLabelColor.Colorize($"{animal.Name} ({animal.TypeName})");
        string szakaszInfo = StatLabelColor.Colorize($"Életszakasz: {TimeManager.GetStateName(animal.State)}");
        string ageInfo = StatLabelColor.Colorize($"Életkor: {animal.Age}");

        Render.WriteAtCenter(top, nameInfo);
        Render.WriteAtCenter(top + 1, szakaszInfo);
        Render.WriteAtCenter(top + 2, ageInfo);

        CustomColors hungerBarColor = animal.Hunger switch
        {
            >= 75 => DangerColor,
            >= 50 => WarningColor,
            _ => HealthyColor
        };
        string hungerBar = Render.BuildStatBar("Éhség    ", animal.Hunger, 100, hungerBarColor, EmptyBarColor);
        Render.WriteAtCenter(top + 4, hungerBar);

        CustomColors happinessBarColor = animal.Happiness switch
        {
            <= 25 => DangerColor,
            <= 50 => WarningColor,
            _ => HealthyColor
        };
        string happinessBar = Render.BuildStatBar("Boldogság", animal.Happiness, 100, happinessBarColor, EmptyBarColor);
        Render.WriteAtCenter(top + 5, happinessBar);

        string healthStatus = animal.IsHealthy
            ? HealthyColor.Colorize("Egészséges ✓")
            : DangerColor.Colorize("Beteg ✗");
        Render.WriteAtCenter(top + 6, $"{StatLabelColor.Colorize("Állapot:")}  {healthStatus}");
    }

    private static void DrawAsciiArt(IAnimal animal)
    {
        int centerTop = Console.WindowHeight / 2 - animal.AsciiArt.Length / 2;

        for (int i = 0; i < animal.AsciiArt.Length; i++)
        {
            Render.WriteAtCenter(centerTop + i, animal.AsciiArt[i]);
        }
    }

    private static void DrawEventMessage()
    {
        if (_eventMessage == null || _eventMessageTicks <= 0) return;

        int msgTop = Console.WindowHeight - 5;
        Render.WriteAtCenter(msgTop, EventColor.Colorize(_eventMessage));
        _eventMessageTicks--;

        if (_eventMessageTicks <= 0)
        {
            _eventMessage = null;
        }
    }

    private static void DrawActions(List<(string Nev, Action<IAnimal>? Akcio)> actions)
    {
        int bottom = Console.WindowHeight - 2;

        var parts = new List<string>();
        int totalVisibleLength = 0;

        for (int i = 0; i < actions.Count; i++)
        {
            string label = actions[i].Nev;
            string separator = i < actions.Count - 1 ? "  |  " : "";

            if (i == _selectedAction)
            {
                parts.Add(SelectedActionColor.Colorize($"[{label}]") + separator);
            }
            else
            {
                parts.Add(ActionColor.Colorize($" {label} ") + separator);
            }

            totalVisibleLength += label.Length + 2 + (i < actions.Count - 1 ? 5 : 0);
        }

        int left = Math.Max(0, (Console.WindowWidth - totalVisibleLength) / 2);
        Console.SetCursorPosition(left, bottom);

        foreach (string part in parts)
        {
            Console.Write(part);
        }

        string hint = StatLabelColor.Colorize("◄ ► Választás | ENTER Végrehajtás | ESC Kilépés");
        Render.WriteAtCenter(bottom - 1, hint);
    }
}