using System.Text.Json.Serialization;
using RePontGame.Models.Enums;

namespace RePontGame.Models;

public class PlayerData
{
    public string Name { get; set; } = "Ismeretlen";
    public long TotalMoneyEarned { get; set; } = 0;

    public int AttackUpgradeLevel { get; set; } = 0;
    public int RunUpgradeLevel { get; set; } = 0;
    public int KnifeDurabilityUpgradeLevel { get; set; } = 0;
    public int KnifeAttackUpgradeLevel { get; set; } = 0;

    [JsonIgnore] public const int MaxUpgradeLevel = 5;

    [JsonIgnore] public static long AttackUpgradeBaseCost { get; } = 150;
    [JsonIgnore] public static long RunUpgradeBaseCost { get; } = 100;
    [JsonIgnore] public static long KnifeDurabilityUpgradeBaseCost { get; } = 200;
    [JsonIgnore] public static long KnifeAttackUpgradeBaseCost { get; } = 250;

    public long GetNextUpgradeCost(UpgradeType type)
    {
        int currentLevel = type switch
        {
            UpgradeType.Attack => AttackUpgradeLevel,
            UpgradeType.Run => RunUpgradeLevel,
            UpgradeType.KnifeDurability => KnifeDurabilityUpgradeLevel,
            UpgradeType.KnifeAttack => KnifeAttackUpgradeLevel,
            _ => 0
        };
        if (currentLevel >= MaxUpgradeLevel) return long.MaxValue;

        long baseCost = type switch
        {
            UpgradeType.Attack => AttackUpgradeBaseCost,
            UpgradeType.Run => RunUpgradeBaseCost,
            UpgradeType.KnifeDurability => KnifeDurabilityUpgradeBaseCost,
            UpgradeType.KnifeAttack => KnifeAttackUpgradeBaseCost,
            _ => long.MaxValue
        };

        return baseCost * (long)Math.Pow(2, currentLevel);
    }

    [JsonIgnore] public double BaseAttackChance { get; } = 0.20;
    [JsonIgnore] public double AttackChancePerLevel { get; } = 0.06;

    [JsonIgnore] public double BaseRunChance { get; } = 0.80;
    [JsonIgnore] public double RunChancePerLevel { get; } = 0.03;

    [JsonIgnore] public double BaseKnifeBreakChance { get; } = 0.30;
    [JsonIgnore] public double KnifeBreakChanceReductionPerLevel { get; } = 0.05;

    [JsonIgnore] public double BaseKnifeAttackChance { get; } = 0.75;
    [JsonIgnore] public double KnifeAttackChancePerLevel { get; } = 0.04;

    public double GetCurrentAttackChance()
    {
        double chance = BaseAttackChance + (AttackUpgradeLevel * AttackChancePerLevel);
        return Math.Min(chance, 0.95);
    }

    public double GetCurrentRunChance()
    {
        double chance = BaseRunChance + (RunUpgradeLevel * RunChancePerLevel);
        return Math.Min(chance, 0.99);
    }

    public double GetCurrentKnifeBreakChance()
    {
        double chance = BaseKnifeBreakChance - (KnifeDurabilityUpgradeLevel * KnifeBreakChanceReductionPerLevel);
        return Math.Max(chance, 0.05);
    }

    public double GetCurrentKnifeAttackChance()
    {
        double chance = BaseKnifeAttackChance + (KnifeAttackUpgradeLevel * KnifeAttackChancePerLevel);
        return Math.Min(chance, 0.99);
    }

    public bool TryPurchaseUpgrade(UpgradeType type)
    {
        long cost = GetNextUpgradeCost(type);
        int currentLevel = type switch
        {
            UpgradeType.Attack => AttackUpgradeLevel,
            UpgradeType.Run => RunUpgradeLevel,
            UpgradeType.KnifeDurability => KnifeDurabilityUpgradeLevel,
            UpgradeType.KnifeAttack => KnifeAttackUpgradeLevel,
            _ => MaxUpgradeLevel
        };

        if (currentLevel < MaxUpgradeLevel && TotalMoneyEarned >= cost)
        {
            TotalMoneyEarned -= cost;
            switch (type)
            {
                case UpgradeType.Attack: AttackUpgradeLevel++; break;
                case UpgradeType.Run: RunUpgradeLevel++; break;
                case UpgradeType.KnifeDurability: KnifeDurabilityUpgradeLevel++; break;
                case UpgradeType.KnifeAttack: KnifeAttackUpgradeLevel++; break;
            }
            return true;
        }
        return false;
    }
}