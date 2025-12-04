using System.Text;
using KobolduldozokLib.Entities.Characters;
using KobolduldozokLib.Entities.Objects;
using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.UI.Menu;

public class HelpMenu
{
    private readonly CustomColors _titleColor;
    private readonly CustomColors _textColor;
    private readonly CustomColors _accentColor;

    public HelpMenu()
    {
        _titleColor = new CustomColors("#FFD700");
        _textColor = new CustomColors("#FFFFFF");
        _accentColor = new CustomColors("#00FF00");
    }

    public void Show()
    {
        Console.Clear();
        Console.CursorVisible = false;

        Render();

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'q' || key.KeyChar == 'Q' || key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }

        Console.CursorVisible = true;
    }

    private void Render()
    {
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        int startY = Math.Max(2, (consoleHeight - 20) / 2);

        const string title = "╔══════════════════════════╗";
        const string titleText = "║        Információk       ║";
        const string titleBottom = "╚══════════════════════════╝";

        RenderCenteredLine(startY, title, _titleColor);
        RenderCenteredLine(startY + 1, titleText, _titleColor);
        RenderCenteredLine(startY + 2, titleBottom, _titleColor);

        startY += 4;

        const int entityContentWidth = 20;
        int entityLeftMargin = (consoleWidth - entityContentWidth) / 2;

        const int infoContentWidth = 53;
        int infoContentMargin = (consoleWidth - infoContentWidth) / 2;
        
        RenderCenteredLine(startY++, "JELMAGYARÁZAT:", _accentColor);

        House sampleHouse = new House(new Position(0, 0));
        RenderEntityLine(startY++, entityLeftMargin, sampleHouse.DisplaySymbol, sampleHouse.CustomColor, sampleHouse.Name);

        Farmer sampleFarmer = new Farmer(new Position(0, 0));
        RenderEntityLine(startY++, entityLeftMargin, sampleFarmer.DisplaySymbol, sampleFarmer.CustomColor, sampleFarmer.Name);

        Kobold sampleKobold = new Kobold(new Position(0, 0));
        RenderEntityLine(startY++, entityLeftMargin, sampleKobold.DisplaySymbol, sampleKobold.CustomColor, sampleKobold.Name);

        Angel sampleAngel = new Angel(new Position(0, 0));
        RenderEntityLine(startY++, entityLeftMargin, sampleAngel.DisplaySymbol, sampleAngel.CustomColor, sampleAngel.Name);

        Coin sampleCoin = new Coin(new Position(0, 0));
        RenderEntityLine(startY++, entityLeftMargin, sampleCoin.DisplaySymbol, sampleCoin.CustomColor, sampleCoin.Name);

        startY += 2;

        RenderCenteredLine(startY++, "SZIMULÁCIÓ MENETE:", _accentColor);
        RenderLeftAlignedLine(startY++, infoContentMargin, "• Barna koboldok illegálisan ingatlant bitorolnak, fenyegetőznek", _textColor);
        RenderLeftAlignedLine(startY++, infoContentMargin, "• 2 érme (segély) felvétele után osztódnak (+2-4)", _textColor);
        RenderLeftAlignedLine(startY++, infoContentMargin, "• Angyalok elindulnak a koboldok felé, ha azok házhoz értek", _textColor);
        RenderLeftAlignedLine(startY++, infoContentMargin, "• Angyalok üldözik és megsemmisítik a koboldokat", _textColor);

        RenderCenteredLine(consoleHeight - 2, "ESC/Q: Visszalépés", new CustomColors("#808080"));
    }

    private static void RenderLeftAlignedLine(int y, int x, string text, CustomColors color)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(color.Colorize(text));
    }

    private static void RenderEntityLine(int y, int x, char symbol, CustomColors symbolColor, string name)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("  ");
        Console.Write(symbolColor.Colorize(symbol));
        Console.Write(" - ");
        Console.Write(name);
    }

    private static void RenderCenteredLine(int y, string text, CustomColors color)
    {
        int consoleWidth = Console.WindowWidth;
        int startX = (consoleWidth - StripAnsiCodes(text).Length) / 2;

        if (startX < 0) startX = 0;

        Console.SetCursorPosition(startX, y);
        Console.Write(color.Colorize(text));
    }

    private static string StripAnsiCodes(string text)
    {
        return System.Text.RegularExpressions.Regex.Replace(text, @"\x1b\[[0-9;]*m", "");
    }
}
