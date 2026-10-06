using System.Text;
using UtazasiCsomagok_VB_Lib;

namespace UtazasiCsomagok_VB_Console;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Programok programok = new(File.ReadLines("programok.txt").Skip(1).Select(UtazasiProgramLetrehozas));

        Console.WriteLine("Elérhető belföldi programok:");
        foreach (UtazasiProgram program in programok.BelfoldiProgramok())
        {
            Console.WriteLine(program);
        }

        List<ProgramElem> programElemek = new();
        List<string> hibak = new();
        foreach (string utazasAzonositok in File.ReadLines("utazasok.txt").Where(x => !string.IsNullOrWhiteSpace(x)))
        {
            try
            {
                programElemek.Add(UtazasFactory.Factory(utazasAzonositok, programok));
            }
            catch (HibasProgramException ex)
            {
                hibak.Add($"HIBA: {ex.Message} ({utazasAzonositok})");
            }
        }
        File.WriteAllLines("hibalista.txt", hibak);

        Console.WriteLine("Elkészített objektumok:");
        foreach (ProgramElem programElem in programElemek)
        {
            Console.WriteLine(programElem);
        }

        Console.WriteLine($"Hibák száma: {hibak.Count}");
    }

    private static UtazasiProgram UtazasiProgramLetrehozas(string programSor)
    {
        string[] adatTomb = programSor.Split(';');

        string azonosito = adatTomb[0];
        string megnevezes = adatTomb[1];
        string helyszin = adatTomb[2];
        int ar = int.Parse(adatTomb[3]);

        return new UtazasiProgram(azonosito, megnevezes, helyszin, ar);
    }
}
