namespace Viragkoteszet_VB_Lib;

public class FeladatLista
{
    public List<string> Feladatok { get; } = new List<string>();
    
    public FeladatLista(IEnumerable<string> feladatok)
    {
        foreach (string feladat in feladatok)
        {
            Feladatok.Add(feladat);
        }
    }

    public static List<string> operator +(string feladat)
    {
        Feladatok.Add(feladat);
        return Feladatok;
    }
}