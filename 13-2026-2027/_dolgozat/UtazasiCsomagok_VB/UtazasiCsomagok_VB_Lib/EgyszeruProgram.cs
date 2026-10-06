namespace UtazasiCsomagok_VB_Lib;

public sealed class EgyszeruProgram : ProgramElem
{
    public override string Nev { get; set; }
    public override int Ar { get; set; }

    public EgyszeruProgram(UtazasiProgram utazasiProgram)
    {
        Nev = utazasiProgram.Megnevezes;
        Ar = utazasiProgram.Ar;
    }
}
