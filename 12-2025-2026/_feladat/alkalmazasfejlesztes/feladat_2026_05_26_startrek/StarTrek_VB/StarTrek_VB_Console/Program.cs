using StartTrek_VB_Lib;

namespace StarTrek_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStore.InitCsv();

            Console.WriteLine($"4. feladat: {DataStore.Instance!.EnterpriseCount} db űrhajó nevében szerepel az Enterprise név.");
        }
    }
}
