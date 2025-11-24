namespace JoAlany_VB_Lib;

public class SzemelyFactory
{
    public static Szemely CreateSzemely(string adatSor)
    {
        string[] split = adatSor.Split(';');
        
        string szemelyFajta = split[0];
        string szemelyNev = split[1];
        DateTime szuletesiIdo = Convert.ToDateTime(split[2]);
        
        if (szemelyFajta == "t")
        {
            return new Tanar(szemelyNev, szuletesiIdo, Convert.ToDouble(split[3]));
        }
        return new Diak(szemelyNev, szuletesiIdo, Convert.ToInt32(split[3]));
    }
}