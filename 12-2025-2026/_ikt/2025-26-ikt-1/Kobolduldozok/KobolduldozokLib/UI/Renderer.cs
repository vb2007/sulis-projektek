using System.Text;
using KobolduldozokLib.Entities;
using KobolduldozokLib.Helpers;
using KobolduldozokLib.UI.Simulation;

namespace KobolduldozokLib.UI;

public class Renderer
{
    private const int MatrixWidth = 31;
    private const int StatsHeight = 7;
    private readonly CustomColors _titleColor = new("#FFD700");

    public void RenderAll(IEntity?[,] grid, Statistics stats, ActivityLog activityLog, bool isRunning)
    {
        Console.Clear();

        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        RenderMatrix(grid, 0, 0);
        RenderStatistics(stats, MatrixWidth + 2, 0, consoleWidth - MatrixWidth - 2);
        RenderActivityLog(activityLog, MatrixWidth + 2, StatsHeight + 1, consoleWidth - MatrixWidth - 2, consoleHeight - StatsHeight - 1);
    }

    private void RenderMatrix(IEntity?[,] grid, int startX, int startY)
    {
        StringBuilder sb = new StringBuilder();
        int height = grid.GetLength(0);
        int width = grid.GetLength(1);

        sb.Append("  ┌");
        sb.Append(new string('─', width * 2 - 1));
        sb.AppendLine("┐");

        for (int y = 0; y < height; y++)
        {
            sb.Append("  │");
            for (int x = 0; x < width; x++)
            {
                var entity = grid[y, x];
                sb.Append(entity != null ? entity.CustomColor.Colorize(entity.DisplaySymbol) : '·');
                if (x < width - 1) sb.Append(' ');
            }
            sb.AppendLine("│");
        }

        sb.Append("  └");
        sb.Append(new string('─', width * 2 - 1));
        sb.AppendLine("┘");

        Console.SetCursorPosition(startX, startY);
        Console.Write(sb.ToString());
    }

    private void RenderStatistics(Statistics stats, int startX, int startY, int width)
    {
        int borderWidth = width - 4;
        string title = "Statisztikák";

        RenderTitleBorder(startX, startY, borderWidth, title);

        RenderContentLine(startX, startY + 1, borderWidth, $"Frame: {stats.FrameCount}");
        RenderContentLine(startX, startY + 2, borderWidth, "Koboldok: ", new CustomColors("#8B4513").Colorize(stats.KoboldCount.ToString()));

        string angelStatus = stats.AngelsActive ? "(AKTÍV)" : "(Várakozik)";
        RenderContentLine(startX, startY + 3, borderWidth, "Angyalok: ", new CustomColors("#00FF00").Colorize(stats.AngelCount.ToString()), $" {angelStatus}");

        RenderContentLine(startX, startY + 4, borderWidth, "Érmék: ", _titleColor.Colorize(stats.CoinCount.ToString()));
        RenderContentLine(startX, startY + 5, borderWidth, $"Gyűjtött érmék: {stats.CoinsCollected}");
        RenderContentLine(startX, startY + 6, borderWidth, $"Cél ház: {stats.CurrentHouseIndex + 1}/{stats.TotalHouses}");

        RenderBottomBorder(startX, startY + 7, borderWidth);
    }

    private void RenderActivityLog(ActivityLog log, int startX, int startY, int width, int height)
    {
        int borderWidth = width - 4;
        string title = "Aktivitás napló";

        RenderTitleBorder(startX, startY, borderWidth, title);

        int maxLines = height - 2;
        var recentEvents = log.GetRecentEvents(maxLines);

        int lineY = startY + 1;
        foreach (var eventMsg in recentEvents)
        {
            string displayMsg = eventMsg.Length > borderWidth - 2
                ? eventMsg.Substring(0, borderWidth - 5) + "..."
                : eventMsg;

            RenderContentLine(startX, lineY++, borderWidth, displayMsg);
        }

        for (int i = recentEvents.Count; i < maxLines; i++)
        {
            RenderContentLine(startX, lineY++, borderWidth, "");
        }

        RenderBottomBorder(startX, startY + height - 1, borderWidth);
    }

    private void RenderTitleBorder(int x, int y, int width, string title)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("┌");
        Console.Write(_titleColor.Colorize(title));
        Console.Write(new string('─', Math.Max(0, width - title.Length)));
        Console.Write("┐");
    }

    private void RenderContentLine(int x, int y, int width, params string[] parts)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("│ ");

        int contentLength = 0;
        foreach (var part in parts)
        {
            Console.Write(part);
            contentLength += StripAnsiCodes(part).Length;
        }

        Console.Write(new string(' ', Math.Max(0, width - contentLength - 1)));
        Console.Write("│");
    }

    private void RenderBottomBorder(int x, int y, int width)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("└");
        Console.Write(new string('─', width));
        Console.Write("┘");
    }

    private static string StripAnsiCodes(string text)
    {
        return System.Text.RegularExpressions.Regex.Replace(text, @"\x1b\[[0-9;]*m", "");
    }
}
