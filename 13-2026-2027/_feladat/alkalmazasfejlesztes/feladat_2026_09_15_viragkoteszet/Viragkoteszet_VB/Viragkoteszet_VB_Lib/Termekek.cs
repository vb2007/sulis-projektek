using System.Collections;

namespace Viragkoteszet_VB_Lib
{
    public class Termekek : IEnumerable<Termek>
    {
        private readonly List<Termek> _termekek = new();

        public Termek this[int id] =>
            _termekek.FirstOrDefault(x => x.Id == id)
            ?? throw new KeyNotFoundException($"Nincs ilyen termék: {id}");

        public void Hozzaad(Termek termek)
        {
            _termekek.Add(termek);
        }

        public IEnumerator<Termek> GetEnumerator() => _termekek.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _termekek);
        }
    }
}
