using Mesterek_VB_Lib;

namespace Mesterek_VB;

class Program
{
    static void Main(string[] args)
    {
        List<MesterEmber> mesterek = new List<MesterEmber>();
        IEnumerable<string> adatSorok = File.ReadAllLines("input.txt");

        foreach (string adatSor in adatSorok)
        {
            MesterEmber mesterEmber = MesterFactory.Factory(adatSor);
        }
    }
}