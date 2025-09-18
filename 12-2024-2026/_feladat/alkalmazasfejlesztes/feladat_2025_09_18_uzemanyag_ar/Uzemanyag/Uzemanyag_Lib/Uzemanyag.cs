namespace Uzemanyag_Lib
{
    public class Uzemanyag
    {
        public DateTime Valtozas { get; set; }
        public int BenzinAr { get; set; }
        public int GazolajAr { get; set; }

        public Uzemanyag(string adatSor)
        {
            string[] darabolt = adatSor.Split(';');

            Valtozas = DateTime.Parse(darabolt[0]);
            BenzinAr = int.Parse(darabolt[1]);
            GazolajAr = int.Parse(darabolt[2]);
        }
    }
}
