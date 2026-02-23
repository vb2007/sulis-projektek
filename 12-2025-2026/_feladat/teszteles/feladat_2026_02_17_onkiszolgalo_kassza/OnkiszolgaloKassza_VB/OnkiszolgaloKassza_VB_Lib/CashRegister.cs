namespace OnkiszolgaloKassza_VB_Lib;

public class CashRegister
{
    private static bool _sessionActive = false;
    private static List<(string Name, int Price)> _items = new List<(string Name, int Price)>();

    public static bool IsSessionActive()
    {
        return _sessionActive;
    }

    public static void StartNewSession()
    {
        if (_sessionActive)
        {
            throw new InvalidOperationException("A session is already active. Complete the current session before starting a new one.");
        }
        
        _sessionActive = true;
        _items.Clear();
    }

    public static void ScanItem(string name, int price)
    {
        if (!_sessionActive)
        {
            throw new InvalidOperationException("No active session. Start a new session first.");
        }
        
        _items.Add((name, price));
    }
    
    public static void RemoveItem()
    {
        if (!_sessionActive)
        {
            throw new InvalidOperationException("No active session. Start a new session first.");
        }
        
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("No items to remove.");
        }
        
        _items.RemoveAt(_items.Count - 1);
    }

    public static int FinalSum()
    {
        if (!_sessionActive)
        {
            throw new InvalidOperationException("No active session. Start a new session first.");
        }
        
        return _items.Sum(item => item.Price);
    }

    public static string[] ItemsInSession()
    {
        if (!_sessionActive)
        {
            throw new InvalidOperationException("No active session. Start a new session first.");
        }
        
        return _items.Select(item => $"{item.Name} - {item.Price} Ft").ToArray();
    }

    public static int Payment(int amountPaid)
    {
        if (!_sessionActive)
        {
            throw new InvalidOperationException("No active session. Start a new session first.");
        }
        
        int totalSum = FinalSum();
        
        if (amountPaid < totalSum)
        {
            throw new InvalidOperationException($"Insufficient payment. Total: {totalSum} Ft, Paid: {amountPaid} Ft");
        }
        
        int change = amountPaid - totalSum;
        _sessionActive = false;
        _items.Clear();
        
        return change;
    }
}