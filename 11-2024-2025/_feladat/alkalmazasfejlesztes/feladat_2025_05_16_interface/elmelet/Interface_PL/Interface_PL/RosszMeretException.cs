namespace Interface_PL
{
    internal class RosszMeretException : Exception
    {
        public RosszMeretException(string mezo = null) 
            : base($"A megadott {mezo} nem pozitív")
        {
            
        }
    }
}
