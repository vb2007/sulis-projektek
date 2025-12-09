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
    
    public bool this[int nap]
    {
        get
        {
            if (nap < 1 || nap > 31)
            {
                throw new IndexOutOfRangeException("A nap sorszámának 1 és 31 között kell lennie.");
            }
            
            return Elfoglaltsag[nap - 1];
        }
    }
    
    public virtual bool MunkatVallal(int nap)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Neve: {Nev}, Napidíja: {NapiDij}, Szabadnapok: {string.Join(", ", FoglalhatoNapok())}";
    }
}