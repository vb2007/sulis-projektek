namespace Teremfoglalas_VB_Lib;

public class TeremNyilvantartas
{
    private Dictionary<int, Terem> termek;

    public TeremNyilvantartas()
    {
        termek = new Dictionary<int, Terem>();
    }

    public IEnumerable<int> TeremAzonositok
    {
        get { return termek.Keys; }
    }

    public Terem? this[int teremAzonosito]
    {
        get
        {
            if (termek.ContainsKey(teremAzonosito))
            {
                return termek[teremAzonosito];
            }
            return null;
        }
    }

    public IEnumerable<Terem> OsszesTerem
    {
        get { return termek.Values; }
    }

    public void TeremHozzaadas(Terem terem)
    {
        if (!termek.ContainsKey(terem.TeremAzonosito))
        {
            termek.Add(terem.TeremAzonosito, terem);
        }
    }

    public void TeremFoglalasok(IEnumerable<Foglalas> foglalasok)
    {
        List<string> hibaLista = new List<string>();

        foreach (var foglalas in foglalasok)
        {
            try
            {
                if (termek.ContainsKey(foglalas.HelyszinAzonosito))
                {
                    Terem terem = termek[foglalas.HelyszinAzonosito];
                    terem.IdopontFoglalas(foglalas);
                }
                else
                {
                    hibaLista.Add($"Foglalás adatai: {foglalas}\nHiba: A terem nem található a nyilvántartásban.\n");
                }
            }
            catch (FoglalasException ex)
            {
                hibaLista.Add($"Foglalás adatai: {foglalas}\nHiba: {ex.Message}\n");
            }
            catch (IdotartamException ex)
            {
                hibaLista.Add($"Foglalás adatai: {foglalas}\nHiba: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                hibaLista.Add($"Foglalás adatai: {foglalas}\nHiba: {ex.Message}\n");
            }
        }

        if (hibaLista.Count > 0)
        {
            File.WriteAllLines("hibalista.txt", hibaLista);
        }
    }

    public override string ToString()
    {
        if (termek.Count == 0)
        {
            return "Nincs terem a nyilvántartásban.";
        }

        string eredmeny = "Termek nyilvántartása:\n";
        foreach (Terem terem in termek.Values)
        {
            eredmeny += "\n" + terem.ToString() + "\n";
        }

        return eredmeny.TrimEnd('\n');
    }
}
