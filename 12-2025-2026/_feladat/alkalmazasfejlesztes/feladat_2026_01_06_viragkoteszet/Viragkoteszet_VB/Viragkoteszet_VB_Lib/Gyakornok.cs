namespace Viragkoteszet_VB_Lib;

public class Gyakornok : Dolgozo
{
    public int Gyakorlottsag { get; } = Random.Shared.Next(70, 91);
    
    public Gyakornok(int azonosito, string nev) : base(azonosito, nev)
    {
    }

    public void UjFeladatHozzaadasa()
    {
        
    }

    public override string ToString()
    {
        return base.ToString();
    }
}