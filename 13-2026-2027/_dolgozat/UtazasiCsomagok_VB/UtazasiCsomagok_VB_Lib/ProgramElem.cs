namespace UtazasiCsomagok_VB_Lib;

public abstract class ProgramElem : IProgram
{
    public abstract string Nev { get; }
    public abstract int Ar { get; }

    public override string ToString()
    {
        //ár magyar lokalizáción pl.: 11 000 Ft
        return $"{Nev} - {Ar:C0}";
    }
}

