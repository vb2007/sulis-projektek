using System.Text.Json;
using System.Text.RegularExpressions;
using RePontGame.Models;

namespace RePontGame.Services;

public static class SaveManager
{
    private static readonly string SaveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves");

    static SaveManager()
    {
        try
        {
            Directory.CreateDirectory(SaveDirectory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Figyelem: Nem sikerült létrehozni a mentési mappát ({SaveDirectory}): {ex.Message}");
            Console.WriteLine("A mentés/betöltés nem fog működni.");
            Console.ReadKey();
        }
    }

    private static string SanitizeFileName(string name)
    {
        string invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        string sanitizedName = Regex.Replace(name, $"[{Regex.Escape(invalidChars)}]", "_", RegexOptions.Compiled);
        sanitizedName = sanitizedName.TrimStart('.').TrimEnd('.');
        if (string.IsNullOrWhiteSpace(sanitizedName) || sanitizedName.Length > 100)
        {
            sanitizedName = $"player_{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
        return sanitizedName;
    }

    private static string GetSaveFilePath(string playerName)
    {
        string safeFileName = SanitizeFileName(playerName) + ".json";
        return Path.Combine(SaveDirectory, safeFileName);
    }

    public static PlayerData LoadPlayerData(string playerName)
    {
        string filePath = GetSaveFilePath(playerName);
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                PlayerData? data = JsonSerializer.Deserialize<PlayerData>(json);
                if (data != null)
                {
                    data.Name = playerName;
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Hiba a '{playerName}' mentés betöltése közben ({filePath}): {ex.Message}");
                Thread.Sleep(1500);
            }
        }

        return new PlayerData { Name = playerName, TotalMoneyEarned = 0 };
    }

    public static void SavePlayerData(PlayerData playerData)
    {
        if (string.IsNullOrWhiteSpace(playerData.Name))
        {
            Console.Error.WriteLine("Hiba: Név nélküli játékosadat mentése nem lehetséges.");
            return;
        }

        string filePath = GetSaveFilePath(playerData.Name);
        try
        {
            string json = JsonSerializer.Serialize(playerData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Hiba a mentés során ({playerData.Name} -> {filePath}): {ex.Message}");
            Thread.Sleep(1500);
        }
    }
}