namespace UtazasiCsomagok_VB_Lib;

public class UtazasiProgram
{
    public string Azonosito { get; set; }
    public string Megnevezes { get; set; }
    public string Helyszin { get; set; }
    public int Ar { get; set; }

    public bool Belfoldi => Helyszin.Equals("Magyarország");

    //"A helyszín nevét tárold el megfelelően az osztályban BelfoldiHelyszin néven."
    public string BelfoldiHelyszin => Helyszin;

    public UtazasiProgram(string azonosito, string megnevezes, string helyszin, int ar)
    {
        Azonosito = azonosito;
        Megnevezes = megnevezes;
        Helyszin = helyszin;
        Ar = ar;
    }
}
