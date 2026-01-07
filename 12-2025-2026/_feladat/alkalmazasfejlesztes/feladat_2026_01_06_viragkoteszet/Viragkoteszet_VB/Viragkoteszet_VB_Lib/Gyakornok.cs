namespace Viragkoteszet_VB_Lib;

public class Gyakornok : Dolgozo
{
    public override double Gyakorlottsag { get; }
    private List<int> _elkeszithetorTermekAzonositok;
    
    public override int MunkaraForditottIdo 
    { 
        get 
        {
            int ossz = 0;
            double szorzo = (100 - Gyakorlottsag) / 100.0;
            foreach (var feladat in FeladatLista.Feladatok)
            {
                ossz += feladat.ElkeszitesiIdo + (int)(feladat.ElkeszitesiIdo * szorzo);
            }
            return ossz;
        }
    }
    
    public Gyakornok(int azonosito, string nev, IEnumerable<int> termekAzonositok) : base(azonosito, nev)
    {
        _elkeszithetorTermekAzonositok = new List<int>(termekAzonositok);
        // Gyakorlottság véletlenszerűen 70, 80 vagy 90
        int[] lehetsegesErtekek = { 70, 80, 90 };
        Gyakorlottsag = lehetsegesErtekek[Random.Shared.Next(3)];
    }

    public override void UjFeladatHozzaadasa(Termek termek)
    {
        if (!_elkeszithetorTermekAzonositok.Contains(termek.Azonosito))
        {
            throw new HibasFeladatException();
        }
        base.UjFeladatHozzaadasa(termek);
    }

    public override string ToString()
    {
        return $"{Nev} - {MunkaraForditottIdo} perc (gyakornok)";
    }
}