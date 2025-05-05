namespace OnlineJatek_VB_Lib
{
    public class Jatek
    {
        //jatek_nev;mufaj;megjelenes_ideje;aktiv_jatekosok
        public string Nev { get; init; }
        public string Mufaj { get; init; }
        public DateOnly MegjelenesIdeje { get; init; }
        public int AktivJatekosok { get; init; }

        public Jatek(string adatSor)
        {
            string[] darabolt = adatSor.Split(';');

            Nev = darabolt[0];
            Mufaj = darabolt[1];
            MegjelenesIdeje = DateOnly.Parse(darabolt[2]);
            AktivJatekosok = int.Parse(darabolt[3]);
        }

        public override string ToString()
        {
            return $"{Mufaj}: ";
        }
    }
}
