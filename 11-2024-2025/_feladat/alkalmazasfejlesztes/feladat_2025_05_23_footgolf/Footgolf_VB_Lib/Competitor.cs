namespace Footgolf_VB_Lib
{
    public class Competitor
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Team { get; set; }
        public int[] Points { get; set; }

        public Competitor(string dataLine)
        {
            string[] splitted = dataLine.Split(';');

            Name = splitted[0];
            Category = splitted[1];
            Team = splitted[2];
            for (int i = 0; i < 8; i++)
            {
                Points[i] = int.Parse(splitted[i + 2]);
            }
        }
    }
}
