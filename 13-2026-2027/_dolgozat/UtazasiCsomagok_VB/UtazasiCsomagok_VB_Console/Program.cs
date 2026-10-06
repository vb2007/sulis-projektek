using UtazasiCsomagok_VB_Lib;

namespace UtazasiCsomagok_VB_Console;

internal class Program
{
    static void Main(string[] args)
    {
        Programok programok = new(File.ReadLines("programok.txt").Skip(1));

        Console.WriteLine("Elérhető belföldi programok:");
        IEnumerable<UtazasiProgram> belfoldiProgramok = programok.BelfoldiProgramok;
        foreach (UtazasiProgram program in belfoldiProgramok)
        {
            Console.WriteLine(program.ToString());
        }
    }
}
