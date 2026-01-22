using Ajandekdoboz_VB_Lib;

namespace Ajandekdoboz_VB;

class Program
{
    static void Main(string[] args)
    {
        AjandekDoboz<Kozmetikum> kozmetikaiDoboz = new AjandekDoboz<Kozmetikum>();

        kozmetikaiDoboz.Add(new Kozmetikum("Krém", 1990, "DM Sajátmárka"));
        kozmetikaiDoboz.Add(new Kozmetikum("Szempillaspirál", 2990, "Kyx"));

        AjandekDoboz<Husaru> husaruDoboz = new AjandekDoboz<Husaru>();
        
        husaruDoboz.Add(new Husaru("Füstölt sonka", 4990, true));
        husaruDoboz.Add(new Husaru("Szalámi", 3990, false));
        
        Console.WriteLine(kozmetikaiDoboz);
        Console.WriteLine(husaruDoboz);
    }
}