using System.Text.RegularExpressions;

namespace KobolduldozokLib.Helpers;

public class CustomColors
{
    public string HexColor { get; private set; }
    public int R { get; private set; }
    public int G { get; private set; }
    public int B { get; private set; }

    public CustomColors(string hexColor)
    {
        if (!IsValidHexColor(hexColor))
        {
            throw new ArgumentException($"Érvénytelen HEX színformátum: {hexColor}. Elvárt: #RRGGBB vagy RRGGBB");
        }

        hexColor = hexColor.TrimStart('#');
        HexColor = "#" + hexColor.ToUpper();

        R = Convert.ToInt32(hexColor.Substring(0, 2), 16);
        G = Convert.ToInt32(hexColor.Substring(2, 2), 16);
        B = Convert.ToInt32(hexColor.Substring(4, 2), 16);
    }

    private bool IsValidHexColor(string hexColor)
    {
        if (string.IsNullOrWhiteSpace(hexColor))
        {
            return false;
        }

        hexColor = hexColor.TrimStart('#');
        return hexColor.Length == 6 && Regex.IsMatch(hexColor, "^[0-9A-Fa-f]{6}$");
    }

    //ANSI escape kódok szín be/visszaállításra
    public string GetAnsiColorCode()
    {
        return $"\x1b[38;2;{R};{G};{B}m";
    }
    
    public static string GetResetCode()
    {
        return "\x1b[0m";
    }

    public string Colorize(string text)
    {
        return $"{GetAnsiColorCode()}{text}{GetResetCode()}";
    }

    public string Colorize(char character)
    {
        return $"{GetAnsiColorCode()}{character}{GetResetCode()}";
    }

    public override string ToString()
    {
        return $"{HexColor} (R:{R}, G:{G}, B:{B})";
    }
}
