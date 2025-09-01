using RePontGame.Core;
using RePontGame.Models;
using RePontGame.Models.Entities;

namespace RePontGame.Handlers;

public static class InputHandler
{
    public static void ProcessInput(GameState state, ConsoleKey key)
    {
        if (state.IsGameOver) return;

        Position currentPos = state.GamePlayer.Position;
        Position nextPos = currentPos;
        bool playerMoved = false;

        switch (key)
        {
            case ConsoleKey.W: nextPos = currentPos with { Y = currentPos.Y - 1 }; playerMoved = true; break;
            case ConsoleKey.S: nextPos = currentPos with { Y = currentPos.Y + 1 }; playerMoved = true; break;
            case ConsoleKey.A: nextPos = currentPos with { X = currentPos.X - 1 }; playerMoved = true; break;
            case ConsoleKey.D: nextPos = currentPos with { X = currentPos.X + 1 }; playerMoved = true; break;
            case ConsoleKey.Q: state.IsGameOver = true; state.AddMessage("Kiléptél a játékból."); return;
            default: state.AddMessage("Érvénytelen parancs. Használd: W, A, S, D, Q."); return;
        }

        if (playerMoved)
        {
            if (state.GameMap.IsWithinBounds(nextPos))
            {
                Enemy? collidingEnemy = state.Enemies.FirstOrDefault(e => e.Position == nextPos);
                if (collidingEnemy != null)
                {
                    state.AddMessage($"Nem léphetsz rá erre: {collidingEnemy.Name}.");
                }
                else
                {
                    state.GamePlayer.Position = nextPos;
                    EffectHandler.TickPlayerEffects(state);
                    PlayerActionHandler.CheckPlayerActions(state);
                    if (!state.IsGameOver)
                    {
                        EnemySpawnHandler.TrySpawnEnemy(state);
                        EncounterHandler.CheckForEncounters(state);
                    }
                }
            }
            else
            {
                state.AddMessage("Nem mehetsz ki a pályáról!");
            }
        }
    }
}