namespace Hegyek_VB_Lib
{
    public class Hegy
    {
        public string Hegycsucs { get; set; }
        public string Hegyseg { get; set; }
        public int Magassag { get; set; }

        public Hegy(string adatSor)
        {
            string[] darabolt = adatSor.Split(';');

            Hegycsucs = darabolt[0];
            Hegyseg = darabolt[1];
            Magassag = int.Parse(darabolt[2]);
        }

        public double LabraValtas => Magassag * 3.280839895;

        public string LegalacsonyabbHegyFormatum => $"{Hegycsucs} ({Hegyseg}), {Magassag} m";
        public string FajlbairasFormatum => $"{Magassag} m - {Hegyseg}: {Hegycsucs}";
    }
}
