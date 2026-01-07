namespace Viragkoteszet_VB_Lib;

public class FeladatLista
{
    public List<Termek> Feladatok { get; } = new List<Termek>();
    
    public FeladatLista()
    {
    }

    public static FeladatLista operator +(FeladatLista lista, Termek termek)
    {
        FeladatLista ujLista = new FeladatLista();
        foreach (var f in lista.Feladatok)
        {
            ujLista.Feladatok.Add(f);
        }
        ujLista.Feladatok.Add(termek);
        return ujLista;
    }
}