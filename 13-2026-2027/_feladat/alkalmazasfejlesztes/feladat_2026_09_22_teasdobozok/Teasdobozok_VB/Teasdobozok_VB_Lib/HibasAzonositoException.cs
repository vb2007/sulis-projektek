namespace Teasdobozok_VB_Lib
{
    public class HibasAzonositoException : Exception
    {
        public HibasAzonositoException() : base("A megadott filter azonosító nem létezik.") { }
    }
}
