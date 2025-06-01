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
            string[] split = dataLine.Split(';');

            StartPoint = split[0];
            EndPoint = split[1];
            Length = double.Parse(split[2]);
            Increments = int.Parse(split[3]);
            Decrements = int.Parse(split[4]);
            //inline if, alapból bool-al tér vissza, tehát nem kell true / false értékeket megadni
            IsPostmarkPoint = split[5] == "i";
        }

        public bool IncorrectName =>
            IsPostmarkPoint && !EndPoint.ToLower().Contains("pecsetelohely");
    }
}
