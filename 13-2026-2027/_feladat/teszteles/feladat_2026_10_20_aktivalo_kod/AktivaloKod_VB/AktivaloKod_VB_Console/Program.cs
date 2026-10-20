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
                PrintResult(sample);
            }

            Console.WriteLine();
            Console.Write("Adj meg egy kódot: ");
            string? input = Console.ReadLine();
            PrintResult(input!);
        }

        private static void PrintResult(string code)
        {
            bool valid = CodeValidator.CheckCodeValidityWithErrorHandling(code, out List<string> errors);

            Console.WriteLine($"\"{code}\": {(valid ? "jó kód" : "rossz kód")}");

            foreach (string error in errors)
            {
                Console.WriteLine($"\t- {error}");
            }
        }
    }
}
