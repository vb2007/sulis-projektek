namespace MikulasCukraszdaja_VB_Lib
{
    public class Sutemenyek
    {
        private readonly List<Sutemeny> _sutemenyek;

        public IEnumerable<Sutemeny> Osszes => _sutemenyek;

        public Sutemenyek(IEnumerable<Sutemeny> sutemenyek)
        {
            _sutemenyek = sutemenyek.ToList();
        }
    }
}
