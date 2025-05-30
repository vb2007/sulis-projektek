namespace FifaVilagranglista_VB_Lib
{
    public class Team
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int Difference { get; set; }
        public int Points { get; set; }

        public Team(string dataLine)
        {
            string[] splitted = dataLine.Split(';');

            Name = splitted[0];
            Rank = int.Parse(splitted[1]);
            Difference = int.Parse(splitted[2]);
            Points = int.Parse(splitted[3]);
        }
    }
}
