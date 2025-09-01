using System.Text;
using RePontGame.Core;
using RePontGame.Models;
using RePontGame.Models.Entities;
using RePontGame.Utils;

namespace RePontGame.UI;

public static class Renderer
{
    private const int WindowWidth = 110;
    private const int WindowHeight = 28;

    private const int MapContentWidth = Services.GameConstants.MapSizeX;
    private const int MapContentHeight = Services.GameConstants.MapSizeY;
    private const int MapFrameInnerWidth = MapContentWidth;
    private const int MapFrameInnerHeight = MapContentHeight;
    private const int MapFrameOuterWidth = MapFrameInnerWidth + 2;
    private const int MapFrameOuterHeight = MapFrameInnerHeight + 2;
    private const int MapFrameLeft = 1;
    private const int MapFrameTop = 1;

    private const int InfoFrameLeft = MapFrameLeft + MapFrameOuterWidth + 1;
    private const int InfoFrameTop = MapFrameTop;
    private const int InfoFrameWidth = WindowWidth - InfoFrameLeft - 1;
    private const int InfoFrameHeight = 10;
    private const int InfoContentWidth = InfoFrameWidth - 2;

    private const int MsgFrameLeft = InfoFrameLeft;
    private const int MsgFrameTop = InfoFrameTop + InfoFrameHeight + 1;
    private const int MsgFrameWidth = InfoFrameWidth;
    private const int MsgFrameHeight = 6;
    private const int MsgContentWidth = MsgFrameWidth - 2;
    private const int MaxLogMessages = MsgFrameHeight - 2;

    private const int InteractFrameLeft = InfoFrameLeft;
    private const int InteractFrameTop = MsgFrameTop + MsgFrameHeight + 1;
    private const int InteractFrameWidth = InfoFrameWidth;
    private const int InteractFrameHeight = WindowHeight - ((InfoFrameTop + InfoFrameHeight) + MsgFrameHeight + 1) - 1;
    private const int InteractContentWidth = InteractFrameWidth - 2;

    public static readonly ConsoleColor BorderColor = ConsoleColor.DarkGray;
    public static readonly ConsoleColor TitleColor = ConsoleColor.White;
    public static readonly ConsoleColor PlayerInfoColor = ConsoleColor.Yellow;
    public static readonly ConsoleColor MessageColor = ConsoleColor.Gray;
    public static readonly ConsoleColor ErrorColor = ConsoleColor.Red;
    public static readonly ConsoleColor SuccessColor = ConsoleColor.Green;
    public static readonly ConsoleColor PromptColor = ConsoleColor.Cyan;
    public static readonly ConsoleColor WarningColor = ConsoleColor.DarkYellow;
    public static readonly ConsoleColor UpgradeColor = ConsoleColor.Cyan;
    public static readonly ConsoleColor EffectColor = ConsoleColor.Magenta;
    public static readonly ConsoleColor MaxLevelColor = ConsoleColor.DarkCyan;
    public static readonly ConsoleColor UnaffordableColor = ConsoleColor.DarkRed;
    public static readonly ConsoleColor HighlightColor = ConsoleColor.White;
    public static readonly ConsoleColor HighlightBgColor = ConsoleColor.DarkBlue;
    public static readonly ConsoleColor HelpTextColor = ConsoleColor.Gray;
    public static readonly ConsoleColor HelpHeaderColor = ConsoleColor.Cyan;
    public static readonly ConsoleColor HelpSymbolColor = ConsoleColor.Yellow;

    public static bool InitializeConsole()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Gödöllői Kalandjáték - RePont";
        Console.CursorVisible = false;

        try
        {
            if (OperatingSystem.IsWindows())
            {
                int targetWidth = WindowWidth;
                int targetHeight = WindowHeight;

                try
                {
                    int bufferWidth = Math.Max(Console.BufferWidth, targetWidth);
                    int bufferHeight = Math.Max(Console.BufferHeight, targetHeight);
                    Console.SetBufferSize(bufferWidth, bufferHeight);
                    Console.SetWindowSize(targetWidth, targetHeight);
                    if (Console.BufferWidth < targetWidth || Console.BufferHeight < targetHeight)
                        Console.SetBufferSize(targetWidth, targetHeight);
                }
                catch (ArgumentOutOfRangeException) { }
                catch (IOException) { }
                catch (PlatformNotSupportedException) { }

                Thread.Sleep(100);
                if (Console.WindowWidth < targetWidth || Console.WindowHeight < targetHeight)
                {
                    Console.Clear();
                    Console.ForegroundColor = WarningColor;
                    Console.WriteLine($"Figyelem: A konzol mérete ({Console.WindowWidth}x{Console.WindowHeight})");
                    Console.WriteLine($"kisebb, mint az ajánlott ({targetWidth}x{targetHeight}). A megjelenítés hibás lehet.");
                    Console.ResetColor();
                    Console.WriteLine("\nNyomj egy gombot a folytatáshoz...");
                    Console.ReadKey(true);
                }
            }
            else
            {
                if (Console.WindowWidth < WindowWidth || Console.WindowHeight < WindowHeight)
                {
                    Console.Clear();
                    Console.ForegroundColor = WarningColor;
                    Console.WriteLine($"Figyelem: A konzol mérete ({Console.WindowWidth}x{Console.WindowHeight}) kisebb, mint az ajánlott ({WindowWidth}x{WindowHeight}).");
                    Console.WriteLine("A megjelenítés hibás lehet. Próbáld manuálisan nagyobbra állítani.");
                    Console.ResetColor();
                    Console.WriteLine("\nNyomj egy gombot a folytatáshoz...");
                    Console.ReadKey(true);
                }
            }
            return true;
        }
        catch (PlatformNotSupportedException)
        {
            Console.Clear();
            Console.ForegroundColor = WarningColor;
            Console.WriteLine("Figyelem: A konzol méretének automatikus beállítása nem támogatott ezen a platformon.");
            Console.WriteLine($"Ajánlott méret: {WindowWidth}x{WindowHeight}. A jelenlegi: {Console.WindowWidth}x{Console.WindowHeight}.");
            if (Console.WindowWidth < WindowWidth || Console.WindowHeight < WindowHeight)
            {
                Console.WriteLine("A megjelenítés hibás lehet. Próbáld manuálisan nagyobbra állítani.");
            }
            Console.ResetColor();
            Console.WriteLine("\nNyomj egy gombot a folytatáshoz...");
            Console.ReadKey(true);
            return true;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine("Váratlan hiba a konzol inicializálása közben:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Console.WriteLine("\nNyomj egy gombot a kilépéshez...");
            Console.ReadKey();
            return false;
        }
    }

    public static void DrawLayout(int mapDisplayWidth, int mapDisplayHeight)
    {
        Console.Clear();
        DrawBox(MapFrameLeft, MapFrameTop, mapDisplayWidth + 2, mapDisplayHeight + 2, "Térkép");
        DrawBox(InfoFrameLeft, InfoFrameTop, InfoFrameWidth, InfoFrameHeight, "Játékos");
        DrawBox(MsgFrameLeft, MsgFrameTop, MsgFrameWidth, MsgFrameHeight, "Események");
        DrawBox(InteractFrameLeft, InteractFrameTop, InteractFrameWidth, InteractFrameHeight, "Interakció");
        Console.ResetColor();
    }

    //positions
    public static void Render(GameState state)
    {
        DrawMapContent(state);
        DrawPlayerInfo(state);
        DrawMessages(state);
        if (!state.IsGameOver && !state.Enemies.Any(e => MapUtils.GetAdjacentPositions(state.GamePlayer.Position, state.GameMap).Contains(e.Position)))
        {
            ClearInteractionPanel();
        }
    }

    public static void ClearInteractionPanel()
    {
        ClearRegion(InteractFrameLeft + 1, InteractFrameTop + 1, InteractContentWidth, InteractFrameHeight - 2);
    }

    internal static void DrawBox(int left, int top, int width, int height, string title = "")
    {
        if (width < 2 || height < 2 || left + width > Console.BufferWidth || top + height > Console.BufferHeight || left < 0 || top < 0)
        {
            return;
        }

        Console.ForegroundColor = BorderColor;

        WriteAt(left, top, '╔', BorderColor);
        for (int i = 1; i < width - 1; i++) WriteAt(left + i, top, '═', BorderColor);
        WriteAt(left + width - 1, top, '╗', BorderColor);

        for (int y = top + 1; y < top + height - 1; y++)
        {
            if (y < Console.BufferHeight)
            {
                if (left >= 0 && left < Console.BufferWidth) WriteAt(left, y, '║', BorderColor);
                if (left + width - 1 >= 0 && left + width - 1 < Console.BufferWidth) WriteAt(left + width - 1, y, '║', BorderColor);
            }
        }

        if (top + height - 1 < Console.BufferHeight)
        {
            WriteAt(left, top + height - 1, '╚', BorderColor);
            for (int i = 1; i < width - 1; i++) WriteAt(left + i, top + height - 1, '═', BorderColor);
            WriteAt(left + width - 1, top + height - 1, '╝', BorderColor);
        }


        if (!string.IsNullOrEmpty(title))
        {
            int titleStartOffset = 2;
            int titleEndOffset = 2;
            int maxTitleWidth = width - titleStartOffset - titleEndOffset;
            if (maxTitleWidth < 1) maxTitleWidth = 1;

            string clippedTitle = title.Length <= maxTitleWidth ? title : title.Substring(0, maxTitleWidth);
            int titleStartX = left + titleStartOffset;

            if (clippedTitle.Length > 0 && top >= 0 && top < Console.BufferHeight)
            {
                if (titleStartX - 1 >= 0 && titleStartX - 1 < Console.BufferWidth) WriteAt(titleStartX - 1, top, '╣', BorderColor);
                if (titleStartX + clippedTitle.Length >= 0 && titleStartX + clippedTitle.Length < Console.BufferWidth) WriteAt(titleStartX + clippedTitle.Length, top, '╠', BorderColor);
                WriteAt(titleStartX, top, clippedTitle, TitleColor);
            }
        }
        Console.ResetColor();
    }

    internal static void WriteAt(int left, int top, char c, ConsoleColor color)
    {
        WriteAt(left, top, c.ToString(), color, Console.BackgroundColor);
    }

    internal static void WriteAt(int left, int top, string s, ConsoleColor color)
    {
        WriteAt(left, top, s, color, Console.BackgroundColor);
    }

    internal static void WriteAt(int left, int top, string s, ConsoleColor fgColor, ConsoleColor bgColor)
    {
        if (left >= 0 && top >= 0 && top < Console.BufferHeight)
        {
            try
            {
                Console.SetCursorPosition(left, top);
                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;
                int availableWidth = Console.BufferWidth - left;
                if (availableWidth <= 0) return;
                string clippedString = s.Length <= availableWidth ? s : s.Substring(0, availableWidth);
                Console.Write(clippedString);
            }
            catch (ArgumentOutOfRangeException) { }
            catch (IOException) { }
            finally
            {
                Console.ResetColor();
            }
        }
    }

    internal static void WriteAtAndClearRest(int left, int top, string s, int contentWidth, ConsoleColor fgColor, ConsoleColor bgColor)
    {
        if (left >= 0 && top >= 0 && top < Console.BufferHeight && contentWidth > 0)
        {
            try
            {
                Console.SetCursorPosition(left, top);
                Console.ForegroundColor = fgColor;
                Console.BackgroundColor = bgColor;

                int availableWriteWidth = Math.Min(contentWidth, Console.BufferWidth - left);
                if (availableWriteWidth <= 0) return;

                string clippedString = s.Length <= availableWriteWidth ? s : s.Substring(0, availableWriteWidth);
                Console.Write(clippedString);

                int clearWidth = availableWriteWidth - clippedString.Length;
                if (clearWidth > 0)
                {
                    clearWidth = Math.Min(clearWidth, Console.BufferWidth - (left + clippedString.Length));
                    if (clearWidth > 0)
                        Console.Write(new string(' ', clearWidth));
                }
            }
            catch (ArgumentOutOfRangeException) { }
            catch (IOException) { }
            finally
            {
                Console.ResetColor();
            }
        }
    }

    internal static void ClearRegion(int left, int top, int width, int height)
    {
        if (left < 0) { width += left; left = 0; }
        if (top < 0) { height += top; top = 0; }
        if (width <= 0 || height <= 0) return;

        int effectiveWidth = Math.Min(width, Console.BufferWidth - left);
        int effectiveHeight = Math.Min(height, Console.BufferHeight - top);
        if (effectiveWidth <= 0 || effectiveHeight <= 0) return;

        string emptyLine = new string(' ', effectiveWidth);
        Console.BackgroundColor = ConsoleColor.Black;

        for (int y = 0; y < effectiveHeight; y++)
        {
            int currentTop = top + y;
            if (currentTop >= Console.BufferHeight) break;
            try
            {
                Console.SetCursorPosition(left, currentTop);
                Console.Write(emptyLine);
            }
            catch (ArgumentOutOfRangeException) { }
            catch (IOException) { }
        }

        Console.ResetColor();
    }

    private static void DrawMapContent(GameState state)
    {
        int contentLeft = MapFrameLeft + 1;
        int contentTop = MapFrameTop + 1;
        ClearRegion(contentLeft, contentTop, MapContentWidth, MapContentHeight);

        foreach (var item in state.Items)
            if (item.Position.X >= 0 && item.Position.X < MapContentWidth && item.Position.Y >= 0 && item.Position.Y < MapContentHeight)
                WriteAt(contentLeft + item.Position.X, contentTop + item.Position.Y, item.Symbol, item.Color);
        foreach (var enemy in state.Enemies)
            if (enemy.Position.X >= 0 && enemy.Position.X < MapContentWidth && enemy.Position.Y >= 0 && enemy.Position.Y < MapContentHeight)
                WriteAt(contentLeft + enemy.Position.X, contentTop + enemy.Position.Y, enemy.Symbol, enemy.Color);

        if (state.TargetRePont.Position.X >= 0 && state.TargetRePont.Position.X < MapContentWidth && state.TargetRePont.Position.Y >= 0 && state.TargetRePont.Position.Y < MapContentHeight)
            WriteAt(contentLeft + state.TargetRePont.Position.X, contentTop + state.TargetRePont.Position.Y, state.TargetRePont.Symbol, state.TargetRePont.Color);

        if (state.GamePlayer.Position.X >= 0 && state.GamePlayer.Position.X < MapContentWidth && state.GamePlayer.Position.Y >= 0 && state.GamePlayer.Position.Y < MapContentHeight)
        {
            ConsoleColor playerColor = state.GamePlayer.TemporarySpeedBoostTurns > 0 ? EffectColor : state.GamePlayer.Color;
            WriteAt(contentLeft + state.GamePlayer.Position.X, contentTop + state.GamePlayer.Position.Y, state.GamePlayer.Symbol, playerColor);
        }

        Console.ResetColor();
    }

    private static void DrawPlayerInfo(GameState state)
    {
        int contentLeft = InfoFrameLeft + 1;
        int contentTop = InfoFrameTop + 1;
        int contentWidth = InfoContentWidth;
        int contentHeight = InfoFrameHeight - 2;
        ClearRegion(contentLeft, contentTop, contentWidth, contentHeight);

        PlayerData pData = state.CurrentPlayerData;
        int currentLine = contentTop;
        int maxLine = contentTop + contentHeight;

        void WriteInfoLine(string label, string value, ConsoleColor labelColor, ConsoleColor valueColor)
        {
            if (currentLine < maxLine && currentLine < Console.BufferHeight)
            {
                string displayLabel = label.Length > contentWidth ? label.Substring(0, contentWidth) : label;
                WriteAt(contentLeft, currentLine, displayLabel, labelColor);

                int valueLeft = contentLeft + displayLabel.Length;
                int remainingWidth = contentWidth - displayLabel.Length;

                if (remainingWidth > 0 && valueLeft < contentLeft + contentWidth)
                {
                    string displayValue = value.Length <= remainingWidth ? value : value.Substring(0, remainingWidth);
                    WriteAtAndClearRest(valueLeft, currentLine, displayValue, remainingWidth, valueColor, ConsoleColor.Black);
                }

                currentLine++;
            }
        }

        WriteInfoLine("Név      : ", pData.Name, TitleColor, PlayerInfoColor);
        WriteInfoLine("Vagyon   : ", $"{pData.TotalMoneyEarned} Ft", TitleColor, SuccessColor);
        WriteInfoLine("Pozíció  : ", $"({state.GamePlayer.Position.X}, {state.GamePlayer.Position.Y})", TitleColor, PlayerInfoColor);
        WriteInfoLine("Palackok : ", $"{state.GamePlayer.BottlesCollected}", TitleColor, PlayerInfoColor);

        string knifeStatus = state.GamePlayer.HasKnife ? "Van" : "Nincs";
        ConsoleColor knifeColor = state.GamePlayer.HasKnife ? SuccessColor : PlayerInfoColor;
        WriteInfoLine("Zsebkés  : ", knifeStatus, TitleColor, knifeColor);

        if (state.GamePlayer.TemporarySpeedBoostTurns > 0)
        {
            WriteInfoLine("Gyorsítás: ", $"{state.GamePlayer.TemporarySpeedBoostTurns} kör", TitleColor, EffectColor);
        }
        else
        {
            WriteInfoLine("Gyorsítás: ", "-", TitleColor, PlayerInfoColor);
        }

        WriteInfoLine("SpawnRate: ", $"{state.GetCurrentEnemySpawnRate():P0}", TitleColor, WarningColor);
        WriteInfoLine($"Harc (Lv{pData.AttackUpgradeLevel}): ", $"{pData.GetCurrentAttackChance():P0}", UpgradeColor, UpgradeColor);
        WriteInfoLine($"Kés (Lv{pData.KnifeAttackUpgradeLevel}): ", $"{pData.GetCurrentKnifeAttackChance():P0}", UpgradeColor, UpgradeColor);
        WriteInfoLine($"Futás (Lv{pData.RunUpgradeLevel}): ", $"{pData.GetCurrentRunChance():P0}", UpgradeColor, UpgradeColor);
        WriteInfoLine($"Tartós (Lv{pData.KnifeDurabilityUpgradeLevel}): ", $"{pData.GetCurrentKnifeBreakChance():P0} törés", UpgradeColor, UpgradeColor);

        while (currentLine < maxLine && currentLine < Console.BufferHeight)
        {
            WriteAtAndClearRest(contentLeft, currentLine, "", contentWidth, ConsoleColor.Black, ConsoleColor.Black);
            currentLine++;
        }

        Console.ResetColor();
    }

    private static void DrawMessages(GameState state)
    {
        int contentLeft = MsgFrameLeft + 1;
        int contentTop = MsgFrameTop + 1;
        int contentWidth = MsgContentWidth;
        int contentHeight = MaxLogMessages;
        ClearRegion(contentLeft, contentTop, contentWidth, contentHeight);

        int displayCount = 0;
        int messageIndex = state.MessageLog.Count - 1;
        int currentLine = contentTop + contentHeight - 1;

        while (messageIndex >= 0 && displayCount < contentHeight)
        {
            if (currentLine < contentTop || currentLine >= Console.BufferHeight) break;

            string rawMessage = state.MessageLog[messageIndex];
            List<string> messageLines = SplitIntoLines(rawMessage, contentWidth);

            for (int j = messageLines.Count - 1; j >= 0; j--)
            {
                if (currentLine < contentTop || currentLine >= Console.BufferHeight || displayCount >= contentHeight) break;

                string message = messageLines[j];
                ConsoleColor color = GetMessageColor(rawMessage);
                WriteAtAndClearRest(contentLeft, currentLine, message, contentWidth, color, ConsoleColor.Black);
                currentLine--;
                displayCount++;
            }
            messageIndex--;
        }

        Console.ResetColor();
    }

    private static ConsoleColor GetMessageColor(string rawMessage)
    {
        if (rawMessage.Contains("sikeresen", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("felvettél", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Ft-ot szereztél", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Gratulálok", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Sikerült!", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("legyőzted", StringComparison.OrdinalIgnoreCase))
            return SuccessColor;
        else if (rawMessage.Contains("hiba", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("nem sikerült", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("legyőzött", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("eltört", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Vége a játéknak", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("elkapott", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Bekerítettek", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("sikertelen", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Nem hatotta meg", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Leszarta", StringComparison.OrdinalIgnoreCase))
            return ErrorColor;
        else if (rawMessage.Contains("Figyelem", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("megjelent", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Összefutottál", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("közeledben", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("próbálkozol", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Megpróbálod", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("Megpróbálsz", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("nehezebb dolgod van", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("ideges a tizedes", StringComparison.OrdinalIgnoreCase))
            return WarningColor;
        else if (rawMessage.Contains("Gyorsabb lettél", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("hatása elmúlt", StringComparison.OrdinalIgnoreCase) || rawMessage.Contains("energiaital", StringComparison.OrdinalIgnoreCase))
            return EffectColor;
        else if (rawMessage.Contains("Kiléptél", StringComparison.OrdinalIgnoreCase))
            return TitleColor;

        return MessageColor;
    }

    public static int ShowInteractionMenu(GameState state, Enemy enemy, bool intimidateAttempted)
    {
        int contentLeft = InteractFrameLeft + 1;
        int contentTop = InteractFrameTop + 1;
        int contentWidth = InteractContentWidth;
        int contentHeight = InteractFrameHeight - 2;

        int currentLine = contentTop;
        int maxLine = contentTop + contentHeight;
        string[] baseOptions = { "Megtámadom", "Elfutok", "Megfélemlítem" };
        int selectedIndex = 0;

        List<Tuple<string, bool>> options = new List<Tuple<string, bool>>();
        for (int i = 0; i < baseOptions.Length; i++)
        {
            bool enabled = !(i == 2 && intimidateAttempted);
            string text = baseOptions[i];
            if (!enabled) text += " (Már próbáltad)";
            options.Add(Tuple.Create(text, enabled));
        }

        void RenderMenu()
        {
            int headerLines = 4;
            ClearRegion(contentLeft, contentTop + headerLines, contentWidth, contentHeight - headerLines);

            currentLine = contentTop;

            if (currentLine < maxLine && currentLine < Console.BufferHeight)
                WriteAtAndClearRest(contentLeft, currentLine++, $"Felbukkant: {enemy.Name}!", contentWidth, ErrorColor, ConsoleColor.Black);
            currentLine++;
            if (currentLine < maxLine && currentLine < Console.BufferHeight)
                WriteAtAndClearRest(contentLeft, currentLine++, "Mit teszel?", contentWidth, TitleColor, ConsoleColor.Black);
            currentLine++;

            for (int i = 0; i < options.Count; i++)
            {
                if (currentLine >= maxLine || currentLine >= Console.BufferHeight) break;

                string prefix = (i == selectedIndex) ? " > " : "   ";
                string suffix = (i == selectedIndex) ? " < " : "   ";
                string optionText = $"{prefix}{i + 1}. {options[i].Item1}{suffix}";
                bool enabled = options[i].Item2;

                ConsoleColor fg = enabled ? (i == selectedIndex ? HighlightColor : PromptColor) : ConsoleColor.DarkGray;
                ConsoleColor bg = ConsoleColor.Black;

                WriteAtAndClearRest(contentLeft, currentLine++, optionText, contentWidth, fg, bg);
            }
            Console.ResetColor();
        }

        while (!options[selectedIndex].Item2 && options.Any(o => o.Item2))
        {
            selectedIndex = (selectedIndex + 1) % options.Count;
        }
        if (!options.Any(o => o.Item2)) return 1;

        while (true)
        {
            RenderMenu();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    int originalIndex = selectedIndex;
                    do
                    {
                        selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                    } while (!options[selectedIndex].Item2 && selectedIndex != originalIndex);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    originalIndex = selectedIndex;
                    do
                    {
                        selectedIndex = (selectedIndex + 1) % options.Count;
                    } while (!options[selectedIndex].Item2 && selectedIndex != originalIndex);
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (options[selectedIndex].Item2)
                    {
                        ClearInteractionPanel();
                        Console.ResetColor();
                        return selectedIndex + 1;
                    }
                    break;
                default:
                    if (int.TryParse(key.KeyChar.ToString(), out int choice) && choice >= 1 && choice <= options.Count)
                    {
                        if (options[choice - 1].Item2)
                        {
                            selectedIndex = choice - 1;
                            ClearInteractionPanel();
                            Console.ResetColor();
                            return choice;
                        }
                    }
                    break;
            }
        }
    }

    public static void DisplayInteractionMessage(string message, ConsoleColor color = ConsoleColor.White, bool clearFirst = true)
    {
        int contentLeft = InteractFrameLeft + 1;
        int contentTop = InteractFrameTop + 1;
        int contentWidth = InteractContentWidth;
        int contentHeight = InteractFrameHeight - 2;
        if (clearFirst) ClearRegion(contentLeft, contentTop, contentWidth, contentHeight);

        if (contentWidth <= 0 || contentHeight <= 0) return;

        var lines = SplitIntoLines(message, contentWidth);
        int messageHeight = lines.Count;
        int startLine = contentTop + Math.Max(0, (contentHeight - messageHeight) / 2);

        for (int i = 0; i < lines.Count; i++)
        {
            int currentLine = startLine + i;
            if (currentLine >= contentTop + contentHeight || currentLine >= Console.BufferHeight) break;

            string centeredLine = CenterAlign(lines[i], contentWidth);
            WriteAtAndClearRest(contentLeft, currentLine, centeredLine, contentWidth, color, ConsoleColor.Black);
        }
        Console.ResetColor();
    }

    public static void DisplayTemporaryInteractionMessage(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        int contentLeft = InteractFrameLeft + 1;
        int contentTop = InteractFrameTop + 1;
        int contentWidth = InteractContentWidth;
        int contentHeight = InteractFrameHeight - 2;

        if (contentWidth <= 0 || contentHeight <= 0) return;

        int targetLine = contentTop + contentHeight / 2;
        ClearRegion(contentLeft, targetLine, contentWidth, 1);

        if (targetLine >= contentTop + contentHeight || targetLine >= Console.BufferHeight) return;

        string centeredLine = CenterAlign(message, contentWidth);
        WriteAtAndClearRest(contentLeft, targetLine, centeredLine, contentWidth, color, ConsoleColor.Black);
        Console.ResetColor();
    }

    public static void FlashEffect(Position pos, char flashChar, ConsoleColor flashColor, int durationMs = 150, int flashes = 2)
    {
        int mapLeft = MapFrameLeft + 1;
        int mapTop = MapFrameTop + 1;
        int consoleX = mapLeft + pos.X;
        int consoleY = mapTop + pos.Y;

        if (consoleX < mapLeft || consoleX >= mapLeft + MapContentWidth || consoleY < mapTop || consoleY >= mapTop + MapContentHeight)
            return;

        for (int i = 0; i < flashes; i++)
        {
            WriteAt(consoleX, consoleY, flashChar, flashColor);
            Thread.Sleep(durationMs / (flashes * 2));

            WriteAt(consoleX, consoleY, ' ', ConsoleColor.Black);
            Thread.Sleep(durationMs / (flashes * 2));
        }
    }

    public static void AnimateWinScreen(GameState state, long sessionEarnings)
    {
        string winMessage = $"****** GYŐZTÉL, {state.CurrentPlayerData.Name}! ******";
        string details1 = $"Ebben a körben {state.GamePlayer.BottlesCollected} palackot gyűjtöttél ({sessionEarnings} Ft).";
        string details2 = $"Összesen eddig {state.CurrentPlayerData.TotalMoneyEarned} Ft-ot szereztél.";
        string continuePrompt = "Nyomj meg egy gombot a főmenühöz...";

        int contentLeft = InteractFrameLeft + 1;
        int contentTop = InteractFrameTop + 1;
        int contentWidth = InteractContentWidth;
        int contentHeight = InteractFrameHeight - 2;
        ClearRegion(contentLeft, contentTop, contentWidth, contentHeight);

        int currentLine = contentTop + 1;
        string centeredWinMessage = CenterAlign(winMessage, contentWidth);

        if (currentLine >= contentTop + contentHeight || currentLine >= Console.BufferHeight)
        {
            currentLine = Math.Min(contentTop + contentHeight - 1, Console.BufferHeight - 1);
            if (currentLine < contentTop) currentLine = contentTop;
        }

        for (int i = 0; i < 4; i++)
        {
            if (currentLine >= contentTop + contentHeight || currentLine >= Console.BufferHeight) break;

            if (i % 2 == 0)
            {
                WriteAtAndClearRest(contentLeft, currentLine, centeredWinMessage, contentWidth, ConsoleColor.Cyan, ConsoleColor.DarkGreen);
            }
            else
            {
                WriteAtAndClearRest(contentLeft, currentLine, centeredWinMessage, contentWidth, ConsoleColor.White, ConsoleColor.Black);
            }
            Thread.Sleep(150);
        }
        if (currentLine < contentTop + contentHeight && currentLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, currentLine, centeredWinMessage, contentWidth, SuccessColor, ConsoleColor.Black);

        currentLine += 2;

        if (currentLine < contentTop + contentHeight && currentLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, currentLine++, CenterAlign(details1, contentWidth), contentWidth, TitleColor, ConsoleColor.Black);
        if (currentLine < contentTop + contentHeight && currentLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, currentLine++, CenterAlign(details2, contentWidth), contentWidth, TitleColor, ConsoleColor.Black);

        int promptLine = contentTop + contentHeight - 2;
        if (promptLine >= Console.BufferHeight) promptLine = Console.BufferHeight - 1;
        if (promptLine < currentLine) promptLine = currentLine;
        if (promptLine < contentTop) promptLine = contentTop;

        if (promptLine >= contentTop && promptLine < contentTop + contentHeight && promptLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, promptLine, "", contentWidth, ConsoleColor.Black, ConsoleColor.Black);

        if (promptLine >= contentTop && promptLine < contentTop + contentHeight && promptLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, promptLine, CenterAlign(continuePrompt, contentWidth), contentWidth, PromptColor, ConsoleColor.Black);

        Console.ResetColor();
    }

    public static void AnimateLossScreen(GameState state, string cause)
    {
        string lossMessage = $"****** VESZTETTÉL, {state.CurrentPlayerData.Name}! ******";
        string reason = cause;
        string continuePrompt = "Nyomj meg egy gombot a főmenühöz...";

        int contentLeft = InteractFrameLeft + 1;
        int contentTop = InteractFrameTop + 1;
        int contentWidth = InteractContentWidth;
        int contentHeight = InteractFrameHeight - 2;
        ClearRegion(contentLeft, contentTop, contentWidth, contentHeight);

        int currentLine = contentTop + 1;
        string centeredLossMessage = CenterAlign(lossMessage, contentWidth);

        if (currentLine >= contentTop + contentHeight || currentLine >= Console.BufferHeight)
        {
            currentLine = Math.Min(contentTop + contentHeight - 1, Console.BufferHeight - 1);
            if (currentLine < contentTop) currentLine = contentTop;
        }

        for (int i = 0; i < 4; i++)
        {
            if (currentLine >= contentTop + contentHeight || currentLine >= Console.BufferHeight) break;

            if (i % 2 == 0)
            {
                WriteAtAndClearRest(contentLeft, currentLine, centeredLossMessage, contentWidth, ErrorColor, ConsoleColor.DarkRed);
            }
            else
            {
                WriteAtAndClearRest(contentLeft, currentLine, centeredLossMessage, contentWidth, ConsoleColor.White, ConsoleColor.Black);
            }
            Thread.Sleep(180);
        }
        if (currentLine < contentTop + contentHeight && currentLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, currentLine, centeredLossMessage, contentWidth, ErrorColor, ConsoleColor.Black);

        currentLine += 2;

        var reasonLines = SplitIntoLines(reason, contentWidth);
        foreach (var line in reasonLines)
        {
            if (currentLine >= contentTop + contentHeight || currentLine >= Console.BufferHeight) break;
            WriteAtAndClearRest(contentLeft, currentLine++, CenterAlign(line, contentWidth), contentWidth, TitleColor, ConsoleColor.Black);
        }

        int promptLine = contentTop + contentHeight - 2;
        if (promptLine >= Console.BufferHeight) promptLine = Console.BufferHeight - 1;
        if (promptLine < currentLine) promptLine = currentLine;
        if (promptLine < contentTop) promptLine = contentTop;

        if (promptLine >= contentTop && promptLine < contentTop + contentHeight && promptLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, promptLine, "", contentWidth, ConsoleColor.Black, ConsoleColor.Black);

        if (promptLine >= contentTop && promptLine < contentTop + contentHeight && promptLine < Console.BufferHeight)
            WriteAtAndClearRest(contentLeft, promptLine, CenterAlign(continuePrompt, contentWidth), contentWidth, PromptColor, ConsoleColor.Black);

        Console.ResetColor();
    }

    internal static string CenterAlign(string text, int width)
    {
        if (string.IsNullOrEmpty(text)) return new string(' ', width);
        int textLength = text.Length;
        if (textLength >= width) return text.Substring(0, width);
        int spaces = width - textLength;
        int padLeft = spaces / 2;
        return text.PadLeft(padLeft + textLength).PadRight(width);
    }

    internal static List<string> SplitIntoLines(string text, int maxWidth)
    {
        if (string.IsNullOrEmpty(text) || maxWidth <= 0) return new List<string> { "" };

        var lines = new List<string>();
        var normalizedText = text.Replace("\r\n", "\n").Replace("\r", "\n");
        var paragraphs = normalizedText.Split('\n');

        foreach (var paragraph in paragraphs)
        {
            if (string.IsNullOrWhiteSpace(paragraph))
            {
                continue;
            }

            var words = paragraph.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var currentLine = new StringBuilder();

            foreach (var word in words)
            {
                if (word.Length > maxWidth)
                {
                    if (currentLine.Length > 0)
                    {
                        lines.Add(currentLine.ToString());
                        currentLine.Clear();
                    }
                    int offset = 0;
                    while (offset < word.Length)
                    {
                        int count = Math.Min(maxWidth, word.Length - offset);
                        lines.Add(word.Substring(offset, count));
                        offset += count;
                    }
                    continue;
                }

                if (currentLine.Length == 0)
                {
                    currentLine.Append(word);
                }
                else if (currentLine.Length + 1 + word.Length <= maxWidth)
                {
                    currentLine.Append(' ');
                    currentLine.Append(word);
                }
                else
                {
                    lines.Add(currentLine.ToString());
                    currentLine.Clear();
                    currentLine.Append(word);
                }
            }

            if (currentLine.Length > 0)
            {
                lines.Add(currentLine.ToString());
            }
        }

        if (lines.Count == 0 && text != null) lines.Add("");

        return lines;
    }
}