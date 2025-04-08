namespace Hegyek_Lib
{
    public class Hegy
    {
        //Hegycsúcs neve;Hegység;Magasság
        public string Hegycsucs { get; init; }
        public string Hegyseg { get; init; }
        public int Magassag { get; init; }

        public Hegy(string adatSor)
        {
            string[] darabolt = adatSor.Split(';');

            Hegycsucs = darabolt[0];
            Hegyseg = darabolt[1];
            Magassag = int.Parse(darabolt[2]);
        }

        public double LabraValtas => Magassag * 3.280839895;
        public override string ToString()
        {
            return $"{Magassag} m - {Hegycsucs}: {Hegycsucs}";
        }
    }
}
