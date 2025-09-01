namespace MemoryCardGame.Other
{
    public class Handle
    {
        public static (int, int) GetUserInputs()
        {
            int rows, columns;
            int windowWidth = Console.WindowWidth;

            while (true)
            {
                string prompt = "Add meg a sorok számát: ";
                Console.SetCursorPosition((windowWidth - prompt.Length) / 2, Console.CursorTop);
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(input, out rows) && rows >= 2 && rows <= 8)
                {
                    break;
                }
                string errorMsg = "Hibás érték! A sorok száma 2 és 8 között kell legyen, és egész szám.";
                Console.SetCursorPosition((windowWidth - errorMsg.Length) / 2, Console.CursorTop);
                Console.WriteLine(errorMsg);
            }

            while (true)
            {
                string prompt = "Add meg az oszlopok számát: ";
                Console.SetCursorPosition((windowWidth - prompt.Length) / 2, Console.CursorTop);
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(input, out columns) && columns >= 2 && columns <= 8)
                {
                    if (rows * columns % 2 == 0)
                    {
                        break;
                    }
                    else
                    {
                        string errorMsg = "A sorok és oszlopok szorzatának párosnak kell lennie!";
                        Console.SetCursorPosition((windowWidth - errorMsg.Length) / 2, Console.CursorTop);
                        Console.WriteLine(errorMsg);
                    }
                }
                string errorMsg2 = "Hibás érték! Az oszlopok száma 2 és 8 között kell legyen, és egész szám.";
                Console.SetCursorPosition((windowWidth - errorMsg2.Length) / 2, Console.CursorTop);
                Console.WriteLine(errorMsg2);
            }

            return (rows, columns);
        }

        public static int GetCoordinateInput(string prompt, int maxValue)
        {
            int coordinate;
            int windowWidth = Console.WindowWidth;

            while (true)
            {
                Console.SetCursorPosition((windowWidth - prompt.Length) / 2, Console.CursorTop);
                Console.Write(prompt);
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine();
                Console.ResetColor();
                if (int.TryParse(input, out coordinate) && coordinate >= 0 && coordinate < maxValue)
                {
                    return coordinate;
                }
                string errorMsg = $"Érvénytelen érték.  0 és {maxValue - 1} közötti számot adj meg.";
                Console.SetCursorPosition((windowWidth - errorMsg.Length) / 2, Console.CursorTop);
                Console.WriteLine(errorMsg);
            }
        }
    }
}