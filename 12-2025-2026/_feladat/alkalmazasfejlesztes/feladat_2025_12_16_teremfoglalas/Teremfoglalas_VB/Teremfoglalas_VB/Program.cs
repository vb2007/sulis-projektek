using Teremfoglalas_VB_Lib;

namespace Teremfoglalas_VB;

class Program
{
    static Dictionary<int, string> teremAzonositoMap = new Dictionary<int, string>();
    static Dictionary<int, string> tanarAzonositoMap = new Dictionary<int, string>();
    static int teremCounter = 1;
    static int tanarCounter = 1;

    static void Main(string[] args)
    {
        File.WriteAllText("hibalista.txt", "");

        TeremNyilvantartas nyilvantartas = new TeremNyilvantartas();

        TermekBeolvasasa(nyilvantartas);

        List<Foglalas> foglalasok = FoglalasokBeolvasasa();

        nyilvantartas.TeremFoglalasok(foglalasok);

        Console.WriteLine("Az elérhető termek:");
        foreach (int azonosito in nyilvantartas.TeremAzonositok)
        {
            Console.WriteLine(teremAzonositoMap[azonosito]);
        }
        Console.WriteLine();

        Console.WriteLine("A termek a foglalások után:\n");
        foreach (Terem terem in nyilvantartas.OsszesTerem)
        {
            string teremNev = teremAzonositoMap[terem.TeremAzonosito];

            if (terem is SpecialisTerem specialisTerem)
            {
                Console.WriteLine($"{teremNev} (takarítási idő: {specialisTerem.TakaritasiIdoPerc} perc):");
            }
            else
            {
                Console.WriteLine($"{teremNev}:");
            }

            Console.WriteLine("Foglalt időpontok:");
            MegjelenitFoglalasok(terem);
            Console.WriteLine();
        }

        Console.Write("Kérem egy tanár azonosítóját: ");
        string tanarAzonosito = Console.ReadLine() ?? "";
        Console.WriteLine($"A tanár foglalásai:");
        TanarFoglalasainakMegjelenites(nyilvantartas, tanarAzonosito);
    }

    static void TermekBeolvasasa(TeremNyilvantartas nyilvantartas)
    {
        string[] sorok = File.ReadAllLines("termek.txt");

        for (int i = 1; i < sorok.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(sorok[i])) continue;

            string[] adatok = sorok[i].Split(';');

            string tipus = adatok[0];
            string teremAzonositoStr = adatok[1];
            int helyekSzama = int.Parse(adatok[2]);

            int teremId = teremCounter++;
            teremAzonositoMap[teremId] = teremAzonositoStr;

            if (tipus == "s")
            {
                int takaritasiIdo = int.Parse(adatok[3]);
                SpecialisTerem terem = new SpecialisTerem(teremId, helyekSzama, takaritasiIdo);
                nyilvantartas.TeremHozzaadas(terem);
            }
            else if (tipus == "a")
            {
                AltalanosTerem terem = new AltalanosTerem(teremId, helyekSzama);
                nyilvantartas.TeremHozzaadas(terem);
            }
        }
    }

    static int GetTeremId(string teremAzonositoStr)
    {
        foreach (var kvp in teremAzonositoMap)
        {
            if (kvp.Value == teremAzonositoStr)
                return kvp.Key;
        }
        
        return -1;
    }

    static int GetTanarId(string tanarAzonositoStr)
    {
        foreach (var kvp in tanarAzonositoMap)
        {
            if (kvp.Value == tanarAzonositoStr)
            {
                return kvp.Key;                
            }
        }

        //ha még nincs létrehozza
        int tanarId = tanarCounter++;
        tanarAzonositoMap[tanarId] = tanarAzonositoStr;
        return tanarId;
    }

    static List<Foglalas> FoglalasokBeolvasasa()
    {
        List<Foglalas> foglalasok = new List<Foglalas>();
        List<string> hibaLista = new List<string>();

        string[] sorok = File.ReadAllLines("foglalasok.txt");

        for (int i = 1; i < sorok.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(sorok[i])) continue;

            string[] adatok = sorok[i].Split(';');

            try
            {
                DateTime kezdet = DateTime.Parse(adatok[0]);
                int idotartamPerc = int.Parse(adatok[1]);
                string teremAzonositoStr = adatok[2];
                string tanarAzonositoStr = adatok[3];

                int teremId = GetTeremId(teremAzonositoStr);
                int tanarId = GetTanarId(tanarAzonositoStr);

                Foglalas foglalas = new Foglalas(
                    kezdet,
                    idotartamPerc,
                    teremId,
                    tanarId
                );

                foglalasok.Add(foglalas);
            }
            catch (IdotartamException ex)
            {
                string hibaUzenet = $"{adatok[0]};{adatok[1]};{adatok[2]};{adatok[3]} - {ex.Message}";
                hibaLista.Add(hibaUzenet);
            }
            catch (Exception ex)
            {
                string hibaUzenet = $"{adatok[0]};{adatok[1]};{adatok[2]};{adatok[3]} - {ex.Message}";
                hibaLista.Add(hibaUzenet);
            }
        }

        if (hibaLista.Count > 0)
        {
            File.AppendAllLines("hibalista.txt", hibaLista);
        }

        return foglalasok;
    }

    static void MegjelenitFoglalasok(Terem terem)
    {
        string orarendStr = terem.Orarend.ToString();

        if (orarendStr == "Nincs foglalás.")
        {
            Console.WriteLine("-");
        }
        else
        {
            string[] sorok = orarendStr.Split('\n');
            for (int i = 1; i < sorok.Length; i++)
            {
                string sor = sorok[i];

                foreach (var kvp in tanarAzonositoMap)
                {
                    sor = sor.Replace($"Tanár azonosító: {kvp.Key}", kvp.Value);
                }

                if (sor.Contains("Tanár azonosító: -1"))
                {
                    sor = sor.Replace("Tanár azonosító: -1", "takarítás");
                }

                Console.WriteLine(sor);
            }
        }
    }

    static void TanarFoglalasainakMegjelenites(TeremNyilvantartas nyilvantartas, string tanarAzonositoStr)
    {
        int tanarId = GetTanarId(tanarAzonositoStr);
        bool vanFoglalas = false;

        foreach (Terem terem in nyilvantartas.OsszesTerem)
        {
            //van-e a tanárnak foglalása ebben a teremben
            List<string> foglalasok = new List<string>();

            string orarendStr = terem.Orarend.ToString();
            if (orarendStr != "Nincs foglalás.")
            {
                string[] sorok = orarendStr.Split('\n');
                for (int i = 1; i < sorok.Length; i++)
                {
                    if (sorok[i].Contains($"Tanár azonosító: {tanarId}"))
                    {
                        vanFoglalas = true;
                        string sor = sorok[i].Replace($"Tanár azonosító: {tanarId}", tanarAzonositoStr);
                        foglalasok.Add(sor);
                    }
                }
            }

            if (foglalasok.Count > 0)
            {
                Console.WriteLine(teremAzonositoMap[terem.TeremAzonosito]);
                foreach (string foglalas in foglalasok)
                {
                    Console.WriteLine(foglalas);
                }
                Console.WriteLine();
            }
        }

        if (!vanFoglalas)
        {
            Console.WriteLine("Nincs foglalás ehhez a tanárhoz.");
        }
    }
}
