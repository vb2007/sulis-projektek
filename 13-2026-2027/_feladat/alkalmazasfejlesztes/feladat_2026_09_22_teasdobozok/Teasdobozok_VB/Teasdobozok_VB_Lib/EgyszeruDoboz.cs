namespace Teasdobozok_VB_Lib
{
    internal sealed class EgyszeruDoboz : TeasDoboz
    {
        internal Filter Filter { get; init; }
        internal int DarabSzam { get; set; }
        internal int Ar =>
            Filter.Ar * DarabSzam + 100;
        internal string Nev =>
            $"{Filter.Tipus} tea";

        public EgyszeruDoboz(int darabSzam, string filterId, Filterek filterek) : base(darabSzam)
        {
            DarabSzam = darabSzam;
            Filter = filterek[filterId];
        }
    }
}
