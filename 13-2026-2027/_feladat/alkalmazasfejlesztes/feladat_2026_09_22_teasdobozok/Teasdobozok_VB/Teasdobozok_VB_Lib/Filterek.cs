namespace Teasdobozok_VB_Lib
{
    internal class Filterek
    {
        private protected List<Filter> _filterek = new List<Filter>();

        public Filterek(IEnumerable<string> adatSorok)
        {
            foreach (string adatSor in adatSorok)
            {
                string[] adatok = adatSor.Split(";");
                _filterek.Add(new (
                    adatok[0],
                    adatok[1],
                    int.Parse(adatok[2])
                 ));
            }
        }

        public Filter this[string id] =>
            _filterek.FirstOrDefault(x => x.Id == id)!;

        public List<string> GyogynovenyFilterek =>
            _filterek
                .Select(x => x.Tipus)
                .OrderBy(x => x)
                .ToList();
    }
}
