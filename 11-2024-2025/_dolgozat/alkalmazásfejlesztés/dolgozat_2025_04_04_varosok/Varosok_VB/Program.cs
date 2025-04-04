namespace Varosok_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Feladat
            List<Varos> varosok = new();

            foreach (var varos in File.ReadAllLines("varosok.txt").Skip(1))
            {
                string[] darabolt = varos.Split(';');
                varosok.Add(new Varos(
                    darabolt[0],
                    darabolt[1],
                    int.Parse(darabolt[2]),
                    double.Parse(darabolt[3]),
                    darabolt[4]));
            }

            //foreach (Varos item in varosok)
            //{
            //    Console.WriteLine($"Név: {item.Nev}");
            //    Console.WriteLine($"Vármegye: {item.Varmegye}");
            //    Console.WriteLine($"Népesség: {item.Nepesseg}");
            //    Console.WriteLine($"Terület: {item.Terulet}");
            //    Console.WriteLine($"Nyilv éve: {item.NyilvanitasEve}");
            //}

            //2. Feladat
            Console.WriteLine($"2. Feladat: Magyarország {varosok.Count} városa szerepel a listában.");

            //3. Feladat
            Varos? elso200FonelKevesebbLakossagu = varosok.FirstOrDefault(x => x.Nepesseg < 2000);

            Console.WriteLine($"3. Feladat: Az első 2000 főnél kevesebb lakosú város:");
            Console.WriteLine($"\tNeve: {elso200FonelKevesebbLakossagu?.Nev}");
            Console.WriteLine($"\tVármegye: {elso200FonelKevesebbLakossagu?.Varmegye}");
            Console.WriteLine($"\tLakossága: {elso200FonelKevesebbLakossagu?.Nepesseg} fő");
            Console.WriteLine($"\tVárosság nyilvánítás éve: {elso200FonelKevesebbLakossagu?.NyilvanitasEve}");

            //4. Feladat
            double atlagTerulet = varosok
                .Select(x => x.Terulet)
                .Average();
            double atlagTeruletKerekitett = Math.Round(atlagTerulet, 2);

            Console.WriteLine($"4. Feladat: A városok átlagos területe: {atlagTeruletKerekitett} km2");

            //5. Feladat
            int rendszervaltasUtanVarosokSzama = varosok
                .Count(x => x.NyilvanitasEve > 1990);

            Console.WriteLine($"5. Feladat: A rendszerváltás után {rendszervaltasUtanVarosokSzama} település kapott városi rangot");

            //6. Feladat
            Varos legritkabbanLakottVaros = varosok
                .OrderBy(x => x.Nepesseg / x.Terulet)
                .First();

            double legritkabbanLakottVarosNepsurusege = (double)legritkabbanLakottVaros.Nepesseg / legritkabbanLakottVaros.Terulet;
            double legritkabbanLakottVarosNepsurusegeKerekitett = Math.Round(legritkabbanLakottVarosNepsurusege, 2);

            Console.WriteLine($"6. Feladat: A legkisebb népsűrűségű város: {legritkabbanLakottVaros.Nev}");
            Console.WriteLine($"\tNépsűrűseg: {legritkabbanLakottVarosNepsurusegeKerekitett} fő/km2");
            Console.WriteLine($"\tVármegye: {legritkabbanLakottVaros.Varmegye}");
            Console.WriteLine($"\tVárossá nyilvánítás éve: {legritkabbanLakottVaros.NyilvanitasEve}");

            //7. Feladat
            Console.Write("7. feladat: A keresett év: ");
            int keresettEv = int.Parse(Console.ReadLine()!);

            bool vanIlyenVaros = varosok.Any(x => x.NyilvanitasEve == keresettEv);

            if (vanIlyenVaros)
            {
                Console.WriteLine($"\tVolt {keresettEv}-ban/ben várossá nyilvánított település");
            }
            else
            {
                Console.WriteLine("\tNem volt ebben az évben várossá nyilvánított település");
            }

            //8. Feladat
            var top3LegsurubbenLakottVaros = varosok
                .Where(x => x.Varmegye == "Pest")
                .OrderByDescending(x => x.Nepesseg / x.Terulet)
                .Take(3)
                .Select((x, index) => new { Helyezes = index + 1, Varos = x });

            Console.WriteLine("8. Feladat: A 3 legsűrűbben lakott Pest vármegyei város:");
            foreach (var item in top3LegsurubbenLakottVaros)
            {
                Console.WriteLine($"\t{item.Helyezes}. {item.Varos.Nev}");
            }

            //9. Feladat
            IEnumerable<string> nogradMegyeiVarosok = varosok
                .Where(x => x.Varmegye == "Nógrád")
                .OrderBy(x => x.Nev)
                .Select(x => x.Nev);

            Console.WriteLine("9. Feladat: Nógrád vármegyei városok:");
            Console.WriteLine(string.Join(", ", nogradMegyeiVarosok));

            //10. Feladat
            var varosokMegyekent = varosok
                .GroupBy(x => x.Varmegye)
                .Select(g => new { Varmegye = g.Key, VarosokSzama = g.Count() });

            Console.WriteLine("10. Feladat: Városok száma megyénként:");
            foreach (var item in varosokMegyekent)
            {
                Console.WriteLine($"\t{item.Varmegye}: {item.VarosokSzama} város");
            }
        }
    }
}
