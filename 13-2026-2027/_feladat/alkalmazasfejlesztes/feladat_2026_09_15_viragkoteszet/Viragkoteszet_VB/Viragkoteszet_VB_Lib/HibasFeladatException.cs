namespace Viragkoteszet_VB_Lib
{
    internal class HibasFeladatException : Exception
    {
        public HibasFeladatException() : base("A feladathoz nincs elegendő tudása a gyakornoknak.") { }
    }
}
