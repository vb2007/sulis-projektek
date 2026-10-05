using System.Collections;

namespace Viragkoteszet_VB_Lib
{
    public class Dolgozok : IEnumerable<Dolgozo>
    {
        private readonly List<Dolgozo> _dolgozok = new();

        public int Darabszam => _dolgozok.Count;

        public Dolgozo this[int id] =>
            _dolgozok.FirstOrDefault(x => x.Id == id)
            ?? throw new KeyNotFoundException($"Nincs ilyen dolgozó: {id}");

        public void Hozzaad(Dolgozo dolgozo)
        {
            _dolgozok.Add(dolgozo);
        }

        public IEnumerator<Dolgozo> GetEnumerator() => _dolgozok.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
