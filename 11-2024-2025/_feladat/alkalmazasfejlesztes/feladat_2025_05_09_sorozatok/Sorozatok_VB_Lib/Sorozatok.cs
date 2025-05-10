namespace Sorozatok_VB_Lib
{
    public class Sorozatok
    {
        private readonly List<Sorozat> sorozatok = new();

        public Sorozatok(IEnumerable<string> adatSorok)
        {
            foreach (var item in adatSorok)
            {
                sorozatok.Add(new(item));
            }
        }

        public int SorozatokSzama => sorozatok.Count;
    }
}
