namespace Lift_VB;

using Lift_VB_Lib;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] sorok = File.ReadAllLines("input.txt");

            //első sor: liftek száma
            int liftekSzama = int.Parse(sorok[0]);

            List<Lift> liftLista = new List<Lift>();
            for (int i = 1; i <= liftekSzama; i++)
            {
                try
                {
                    int emeletekSzama = int.Parse(sorok[i]);
                    liftLista.Add(new Lift(emeletekSzama));
                }
                catch (FormatException)
                {
                    //ha nem konvertálható, 10
                    liftLista.Add(new Lift(10));
                }
            }

            Liftek liftek = new Liftek(liftLista);

            for (int i = liftekSzama + 1; i < sorok.Length; i++)
            {
                string sor = sorok[i].Trim();

                try
                {
                    string[] reszek = sor.Split(';');
                    int liftSorszam = int.Parse(reszek[0]);
                    string irany = reszek[1].Trim().ToLower();

                    Lift lift = liftek[liftSorszam];

                    if (irany == "fel")
                    {
                        lift.Felfele();
                        Console.WriteLine(lift);
                    }
                    else if (irany == "le")
                    {
                        lift.Lefele();
                        Console.WriteLine(lift);
                    }
                }
                catch (HibasIranyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex.Message == "A lift elromlott")
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hibás sor");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Index hiba: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt: {ex.Message}");
        }
    }
}
