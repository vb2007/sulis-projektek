using Teasdobozok_VB_Lib;

namespace Teasdobozok_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Filterek filterek = new Filterek(File.ReadAllLines("dobozok.txt").Skip(1));
        }
    }
}
