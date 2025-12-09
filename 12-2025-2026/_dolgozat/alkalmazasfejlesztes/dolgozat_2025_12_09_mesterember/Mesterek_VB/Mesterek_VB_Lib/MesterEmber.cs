namespace Mesterek_VB_Lib;

public class MesterEmber : IFoglalhato
{
    public string Nev { get; set; }
    public int NapiDij { get; set; }
    public bool[] Elfoglaltsag { get; set; } = new bool[31];

    public MesterEmber(string nev, int napiDij)
    {
        Nev = nev;
        NapiDij = napiDij;
        
        for (int i = 0; i < Elfoglaltsag.Length; i++)
        {
            Elfoglaltsag[i] = true;
        }
    }
    
    public IEnumerable<int> FoglalhatoNapok()
    {
        for (int i = 0; i < Elfoglaltsag.Length; i++)
        {
            if (Elfoglaltsag[i])
            {
                // return i;
                yield return i;
            }
        }
    }

    public int SzabadnapokSzama => Elfoglaltsag.Count(x => x);
}