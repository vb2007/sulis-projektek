namespace Viragkoteszet_VB_Lib
{
    internal static class FeladatLista
    {
        public static List<(int dolgozoId, Termek termek)> _feladatLista = new();
        
        // public static FeladatLista operator +(FeladatLista feladatLista, Termek termek)
        // {
        //     return _feladatLista.Add((termek.Id, termek));
        // }
    }
}
