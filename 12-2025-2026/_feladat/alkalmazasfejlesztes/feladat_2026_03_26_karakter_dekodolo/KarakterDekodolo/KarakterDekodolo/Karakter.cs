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

        public bool Felismer(Karakter felismerendo)
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                if (Matrix[i] != felismerendo.Matrix[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
