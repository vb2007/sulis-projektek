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
            _fajok = File.ReadAllLines("Input\\fajok.csv").Skip(1)
                .Select(x => new Fajok(x))
                .ToList();

            _hajoOsztalyok = File.ReadAllLines("Input\\hajo_osztalyok.csv").Skip(1)
                .Select(x => new HajoOsztalyok(x))
                .ToList();

            _hajoSzerepek = File.ReadAllLines("Input\\hajo_szerepek.csv").Skip(1)
                .Select(x => new HajoSzerepek(x))
                .ToList();

            _urhajok = File.ReadAllLines("Input\\urhajok.csv").Skip(1)
                .Select(x => new Urhajok(x))
                .ToList();
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


        public int EnterpriseCount =>
            _urhajok.Count(x => x.UrhajoNev.ToLower().Contains("Enterprise".ToLower()));

        public string HajoOsztalySzerepCount(string szerepNev)
        {
            var szerep = _hajoSzerepek.FirstOrDefault(x => x.SzerepNev == szerepNev);

            if (szerep == null)
            {
                return "Ilyen szerep nincs az adatbázisban.";
            }

            int count = _hajoOsztalyok.Count(x => x.SzerepId == szerep.SzerepId);
            return $"{count} hajóosztály rendeltetése a megadott szerep.";
        }
    }
}
