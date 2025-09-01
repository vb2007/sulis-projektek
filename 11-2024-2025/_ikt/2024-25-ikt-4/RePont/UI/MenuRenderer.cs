using RePontGame.Models;
using RePontGame.Models.Enums;
using RePontGame.Services;

namespace RePontGame.UI;

public static class MenuRenderer
{
    private const int WindowWidth = 110;
    private const int WindowHeight = 28;

    public enum MainMenuSelection { StartGame, Upgrades, Help, Quit }

    public static void DisplayAsciiArt(string[] art, int top, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        if (art == null || art.Length == 0) return;

        int maxWidth = art.Max(line => line?.Length ?? 0);
        int left = (Console.WindowWidth - maxWidth) / 2;
        if (left < 0) left = 0;

        for (int i = 0; i < art.Length; i++)
        {
            if (top + i >= Console.WindowHeight || art[i] == null) break;
            try
            {
                Renderer.WriteAt(left, top + i, art[i], color);
            }
            catch (Exception) { }
        }
        Console.ResetColor();
    }

    public static MainMenuSelection ShowMainMenu(PlayerData playerData)
    {
        Console.Clear();
        Console.CursorVisible = false;

        int artTop = 3;
        DisplayAsciiArt(AsciiArt.RePontLogo, artTop, ConsoleColor.Cyan);

        int menuTop = artTop + AsciiArt.RePontLogo.Length + 3;
        string[] options = { "Új Játék Indítása", "Fejlesztések", "Segítség", "Kilépés" };
        int selectedIndex = 0;
        const int menuSpacing = 2;

        while (true)
        {
            string moneyInfo = $"Játékos: {playerData.Name} | Vagyon: {playerData.TotalMoneyEarned} Ft";
            int infoLeft = (Console.WindowWidth - moneyInfo.Length) / 2;
            if (infoLeft < 0) infoLeft = 0;
            try
            {
                int clearWidth = Console.WindowWidth - 1;
                Renderer.WriteAtAndClearRest(infoLeft, menuTop - 2, moneyInfo, clearWidth, ConsoleColor.Yellow, ConsoleColor.Black);
            }
            catch(Exception) { }

            int maxOptionLength = options.Max(opt => opt.Length);

            int longestLineLength = maxOptionLength + 6;
            int baseLeft = (Console.WindowWidth - longestLineLength) / 2;
            if (baseLeft < 0) baseLeft = 0;

            for (int i = 0; i < options.Length; i++)
            {
                bool isSelected = i == selectedIndex;
                string prefix = isSelected ? ">> | " : "   | ";
                string text = prefix + options[i];

                ConsoleColor fg = isSelected ? Renderer.HighlightColor : ConsoleColor.Gray;
                ConsoleColor bg = ConsoleColor.Black;

                try
                {
                    int currentLineTop = menuTop + i * menuSpacing;
                    int clearWidth = Console.WindowWidth - 1;
                    Renderer.WriteAtAndClearRest(baseLeft, currentLineTop, text, clearWidth, fg, bg);

                    if (menuSpacing > 1 && currentLineTop + 1 < Console.WindowHeight)
                    {
                        Renderer.WriteAtAndClearRest(0, currentLineTop + 1, "", clearWidth, ConsoleColor.Black, ConsoleColor.Black);
                    }
                }
                catch { }
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    Console.Clear();
                    return (MainMenuSelection)selectedIndex;
            }
        }
    }

    public static void ShowUpgradeMenu(PlayerData playerData)
    {
        Console.Clear();
        Console.CursorVisible = false;
        int selectedIndex = 0;
        var upgradeTypes = Enum.GetValues<UpgradeType>();
        string feedbackMessage = "";
        ConsoleColor feedbackColor = ConsoleColor.White;
        const int listTopMargin = 1;

        const int colIndicator = 0;
        const int colName = 2;
        const int colSeparator1 = colName + 16;
        const int colLevel = colSeparator1 + 2;
        const int colSeparator2 = colLevel + 13;
        const int colDesc = colSeparator2 + 2;
        const int colSeparator3 = colDesc + 22;
        const int colValue = colSeparator3 + 2;
        const int colSeparator4 = colValue + 15;
        const int colCost = colSeparator4 + 2;

        while (true)
        {
            int headerHeight = 6;
            int footerHeight = 3;
            int availableHeight = Console.WindowHeight - headerHeight - footerHeight - listTopMargin;
            int itemsPerPage = Math.Max(1, availableHeight);
            int totalItems = upgradeTypes.Length;
            int startIndex = 0;
            int endIndex = Math.Min(startIndex + itemsPerPage, totalItems);

            int listDrawTop = headerHeight + listTopMargin;

            //menu - info

            try { Console.SetCursorPosition(0, 0); } catch { }
            int headerClearWidth = Console.WindowWidth - 1;
            Renderer.WriteAtAndClearRest(0, 0, "=".PadRight(Console.WindowWidth - 1, '='), headerClearWidth, ConsoleColor.DarkGray, ConsoleColor.Black);
            string title = "Fejlesztések";
            Renderer.WriteAtAndClearRest(0, 1, Renderer.CenterAlign(title, Console.WindowWidth -1), headerClearWidth, ConsoleColor.White, ConsoleColor.Black);
            Renderer.WriteAtAndClearRest(0, 2, "=".PadRight(Console.WindowWidth - 1, '='), headerClearWidth, ConsoleColor.DarkGray, ConsoleColor.Black);
            Renderer.WriteAtAndClearRest(0, 4, $"Jelenlegi vagyonod: {playerData.TotalMoneyEarned} Ft", headerClearWidth, ConsoleColor.Yellow, ConsoleColor.Black);
            Renderer.WriteAtAndClearRest(0, 5, "Nyilak: Mozgás | ENTER: Vásárlás | ESC/Q: Vissza", headerClearWidth, ConsoleColor.Cyan, ConsoleColor.Black);

            int currentLine = listDrawTop;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (currentLine >= Console.WindowHeight - footerHeight) break;
                try { Console.SetCursorPosition(0, currentLine); } catch { }

                UpgradeType type = upgradeTypes[i];
                int level = 0; string name = ""; string description = "";
                double currentValue = 0; double nextValue = 0; double baseValue = 0; double perLevel = 0;
                bool isPercentage = true;

                switch (type)
                {
                    case UpgradeType.Attack: level = playerData.AttackUpgradeLevel; name = "Puszta Kéz"; baseValue = playerData.BaseAttackChance; perLevel = playerData.AttackChancePerLevel; currentValue = playerData.GetCurrentAttackChance(); description = "Támadás esélye"; break;
                    case UpgradeType.KnifeAttack: level = playerData.KnifeAttackUpgradeLevel; name = "Késes Harc"; baseValue = playerData.BaseKnifeAttackChance; perLevel = playerData.KnifeAttackChancePerLevel; currentValue = playerData.GetCurrentKnifeAttackChance(); description = "Késes támadás esélye"; break;
                    case UpgradeType.Run: level = playerData.RunUpgradeLevel; name = "Futás"; baseValue = playerData.BaseRunChance; perLevel = playerData.RunChancePerLevel; currentValue = playerData.GetCurrentRunChance(); description = "Menekülés esélye"; break;
                    case UpgradeType.KnifeDurability: level = playerData.KnifeDurabilityUpgradeLevel; name = "Kés Tartósság"; baseValue = playerData.BaseKnifeBreakChance; perLevel = -playerData.KnifeBreakChanceReductionPerLevel; currentValue = playerData.GetCurrentKnifeBreakChance(); description = "Kés törés esélye"; break;
                }

                string valueString;
                if (level < PlayerData.MaxUpgradeLevel)
                {
                    nextValue = Math.Clamp(baseValue + (level + 1) * perLevel, 0.01, 0.99);
                    valueString = isPercentage ? $"{currentValue:P0} -> {nextValue:P0}" : $"{currentValue} -> {nextValue}";
                }
                else { valueString = isPercentage ? $"{currentValue:P0}" : $"{currentValue}"; }

                long cost = playerData.GetNextUpgradeCost(type);
                string costText = (level >= PlayerData.MaxUpgradeLevel) ? "MAX" : $"{cost} Ft";
                string levelText = $"Szint: {level}/{PlayerData.MaxUpgradeLevel}";
                string descriptionText = description + ":";

                bool canAfford = playerData.TotalMoneyEarned >= cost && level < PlayerData.MaxUpgradeLevel;
                bool isSelected = (i == selectedIndex);
                bool isMax = (level >= PlayerData.MaxUpgradeLevel);

                ConsoleColor fg;
                ConsoleColor bg = isSelected ? Renderer.HighlightBgColor : ConsoleColor.Black;

                if (isMax) fg = Renderer.MaxLevelColor;
                else if (!canAfford) fg = Renderer.UnaffordableColor;
                else fg = ConsoleColor.White;

                if (isSelected) fg = Renderer.HighlightColor;

                int listClearWidth = Console.WindowWidth - 1;
                Renderer.WriteAtAndClearRest(0, currentLine, "", listClearWidth, ConsoleColor.Black, bg);

                Renderer.WriteAt(colIndicator, currentLine, isSelected ? ">" : " ", fg, bg);
                Renderer.WriteAt(colName, currentLine, name, fg, bg);
                Renderer.WriteAt(colSeparator1, currentLine, "|", Renderer.BorderColor, bg);
                Renderer.WriteAt(colLevel, currentLine, levelText, fg, bg);
                Renderer.WriteAt(colSeparator2, currentLine, "|", Renderer.BorderColor, bg);
                Renderer.WriteAt(colDesc, currentLine, descriptionText, fg, bg);
                Renderer.WriteAt(colSeparator3, currentLine, "|", Renderer.BorderColor, bg);
                Renderer.WriteAt(colValue, currentLine, valueString, fg, bg);
                Renderer.WriteAt(colSeparator4, currentLine, "|", Renderer.BorderColor, bg);
                Renderer.WriteAt(colCost, currentLine, "Köv: " + costText, fg, bg);

                currentLine++;
            }

            int listEndLine = listDrawTop + itemsPerPage;
            while (currentLine < listEndLine && currentLine < Console.WindowHeight - footerHeight)
            {
                try
                {
                    int clearRemWidth = Console.WindowWidth - 1;
                    Renderer.WriteAtAndClearRest(0, currentLine, "", clearRemWidth, ConsoleColor.Black, ConsoleColor.Black);
                    currentLine++;
                }
                catch { }
            }

            int feedbackLine = Console.WindowHeight - 2;
            if (feedbackLine >= listEndLine && feedbackLine < Console.WindowHeight)
            {
                try
                {
                    int feedbackClearWidth = Console.WindowWidth - 1;
                    Renderer.WriteAtAndClearRest(0, feedbackLine, feedbackMessage, feedbackClearWidth, feedbackColor, ConsoleColor.Black);
                    if (feedbackLine + 1 < Console.WindowHeight)
                        Renderer.WriteAtAndClearRest(0, feedbackLine + 1, "", feedbackClearWidth, ConsoleColor.Black, ConsoleColor.Black);
                }
                catch { }
            }
            feedbackMessage = "";

            Console.ResetColor();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    selectedIndex = (selectedIndex - 1 + totalItems) % totalItems;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    selectedIndex = (selectedIndex + 1) % totalItems;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    UpgradeType toBuy = upgradeTypes[selectedIndex];
                    long purchaseCost = playerData.GetNextUpgradeCost(toBuy);
                    int currentLevel = toBuy switch
                    {
                        UpgradeType.Attack => playerData.AttackUpgradeLevel,
                        UpgradeType.Run => playerData.RunUpgradeLevel,
                        UpgradeType.KnifeDurability => playerData.KnifeDurabilityUpgradeLevel,
                        UpgradeType.KnifeAttack => playerData.KnifeAttackUpgradeLevel,
                        _ => PlayerData.MaxUpgradeLevel
                    };

                    if (currentLevel < PlayerData.MaxUpgradeLevel)
                    {
                        if (playerData.TotalMoneyEarned >= purchaseCost)
                        {
                            if (playerData.TryPurchaseUpgrade(toBuy))
                            {
                                feedbackMessage = $"{GetUpgradeName(toBuy)} fejlesztve! Új szint: {currentLevel + 1}";
                                feedbackColor = Renderer.SuccessColor;
                                SaveManager.SavePlayerData(playerData);
                            }
                            else { feedbackMessage = "Ismeretlen hiba a vásárlás során."; feedbackColor = Renderer.ErrorColor; }
                        }
                        else { feedbackMessage = $"Nincs elég pénzed! ({purchaseCost} Ft szükséges)"; feedbackColor = Renderer.ErrorColor; }
                    }
                    else { feedbackMessage = "Ez a fejlesztés már maximális szintű."; feedbackColor = Renderer.WarningColor; }

                    int feedbackDisplayLine = Console.WindowHeight - 2;
                    if (feedbackDisplayLine >= 0)
                    {
                        int fbDispClearWidth = Console.WindowWidth - 1;
                        Renderer.WriteAtAndClearRest(0, feedbackDisplayLine, feedbackMessage, fbDispClearWidth, feedbackColor, ConsoleColor.Black);
                    }
                    Thread.Sleep(800);
                    feedbackMessage = "";
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Q:
                    Console.Clear(); return;
            }
        }
    }

    private static string GetUpgradeName(UpgradeType type) => type switch
    {
        UpgradeType.Attack => "Puszta Kéz",
        UpgradeType.KnifeAttack => "Késes Harc",
        UpgradeType.Run => "Futás",
        UpgradeType.KnifeDurability => "Kés Tartósság",
        _ => "Ismeretlen fejlesztés"
    };

    public static void ShowHelpScreen()
    {
        Console.Clear();
        Console.CursorVisible = false;
        int width = WindowWidth;
        int height = WindowHeight;
        int left = 0;
        int top = 0;
        int contentWidth = width - 4;
        int currentLine = top + 1;

        Renderer.DrawBox(left, top, width, height, "Segítség / Játékinformáció");

        void WriteHelpLine(string text, ConsoleColor color = ConsoleColor.Gray, int indent = 2)
        {
            if (currentLine < top + height - 2)
            {
                Renderer.WriteAtAndClearRest(left + indent, currentLine, text, contentWidth - indent, color, ConsoleColor.Black);
                currentLine++;
            }
        }

        void WriteHelpLineWithColoredPart(string textPart1, string textPart2, string textPart3 = "", ConsoleColor colorPart2 = ConsoleColor.Green, int indent = 2)
        {
            if (currentLine < top + height - 2)
            {
                Renderer.WriteAt(left + indent, currentLine, textPart1, Renderer.HelpTextColor);
                Renderer.WriteAt(left + indent + textPart1.Length, currentLine, textPart2, colorPart2);
                Renderer.WriteAt(left + indent + textPart1.Length + textPart2.Length, currentLine, textPart3, Renderer.HelpTextColor);

                int writtenLength = textPart1.Length + textPart2.Length + textPart3.Length;
                int remainingWidth = contentWidth - indent - writtenLength;
                if (remainingWidth > 0)
                {
                    Renderer.WriteAt(left + indent + writtenLength, currentLine, new string(' ', remainingWidth), Renderer.HelpTextColor, ConsoleColor.Black);
                }

                currentLine++;
            }
        }

        void WriteHeader(string text)
        {
            if (currentLine > top + 2) currentLine++;
            WriteHelpLine(text, Renderer.HelpHeaderColor, 2);
            WriteHelpLine(new string('-', text.Length), Renderer.HelpHeaderColor, 2);
        }

        void WriteSymbolText(char symbol, ConsoleColor symbolColor, string description)
        {
            if (currentLine < top + height - 2)
            {
                string line = " ";
                Renderer.WriteAt(left + 4, currentLine, line, Renderer.HelpTextColor);
                Renderer.WriteAt(left + 4, currentLine, symbol.ToString(), symbolColor);
                Renderer.WriteAt(left + 6, currentLine, $": {description}", Renderer.HelpTextColor);
                currentLine++;
            }
        }

        WriteHeader("A Játék Célja");
        WriteHelpLineWithColoredPart("Gyűjts össze minél több visszaváltható palackot ('", "b", "') és juss el", Renderer.SuccessColor);
        WriteHelpLineWithColoredPart("a RePont ('", "R", "') leadóhelyhez, mielőtt elkapnak az ellenségek.", Renderer.EffectColor);
        WriteHelpLine($"Minden palack {GameConstants.MoneyPerBottle} Ft-ot ér a kör végén.");
        WriteHelpLine($"Figyelem: Minél több palackod van, annál gyakrabban jelennek meg ellenségek!");

        WriteHeader("Irányítás");
        WriteHelpLine("W / Fel Nyíl   : Mozgás felfelé");
        WriteHelpLine("S / Le Nyíl    : Mozgás lefelé");
        WriteHelpLine("A / Balra Nyíl : Mozgás balra");
        WriteHelpLine("D / Jobbra Nyíl: Mozgás jobbra");
        WriteHelpLine("H              : Segítség (ez a képernyő)");
        WriteHelpLine("Q              : Kilépés a játékból (kör közben is)");
        WriteHelpLine("ESC            : Kilépés menükből (pl. Fejlesztések, Segítség)");

        WriteHeader("Térkép Elemek");
        WriteSymbolText('@', ConsoleColor.Yellow, "Te vagy (Játékos)");
        WriteSymbolText('R', ConsoleColor.Magenta, "Cél: RePont leadóhely");
        WriteSymbolText('b', ConsoleColor.Green, "Palack (+50 Ft a végén, növeli a Spawn Rate-et)");
        WriteSymbolText('k', ConsoleColor.Cyan, "Zsebkés (Jobb támadás, de eltörhet)");
        WriteSymbolText('E', ConsoleColor.DarkYellow, "Energiaital (Garantált menekülés +10 körig)");

        WriteHeader("Ellenségek");
        WriteSymbolText('C', ConsoleColor.Red, "Zsebes (kisebbségi roma állampolgár)");
        WriteSymbolText('K', ConsoleColor.DarkYellow, "Pamkutya");
        WriteSymbolText('Ő', ConsoleColor.DarkCyan, "Biztonsági Őr (Westend tetős)");

        WriteHeader("Harc és Találkozások");
        WriteHelpLine("Ha egy ellenség mellé lépsz, találkozás történik.");
        WriteHelpLine("Választhatsz:", Renderer.HelpTextColor, 4);
        WriteHelpLine("1. Támadás: Esélyed függ a fejlesztéseidtől (puszta kéz / kés).", Renderer.HelpTextColor, 6);
        WriteHelpLine("   A kés eltörhet (esélye fejlesztéssel csökken). Sikertelenség = Vége.", Renderer.HelpTextColor, 6);
        WriteHelpLine("2. Futás: Esélyed függ a fejlesztéseidtől.", Renderer.HelpTextColor, 6);
        WriteHelpLine($"   Az {Renderer.EffectColor}Energiaital{Renderer.HelpTextColor} garantálja a sikert. Sikertelenség = Vége.", Renderer.HelpTextColor, 6);
        WriteHelpLine($"3. Megfélemlítés: Fix {GameConstants.IntimidateSuccessChance:P0} esély, hogy az ellenfél elmenekül.", Renderer.HelpTextColor, 6);
        WriteHelpLine($"   Sikertelenség esetén az ellenfél 'Ideges Tizedes' lesz,", Renderer.HelpTextColor, 6);
        WriteHelpLine($"   ami {GameConstants.FailedIntimidatePenaltyMultiplier:P0} szorzóval csökkenti a Támadás/Futás esélyed.", Renderer.HelpTextColor, 6);
        WriteHelpLine($"   Csak egyszer próbálkozhatsz vele találkozásonként.", Renderer.HelpTextColor, 6);

        WriteHeader("Fejlesztések");
        WriteHelpLine("A főmenüből érheted el. A játékok során szerzett pénzből");
        WriteHelpLine("növelheted a támadási, futási esélyeidet és a kés tartósságát.");

        string closePrompt = "Nyomj Q-t vagy ESC-et a bezáráshoz";
        int promptTop = top + height - 2;
        if (promptTop >= top + 1 && promptTop < Console.BufferHeight)
        {
            Renderer.WriteAtAndClearRest(left + 1, promptTop, Renderer.CenterAlign(closePrompt, width - 2), width - 2, Renderer.PromptColor, ConsoleColor.Black);
        }

        Console.ResetColor();

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Q || key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }

        Console.Clear();
    }
}