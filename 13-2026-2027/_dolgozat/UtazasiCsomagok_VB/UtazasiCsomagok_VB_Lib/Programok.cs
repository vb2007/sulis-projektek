namespace UtazasiCsomagok_VB_Lib;

public class Programok
{
    private static readonly List<UtazasiProgram> _programok = new();

    public Programok(IEnumerable<string> nyersProgramSorok)
    {
        foreach (string programSor in nyersProgramSorok)
        {
            string[] adatTomb = programSor.Split(";");

            string azonosito = adatTomb[0];
            string megnevezes = adatTomb[1];
            string helyszin = adatTomb[2];
            int ar = int.Parse(adatTomb[3]);

            _programok.Add(new(azonosito, megnevezes, helyszin, ar));
        }
    }

    public UtazasiProgram? this[string id] => _programok
        .FirstOrDefault(x => x.Azonosito == id);

    public IEnumerable<UtazasiProgram> BelfoldiProgramok => _programok
        .Where(x => x.Belfoldi == true)
        .OrderBy(x => x.Megnevezes);
}

