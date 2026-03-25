namespace Keresztrejtveny;


public class KeresztrejtvenyRacs
{
    private List<string> Adatsorok;
    private char[,] Racs;
    private int[,] Sorszamok;

    public int SorokDb { get; private set; }
    public int OszlopokDb { get; private set; }

    public KeresztrejtvenyRacs(string forras)
    {
        Adatsorok = new List<string>();
        BeolvasAdatsorok(forras);

        SorokDb = Adatsorok.Count;
        OszlopokDb = Adatsorok.Count > 0 ? Adatsorok[0].Length : 0;

        //két sorral és oszloppal nagyobb mátrixok (a széleken való kereséshez)
        Racs = new char[SorokDb + 2, OszlopokDb + 2];
        Sorszamok = new int[SorokDb + 2, OszlopokDb + 2];

        for (int i = 0; i < SorokDb + 2; i++)
        {
            for (int j = 0; j < OszlopokDb + 2; j++)
            {
                Racs[i, j] = '#';
                Sorszamok[i, j] = 0;
            }
        }

        FeltoltRacs();
    }

    private void BeolvasAdatsorok(string forras)
    {
        string[] sorok = File.ReadAllLines(forras);
        foreach (string sor in sorok)
        {
            if (!string.IsNullOrEmpty(sor))
            {
                Adatsorok.Add(sor);
            }
        }
    }

    private void FeltoltRacs()
    {
        for (int i = 0; i < SorokDb; i++)
        {
            for (int j = 0; j < Adatsorok[i].Length; j++)
            {
                Racs[i + 1, j + 1] = Adatsorok[i][j];
            }
        }
    }

    public void MegjelenitRacs()
    {
        for (int i = 1; i <= SorokDb; i++)
        {
            for (int j = 1; j <= OszlopokDb; j++)
            {
                if (Racs[i, j] == '#')
                {
                    Console.Write("##");
                }
                else
                {
                    Console.Write("[]");
                }
            }
            Console.WriteLine();
        }
    }

    public int LeghosszabbFuggoSzo()
    {
        int maxHossz = 0;

        for (int j = 1; j <= OszlopokDb; j++)
        {
            int aktualisHossz = 0;
            for (int i = 1; i <= SorokDb + 1; i++)
            {
                if (Racs[i, j] == '-')
                {
                    aktualisHossz++;
                }
                else
                {
                    if (aktualisHossz >= 2 && aktualisHossz > maxHossz)
                    {
                        maxHossz = aktualisHossz;
                    }
                    aktualisHossz = 0;
                }
            }
        }

        return maxHossz;
    }

    public Dictionary<int, int> VizszintesSzavakStatisztika()
    {
        Dictionary<int, int> statisztika = new Dictionary<int, int>();

        for (int i = 1; i <= SorokDb; i++)
        {
            int aktualisHossz = 0;
            for (int j = 1; j <= OszlopokDb + 1; j++)
            {
                if (Racs[i, j] == '-')
                {
                    aktualisHossz++;
                }
                else
                {
                    if (aktualisHossz >= 2)
                    {
                        if (statisztika.ContainsKey(aktualisHossz))
                        {
                            statisztika[aktualisHossz]++;
                        }
                        else
                        {
                            statisztika[aktualisHossz] = 1;
                        }
                    }
                    aktualisHossz = 0;
                }
            }
        }

        return statisztika;
    }

    public void SzamozMezok()
    {
        int sorszam = 1;

        for (int i = 1; i <= SorokDb; i++)
        {
            for (int j = 1; j <= OszlopokDb; j++)
            {
                if (Racs[i, j] == '-')
                {
                    bool vizszintesKezdet = false;
                    bool fuggoKezdet = false;

                    //vízszintes kezdet: bal oldalt # vagy szél, és jobbra van legalább 2 karakter
                    if (Racs[i, j - 1] == '#')
                    {
                        int hossz = 0;
                        int k = j;
                        while (k <= OszlopokDb && Racs[i, k] == '-')
                        {
                            hossz++;
                            k++;
                        }
                        if (hossz >= 2)
                        {
                            vizszintesKezdet = true;
                        }
                    }

                    if (Racs[i - 1, j] == '#')
                    {
                        int hossz = 0;
                        int k = i;
                        while (k <= SorokDb && Racs[k, j] == '-')
                        {
                            hossz++;
                            k++;
                        }
                        if (hossz >= 2)
                        {
                            fuggoKezdet = true;
                        }
                    }

                    if (vizszintesKezdet || fuggoKezdet)
                    {
                        Sorszamok[i, j] = sorszam;
                        sorszam++;
                    }
                }
            }
        }
    }

    public void MegjelenitSzamokkal()
    {
        for (int i = 1; i <= SorokDb; i++)
        {
            for (int j = 1; j <= OszlopokDb; j++)
            {
                if (Racs[i, j] == '#')
                {
                    Console.Write("##");
                }
                else if (Sorszamok[i, j] > 0)
                {
                    Console.Write($"{Sorszamok[i, j]:D2}");
                }
                else
                {
                    Console.Write("[]");
                }
            }
            Console.WriteLine();
        }
    }
}
