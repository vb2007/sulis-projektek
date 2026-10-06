using System.Numerics;

namespace UtazasiCsomagok_VB_Lib;

public sealed class UtazasiCsomag : ProgramElem
{
    private static List<UtazasiProgram> _utazasiCsomag = new();

    public override string Nev { get; set; }
    public override int Ar { get; set; }

    public UtazasiCsomag(IEnumerable<UtazasiProgram> utazasiProgramok)
    {
        Nev = $"Utazási csomag: {_utazasiCsomag.Select(x => x.Megnevezes)}";
        Ar = _utazasiCsomag.Sum(x => x.Ar);
    }

    //public static UtazasiProgram operator +(UtazasiCsomag utazasiCsomag, UtazasiProgram utazasiProgram)
    //{
    //    UtazasiCsomag utazasiCsomag = new();
    //}
}

