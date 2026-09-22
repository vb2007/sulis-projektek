namespace Teasdobozok_VB_Lib
{
    internal class HibasAzonositoException : Exception
    {
        public HibasAzonositoException() : base("A megadott filter azonosító nem létezik.") { }
    }
}
