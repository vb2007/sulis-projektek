using RePontGame.Core;
using RePontGame.Models;
using RePontGame.Models.Entities;
using RePontGame.Services;
using RePontGame.UI;
using RePontGame.Utils;

namespace RePontGame.Handlers;

public static class EncounterHandler
{
    private const double IntimidateSuccessChance = GameConstants.IntimidateSuccessChance;
    private const double FailedIntimidatePenaltyMultiplier = GameConstants.FailedIntimidatePenaltyMultiplier;

    public static void CheckForEncounters(GameState state)
    {
        if (state.IsGameOver) return;
        List<Position> adjacent = MapUtils.GetAdjacentPositions(state.GamePlayer.Position, state.GameMap);
        Enemy? encounteredEnemy = state.Enemies.FirstOrDefault(e => adjacent.Contains(e.Position));

        if (encounteredEnemy != null)
        {
            state.AddMessage($"Összefutottál vele: {encounteredEnemy.Name}!");
            HandleEncounter(state, encounteredEnemy);
        }
    }

    private static void HandleEncounter(GameState state, Enemy enemy)
    {
        bool encounterResolved = false;
        bool intimidateAttempted = false;

        while (!encounterResolved && !state.IsGameOver)
        {
            Renderer.Render(state);
            int choice = Renderer.ShowInteractionMenu(state, enemy, intimidateAttempted);

            switch (choice)
            {
                case 1:
                    HandleAttack(state, enemy, intimidateAttempted ? FailedIntimidatePenaltyMultiplier : 1.0);
                    encounterResolved = true;
                    break;
                case 2:
                    HandleRun(state, enemy, intimidateAttempted ? FailedIntimidatePenaltyMultiplier : 1.0);
                    encounterResolved = true;
                    break;
                case 3:
                    if (!intimidateAttempted)
                    {
                        intimidateAttempted = true;
                        encounterResolved = HandleIntimidate(state, enemy);
                    }
                    else
                    {
                        state.AddMessage("Ezt már próbáltad. Válassz mást!");
                    }
                    break;
                default:
                    encounterResolved = true;
                    break;
            }
            if (encounterResolved && !state.IsGameOver) Thread.Sleep(300);
        }
        if (!state.IsGameOver) Renderer.Render(state);
    }

    private static void HandleAttack(GameState state, Enemy enemy, double successMultiplier)
    {
        double baseSuccessChance;
        string actionMsg;
        if (state.GamePlayer.HasKnife)
        {
            baseSuccessChance = state.CurrentPlayerData.GetCurrentKnifeAttackChance();
            actionMsg = $"Megpróbálod a zsebkéseddel ({baseSuccessChance:P0} esély)...";
        }
        else
        {
            baseSuccessChance = state.CurrentPlayerData.GetCurrentAttackChance();
            actionMsg = $"Puszta kézzel próbálkozol ({baseSuccessChance:P0} esély)...";
        }
        state.AddMessage(actionMsg);

        double actualSuccessChance = baseSuccessChance * successMultiplier;
        if (successMultiplier < 1.0)
        {
            state.AddMessage($"Mivel ideges a tizedes ezért kisebb esélyed van! ({actualSuccessChance:P0} esély)");
        }

        Renderer.Render(state);
        Thread.Sleep(500);

        bool success = state.RandomGenerator.NextDouble() < actualSuccessChance;

        if (success)
        {
            string msg = $"Sikeresen legyőzted: {enemy.Name}!";
            Position enemyPos = enemy.Position;
            state.Enemies.Remove(enemy);

            Renderer.FlashEffect(enemyPos, 'X', Renderer.SuccessColor, GameConstants.EffectFlashDuration, 3);

            if (state.GamePlayer.HasKnife && state.RandomGenerator.NextDouble() < state.CurrentPlayerData.GetCurrentKnifeBreakChance())
            {
                state.GamePlayer.HasKnife = false;
                msg += $" A zsebkésed eltört a harcban! ({state.CurrentPlayerData.GetCurrentKnifeBreakChance():P0} esély volt rá)";
            }
            state.AddMessage(msg);
        }
        else
        {
            state.AddMessage($"Támadásod sikertelen! A(z) {enemy.Name} legyőzött! Vége a játéknak.");
            state.IsGameOver = true;
            Renderer.FlashEffect(state.GamePlayer.Position, 'X', Renderer.ErrorColor, GameConstants.EffectFlashDuration, 4);
            Thread.Sleep(500);
        }
    }

    private static void HandleRun(GameState state, Enemy enemy, double successMultiplier)
    {
        double baseSuccessChance = state.CurrentPlayerData.GetCurrentRunChance();
        double actualSuccessChance = baseSuccessChance * successMultiplier;
        bool usedBoost = false;

        if (state.GamePlayer.TemporarySpeedBoostTurns > 0)
        {
            actualSuccessChance = 1.0;
            state.AddMessage("Az szörny energiaital segít, biztosan el tudsz menekülni!");
            usedBoost = true;
        }
        else
        {
            state.AddMessage($"Megpróbálsz elfutni ({baseSuccessChance:P0} esély)...");
            if (successMultiplier < 1.0)
            {
                state.AddMessage($"Mivel ideges a tizedes ezért kisebb esélyed van! ({actualSuccessChance:P0} esély)");
            }
        }

        Renderer.Render(state);
        Thread.Sleep(500);

        bool success = usedBoost || state.RandomGenerator.NextDouble() < actualSuccessChance;

        if (success)
        {
            state.AddMessage("Sikeresen elfutottál!");
            Renderer.FlashEffect(state.GamePlayer.Position, '>', ConsoleColor.Cyan, GameConstants.EffectFlashDuration, 2);
        }
        else
        {
            state.AddMessage($"Nem sikerült elfutni! A(z) {enemy.Name} elkapott! Vége a játéknak.");
            state.IsGameOver = true;
            Renderer.FlashEffect(state.GamePlayer.Position, 'X', Renderer.ErrorColor, GameConstants.EffectFlashDuration, 4);
            Thread.Sleep(500);
        }
    }

    private static bool HandleIntimidate(GameState state, Enemy enemy)
    {
        state.AddMessage($"Megpróbálod megfélemlíteni ({IntimidateSuccessChance:P0} esély)...");

        Renderer.Render(state);
        Thread.Sleep(500);

        bool success = state.RandomGenerator.NextDouble() < IntimidateSuccessChance;

        if (success)
        {
            state.AddMessage($"Sikerült! A(z) {enemy.Name} meghátrált és elmenekült.");
            Position enemyPos = enemy.Position;
            state.Enemies.Remove(enemy);
            Renderer.FlashEffect(enemyPos, '!', ConsoleColor.Yellow, GameConstants.EffectFlashDuration, 3);
            return true;
        }
        else
        {
            state.AddMessage($"Leszarta. Most Ideges a Tizedes!");
            Renderer.FlashEffect(enemy.Position, '?', ConsoleColor.Red, GameConstants.EffectFlashDuration, 2);
            return false;
        }
    }
}