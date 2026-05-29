using StartTrek_VB_Lib.Tables;

namespace StartTrek_VB_Lib
{
    public class DataStore
    {
        private readonly List<Fajok> _fajok;
        private readonly List<HajoOsztalyok> _hajoOsztalyok;
        private readonly List<HajoSzerepek> _hajoSzerepek;
        private readonly List<Urhajok> _urhajok;

        private DataStore()
        {
            //Linuxon nem működik:
            //_fajok = ReadCsvLines("fajok.csv").Skip(1)
            
            _fajok = ReadCsvLines("fajok.csv").Skip(1)
                .Select(x => new Fajok(x))
                .ToList();

            _hajoOsztalyok = ReadCsvLines("hajo_osztalyok.csv").Skip(1)
                .Select(x => new HajoOsztalyok(x))
                .ToList();

            _hajoSzerepek = ReadCsvLines("hajo_szerepek.csv").Skip(1)
                .Select(x => new HajoSzerepek(x))
                .ToList();

            _urhajok = ReadCsvLines("urhajok.csv").Skip(1)
                .Select(x => new Urhajok(x))
                .ToList();
        }

        private static string[] ReadCsvLines(string fileName)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Input", fileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Hiányzó bemeneti fájl: {path}", path);
            }

            return File.ReadAllLines(path);
        }

        public static DataStore? Instance { get; private set; }
        
        public static void InitCsv()
        {
            if (Instance is not null)
            {
                throw new InvalidOperationException("Már inicializálva van.");
            }

            Instance = new DataStore();
        }


        public int EnterpriseCount => _urhajok
            .Count(x => x.UrhajoNev.ToLower().Contains("Enterprise".ToLower()));

        public string HajoOsztalySzerepCount(string szerepNev)
        {
            HajoSzerepek? hajoSzerep = _hajoSzerepek
                .FirstOrDefault(x => x.SzerepNev == szerepNev);

            if (hajoSzerep == null)
            {
                return "Ilyen szerep nincs az adatbázisban.";
            }

            int count = _hajoOsztalyok.Count(x => x.SzerepId == hajoSzerep.SzerepId);
            return $"{count} hajóosztály rendeltetése a megadott szerep.";
        }

        public Dictionary<string, int> Top3HajoOsztaly => _urhajok
                .GroupBy(x => x.OsztalyId)
                .Select(g => new
                {
                    OsztalyId = g.Key,
                    Count = g.Count()
                })
                .Join(_hajoOsztalyok,
                    ship => ship.OsztalyId,
                    osztaly => osztaly.OsztalyId,
                    (ship, osztaly) => new { osztaly.OsztalyNev, ship.Count })
                .OrderByDescending(x => x.Count)
                .Take(3)
                .ToDictionary(x => x.OsztalyNev, x => x.Count);
    }
}
