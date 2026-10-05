namespace Viragkoteszet_VB_Lib
{
    public class Viragkoto : Dolgozo
    {
        public override double Gyakorlottsag => 100;

        public override int MunkaraForditottIdo =>
            FeladatLista.Feladatok.Sum(x => x.ElkeszitesiIdo);

        public Viragkoto(int id, string nev) : base(id, nev) { }
    }
}
