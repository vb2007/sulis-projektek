namespace Berek2020
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3. Feladat
            List<Dolgozo> dolgozok = new();

            foreach (var item in File.ReadAllLines("berek2020.txt").Skip(1))
            {
                string[] darabolt = item.Split(';');
                //0: Név, 1: Neme, 2: Részleg, 3: Belépés, 4: Bér
                dolgozok.Add(new Dolgozo(darabolt[0], darabolt[1], darabolt[2], int.Parse(darabolt[3]), int.Parse(darabolt[4])));
            }

            //4. Feladat
            Console.WriteLine($"4. Feladat: {dolgozok.Count} dolgozók adatai találhatók a forrásállományban.");

            //5. Feladat
            double atlagBer = dolgozok.Average(x => x.Ber) / 1000.0;
            Console.WriteLine($"5. Feladat: A dolgozók átlag 2020-as bére: {atlagBer:F1} e Ft");

            //6. Feladat
            Console.Write("6. Feladat: Kérem egy részleg nevét: ");
            string dolgozoBemenet = Console.ReadLine()!;

            //7. Feladat
            Dolgozo? legtobbetKereso = dolgozok
                .Where(x => x.Reszleg == dolgozoBemenet)
                .OrderByDescending(x => x.Ber)
                .FirstOrDefault();

            if (legtobbetKereso == null)
            {
                Console.WriteLine("7. Feladat: A megadott részleg nem létezik a cégnél!");
            }
            else
            {
                Console.WriteLine("7. Feladat: A legtöbbet kereső dolgozó a megadott részlegen:");
                Console.WriteLine($"\tNév: {legtobbetKereso.Nev}");
                Console.WriteLine($"\tNeme: {legtobbetKereso.Nem}");
                Console.WriteLine($"\tBelépés: {legtobbetKereso.Belepes}");
                Console.WriteLine($"\tBér: {legtobbetKereso.Ber} Ft");
            }

            //8. Feladat
            var reszlegStatisztika = dolgozok
                .GroupBy(x => x.Reszleg)
                .Select(g => new { Reszleg = g.Key, Letszam = g.Count() });

            Console.WriteLine("8. Feladat: Statisztika az egyes részlegeken dolgozók összesített számáról:");
            foreach (var reszleg in reszlegStatisztika)
            {
                Console.WriteLine($"\t{reszleg.Reszleg} - {reszleg.Letszam} fő");
            }
        }
    }
}
