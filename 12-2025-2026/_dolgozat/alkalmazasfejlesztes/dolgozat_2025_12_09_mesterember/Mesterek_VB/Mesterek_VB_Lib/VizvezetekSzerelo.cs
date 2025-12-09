namespace Mesterek_VB_Lib;

public sealed class VizvezetekSzerelo : MesterEmber
{
    public int TapasztalatokEve { get; set; }
    
    public VizvezetekSzerelo(string nev, int tapasztalatokEve) : base(nev, napiDij: tapasztalatokEve * 6500)
    {
        TapasztalatokEve = tapasztalatokEve;
    }
    
    public override bool MunkatVallal(int nap)
    {
        if (nap < 2 || nap > 30)
        {
            return false;
        }
        
        if (!this[nap - 1] || !this[nap] || !this[nap + 1])
        {
            return false;
        }
        
        Elfoglaltsag[nap - 2] = false;
        Elfoglaltsag[nap - 1] = false;
        Elfoglaltsag[nap] = false;
        
        return true;
    }
    
    public new IEnumerable<int> FoglalhatoNapok()
    {
        for (int nap = 2; nap <= 30; nap++)
        {
            if (this[nap - 1] && this[nap] && this[nap + 1])
            {
                yield return nap;
            }
        }
    }
    
    public new int SzabadnapokSzama => FoglalhatoNapok().Count();
    
    public override string ToString()
    {
        return $"Neve: {Nev}, Tapasztalatok évei: {TapasztalatokEve}, Napidíja: {NapiDij}, Szabadnapok: {string.Join(", ", FoglalhatoNapok())}";
    }
}