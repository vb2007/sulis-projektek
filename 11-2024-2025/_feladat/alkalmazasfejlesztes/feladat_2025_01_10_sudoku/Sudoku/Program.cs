class Sudoku
{
    static void Main()
    {
        #region 1. Feladat
        Console.WriteLine("1. feladat");
        Console.Write("Adja meg a fájl nevét: ");
        string fileName = Console.ReadLine()!;

        Console.Write("Adja meg a sor számát (1-9): ");
        int row = int.Parse(Console.ReadLine()!);

        Console.Write("Adja meg az oszlop számát (1-9): ");
        int column = int.Parse(Console.ReadLine()!);
        #endregion

        #region 2. Feladat
        Console.WriteLine("\n2. feladat");

        int[,] table = new int[9, 9];
        string[] lines;

        try
        {
            lines = File.ReadAllLines(fileName);
            for (int i = 0; i < 9; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < 9; j++)
                {
                    table[i, j] = int.Parse(numbers[j]);
                }
            }
        }
        catch (Exception)
        {
            try
            {
                lines = File.ReadAllLines("konnyu.txt");
                for (int i = 0; i < 9; i++)
                {
                    string[] numbers = lines[i].Split(' ');
                    for (int j = 0; j < 9; j++)
                    {
                        table[i, j] = int.Parse(numbers[j]);
                    }
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine($"Hiba történt a fájl beolvasása közben: {ex2.Message}");
                return;
            }
        }

        Console.WriteLine("A táblázat adatai sikeresen beolvasva.");
        #endregion

        #region 3. Feladat
        Console.WriteLine("\n3. feladat");

        int value = table[row - 1, column - 1];
        if (value == 0)
        {
            Console.WriteLine("Az adott helyet még nem töltötték ki.");
        }
        else
        {
            Console.WriteLine($"Az adott helyen lévő érték: {value}");
        }

        int subGridRow = (row - 1) / 3 + 1;
        int subGridColumn = (column - 1) / 3 + 1;
        Console.WriteLine($"Az adott hely a(z) {subGridRow}. sor és {subGridColumn}. oszlop résztáblázatához tartozik.");
        #endregion

        #region 4. Feladat
        Console.WriteLine("\n4. feladat");

        int emptyCells = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (table[i, j] == 0)
                {
                    emptyCells++;
                }
            }
        }

        double percentageEmpty = (emptyCells / 81.0) * 100;
        Console.WriteLine($"A táblázat {percentageEmpty:F1}%-a nincs még kitöltve.");
        #endregion

        #region 5. Feladat
        Console.WriteLine("\n5. feladat");

        for (int i = 9; i < lines.Length; i++)
        {
            string[] step = lines[i].Split(' ');
            int number = int.Parse(step[0]);
            int stepRow = int.Parse(step[1]) - 1;
            int stepColumn = int.Parse(step[2]) - 1;

            Console.WriteLine($"{number} {stepRow + 1} {stepColumn + 1}");

            if (table[stepRow, stepColumn] != 0)
            {
                Console.WriteLine("A helyet már kitöltötték");
                continue;
            }

            bool conflict = false;

            for (int j = 0; j < 9; j++)
            {
                if (table[stepRow, j] == number)
                {
                    Console.WriteLine("Az adott sorban már szerepel a szám");
                    conflict = true;
                    break;
                }

                if (table[j, stepColumn] == number)
                {
                    Console.WriteLine("Az adott oszlopban már szerepel a szám");
                    conflict = true;
                    break;
                }
            }

            if (conflict) continue;

            int startRow = (stepRow / 3) * 3;
            int startColumn = (stepColumn / 3) * 3;

            for (int r = startRow; r < startRow + 3; r++)
            {
                for (int c = startColumn; c < startColumn + 3; c++)
                {
                    if (table[r, c] == number)
                    {
                        Console.WriteLine("Az adott résztáblázatban már szerepel a szám");
                        conflict = true;
                        break;
                    }
                }
                if (conflict) break;
            }

            if (!conflict)
            {
                Console.WriteLine("A lépés megtehető");
            }
        }
        #endregion
    }
}