namespace Teasdobozok_VB_Lib
{
    public abstract class TeasDoboz : IDoboz
    {
        public int DarabSzam { get; }

        public abstract string Nev { get; }

        public abstract int Ar { get; }

        protected TeasDoboz(int darabSzam)
        {
            DarabSzam = darabSzam;
        }

        public override string ToString()
        {
            return $"{Nev} ({Ar} Ft)";
        }
    }
}
