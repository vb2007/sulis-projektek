namespace Mesterek_VB_Lib;

public sealed class VizvezetekSzerelo : MesterEmber
{
    public int TapasztalatokEve { get; set; }
    
    public VizvezetekSzerelo(string nev, int tapasztalatokEve) : base(nev, napiDij: tapasztalatokEve * 6500)
    {
        TapasztalatokEve = tapasztalatokEve;
    }
    
    public override string ToString()
    {
        return $"Neve: {Nev}, Tapasztalatok évei: {TapasztalatokEve} Napidíja: {NapiDij}, Szabadnapok: {string.Join(", ", FoglalhatoNapok())}";
    }
}