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
}