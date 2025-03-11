namespace Termekek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Termek termek = new Termek("alma", 300);
            Console.WriteLine(termek.Informacio());
        }
    }
}
