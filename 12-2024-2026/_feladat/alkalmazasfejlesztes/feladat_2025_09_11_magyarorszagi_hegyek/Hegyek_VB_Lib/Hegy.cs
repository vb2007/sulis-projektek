namespace Hegyek_VB_Lib
{
    public class Hegy
    {
        public string HegycsucsNeve { get; set; }
        public string Hegyseg { get; set; }
        public int Magassag { get; set; }

        public Hegy(string adatSor)
        {
            string[] darabolt = adatSor.Split(';');

            HegycsucsNeve = darabolt[0];
            Hegyseg = darabolt[1];
            Magassag = int.Parse(darabolt[2]);
        }
    }
}
