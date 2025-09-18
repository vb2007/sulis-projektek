namespace Uzemanyag_Lib
{
    public class Uzemanyagok
    {
        private readonly List<Uzemanyag> uzemanyagArak = new List<Uzemanyag>();

        public Uzemanyagok(IEnumerable<string> sorok)
        {
            foreach (var sor in sorok)
            {
                uzemanyagArak.Add(new Uzemanyag(sor));
            }
        }

        public int ValtozasokSzama => uzemanyagArak.Count;
    }
}
