namespace Kemia_VB_Lib;

public class Vegyulet : IReakcioKepes
{
    private Dictionary<KemiaiElem, int> elemek;

    public Vegyulet()
    {
        elemek = new Dictionary<KemiaiElem, int>();
    }

    public void ElemHozzaad(KemiaiElem elem, int mennyiseg)
    {
        elemek[elem] = mennyiseg;
    }

    public bool Szerves()
    {
        foreach (var elem in elemek.Keys)
        {
            if (elem.Vegyjel == "C")
            {
                return true;
            }
        }
        return false;
    }

    public bool Szenhidrat()
    {
        bool vanSzen = false;
        bool vanHidrogen = false;
        bool vanOxigen = false;
        int hidrogenMennyiseg = 0;
        int oxigenMennyiseg = 0;

        foreach (var elem in elemek)
        {
            switch (elem.Key.Vegyjel)
            {
                case "C":
                    vanSzen = true;
                    break;
                case "H":
                    vanHidrogen = true;
                    hidrogenMennyiseg = elem.Value;
                    break;
                case "O":
                    vanOxigen = true;
                    oxigenMennyiseg = elem.Value;
                    break;
            }
        }

        //szénhidrát: C, H, O van benne, és H:O = 2:1
        if (vanSzen && vanHidrogen && vanOxigen && elemek.Count == 3)
        {
            return hidrogenMennyiseg == 2 * oxigenMennyiseg;
        }

        return false;
    }

    public bool ReakciobaLephet()
    {
        //akkor tud reakcióba lépni, ha van benne legalább egy elem
        return elemek.Count > 0;
    }

    public bool ReakciobaLephet(IReakcioKepes obj)
    {
        //vegyület más objektummal is reakcióba léphet
        return elemek.Count > 0;
    }

    public override string ToString()
    {
        string result = "Vegyület: ";
        foreach (var kvp in elemek)
        {
            result += kvp.Key.Vegyjel;
            if (kvp.Value > 1)
            {
                result += kvp.Value;
            }
        }
        
        result += "\n\tSzerves: " + (Szerves() ? "Igen" : "Nem");
        result += "\n\tSzénhidrát: " + (Szenhidrat() ? "Igen" : "Nem");
        
        return result;
    }
}
