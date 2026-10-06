namespace UtazasiCsomagok_VB_Lib;

public class Programok
{
    private readonly List<UtazasiProgram> _programok;

    public Programok(IEnumerable<UtazasiProgram> programok)
    {
        _programok = programok.ToList();
    }

    public UtazasiProgram this[string id] =>
        _programok.FirstOrDefault(x => x.Azonosito == id)
        ?? throw new HibasProgramException();

    public IEnumerable<UtazasiProgram> BelfoldiProgramok => _programok
            .Where(x => x.Belfoldi)
            .OrderBy(x => x.Megnevezes);
}
