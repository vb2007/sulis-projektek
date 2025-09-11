namespace Hegyek_VB_Lib
{
    public class Hegyek
    {
        public readonly List<Hegy> hegyek = new List<Hegy>();

        public Hegyek(IEnumerable<string> adatSorok)
        {
            foreach (var sor in adatSorok)
            {
                hegyek.Add(new Hegy(sor));
            }
        }

        public int HegyekSzama => hegyek.Count;
    }
}
