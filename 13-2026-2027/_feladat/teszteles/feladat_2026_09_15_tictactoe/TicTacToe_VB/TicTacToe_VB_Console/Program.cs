using TicTacToe_VB_Lib;

namespace TicTacToe_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix jatek = new Matrix();

            while (!jatek.JatekVege)
            {
                TablaIras(jatek);
                Console.Write($"Játékos {jatek.AktivJatekos} [Oszlop-Sor (1-3)]: ");
                string input = Console.ReadLine()!;

                if (!LepesFeldolgozas(input, out var sor, out var oszlop))
                {
                    Console.WriteLine("Érvénytelen lépés");
                    continue;
                }

                if (!jatek.Lepes(sor, oszlop))
                {
                    Console.WriteLine("Érvénytelen lépés");
                }
            }

            TablaIras(jatek);
            Console.WriteLine(jatek.Nyertes == ' ' ? "Döntetlen" : $"Játékos {jatek.Nyertes} nyert");
        }

        private static bool LepesFeldolgozas(string? bemenet, out int sor, out int oszlop)
        {
            sor = -1;
            oszlop = -1;

            if (string.IsNullOrWhiteSpace(bemenet))
            {
                return false;
            }

            string[] darabolt = bemenet.Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (darabolt.Length != 2
                || !int.TryParse(darabolt[0], out var rowInput)
                || !int.TryParse(darabolt[1], out var columnInput))
            {
                return false;
            }

            sor = rowInput - 1;
            oszlop = columnInput - 1;
            return sor is >= 0 and < 3 && oszlop is >= 0 and < 3;
        }

        private static void TablaIras(Matrix jatek)
        {
            Console.WriteLine();
            for (int sor = 0; sor < 3; sor++)
            {
                Console.WriteLine($" {jatek.Cella(sor, 0)} | {jatek.Cella(sor, 1)} | {jatek.Cella(sor, 2)} ");
                if (sor < 2)
                {
                    Console.WriteLine("---+---+---");
                }
            }

            Console.WriteLine();
        }
    }
}
