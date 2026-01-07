namespace Viragkoteszet_VB_Lib;

public abstract class Dolgozo
{
    public int Azonosito { get; }
    public string Nev { get; }
    public char Beosztas { get; set; }
    public List<int> AlapanyagAzonositok { get; set; } = new List<int>();
    public FeladatLista FeladatLista { get; set; } = new FeladatLista();
    
    public abstract double Gyakorlottsag { get; }
    public abstract int MunkaraForditottIdo { get; }

    public Dolgozo(int azonosito, string nev)
    {
        Azonosito = azonosito;
        Nev = nev;
    }

    public virtual void UjFeladatHozzaadasa(Termek termek)
    {
        FeladatLista = FeladatLista + termek;
    }

    public override string ToString()
    {
        return $"{Nev} - {MunkaraForditottIdo} perc";
    }
}