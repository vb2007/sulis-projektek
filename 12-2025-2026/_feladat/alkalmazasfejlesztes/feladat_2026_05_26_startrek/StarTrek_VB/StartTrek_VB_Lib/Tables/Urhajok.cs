namespace StartTrek_VB_Lib.Tables
{
    internal class Urhajok
    {
        public int UrhajoId { get; set; }
        public string Azonosito { get; set; }
        public string UrhajoNev { get; set; }
        public int OsztalyId { get; set; }
        public int FajId { get; set; }

        internal Urhajok(string dataLines)
        {
            string[] split = dataLines.Split(';');

            UrhajoId = int.Parse(split[0]);
            Azonosito = split[1];
            UrhajoNev = split[2];
            OsztalyId = int.Parse(split[3]);
            FajId = int.Parse(split[4]);
        }
    }
}
