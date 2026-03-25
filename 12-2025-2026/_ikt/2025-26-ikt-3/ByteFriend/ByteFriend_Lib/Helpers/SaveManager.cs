using System.Text.Json;
using ByteFriend_Lib.Entities;

namespace ByteFriend_Lib.Helpers;

public static class SaveManager
{
    private static readonly string SaveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Saves");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    static SaveManager()
    {
        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }
    }

    public static bool IsNameTaken(string name)
    {
        string filePath = GetFilePath(name);
        return File.Exists(filePath);
    }

    public static void Save(IAnimal animal)
    {
        var data = AnimalFactory.ToSaveData(animal);
        string json = JsonSerializer.Serialize(data, JsonOptions);
        File.WriteAllText(GetFilePath(animal.Name), json);
    }

    public static IAnimal? Load(string name)
    {
        string filePath = GetFilePath(name);
        if (!File.Exists(filePath)) return null;

        string json = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<SaveData>(json);
        if (data == null) return null;

        var allat = AnimalFactory.FromSaveData(data);
        TimeManager.ApplyElapsedTime(allat, data.CloseTime);
        return allat;
    }

    public static List<string> GetAllSaves()
    {
        if (!Directory.Exists(SaveDirectory)) return [];

        return Directory.GetFiles(SaveDirectory, "*.json")
            .Select(Path.GetFileNameWithoutExtension)
            .Where(name => name != null)
            .Cast<string>()
            .ToList();
    }

    public static void Delete(string name)
    {
        string filePath = GetFilePath(name);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public static bool Rename(string oldName, string newName)
    {
        string oldFilePath = GetFilePath(oldName);
        string newFilePath = GetFilePath(newName);

        if (!File.Exists(oldFilePath) || File.Exists(newFilePath)) return false;

        string json = File.ReadAllText(oldFilePath);
        var data = JsonSerializer.Deserialize<SaveData>(json);
        if (data == null) return false;

        var updatedData = new SaveData
        {
            Name = newName,
            TypeName = data.TypeName,
            Age = data.Age,
            IsHealthy = data.IsHealthy,
            Hunger = data.Hunger,
            Happiness = data.Happiness,
            State = data.State,
            AquariumSmashed = data.AquariumSmashed,
            CloseTime = data.CloseTime
        };

        string updatedJson = JsonSerializer.Serialize(updatedData, JsonOptions);
        File.WriteAllText(newFilePath, updatedJson);
        File.Delete(oldFilePath);

        return true;
    }

    public static int GetSaveCount()
    {
        if (!Directory.Exists(SaveDirectory)) return 0;
        return Directory.GetFiles(SaveDirectory, "*.json").Length;
    }

    private static string GetFilePath(string name)
    {
        return Path.Combine(SaveDirectory, $"{name}.json");
    }
}