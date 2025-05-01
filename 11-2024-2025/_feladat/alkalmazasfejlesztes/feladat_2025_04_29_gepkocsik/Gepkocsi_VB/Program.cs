using Gepkocsi_VB_Lib;

namespace Gepkocsi_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicles vehicles = new(File.ReadAllLines("autok.txt").Skip(1));

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Összesen {vehicles.Count} db gépkocsi adatait olvastam be.");

            Console.WriteLine("5. feladat:");
            Console.WriteLine($"A vidéki autók száma {(vehicles.ruralCount > vehicles.budapestCount ? "több" : "kevesebb")}, mint a Budapesti autóké.");

            Console.WriteLine($"6. feladat:");
            Console.WriteLine($"A budapesti gépkocsik átlagos hengerűrtartalma {vehicles.AverageCylinderCapacity} liter.");
            
            Console.WriteLine("7. feladat:");
            Console.WriteLine($"A(z) {vehicles.ManufacturerWithLeastVehicles} gyártónak van a legkevesebb gépjárműve.");

            Console.WriteLine("8. feladat");
            Console.Write($"Melyik gyártmányú atókat írtjam fájlba? ");
            string manufacturerInput = Console.ReadLine()!;

            void WriteToFile(string filename)
            {
                StreamWriter streamWriter = new(filename);

                foreach (var item in vehicles.VehiclesByManufacturer(manufacturerInput))
                {
                    streamWriter.WriteLine(item.ToString());
                }

                streamWriter.Close();
                Console.WriteLine($"Adatok sikeresen kiírva a(z) {filename} fájlba.");
            }

            WriteToFile("gyartmany.txt");
        }
    }
}
