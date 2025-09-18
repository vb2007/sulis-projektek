namespace Szalag_VB_Lib
{
    public class Szallitas
    {
        public int Sorszam { get; }
        public int IndulasiIdo { get; }
        public int IndulasiHely { get; }
        public int CelHely { get; }
        public int Tomeg { get; }
        private readonly int _szalagHossz;
        private readonly int _idoegyseg;
        
        public Szallitas(string adatSor, int sorszam, int szalagHossz, int idoegyseg)
        {
            string[] darabolt = adatSor.Split(' ');
            
            IndulasiIdo = int.Parse(darabolt[0]);
            IndulasiHely = int.Parse(darabolt[1]);
            CelHely = int.Parse(darabolt[2]);
            Tomeg = int.Parse(darabolt[3]);
            
            Sorszam = sorszam;
            _szalagHossz = szalagHossz;
            _idoegyseg = idoegyseg;
        }

        public int Tavolsag => CelHely > IndulasiHely
            ? CelHely - IndulasiHely
            : (_szalagHossz - IndulasiHely) + CelHely;
        
        public int ErkezesiIdo => IndulasiIdo + Tavolsag * _idoegyseg;

        public string KiirasiFormatum => $"Honnan: {IndulasiHely} Hova: {CelHely}";
    }
}