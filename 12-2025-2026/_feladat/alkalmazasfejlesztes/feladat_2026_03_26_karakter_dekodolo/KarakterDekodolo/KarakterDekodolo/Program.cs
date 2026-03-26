namespace KarakterDekodolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Karakter> karakterBank = Beolvas("bank.txt");

            Console.WriteLine($"5. feladat: Karakterek száma: {karakterBank.Count}");

            char betu;
            do
            {
                Console.Write("6. feladat: Kérek egy angol nagybetűt: ");
                string? bemenet = Console.ReadLine();
                if (!string.IsNullOrEmpty(bemenet) && bemenet.Length == 1 && bemenet[0] >= 'A' && bemenet[0] <= 'Z')
                {
                    betu = bemenet[0];
                    break;
                }

                Console.WriteLine("Hibas bemenet! Kerem, adjon meg egy angol nagybetut (A-Z)!");
            } while (true);

            Console.WriteLine("7. feladat:");
            Karakter? talalt = karakterBank.Find(k => k.Betu == betu);
            if (talalt != null)
            {
                talalt.Kiir();
            }
            else
            {
                Console.WriteLine("Nincs ilyen karakter a bankban!");
            }

            List<Karakter> dekodolando = Beolvas("dekodol.txt");

            Console.WriteLine("9. feladat: Dekódolás");
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

            Console.WriteLine(szo);
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
