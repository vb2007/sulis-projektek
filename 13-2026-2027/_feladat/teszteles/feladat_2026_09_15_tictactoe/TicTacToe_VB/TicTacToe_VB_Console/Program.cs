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
                Console.WriteLine();
                Console.Write(TablaMegjelenito.Kirajzol(jatek));
                Console.WriteLine();
                Console.Write($"Játékos {jatek.AktivJatekos} [Oszlop-Sor (1-3)]: ");
                string input = Console.ReadLine()!;

                if (!LepesParser.LepesFeldolgozas(input, out var sor, out var oszlop))
                {
                    Console.WriteLine("Érvénytelen lépés");
                    continue;
                }

                if (!jatek.Lepes(sor, oszlop))
                {
                    Console.WriteLine("Érvénytelen lépés");
                }
            }

            Console.WriteLine();
            Console.Write(TablaMegjelenito.Kirajzol(jatek));
            Console.WriteLine();
            Console.WriteLine(jatek.Nyertes == ' ' ? "Döntetlen" : $"Játékos {jatek.Nyertes} nyert");
        }
    }
}
