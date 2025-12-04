using KobolduldozokLib.Helpers;
using KobolduldozokLib.UI.Simulation;

namespace KobolduldozokLib.UI.Menu;

public class MainMenu
{
    private readonly SimulationSettings _settings;
    private int _selectedButtonIndex;
    private const int MinSpeed = 1;
    private const int MaxSpeed = 10;

    private const int SpeedButtonIndex = 0;
    private const int ManualModeButtonIndex = 1;
    private const int HelpButtonIndex = 2;
    private const int StartButtonIndex = 3;
    private const int TotalButtons = 4;

    private readonly CustomColors _titleColor;
    private readonly CustomColors _selectedColor;
    private readonly CustomColors _normalColor;
    private readonly CustomColors _accentColor;

    public MainMenu()
    {
        _settings = new SimulationSettings();
        _selectedButtonIndex = 0;

        _titleColor = new CustomColors("#FFD700");//arany
        _selectedColor = new CustomColors("#00FF00");//zöld
        _normalColor = new CustomColors("#FFFFFF");//fehér
        _accentColor = new CustomColors("#FFFF00");//sárga
    }

    public SimulationSettings Show()
    {
        Console.CursorVisible = false;

        while (true)
        {
            Render();

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    NavigateUp();
                    break;
                case ConsoleKey.DownArrow:
                    NavigateDown();
                    break;
                case ConsoleKey.LeftArrow:
                    if (_selectedButtonIndex == SpeedButtonIndex)
                    {
                        DecreaseSpeed();
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (_selectedButtonIndex == SpeedButtonIndex)
                    {
                        IncreaseSpeed();
                    }
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (HandleSelection())
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        return _settings;
                    }
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private void Render()
    {
        Console.Clear();

        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        int totalMenuHeight = 7;
        int startY = (consoleHeight - totalMenuHeight) / 2;

        const string title = "╔══════════════════════════╗";
        const string titleText = "║       Koboldüldözők      ║";
        const string titleBottom = "╚══════════════════════════╝";

        RenderCenteredLine(startY, title, _titleColor);
        RenderCenteredLine(startY + 1, titleText, _titleColor);
        RenderCenteredLine(startY + 2, titleBottom, _titleColor);

        startY += 4;

        RenderSpeedButton(startY);
        RenderManualModeButton(startY + 1);
        RenderHelpButton(startY + 2);
        RenderStartButton(startY + 3);

        RenderHelpText(consoleHeight - 2);
    }

    private void RenderSpeedButton(int y)
    {
        bool isSelected = _selectedButtonIndex == SpeedButtonIndex;
        CustomColors color = isSelected ? _selectedColor : _normalColor;

        string leftArrow = isSelected ? "◄" : "<";
        string rightArrow = isSelected ? "►" : ">";
        string buttonText = $"{leftArrow} Sebesség: {_settings.Speed,2} {rightArrow}";

        if (isSelected)
        {
            buttonText = $"[ {buttonText} ]";
        }
        else
        {
            buttonText = $"  {buttonText}  ";
        }

        RenderCenteredLine(y, buttonText, color);
    }

    private void RenderManualModeButton(int y)
    {
        bool isSelected = _selectedButtonIndex == ManualModeButtonIndex;
        CustomColors color = isSelected ? _selectedColor : _normalColor;

        string status = _settings.IsManualMode ? "ON " : "OFF";
        CustomColors statusColor = _settings.IsManualMode ? _accentColor : _normalColor;

        string buttonText = $"Manuális szimuláció [{status}]";

        if (isSelected)
        {
            int consoleWidth = Console.WindowWidth;
            int startX = (consoleWidth - buttonText.Length - 4) / 2;

            Console.SetCursorPosition(startX, y);
            Console.Write(_selectedColor.Colorize("[ "));
            Console.Write(_selectedColor.Colorize("Manuális szimuláció ["));
            Console.Write(statusColor.Colorize(status));
            Console.Write(_selectedColor.Colorize("]"));
            Console.Write(_selectedColor.Colorize(" ]"));
        }
        else
        {
            int consoleWidth = Console.WindowWidth;
            int startX = (consoleWidth - buttonText.Length - 4) / 2;

            Console.SetCursorPosition(startX, y);
            Console.Write(_normalColor.Colorize("  "));
            Console.Write(_normalColor.Colorize("Manuális szimuláció ["));
            Console.Write(statusColor.Colorize(status));
            Console.Write(_normalColor.Colorize("]"));
            Console.Write(_normalColor.Colorize("  "));
        }
    }

    private void RenderHelpButton(int y)
    {
        bool isSelected = _selectedButtonIndex == HelpButtonIndex;
        CustomColors color = isSelected ? _selectedColor : _normalColor;

        string buttonText = "Információk";

        if (isSelected)
        {
            buttonText = $"[ {buttonText} ]";
        }
        else
        {
            buttonText = $"  {buttonText}  ";
        }

        RenderCenteredLine(y, buttonText, color);
    }

    private void RenderStartButton(int y)
    {
        bool isSelected = _selectedButtonIndex == StartButtonIndex;
        CustomColors color = isSelected ? _selectedColor : _normalColor;

        string buttonText = "Indítás";

        if (isSelected)
        {
            buttonText = $"[ ► {buttonText} ◄ ]";
        }
        else
        {
            buttonText = $"   {buttonText}   ";
        }

        RenderCenteredLine(y, buttonText, color);
    }

    private void RenderHelpText(int y)
    {
        string helpText = "↑↓: Navigálás  |  ←→: Sebesség  |  Enter/Space: Kiválaszt  |  ESC/Q: Kilépés";
        RenderCenteredLine(y, helpText, new CustomColors("#808080")); //szürke
    }

    private static void RenderCenteredLine(int y, string text, CustomColors color)
    {
        int consoleWidth = Console.WindowWidth;
        int startX = (consoleWidth - text.Length) / 2;

        if (startX < 0) startX = 0;

        Console.SetCursorPosition(startX, y);
        Console.Write(color.Colorize(text));
    }

    private void NavigateUp()
    {
        _selectedButtonIndex--;
        if (_selectedButtonIndex < 0)
        {
            _selectedButtonIndex = TotalButtons - 1;
        }
    }

    private void NavigateDown()
    {
        _selectedButtonIndex++;
        if (_selectedButtonIndex >= TotalButtons)
        {
            _selectedButtonIndex = 0;
        }
    }

    private void IncreaseSpeed()
    {
        if (_settings.Speed < MaxSpeed)
        {
            _settings.Speed++;
        }
    }

    private void DecreaseSpeed()
    {
        if (_settings.Speed > MinSpeed)
        {
            _settings.Speed--;
        }
    }

    private bool HandleSelection()
    {
        switch (_selectedButtonIndex)
        {
            case SpeedButtonIndex:
                return false;
            case ManualModeButtonIndex:
                _settings.IsManualMode = !_settings.IsManualMode;
                return false;
            case HelpButtonIndex:
                HelpMenu helpMenu = new HelpMenu();
                helpMenu.Show();
                return false;
            case StartButtonIndex:
                return true;
            default:
                return false;
        }
    }
}
