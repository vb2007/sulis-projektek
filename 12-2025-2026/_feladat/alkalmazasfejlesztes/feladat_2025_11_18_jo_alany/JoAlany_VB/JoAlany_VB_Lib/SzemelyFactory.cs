namespace JoAlany_VB_Lib;

public class SzemelyFactory
{
    public static Szemely CreateSzemely(string adatSor)
    {
        string[] split = adatSor.Split(';');

        string szemelyNev = split[0];
        string szemelyFajta = split[1];
        DateTime szuletesiIdo = Convert.ToDateTime(split[2]);
        if (szemelyFajta == "t")
        {
            return new Tanar(szemelyNev, szuletesiIdo, Convert.ToDouble(split[3]));
        }
        else
        {
            return new Tanar(szemelyNev, szuletesiIdo, Convert.ToInt32(split[3]));
        }
    }
}