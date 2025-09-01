namespace MemoryCardGame.Other
{
    public class Draw
    {
        public static string DrawStart()
        {
            string title = @"
__  __                  __       _       
|  \/  |                /_/      (_)      
| \  / | ___ _ __ ___   ___  _ __ _  __ _ 
| |\/| |/ _ \ '_ ` _ \ / _ \| '__| |/ _` |
| |  | |  __/ | | | | | (_) | |  | | (_| |
|_|  |_|\___|_| |_| |_|\___/|_|  |_|\__,_|
";

            string welcome = "Üdvözöllek a memória kártyajátékban!";
            string instructions = "Játék útmutató:";
            string instr1 = "-> Találj meg minden kártyapárt!";
            string instr2 = "-> Válassz 2-8 közötti értékeket a pályamérethez";
            string instr3 = "-> A kártyák koordinátáit írd be formátum: 'sor oszlop'";
            string start = "[Nyomj meg egy gombot a kezdéshez...]";

            int windowWidth = Console.WindowWidth;

            string[] titleLines = title.Split('\n');
            titleLines[1] = titleLines[1].TrimStart();
            title = string.Join("\n", titleLines);

            int longestLineLength = 0;
            foreach (string line in title.Split('\n'))
            {
                if (line.Length > longestLineLength)
                {
                    longestLineLength = line.Length;
                }
            }


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (string line in title.Split('\n'))
            {
                Console.SetCursorPosition((windowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((windowWidth - welcome.Length) / 2, Console.CursorTop);
            Console.WriteLine(welcome);
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition((windowWidth - instructions.Length) / 2, Console.CursorTop);
            Console.WriteLine(instructions);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition((windowWidth - instr1.Length) / 2, Console.CursorTop);
            Console.WriteLine(instr1);
            Console.SetCursorPosition((windowWidth - instr2.Length) / 2, Console.CursorTop);
            Console.WriteLine(instr2);
            Console.SetCursorPosition((windowWidth - instr3.Length) / 2, Console.CursorTop);
            Console.WriteLine(instr3);
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((windowWidth - start.Length) / 2, Console.CursorTop);
            Console.WriteLine(start);
            Console.ResetColor();

            Console.ReadKey();
            Console.Clear();
            return "";
        }

        public static string DrawEnd(bool won)
        {
            if (won)
                return "Gratulálok, minden párt megtaláltál!\nÚj játék indításához nyomj meg egy billentyűt, kilépéshez ESC.";
            else
                return "Sajnálom, vesztettél!\nÚj játék indításához nyomj meg egy billentyűt, kilépéshez ESC.";
        }

        public static void DrawCards(string[,] cards, bool showAll, int rows, int columns, int score)
        {
            Console.Clear();

            int cardWidth = 6;
            int cardHeight = 4;
            int totalWidth = columns * cardWidth + columns + 1;
            int totalHeight = rows * cardHeight + 2;
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int startX = (windowWidth - totalWidth) / 2;
            int startY = (windowHeight - totalHeight) / 2;


            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(startX, startY + i * cardHeight);
                for (int j = 0; j < columns; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("+-----");
                    Console.ResetColor();
                }
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("+");
                Console.ResetColor();


                Console.SetCursorPosition(startX, startY + i * cardHeight + 1);
                for (int j = 0; j < columns; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("|");
                    Console.ResetColor();
                    Console.Write(" ");

                    if (showAll)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(cards[i, j].PadRight(3));
                        Console.ResetColor();
                    }
                    else
                    {
                        if (cards[i, j] == "[ ]")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(cards[i, j].PadRight(3));
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(cards[i, j].PadRight(3));
                            Console.ResetColor();
                        }
                    }
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");
                Console.ResetColor();


                Console.SetCursorPosition(startX, startY + i * cardHeight + 2);
                for (int j = 0; j < columns; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("+-----");
                    Console.ResetColor();
                }
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("+");
                Console.ResetColor();
            }

            string scoreText = $"Lépések száma: {score}";
            Console.SetCursorPosition((windowWidth - scoreText.Length) / 2, startY + rows * cardHeight + 1);
            Console.WriteLine(scoreText);
        }
    }
}