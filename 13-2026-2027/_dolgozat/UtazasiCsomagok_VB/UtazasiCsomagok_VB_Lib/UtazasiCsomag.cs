using System.Numerics;

namespace UtazasiCsomagok_VB_Lib;

public sealed class UtazasiCsomag : ProgramElem
{
    private readonly static List<UtazasiProgram> _utazasiCsomag = new();

    public override string Nev
    {
        get
        {
            string[] utazasNevek = { };
            foreach(UtazasiProgram utazasiProgram in _utazasiCsomag)
            {
                utazasNevek.Append(utazasiProgram.Megnevezes);
            }

            return string.Join(", ", utazasNevek);
        }
    }
    public override int Ar
    {
        get
        {
            int osszeg = 0;
            foreach (UtazasiProgram utazasiProgram in _utazasiCsomag)
            {
                osszeg += utazasiProgram.Ar;
            }

            return osszeg;
        }
    }

    public UtazasiCsomag(IEnumerable<UtazasiProgram> utazasiProgramok)
    {
        foreach (UtazasiProgram utazasiProgram in utazasiProgramok)
        {
            _utazasiCsomag.Append(utazasiProgram);
        }
    }

    //public static UtazasiProgram operator +(UtazasiCsomag utazasiCsomag, UtazasiProgram utazasiProgram)
    //{
    //    UtazasiCsomag utazasiCsomag = new();
    //}
}

