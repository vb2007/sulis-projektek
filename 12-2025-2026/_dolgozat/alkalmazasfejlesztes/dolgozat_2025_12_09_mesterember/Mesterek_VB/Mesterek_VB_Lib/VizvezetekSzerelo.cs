namespace Mesterek_VB_Lib;

public sealed class VizvezetekSzerelo : MesterEmber
{
    public int TapasztalatokEve { get; set; }
    
    public VizvezetekSzerelo(string nev, int tapasztalatokEve) : base(nev, napiDij: tapasztalatokEve * 6500)
    {
        TapasztalatokEve = tapasztalatokEve;
    }
}