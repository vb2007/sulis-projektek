namespace OrszagokVB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Orszagok> orszagok = new();

            foreach (var item in File.ReadAllLines("orszagok.csv").Skip(1))
            {
                string[] darabolt = item.Split(';');
                orszagok.Add(new Orszagok(
                    darabolt[0],
                    int.Parse(darabolt[1]),
                    int.Parse(darabolt[2]),
                    darabolt[3],
                    int.Parse(darabolt[4])));
            }

            Console.WriteLine("7. Feladat");
            foreach (var item in orszagok)
            {
                Console.WriteLine(item.Info() + "\n");
            }

            Console.WriteLine("8. Feladat");
            Console.WriteLine($"{orszagok.Count} ország adatait tároltuk");

            Console.WriteLine("9. Feladat");
            Console.WriteLine($"Összterület:  {orszagok.Sum(x => x.Terulet)}\nÖsszlakosság: {orszagok.Sum(x => x.Lakossag)}");

            Console.WriteLine("10. Feladat");
            Console.WriteLine($"Legnagyobb {orszagok.MaxBy(x => x.Terulet).Orszag}");

            Console.WriteLine("13. Feladat");
            Console.WriteLine($"\"A\" betűvel kezdődik: {orszagok.Count(x => x.Orszag.StartsWith('A'))}");

            Console.WriteLine("");
            Console.WriteLine("Adja meg egy főváros nevét: ");
            string beolvasottFovaros = Console.ReadLine()!;

            if (orszagok.Exists(x => x.Fovaros == beolvasottFovaros))
            {
                Console.WriteLine(orszagok.Find(x => x.Fovaros == beolvasottFovaros).Info());
            }
            else
            {
                Console.WriteLine("Nincs ilyen főváros");
            }

            Console.WriteLine("Mekkora területnél kisebbek: ");
            int beolvasottTerulet = int.Parse(Console.ReadLine()!);

            foreach (var item in orszagok.Where(x => x.Terulet < beolvasottTerulet))
            {
                Console.WriteLine(item.Orszag);
            }

            int magyarorszagTerulete = 93000;
            List<Orszagok> kissebbMONal = orszagok.Where(x => x.Terulet < magyarorszagTerulete).ToList();

            StreamWriter sw = new StreamWriter("kisebbMO.txt");
            foreach (var item in kissebbMONal)
            {
                sw.WriteLine(item.Info() + "\n");
            }
            sw.Close();
        }
    }
}
