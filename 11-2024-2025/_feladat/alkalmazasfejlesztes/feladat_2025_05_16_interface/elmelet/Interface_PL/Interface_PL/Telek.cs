namespace Interface_PL
{
    internal class Telek : IComparable<Telek>, ITerulet
    {
        static int IdSzamlalo = 0;
        public int ID { get; }

        private double szelesseg;
        public double Szelesseg
        {
            get { return szelesseg; }
            set 
            {
                if (value > 0)
                {
                    szelesseg = value;
                }
                else
                {
                    throw new RosszMeretException($"szélesség ({value})");
                }
            }
        }

        private double hosszusag;
        public double Hosszusag
        {
            get { return hosszusag; }
            set
            {
                if (value > 0)
                {
                    hosszusag = value;
                }
                else
                {
                    throw new RosszMeretException($"hosszúság ({value})");
                }
            }
        }

        public double Terulet => Szelesseg * Hosszusag;

        public int CompareTo(Telek? other)
        {
            if (other == null) return 1;
            return Terulet.CompareTo(other.Terulet);
        }

        public Telek(double szelesseg, double hosszusag)
        {
            IdSzamlalo++;
            ID = IdSzamlalo;
            Szelesseg = szelesseg;
            Hosszusag = hosszusag;
        }

        public override string ToString()
        {
            return $"{ID}: {Szelesseg}*{Hosszusag}={Terulet}";
        }
    }
}
