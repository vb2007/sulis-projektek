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
}