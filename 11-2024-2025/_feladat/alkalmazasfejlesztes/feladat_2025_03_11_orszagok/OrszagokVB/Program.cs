namespace OrszagokVB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //6. Feladat
            List<Orszagok> orszagok = new();

            foreach (var item in File.ReadAllLines("orszagok.csv").Skip(1))
            {
                string[] darabolt = item.Split(';');
                orszagok.Add(new Orszagok(
                    darabolt[0],
                    int.Parse(darabolt[1]),
                    int.Parse(darabolt[2]),
                    darabolt[3],
                    int.Parse(darabolt[4])));
            }

            foreach (var item in orszagok)
            {
                Console.WriteLine(item.Info() + "\n");
            }

            Console.WriteLine("7. Feladat:");
            Console.WriteLine($"{orszagok.Count} ország adatait tároltuk");

            Console.WriteLine("8. Feladat:");
            Console.WriteLine($"Országok összterület:  {orszagok.Sum(x => (long)x.Terulet)}\nOrszágok összlakossága: {orszagok.Sum(x => (long)x.Lakossag)}");

            Console.WriteLine("9. Feladat:");
            Console.WriteLine($"Fővárosok átlagos távolsága Budapesstől: {orszagok.Average(x => x.Tavolsag)}");

            Console.WriteLine("10. Feladat:");
            Console.WriteLine($"Legnagyobb területtel rendelkező ország: {orszagok.MaxBy(x => x.Terulet)?.Orszag ?? "N/A"}");

            Console.WriteLine("11. Feladat:");
            Console.WriteLine($"Legkevesebb lakosságú ország fővárosa: {orszagok.MinBy(x => x.Lakossag)?.Fovaros ?? "N/A"}");

            Console.WriteLine("12. Feladat:");
            Console.WriteLine($"Budapesstől legmesszebb elhelyezkedő főváros: {orszagok.MaxBy(x => x.Tavolsag)?.Fovaros ?? "N/A"}");

            Console.WriteLine("13. Feladat:");
            Console.WriteLine($"\"A\" betűvel kezdődő országok száma: {orszagok.Count(x => x.Orszag.StartsWith('A'))}");

            Console.WriteLine("14. Feladat:");
            Console.WriteLine("Adja meg egy főváros nevét: ");
            string beolvasottFovaros = Console.ReadLine()!;

            if (orszagok.Exists(x => x.Fovaros == beolvasottFovaros))
            {
                Console.WriteLine($"\"{beolvasottFovaros}\" főváros országának adatai:");
                Orszagok? orszag = orszagok.Find(x => x.Fovaros == beolvasottFovaros);
                if (orszag != null)
                {
                    Console.WriteLine(orszag.Info());
                }
            }
            else
            {
                Console.WriteLine($"Nincs \"{beolvasottFovaros}\" nevű főváros");
            }

            Console.WriteLine("15. Feladat:");
            Console.WriteLine("Adja meg a minimum területet: ");
            int beolvasottTerulet = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"\"{beolvasottTerulet}\" területnél kisebb területű országok:");
            foreach (var item in orszagok.Where(x => x.Terulet < beolvasottTerulet))
            {
                Console.WriteLine(item.Orszag);
            }

            //16. Feladat
            const int magyarorszagTerulete = 93000;
            List<Orszagok> kissebbMONal = orszagok.Where(x => x.Terulet < magyarorszagTerulete).ToList();

            StreamWriter sw = new StreamWriter("kisebbMO.txt");
            foreach (var item in kissebbMONal)
            {
                sw.WriteLine(item.Info() + "\n");
            }
            sw.Close();
        }
    }
}
