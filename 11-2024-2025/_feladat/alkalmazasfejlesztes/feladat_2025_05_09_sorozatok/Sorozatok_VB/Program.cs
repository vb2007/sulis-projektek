using Sorozatok_VB_Lib;

namespace Sorozatok_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sorozatok sorozatok = new Sorozatok(File.ReadAllLines("sorozatok.txt"));
        }
    }
}
