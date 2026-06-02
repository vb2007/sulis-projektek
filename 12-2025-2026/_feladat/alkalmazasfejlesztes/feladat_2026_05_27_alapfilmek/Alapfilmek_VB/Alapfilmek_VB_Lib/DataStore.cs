using Alapfilmek_VB_Lib.Tables;

namespace Alapfilmek_VB_Lib;

public class DataStore
{
    private readonly List<Alkotok> _alkotok;
    private readonly List<Filmek> _filmek;
    private readonly List<Filmstab> _filmstab;
    private readonly List<Munkakor> _munkakor;

    private DataStore()
    {
        //windowson: _alkotok = File.ReadAllLines("Input\\alkotok.txt")
        //linuxon:
        _alkotok = File.ReadAllLines(Path.Combine("Input", "alkotok.txt"))
            .Skip(1)
            .Select(x => new Alkotok(x))
            .ToList();

        _filmek = File.ReadAllLines(Path.Combine("Input", "filmek.txt"))
            .Skip(1)
            .Select(x => new Filmek(x))
            .ToList();

        _filmstab = File.ReadAllLines(Path.Combine("Input", "filmstab.txt"))
            .Skip(1)
            .Select(x => new Filmstab(x))
            .ToList();

        _munkakor = File.ReadAllLines(Path.Combine("Input", "munkakor.txt"))
            .Skip(1)
            .Select(x => new Munkakor(x))
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

    public int HuszadikSzazadiAlkotokSzama => _alkotok
        .Count(x =>
            x.Szuletett.HasValue &&
            x.Szuletett.Value.Year >= 1900
            && x.Szuletett.Value.Year < 2000);

    public int OtvenEvesFilmekSzama => _filmek
        .Count(x => x.Ev == DateTime.Now.Year - 50);

    public IEnumerable<(string Cim, string Mufaj, int Hossz)> FilmekEgyTanoranBelul =>
        _filmek
            .Where(x => x.Hossz <= 45)
            .OrderBy(x => x.Hossz)
            .Select(x => (x.Cim, x.Mufaj, x.Hossz));

    public (string Cim, int Ev, int FilmAzonosito, string Rendezok)? FilmKereses(string cim)
    {
        Filmek? film = _filmek.FirstOrDefault(x => x.Cim == cim);
        
        if (film is null)
        {
            return null;
        }

       List<string> rendezok = _filmstab
            .Where(x => x.FilmAzonosito == film.FilmAzonosito && x.MunkakorAzonosito == 1)
            .Join(_alkotok, fs => fs.AlkotoAzonosito, a => a.AlkotoAzonosito, (fs, a) => a.Nev)
            .ToList();

        return (film.Cim, film.Ev, film.FilmAzonosito, string.Join(", ", rendezok));
    }

    public IEnumerable<(string Nev, int Darab)> Top2FoszereplosAlkotok =>
        _filmstab
            .GroupBy(x => x.AlkotoAzonosito)
            .OrderByDescending(g => g.Count())
            .Take(2)
            .Join(_alkotok, g => g.Key, a => a.AlkotoAzonosito, (g, a) => (a.Nev, g.Count()));

    public IEnumerable<(string FilmCim, IEnumerable<string> Szinesztarsak)> DajkaMargitSzinesztarsai
    {
        get
        {
            var dajka = _alkotok.First(x => x.Nev == "Dajka Margit");

            return _filmstab
                .Where(x => x.AlkotoAzonosito == dajka.AlkotoAzonosito &&
                            (x.MunkakorAzonosito == 6 || x.MunkakorAzonosito == 7))
                .Select(x => x.FilmAzonosito)
                .Distinct()
                .Select(filmId =>
                {
                    var film = _filmek.First(f => f.FilmAzonosito == filmId);
                    
                    var szinesztarsak = _filmstab
                        .Where(x => x.FilmAzonosito == filmId &&
                                    x.AlkotoAzonosito != dajka.AlkotoAzonosito &&
                                    (x.MunkakorAzonosito == 6 || x.MunkakorAzonosito == 7))
                        .Select(x => x.AlkotoAzonosito)
                        .Distinct()
                        .Join(_alkotok, id => id, a => a.AlkotoAzonosito, (id, a) => a.Nev)
                        .OrderBy(n => n)
                        .ToList();
                    
                    return (FilmCim: film.Cim, Szinesztarsak: (IEnumerable<string>)szinesztarsak);
                })
                .OrderBy(x => x.FilmCim)
                .ToList();
        }
    }
}