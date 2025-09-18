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

        //3. Feladat
        public int ValtozasokSzama => uzemanyagArak.Count;
        //4. Feladat
        public int LegkisebbArKulonbseg => uzemanyagArak.Min(x => x.ArKulonbseg);
        //5. Feladat
        public int LegkisebbArKulonbsegElofordulas => uzemanyagArak.Count(x => x.ArKulonbseg == LegkisebbArKulonbseg);
        //6. Feladat
        
    }
}
