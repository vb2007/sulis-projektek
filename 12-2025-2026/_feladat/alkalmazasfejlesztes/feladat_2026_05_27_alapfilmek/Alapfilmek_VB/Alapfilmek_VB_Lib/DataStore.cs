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
        _alkotok = File.ReadAllLines("Input\\alkotok.txt")
            .Skip(1)
            .Select(x => new Alkotok(x))
            .ToList();

        _filmek = File.ReadAllLines("Input\\filmek.txt")
            .Skip(1)
            .Select(x => new Filmek(x))
            .ToList();

        _filmstab = File.ReadAllLines("Input\\filmstab.txt")
            .Skip(1)
            .Select(x => new Filmstab(x))
            .ToList();

        _munkakor = File.ReadAllLines("Input\\munkakor.txt")
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
        .Count(x => x.Ev == currentYear = DateTime.Now.Year - 50);
}