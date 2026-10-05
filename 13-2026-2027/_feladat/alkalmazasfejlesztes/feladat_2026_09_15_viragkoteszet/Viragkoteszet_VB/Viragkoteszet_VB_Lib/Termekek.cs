namespace Viragkoteszet_VB_Lib
{
    internal class Termekek
    {
        private readonly List<Termek> _termekek = new();

        public Termek? this[int id] =>
            _termekek.FirstOrDefault(x => x.Id == id);
        
        public override string ToString()
        {
            return $"";
        }
    }
}
