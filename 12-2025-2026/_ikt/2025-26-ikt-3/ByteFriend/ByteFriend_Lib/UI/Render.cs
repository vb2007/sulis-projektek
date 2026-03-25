using System.Text.RegularExpressions;
using ByteFriend_Lib.Helpers;

namespace ByteFriend_Lib.UI;

public static class Render
{
    private static readonly Regex AnsiEscapePattern = new(@"\x1b\[[0-9;]*m", RegexOptions.Compiled);

    public static void ClearScreen()
    {
        Console.Clear();
    }

    //currently only used for stripping color codes to properly center text
    private static string StripAnsiCodes(string text)
    {
        return AnsiEscapePattern.Replace(text, string.Empty);
    }

    public static void WriteLineCenter(string text, int? customTop = null, string? colorizedText = null)
    {
        string visibleText = StripAnsiCodes(text);
        int windowWidth = Console.WindowWidth;
        int left = Math.Max(0, (windowWidth - visibleText.Length) / 2);
        
        if (customTop.HasValue)
        {
            Console.SetCursorPosition(left, customTop.Value);
        }
        else
        {
            Console.Write(new string(' ', left));
        }
        
        Console.WriteLine(colorizedText ?? text);
    }

    public static void WriteAt(int left, int top, string text)
    {
        Console.SetCursorPosition(left, top);
        Console.Write(text);
    }

    public static void WriteAtCenter(int top, string text)
    {
        string visible = StripAnsiCodes(text);
        int left = Math.Max(0, (Console.WindowWidth - visible.Length) / 2);
        Console.SetCursorPosition(left, top);
        Console.Write(text);
    }

    public static string BuildStatBar(string label, int value, int max, CustomColors filledColor, CustomColors emptyColor)
    {
        int barWidth = 20;
        int filled = (int)Math.Round((double)value / max * barWidth);
        filled = Math.Clamp(filled, 0, barWidth);
        int empty = barWidth - filled;

        string filledPart = filledColor.Colorize(new string('█', filled));
        string emptyPart = emptyColor.Colorize(new string('░', empty));

        return $"{label}: [{filledPart}{emptyPart}] {value}/{max}";
    }

    public static void ClearLine(int top)
    {
        Console.SetCursorPosition(0, top);
        Console.Write(new string(' ', Console.WindowWidth));
    }
}