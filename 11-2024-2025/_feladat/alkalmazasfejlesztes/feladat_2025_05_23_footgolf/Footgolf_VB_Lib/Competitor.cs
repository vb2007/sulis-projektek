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
            string[] split = dataLine.Split(';');

            Name = split[0];
            Category = split[1];
            Team = split[2];
            Points = new int[8];

            for (int i = 0; i < 8; i++)
            {
                Points[i] = int.Parse(split[i + 3]);
            }
        }

        public int TotalScore
        {
            get
            {
                var sorted = Points.OrderBy(p => p).ToArray();
                int[] dropped = { sorted[0], sorted[1] };
                int sum = sorted.Skip(2).Sum();

                //ha a kieső pontok bármelyike nem nulla, +10 pont jár érte
                foreach (var d in dropped)
                {
                    if (d != 0)
                        sum += 10;
                }

                return sum;
            }
        }
    }
}
