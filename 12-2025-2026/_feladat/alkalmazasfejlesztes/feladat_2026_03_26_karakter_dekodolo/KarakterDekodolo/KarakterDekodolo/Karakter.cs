namespace KarakterDekodolo
{
    public class Karakter
    {
        public char Betu { get; }
        public string[] Matrix { get; }

        public Karakter(char betu, string[] matrix)
        {
            Betu = betu;
            Matrix = matrix;
        }

        public void Kiir()
        {
            foreach (string sor in Matrix)
            {
                Console.WriteLine(sor);
            }
        }

        
    }
}
