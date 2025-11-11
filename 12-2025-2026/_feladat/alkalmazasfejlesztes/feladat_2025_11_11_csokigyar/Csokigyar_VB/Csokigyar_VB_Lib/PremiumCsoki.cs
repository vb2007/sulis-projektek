namespace Csokigyar_VB_Lib;

internal sealed class PremiumCsoki : Csoki
{
    public PremiumCsoki(string csokifajta, IEnumerable<string> alapanyagok, int kakaoTartalom) : base(csokifajta, alapanyagok, kakaoTartalom) { }
}