namespace Forma1_VB;
using Forma1_VB_Lib;

class Program
{
    static void Main(string[] args)
    {
        Races races = new Races(File.ReadAllLines("eredmenyek.csv").Skip(1));
    }
}