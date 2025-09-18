namespace Uzemanyag_Lib
{
    public class Uzemanyagok
    {
        private readonly List<Uzemanyag> uzemanyagArak = new List<Uzemanyag>();

        public Uzemanyagok(IEnumerable<string> sorok)
        {
            foreach (string sor in sorok)
            {
                uzemanyagArak.Add(new Uzemanyag(sor));
            }
        }

        public int ValtozasokSzama => uzemanyagArak.Count;
        public int LegkisebbArKulonbseg => uzemanyagArak.Min(x => x.ArKulonbseg);
        public int LegkisebbArKulonbsegElofordulas => uzemanyagArak.Count(x => x.ArKulonbseg == LegkisebbArKulonbseg);
    }
}
