namespace Teremfoglalas_VB_Lib;

public class Orarend
{
    private List<Foglalas> foglalasok;

    public Orarend()
    {
        foglalasok = new List<Foglalas>();
    }

    public bool FoglaltE(DateTime kezdet, int idotartamPerc)
    {
        DateTime veg = kezdet.AddMinutes(idotartamPerc);

        foreach (Foglalas foglalas in foglalasok)
        {
            //van-e átfedés:
            //ha az új foglalás kezdete a meglévő foglalás időtartamába esik
            //az új foglalás vége a meglévő foglalás időtartamába esik
            //az új foglalás teljesen magába foglalja a meglévő foglalást
            if ((kezdet >= foglalas.Kezdete && kezdet < foglalas.Vege) ||
                (veg > foglalas.Kezdete && veg <= foglalas.Vege) ||
                (kezdet <= foglalas.Kezdete && veg >= foglalas.Vege))
            {
                return true;
            }
        }

        return false;
    }

    public static Orarend operator +(Orarend orarend, Foglalas foglalas)
    {
        int idotartamPerc = (int)(foglalas.Vege - foglalas.Kezdete).TotalMinutes;

        if (orarend.FoglaltE(foglalas.Kezdete, idotartamPerc))
        {
            throw new FoglalasException();
        }

        orarend.foglalasok.Add(foglalas);
        return orarend;
    }

    public override string ToString()
    {
        if (foglalasok.Count == 0)
        {
            return "Nincs foglalás.";
        }

        List<Foglalas> rendezettFoglalasok = foglalasok.OrderBy(f => f.Kezdete).ToList();

        string eredmeny = "Foglalások időrendi sorrendben:\n";
        foreach (var foglalas in rendezettFoglalasok)
        {
            eredmeny += foglalas.ToString() + "\n";
        }

        return eredmeny.TrimEnd('\n');
    }
}
