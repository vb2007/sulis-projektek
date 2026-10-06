namespace UtazasiCsomagok_VB_Lib;

public class UtazasiProgram
{
    private const string BelfoldiHelyszin = "Magyarország";

    public string Azonosito { get; }
    public string Megnevezes { get; }
    public string Helyszin { get; }
    public int Ar { get; }

    public bool Belfoldi => Helyszin == BelfoldiHelyszin;

    public UtazasiProgram(string azonosito, string megnevezes, string helyszin, int ar)
    {
        Azonosito = azonosito;
        Megnevezes = megnevezes;
        Helyszin = helyszin;
        Ar = ar;
    }

    public override string ToString()
    {
        //ár magyar lokalizáción pl.: 11 000 Ft
        return $"{Megnevezes} ({Helyszin}) - {Ar:C0}";
    }
}
