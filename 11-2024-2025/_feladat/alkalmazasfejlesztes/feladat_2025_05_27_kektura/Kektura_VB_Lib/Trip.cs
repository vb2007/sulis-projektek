namespace Kektura_VB_Lib
{
    public class Trip
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public double Length { get; set; }
        public int Increments { get; set; }
        public int Decrements { get; set; }
        public bool IsPostmarkPoint { get; set; }

        public Trip(string dataLine)
        {
            string[] splitted = dataLine.Split(';');

            StartPoint = splitted[0];
            EndPoint = splitted[1];
            Length = double.Parse(splitted[2]);
            Increments = int.Parse(splitted[3]);
            Decrements = int.Parse(splitted[4]);
            //inline if, alapból bool-al tér vissza, tehát nem kell true / false értékeket megadni
            IsPostmarkPoint = splitted[5] == "i";
        }

        public bool IncorrectName =>
            IsPostmarkPoint && !EndPoint.ToLower().Contains("pecsetelohely");
    }
}
