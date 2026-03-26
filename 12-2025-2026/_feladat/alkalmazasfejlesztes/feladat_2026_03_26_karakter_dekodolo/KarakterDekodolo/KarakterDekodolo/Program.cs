namespace KarakterDekodolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4. feladat - bank.txt beolvasása
            List<Karakter> karakterBank = Beolvas("bank.txt");

            // 5. feladat
            Console.WriteLine("5. feladat");
            Console.WriteLine($"A karakterbankban {karakterBank.Count} karakter talalhato.");
            Console.WriteLine();

            // 6. feladat
            Console.WriteLine("6. feladat");
            char betu;
            do
            {
                Console.Write("Kerek egy angol nagybetut: ");
                string? bemenet = Console.ReadLine();
                if (!string.IsNullOrEmpty(bemenet) && bemenet.Length == 1 && bemenet[0] >= 'A' && bemenet[0] <= 'Z')
                {
                    betu = bemenet[0];
                    break;
                }

                Console.WriteLine("Hibas bemenet! Kerem, adjon meg egy angol nagybetut (A-Z)!");
            } while (true);
            Console.WriteLine();

            // 7. feladat
            Console.WriteLine("7. feladat");
            Karakter? talalt = karakterBank.Find(k => k.Betu == betu);
            if (talalt != null)
            {
                talalt.Kiir();
            }
            else
            {
                Console.WriteLine("Nincs ilyen karakter a bankban!");
            }
            Console.WriteLine();

            // 8. feladat - dekodol.txt beolvasása
            List<Karakter> dekodolando = Beolvas("dekodol.txt");

            // 9. feladat
            Console.WriteLine("9. feladat");
            string szo = "";
            foreach (Karakter dk in dekodolando)
            {
                bool megtalalt = false;
                foreach (Karakter bk in karakterBank)
                {
                    if (bk.Felismer(dk))
                    {
                        szo += bk.Betu;
                        megtalalt = true;
                        break;
                    }
                }

                if (!megtalalt)
                {
                    szo += '?';
                }
            }

            Console.WriteLine($"A dekodolt szo: {szo}");
        }

        static List<Karakter> Beolvas(string fajlNev)
        {
            List<Karakter> karakterek = [];
            string[] sorok = File.ReadAllLines(fajlNev);

            int i = 0;
            while (i < sorok.Length)
            {
                char betu = sorok[i][0];
                i++;

                string[] matrix = new string[7];
                for (int j = 0; j < 7; j++)
                {
                    matrix[j] = sorok[i];
                    i++;
                }

                karakterek.Add(new Karakter(betu, matrix));
            }

            return karakterek;
        }
    }
}
