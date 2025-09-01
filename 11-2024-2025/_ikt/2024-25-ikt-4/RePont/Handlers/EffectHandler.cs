using RePontGame.Core;

namespace RePontGame.Handlers;

public static class EffectHandler
{
    public static void TickPlayerEffects(GameState state)
    {
        if (state.GamePlayer.TemporarySpeedBoostTurns > 0)
        {
            state.GamePlayer.TemporarySpeedBoostTurns--;
            if (state.GamePlayer.TemporarySpeedBoostTurns == 0)
            {
                state.AddMessage("Az energiaital hatása elmúlt.");
            }
        }
    }
}