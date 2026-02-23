using OnkiszolgaloKassza_VB_Lib;

namespace OnkiszolgaloKassza_VB_Console;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Önkiszolgáló Kassza ===\n");
        
        bool isRunning = true;
        while (isRunning)
        {
            DisplayMenu();
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    StartSession();
                    break;
                case "2":
                    ScanProduct();
                    break;
                case "3":
                    RemoveProduct();
                    break;
                case "4":
                    ShowTotal();
                    break;
                case "5":
                    ListItems();
                    break;
                case "6":
                    ProcessPayment();
                    break;
                case "7":
                    isRunning = false;
                    Console.WriteLine("\nViszontlátásra!");
                    break;
                default:
                    Console.WriteLine("\nÉrvénytelen választás! Kérem válasszon 1-7 között.");
                    break;
            }
            
            if (isRunning)
            {
                Console.WriteLine("\nNyomjon Enter-t a folytatáshoz...");
                Console.ReadLine();
            }
        }
    }
    
    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Önkiszolgáló Kassza ===");
        Console.WriteLine($"Bevásárlás állapot: {(CashRegister.IsSessionActive() ? "AKTÍV" : "INAKTÍV")}\n");
        Console.WriteLine("1. Új bevásárlás megkezdése");
        Console.WriteLine("2. Termék beolvasása");
        Console.WriteLine("3. Termék törlése (sztornózás)");
        Console.WriteLine("4. Végösszeg megjelenítése");
        Console.WriteLine("5. Tételek listázása");
        Console.WriteLine("6. Fizetés");
        Console.WriteLine("7. Kilépés");
        Console.Write("\nVálasszon egy opciót (1-7): ");
    }
    
    static void StartSession()
    {
        try
        {
            CashRegister.StartNewSession();
            Console.WriteLine("\nÚj bevásárlás sikeresen megkezdve!");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }
    }
    
    static void ScanProduct()
    {
        if (!CashRegister.IsSessionActive())
        {
            Console.WriteLine("\nHiba: Nincs aktív bevásárlás! Először kezdjen új bevásárlást!");
            return;
        }
        
        try
        {
            Console.Write("\nTermék neve: ");
            string? name = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("A termék neve nem lehet üres!");
                return;
            }
            
            Console.Write("Termék ára (Ft): ");
            if (int.TryParse(Console.ReadLine(), out int price) && price > 0)
            {
                CashRegister.ScanItem(name, price);
                Console.WriteLine($"\nTermék hozzáadva: {name} - {price} Ft");
            }
            else
            {
                Console.WriteLine("Érvénytelen ár! Az árnak pozitív egész számnak kell lennie.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }
    }
    
    static void RemoveProduct()
    {
        try
        {
            CashRegister.RemoveItem();
            Console.WriteLine("\nAz utolsó termék sikeresen törölve!");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }
    }
    
    static void ShowTotal()
    {
        try
        {
            int total = CashRegister.FinalSum();
            Console.WriteLine($"\nVégösszeg: {total} Ft");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }
    }
    
    static void ListItems()
    {
        try
        {
            string[] items = CashRegister.ItemsInSession();
            
            Console.WriteLine("\n=== Bevásárolt tételek ===");
            if (items.Length == 0)
            {
                Console.WriteLine("Nincs még termék a kosárban.");
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i]}");
                }
                Console.WriteLine($"\nÖsszesen: {CashRegister.FinalSum()} Ft");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\n✗ Hiba: {ex.Message}");
        }
    }
    
    static void ProcessPayment()
    {
        try
        {
            int total = CashRegister.FinalSum();
            Console.WriteLine($"\nFizetendő összeg: {total} Ft");
            Console.Write("Fizetett összeg (Ft): ");
            
            if (int.TryParse(Console.ReadLine(), out int amountPaid) && amountPaid >= 0)
            {
                int change = CashRegister.Payment(amountPaid);
                Console.WriteLine($"\nFizetés sikeres!");
                Console.WriteLine($"Visszajáró: {change} Ft");
                Console.WriteLine("Köszönjük a vásárlást!");
            }
            else
            {
                Console.WriteLine("Érvénytelen összeg!");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\nHiba: {ex.Message}");
        }
    }
}