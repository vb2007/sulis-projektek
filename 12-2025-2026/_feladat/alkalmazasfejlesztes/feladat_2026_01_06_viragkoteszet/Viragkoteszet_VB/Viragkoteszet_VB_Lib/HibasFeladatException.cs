namespace Viragkoteszet_VB_Lib;

public class HibasFeladatException : Exception
{
    public HibasFeladatException() : base("A feladathoz nincs elegendő tudása a gyakornoknak.") { }
}