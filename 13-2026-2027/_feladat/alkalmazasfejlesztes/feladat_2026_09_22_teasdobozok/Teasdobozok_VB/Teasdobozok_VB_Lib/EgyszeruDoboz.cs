namespace Teasdobozok_VB_Lib
{
    public sealed class EgyszeruDoboz : TeasDoboz
    {
        private Filter Filter { get; }

        public override int Ar => Filter.Ar * DarabSzam + 100;

        public override string Nev => $"{Filter.Tipus} tea";

        public EgyszeruDoboz(int darabSzam, string filterId, Filterek filterek)
            : base(darabSzam)
        {
            Filter = filterek[filterId];
        }
    }
}
