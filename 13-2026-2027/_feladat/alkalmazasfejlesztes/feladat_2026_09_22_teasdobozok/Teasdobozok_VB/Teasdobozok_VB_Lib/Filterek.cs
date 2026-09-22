namespace Teasdobozok_VB_Lib
{
    public class Filterek
    {
        private readonly List<Filter> _filterek = new();

        public Filterek(IEnumerable<string> adatSorok)
        {
            foreach (string adatSor in adatSorok)
            {
                if (string.IsNullOrWhiteSpace(adatSor) || adatSor.StartsWith("ID;"))
                {
                    continue;
                }

                string[] adatok = adatSor.Split(';');
                _filterek.Add(new Filter(
                    adatok[0],
                    adatok[1],
                    int.Parse(adatok[2])));
            }
        }

        public Filter this[string id]
        {
            get
            {
                Filter? filter = _filterek.FirstOrDefault(x => x.Id == id);
                if (filter is null)
                {
                    throw new HibasAzonositoException();
                }

                return filter;
            }
        }

        public List<string> GyogynovenyFilterek()
        {
            return _filterek
                .Where(x => x.Gyogytea)
                .Select(x => x.Tipus)
                .OrderBy(x => x)
                .ToList();
        }
    }
}
