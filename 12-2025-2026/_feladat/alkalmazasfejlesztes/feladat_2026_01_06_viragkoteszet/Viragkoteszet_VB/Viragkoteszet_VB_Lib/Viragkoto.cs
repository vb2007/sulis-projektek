namespace Viragkoteszet_VB_Lib;

public class Viragkoto : Dolgozo
{
    public override double Gyakorlottsag => 100;
    
    public override int MunkaraForditottIdo 
    { 
        get 
        {
            int ossz = 0;
            foreach (var feladat in FeladatLista.Feladatok)
            {
                ossz += feladat.ElkeszitesiIdo;
            }
            return ossz;
        }
    }
    
    public Viragkoto(int azonosito, string nev) : base(azonosito, nev)
    {
    }
}