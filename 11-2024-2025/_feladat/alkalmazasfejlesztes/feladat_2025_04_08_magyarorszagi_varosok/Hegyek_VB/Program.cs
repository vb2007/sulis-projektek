using Hegyek_Lib;

namespace Hegyek_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hegyek hegyek = new(File.ReadLines("hegyekMo.txt").Skip(1));

            Console.WriteLine($"2. feladat: {hegyek} db hegy adatai találhatók a fájlban.");

            Hegy legalacsonyabb = hegyek.Legalacsonyabb;
            Console.WriteLine($"3. feladat: A legalacsonyabb hegy: {legalacsonyabb.Hegycsucs} ({legalacsonyabb.Hegyseg}), {legalacsonyabb.Magassag} m");

            Console.WriteLine($"4. feladat: A hegycsúcsok átlagos magassága: {hegyek.AtlagMagassag} m");

            Console.WriteLine($"5. feladat: A Mátrában {hegyek.HegysegbenHegycsucs("Mátra")} db hegycsúcs található.");

            Console.WriteLine($"8. feladat: A 3000 lábnál magasabb hegyek száma: {hegyek.ErteknelMagasabbakSzama(3000)} db");

            Fajlbairas(3);

            void Fajlbairas(int darabszam)
            {
                List<string> kigyujtott = new List<string>();

                foreach (var item in hegyek.SorbaRendezett.Take(darabszam))
                {
                    kigyujtott.Add(item.ToString());
                }

                File.WriteAllLines("haromlegmagasabb.txt", kigyujtott);
            }
        }
    }
}
