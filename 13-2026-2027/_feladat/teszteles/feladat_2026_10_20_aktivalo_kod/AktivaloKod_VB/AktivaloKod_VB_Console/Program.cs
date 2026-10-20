using AktivaloKod_VB_Lib;

namespace AktivaloKod_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validator = new CodeValidator();

            string[] samples =
            {
                "KGCW-5321-JUAH",
                "AAAA-BBBB-JCG1",
                "AAAA-BBBB-CCCC",
                "--GGJJCCCC1234",
                "ggjj-cccc-1234",
                "CAJAVALA78G",
                "AA-AA-GC-GG-5J-T0",
                "CAJAVA78G",
                "JACA-UU1G-1MOP1",
                "JACA-UU1G1MOP1",
            };

            foreach (string sample in samples)
            {
                Console.WriteLine($"{sample,-20} -> {(validator.CheckCodeValidity(sample) ? "jó kód" : "rossz kód")}");
            }

            Console.WriteLine();
            Console.Write("Adj meg egy kódot: ");
            string? input = Console.ReadLine();
            Console.WriteLine(validator.CheckCodeValidity(input!) ? "jó kód" : "rossz kód");
        }
    }
}
