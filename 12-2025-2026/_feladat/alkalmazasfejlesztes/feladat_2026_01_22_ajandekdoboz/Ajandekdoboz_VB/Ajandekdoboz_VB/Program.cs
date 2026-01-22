using Ajandekdoboz_VB_Lib;

namespace Ajandekdoboz_VB;

class Program
{
    static void Main(string[] args)
    {
        AjandekDoboz<Kozmetikum> kozmetikaiDoboz = new AjandekDoboz<Kozmetikum>();
        kozmetikaiDoboz.Add(new Kozmetikum("Krém", 1990, "DM Sajátmárka"));
        kozmetikaiDoboz.Add(new Kozmetikum("Szempillaspirál", 2990, "Kyx"));
        kozmetikaiDoboz.Add(new Kozmetikum("Parfüm", 9990, "Adidas"));
        kozmetikaiDoboz.Add(new Kozmetikum("Testápoló", 2490, "Nivea"));

        AjandekDoboz<Husaru> husaruDoboz = new AjandekDoboz<Husaru>();
        husaruDoboz.Add(new Husaru("Füstölt sonka", 4990, true));
        husaruDoboz.Add(new Husaru("Szalámi", 3990, false));
        husaruDoboz.Add(new Husaru("Kolbász", 2990, true));
        husaruDoboz.Add(new Husaru("Párizsi", 1990, false));
        
        AjandekDoboz<Iroszer> irszerDoboz = new AjandekDoboz<Iroszer>(new List<Iroszer>
        {
            new ("Toll", 290, "Kék"),
            new ("Ceruza", 150, "Grafit"),
            new ("Filctoll", 350, "Piros"),
            new ("Jelölő", 450, "Sárga")
        });
        
        //Sytem.Threading-ben is van egy monitor class, ezért teljes névvel kell hivatkozni
        AjandekDoboz<Ajandekdoboz_VB_Lib.Monitor> monitorDoboz = new AjandekDoboz<Ajandekdoboz_VB_Lib.Monitor>();
        monitorDoboz.Add(new Ajandekdoboz_VB_Lib.Monitor("Samsung Odyssey", 299990, 144));
        monitorDoboz.Add(new Ajandekdoboz_VB_Lib.Monitor("LG UltraGear", 249990, 120));
        monitorDoboz.Add(new Ajandekdoboz_VB_Lib.Monitor("Acer Predator", 199990, 165));
        monitorDoboz.Add(new Ajandekdoboz_VB_Lib.Monitor("Asus ROG Swift", 349990, 240));
        
        AjandekDoboz<Switch> switchDoboz = new AjandekDoboz<Switch>(new List<Switch>
        {
            new ("Netgear GS308", 9990, 8),
            new ("TP-Link TL-SG105", 7990, 5),
            new ("D-Link DGS-1005A", 6990, 5),
            new ("Cisco SG110D-08", 12990, 8)
        });

        Console.WriteLine("Kozmetikai doboz információi:");
        Console.WriteLine(kozmetikaiDoboz);

        Console.WriteLine($"\nHúsárú doboz 2. eleme: {husaruDoboz[1]}");

        Console.WriteLine($"\nÍrószer doboz elemei:");
        for (int i = 0; i < irszerDoboz.Meret; i++)
        {
            Console.WriteLine($"{i + 1}. - {irszerDoboz[i]}");
        }
        
        Console.WriteLine($"\nMonitor doboz összértéke: {monitorDoboz.OsszErtek} Ft");
        
        Console.WriteLine("\nSwitch doboz elemei a 3. elem törlése előtt:");
        for (int i = 0; i < switchDoboz.Meret; i++)
        {
            Console.WriteLine($"{i + 1}. - {switchDoboz[i]}");
        }
        
        Console.WriteLine("\nSwitch doboz elemei a 3. elem törlése után:");
        switchDoboz.RemoveAt(2);
        for (int i = 0; i < switchDoboz.Meret; i++)
        {
            Console.WriteLine($"{i + 1}. - {switchDoboz[i]}");
        }
    }
}