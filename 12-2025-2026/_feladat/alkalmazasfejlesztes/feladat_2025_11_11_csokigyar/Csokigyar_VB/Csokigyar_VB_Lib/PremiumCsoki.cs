namespace Csokigyar_VB_Lib;

internal sealed class PremiumCsoki : Csoki
{
    public PremiumCsoki(string csokifajta, IEnumerable<string> alapanyagok, int kakaoTartalom) : base(csokifajta, alapanyagok, kakaoTartalom) { }

    public override bool MegfeleloMinoseg
        => KakaoTartalom switch
        {
            > 80 => true,
            >= 0 => false,
            _ => throw new SilanyMinosegException()
        };

    public override string ToString()
    {
        return $"Prémium {base.ToString()}";
    }
}