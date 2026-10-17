namespace UtazasiCsomagok_VB_Lib;

public sealed class UtazasiCsomag : ProgramElem
{
    private readonly List<UtazasiProgram> _utazasiProgramok;

    public override string Nev =>
        $"Utazási csomag: {string.Join(", ", _utazasiProgramok.Select(x => x.Megnevezes))}";

    public override int Ar => _utazasiProgramok.Sum(x => x.Ar);

    public UtazasiCsomag(IEnumerable<UtazasiProgram> utazasiProgramok)
    {
        _utazasiProgramok = utazasiProgramok.ToList();
    }

    public static UtazasiCsomag operator +(UtazasiCsomag utazasiCsomag, UtazasiProgram utazasiProgram)
    {
        return new UtazasiCsomag(utazasiCsomag._utazasiProgramok.Append(utazasiProgram));
    }
}
