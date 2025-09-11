using Hegyek_VB_Lib;

namespace Hegyek_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hegyek hegyek = new Hegyek(File.ReadAllLines("hegyekMo.txt").Skip(1));

            //2. Feladat
            Console.WriteLine($"2. Feladat: {hegyek.HegyekSzama} db hegy adatai találhatók a fájlban.");

            //3. Feladat
            Console.WriteLine($"3. Feladat: A legalacsonyabb hegy adatai: {hegyek.LegalacsonyabbHegy.LegalacsonyabbHegyFormatum}");

            //4. Feladat
            Console.WriteLine($"4. Feladat: Átlagosan {hegyek.AtlagMagassag} m magasak a hegyek.");

            //5. Feladat
            Console.WriteLine($"5. Feladat: {hegyek.HegycsucsokSzamaHegysegAlapjan("Mátra")} db hegycsúc található a Mátrában.");

            //6. Feladat
            Console.WriteLine($"6. Feladat: {hegyek.HegycsucsokSzamaNevAlapjan("bérc")} db hegycsúcs nevében szerepel a \"bérc\" szó.");

            //7. Feladat
            Console.WriteLine($"7. Feladat: Az alábbi hegységekben találhatók a hegycsúcsok: {hegyek.HegysegekNeveiString}");

            //8. Feladat
            Console.WriteLine($"8. Feladat: {hegyek.HegyekSzamaMagasabbMint(3000)} db hegy magasabb 3000 lábnál.");

            //9. Feladat
            Console.WriteLine($"9. Feladat: {hegyek.FajlbaIras(3, "haromlegmag.txt")}");
        }
    }
}
