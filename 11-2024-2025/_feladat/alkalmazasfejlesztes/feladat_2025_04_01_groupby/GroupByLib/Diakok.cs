namespace GroupByLib
{
    public class Diakok
    {
        readonly List<Diak> diakok = new();
        public Diakok(IEnumerable<string> adatSorok)
        {
            foreach (var item in adatSorok)
            {
                string[] darabolt = item.Split(';');
                diakok.Add(new Diak(darabolt[0], darabolt[1], darabolt[2], int.Parse(darabolt[3])));
            }
        }

        public IEnumerable<Diak> Lista => diakok;
        public Dictionary<string, int> OsztalyLetszam =>
            diakok.GroupBy(x => x.Osztaly).ToDictionary(x => x.Key, x => x.Count());
        //public Dictionary<string, int> Osztalyszint =>
            //diakok.GroupBy(x => new()).ToDictionary(x => x.Key, x => x.Atlag());
    }
}
