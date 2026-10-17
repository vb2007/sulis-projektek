namespace UtazasiCsomagok_VB_Lib;

public sealed class EgyszeruProgram : ProgramElem
{
    public override string Nev { get; }
    public override int Ar { get; }

    public EgyszeruProgram(UtazasiProgram utazasiProgram)
    {
        Nev = utazasiProgram.Megnevezes;
        Ar = utazasiProgram.Ar;
    }
}
