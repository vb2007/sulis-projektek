using VB2018_VB_Lib;

namespace VB2018_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stadions stadions = new(File.ReadLines("vb2018.txt").Skip(1));
        }
    }
}
