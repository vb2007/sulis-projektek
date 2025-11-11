namespace Csokigyar_VB_Lib;

public class EtelFactory
{
    public IEtel Factory(string adatSor)
    {
        string[] adatElemek = adatSor.Split(';');
        
        if (adatElemek[^1] == "prémium")
        {
            return new PremiumCsoki(
                csokifajta: adatElemek[0],
                kakaoTartalom: int.Parse(adatElemek[1]),
                alapanyagok: adatElemek[2..^1]
            );
        }

        return new Csoki(
            csokifajta: adatElemek[0],
            kakaoTartalom: int.Parse(adatElemek[1]),
            alapanyagok: adatElemek[2..^1]
        );
    }    
}