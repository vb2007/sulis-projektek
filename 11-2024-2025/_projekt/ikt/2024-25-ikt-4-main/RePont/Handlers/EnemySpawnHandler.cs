using RePontGame.Core;
using RePontGame.Models;
using RePontGame.Models.Entities;
using RePontGame.Models.Enums;
using RePontGame.Services;
using RePontGame.UI;
using RePontGame.Utils;

namespace RePontGame.Handlers;

public static class EnemySpawnHandler
{
    public static void TrySpawnEnemy(GameState state)
    {
        double spawnChance = state.GetCurrentEnemySpawnRate();
        if (state.RandomGenerator.NextDouble() < spawnChance)
        {
            List<Position> possibleSpawnPoints = MapUtils.GetAdjacentPositions(state.GamePlayer.Position, state.GameMap);
            possibleSpawnPoints.RemoveAll(p =>
                state.Enemies.Any(e => e.Position == p) ||
                state.Items.Any(i => i.Position == p) ||
                p == state.TargetRePont.Position ||
                p == state.GamePlayer.Position);

            if (possibleSpawnPoints.Count > 0)
            {
                Position spawnPos = possibleSpawnPoints[state.RandomGenerator.Next(possibleSpawnPoints.Count)];
                EnemyType[] types = Enum.GetValues<EnemyType>();
                EnemyType randomType = types[state.RandomGenerator.Next(types.Length)];
                var newEnemy = new Enemy(spawnPos, randomType);

                state.Enemies.Add(newEnemy);
                state.AddMessage($"Figyelem! Egy {newEnemy.Name} jelent meg a közeledben!");
                Renderer.FlashEffect(spawnPos, newEnemy.Symbol, ConsoleColor.White, GameConstants.EffectFlashDuration, 3);
            }
        }
    }
}