using Foldrenges_VB_Lib.Tables;

namespace Foldrenges_VB_Lib;

public class DataStore
{
    private readonly List<Naplo> _naplok;
    private readonly List<Telepules> _telepulesek;

    private DataStore()
    {
        _naplok = File.ReadAllLines(Path.Combine("Input", "naplo.txt"))
            .Skip(1)
            .Select(x => new Naplo(x))
            .ToList();

        _telepulesek = File.ReadAllLines(Path.Combine("Input", "telepules.txt"))
            .Skip(1)
            .Select(x => new Telepules(x))
            .ToList();
    }
    
    public static DataStore? Instance { get; private set; }

    public static void Init()
    {
        if (Instance is not null)
        {
            throw new InvalidOperationException("Már inicializálva van.");
        }

        Instance = new DataStore();
    }

    public int TelepulesekSzama => _telepulesek
        .Count();

    public float IntenzitasAtlag => (float)Math.Round(
        _naplok.Average(x => x.Intenzitas) ?? 0f,
        1
    );

    public float? LegnagyobbMagnitudo => _naplok
        .Max(x => x.Magnitudo);

    public int NagyobbMint4MagnitudoFoldrengesekSzama => _naplok
        .Count(x => x.Magnitudo > 4.0);

    public bool VoltFoldrenges2003Juliusban => _naplok
        //sznob módon:
        .Exists(x => x.Datum is { Year: 2003, Month: 07 });
        //normálisan, megjegyezhető módon:
        //.Exists(x => x.Datum.Year == 2003 && x.Datum.Month == 07);
        
    public (float? Magnitudo, float? Intenzitas, DateOnly Datum, TimeOnly Ido)? LegelsoFoldrengesTelepulesNevAlapjan(string telepulesNev)
    {
        Telepules? telepules = _telepulesek.FirstOrDefault(x => x.Nev.ToLower() == telepulesNev);
        
        if (telepules is null)
        {
            return null;
        }

        Naplo? elso = _naplok
            .Where(x => x.TelepId == telepules.Id)
            .OrderBy(x => x.Datum)
            .ThenBy(x => x.Ido)
            .FirstOrDefault();

        if (elso is null)
        {
            return null; // van a városban, de nincs hozzá napló sor
        }

        return (elso.Magnitudo, elso.Intenzitas, elso.Datum, elso.Ido);
    }
    
    //honnan a tökömből kéne előhúznom a Richter skálát dolgozatkor
    public List<(string? Telepules, float? Magnitudo)> HaromLegnagyobbMagnitudotElszenvedoTelepules =>
        _naplok
            .OrderByDescending(x => x.Magnitudo)
            .Take(3)
            .Select(x => (
                Telepules: _telepulesek.FirstOrDefault(y => y.Id == x.TelepId)?.Nev,
                x.Magnitudo
            ))
            .ToList();
    
    //takarodjatok a tökömbe a Richter skálával
    public List<(string Telepules, DateOnly Datum, float? Magnitudo)> FoldrengesekVarmegyeAlapjan(string varmegyeNev)
    {
        List<int> telepulesIds = _telepulesek
            .Where(x => x.Varmegye.ToLower() == varmegyeNev)
            .Select(x => x.Id)
            .ToList();

        return _naplok
            .Where(x => telepulesIds.Contains(x.TelepId))
            .Select(x => (
                Telepules: _telepulesek.First(y => y.Id == x.TelepId).Nev,
                x.Datum,
                x.Magnitudo
            ))
            .ToList();
    }
}