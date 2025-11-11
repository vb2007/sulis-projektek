namespace Csokigyar_VB_Lib;

internal class Csoki : IEtel
{
    private string Csokifajta { get; init; }
    private string[] Alapanyagok { get; init; }
    private int KakaoTartalom { get; init; }
    
    public IEnumerable<string> MibolKeszul()
    {
        return Alapanyagok;
    }

    public bool MegfeleloMinoseg
        => KakaoTartalom switch
        {
            > 50 => true,
            >= 0 => false,
            _ => throw new SilanyMinosegException()
        };
    
    public Csoki(string csokifajta, IEnumerable<string> alapanyagok, int kakaoTartalom)
    {
        Csokifajta = csokifajta;
        Alapanyagok = alapanyagok.ToArray();
        KakaoTartalom = kakaoTartalom;
    }

    public override string ToString()
    {
        return $"{Csokifajta} kakótartalom: {KakaoTartalom}%. Alapanyagai: {string.Join(", ", Alapanyagok)}";
    }
}