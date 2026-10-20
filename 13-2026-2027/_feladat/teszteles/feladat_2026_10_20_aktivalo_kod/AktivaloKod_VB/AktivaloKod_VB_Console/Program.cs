using AktivaloKod_VB_Lib;
using AktivaloKod_VB_Lib.Data;

namespace AktivaloKod_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (string sample in SampleCodes.sampleCodeList)
            {
                Console.WriteLine($"{sample,-20} -> {(CodeValidator.CheckCodeValidity(sample) ? "jó kód" : "rossz kód")}");
            }

            Console.WriteLine();
            Console.Write("Adj meg egy kódot: ");
            string? input = Console.ReadLine();
            Console.WriteLine(CodeValidator.CheckCodeValidity(input!) ? "jó kód" : "rossz kód");
        }
    }
}
