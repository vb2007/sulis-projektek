namespace Viragkoteszet_VB_Lib;

public interface ITermek
{
    string Tipus { get; }
    string Megnevezes { get; }
    int ElkeszitesiIdo { get; } // percben
    int Ar { get; }
}