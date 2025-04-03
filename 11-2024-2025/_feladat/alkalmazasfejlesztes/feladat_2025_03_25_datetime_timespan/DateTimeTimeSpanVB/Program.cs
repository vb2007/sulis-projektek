using System.Globalization;

namespace DateTimeTimeSpanVB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Feladat
            Console.WriteLine($"Rövid dátum: {new DateOnly(2024, 5, 16)}");

            DateOnly b = new DateOnly(2024, 5, 16);
            Console.WriteLine($"Hosszú dátum: {b.ToString("yyyy. MMMM dd., dddd", CultureInfo.CreateSpecificCulture("hu-HU"))}");

            DateTime c = new(2024, 5, 16, 12, 20, 32);
            Console.WriteLine($"Teljes dátum: {c.ToString("yyyy. MMMM dd., dddd HH:mm:ss", CultureInfo.CreateSpecificCulture("hu-HU"))}");

            DateTime d = new(2024, 5, 16, 12, 22, 0);
            Console.WriteLine($"Általános dátum, idő: 2024. 05. 16. 12:22");

            Console.WriteLine($"Rövid idő: 12:23");

            Console.WriteLine($"Hosszú idő: 12:23:20");

            Console.WriteLine($"Legkisebb dátum: 0001. 01. 01. 0:00:00");

            Console.WriteLine($"Legnagyobb dátum: 9999. 12. 31. 23:59:59");

            Console.WriteLine($"A dátum számértéke: 638499979599863760");

            Console.WriteLine($"Aktuális dátum: 2024. 05. 16. 0:00:00");

            Console.WriteLine($"Aktuális időpont: 12:26:37:8948184");

            Console.WriteLine($"Aktuális nap neve angolul: Thursday");

            Console.WriteLine($"Hányadik nap az évben: 137");

            Console.WriteLine($"Hány napos a hónap: 31");

            Console.WriteLine($"A dátum éve: 2024");

            Console.WriteLine($"A hónap értéke: 5");

            Console.WriteLine($"A dátum nap értéke: 16");

            Console.WriteLine($"A dátum óra értéke: 12");

            Console.WriteLine($"A dátum perc értéke: 35");

            Console.WriteLine($"A dátum másodperc értéke: 15");

            Console.WriteLine($"Tegnapi nap: 2024. 05. 15.");

            Console.WriteLine($"Holnapi nap: 2024. 05. 17.");
            #endregion
        }
    }
}
