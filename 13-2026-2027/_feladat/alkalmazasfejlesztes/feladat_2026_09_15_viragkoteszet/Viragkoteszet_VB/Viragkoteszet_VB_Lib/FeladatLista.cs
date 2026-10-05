namespace Viragkoteszet_VB_Lib
{
    public class FeladatLista
    {
        private readonly List<Termek> _feladatok;

        public IReadOnlyList<Termek> Feladatok => _feladatok;

        // Kezdetben üres a feladatlista.
        public FeladatLista()
        {
            _feladatok = new List<Termek>();
        }

        private FeladatLista(IEnumerable<Termek> feladatok)
        {
            _feladatok = new List<Termek>(feladatok);
        }

        // Az eredeti listát nem módosítja, hanem egy új, bővített listát ad vissza.
        public static FeladatLista operator +(FeladatLista feladatLista, Termek termek)
        {
            return new FeladatLista(feladatLista._feladatok.Append(termek));
        }
    }
}
