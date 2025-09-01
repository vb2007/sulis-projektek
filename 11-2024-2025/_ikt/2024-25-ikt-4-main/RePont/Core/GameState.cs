using RePontGame.Models;
using RePontGame.Models.Items;
using RePontGame.Models.Entities;
using RePontGame.Services;

namespace RePontGame.Core;

public class GameState
{
    public Map GameMap { get; }
    public Player GamePlayer { get; }
    public List<Enemy> Enemies { get; }
    public List<IItem> Items { get; }
    public RePont TargetRePont { get; }
    public bool IsGameOver { get; internal set; } = false;
    public bool PlayerWon { get; internal set; } = false;
    public List<string> MessageLog { get; } = new List<string>();
    public PlayerData CurrentPlayerData { get; }

    internal double EnemyBaseSpawnRate { get; set; } = GameConstants.EnemyBaseSpawnRate;
    internal double EnemySpawnRateIncreasePerBottle { get; set; } = GameConstants.EnemySpawnRateIncreasePerBottle;
    internal Random RandomGenerator { get; } = new Random();

    private const int MaxLogHistory = 50;

    public GameState(int mapWidth, int mapHeight, PlayerData playerData)
    {
        GameMap = new Map(mapWidth, mapHeight);
        GamePlayer = new Player(new Position(mapWidth / 2, mapHeight / 2));
        CurrentPlayerData = playerData;

        Enemies = new List<Enemy>();
        Items = new List<IItem>();

        TargetRePont = new RePont(GenerateRandomFreePosition(mapWidth, mapHeight, GamePlayer.Position));

        InitializeItems(GameConstants.InitialBottleCount, GameConstants.InitialKnifeCount, GameConstants.InitialEnergyDrinkCount);
        AddMessage($"Indul a gyűjtögetés, {playerData.Name}!");
    }

    private void InitializeItems(int bottleCount, int knifeCount, int energyDrinkCount)
    {
        for (int i = 0; i < bottleCount; i++)
        {
            TryPlaceItem(new Bottle(GenerateRandomFreePosition(GameMap.Width, GameMap.Height, GamePlayer.Position, TargetRePont.Position)));
        }
        for (int i = 0; i < knifeCount; i++)
        {
            TryPlaceItem(new PocketKnife(GenerateRandomFreePosition(GameMap.Width, GameMap.Height, GamePlayer.Position, TargetRePont.Position)));
        }
        for (int i = 0; i < energyDrinkCount; i++)
        {
            TryPlaceItem(new EnergyDrink(GenerateRandomFreePosition(GameMap.Width, GameMap.Height, GamePlayer.Position, TargetRePont.Position)));
        }
    }

    private Position GenerateRandomFreePosition(int mapWidth, int mapHeight, params Position[] occupied)
    {
        Position pos;
        int maxAttempts = mapWidth * mapHeight * 2;
        int attempts = 0;
        do
        {
            if (attempts++ > maxAttempts)
            {
                AddMessage("Figyelem: Nem sikerült szabad helyet találni egy elemnek/célpontnak!");
                return new Position(0, 0);
            }
            pos = new Position(RandomGenerator.Next(mapWidth), RandomGenerator.Next(mapHeight));
        } while (occupied.Contains(pos) || Items.Any(item => item.Position == pos) || Enemies.Any(e => e.Position == pos));

        return pos;
    }

    private void TryPlaceItem(IItem item)
    {
        if (!Items.Any(existingItem => existingItem.Position == item.Position) &&
            item.Position != GamePlayer.Position &&
            item.Position != TargetRePont.Position &&
            !Enemies.Any(e => e.Position == item.Position))
        {
            Items.Add(item);
        }
    }

    public void AddMessage(string message)
    {
        MessageLog.Add(message);
        if (MessageLog.Count > MaxLogHistory)
        {
            MessageLog.RemoveAt(0);
        }
    }

    public double GetCurrentEnemySpawnRate()
    {
        return Math.Min(EnemyBaseSpawnRate + (GamePlayer.BottlesCollected * EnemySpawnRateIncreasePerBottle), 1.0);
    }
}