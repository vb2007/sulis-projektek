using Teasdobozok_VB_Lib;

namespace Teasdobozok_VB_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string alapKonyvtar = AppContext.BaseDirectory;
            string filterekFajl = Path.Combine(alapKonyvtar, "filterek.txt");
            string dobozokFajl = Path.Combine(alapKonyvtar, "dobozok.txt");
            string hibalistaFajl = Path.Combine(alapKonyvtar, "hibalista.txt");

            Filterek filterek = new(File.ReadAllLines(filterekFajl));

            Console.WriteLine("Elérhető gyógynövény filterek:");
            foreach (string filterTipus in filterek.GyogynovenyFilterek())
            {
                foreach (int filterAr in filterek)
                {
                    Console.WriteLine($"{filterTipus} ({filterTipus.Ar} Ft)");
                }
            }

            Console.WriteLine();

            List<TeasDoboz> dobozok = new();
            List<string> hibak = new();

            foreach (string adatSor in File.ReadLines(dobozokFajl).Skip(1))
            {
                try
                {
                    TeasDoboz? doboz = DobozFactory.Factory(adatSor, filterek);
                    if (doboz is not null)
                    {
                        dobozok.Add(doboz);
                    }
                }
                catch (HibasAzonositoException ex)
                {
                    hibak.Add($"{adatSor} -> {ex.Message}");
                }
            }

            File.WriteAllLines(hibalistaFajl, hibak);

            Console.WriteLine("Elkészített teásdobozok:");
            foreach (TeasDoboz doboz in dobozok)
            {
                Console.WriteLine(doboz);
            }
        }
    }
}
