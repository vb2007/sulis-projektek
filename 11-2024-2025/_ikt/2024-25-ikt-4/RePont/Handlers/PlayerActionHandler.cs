using RePontGame.Core;
using RePontGame.Models;
using RePontGame.Models.Items;
using RePontGame.Services;
using RePontGame.UI;

namespace RePontGame.Handlers;

public static class PlayerActionHandler
{
    private const int EnergyDrinkDuration = GameConstants.EnergyDrinkDuration;

    public static void CheckPlayerActions(GameState state)
    {
        CheckRePontReached(state);
        if (state.IsGameOver) return;
        CheckItemPickup(state);
    }

    private static void CheckRePontReached(GameState state)
    {
        if (state.GamePlayer.Position == state.TargetRePont.Position)
        {
            state.PlayerWon = true;
            state.IsGameOver = true;
            long sessionEarnings = state.GamePlayer.BottlesCollected * GameConstants.MoneyPerBottle;
            state.AddMessage($"Gratulálok {state.CurrentPlayerData.Name}! Eljutottál a RePont-hoz {state.GamePlayer.BottlesCollected} palackkal!");
            state.AddMessage($"Ebben a körben {sessionEarnings} Ft-ot szereztél.");
        }
    }

    private static void CheckItemPickup(GameState state)
    {
        IItem? itemToCollect = state.Items.FirstOrDefault(item => item.Position == state.GamePlayer.Position);
        if (itemToCollect != null)
        {
            Position itemPos = itemToCollect.Position;
            char itemSymbol = itemToCollect.Symbol;
            ConsoleColor itemColor = itemToCollect.Color;
            string itemName = itemToCollect.Name;
            bool collected = false;

            if (itemToCollect is Bottle)
            {
                state.GamePlayer.BottlesCollected++;
                state.AddMessage($"Felvettél egy palackot! ({state.GamePlayer.BottlesCollected} db)");
                state.Items.Remove(itemToCollect);
                collected = true;
            }
            else if (itemToCollect is PocketKnife)
            {
                if (!state.GamePlayer.HasKnife)
                {
                    state.GamePlayer.HasKnife = true;
                    state.AddMessage("Felvetted a zsebkést!");
                    state.Items.Remove(itemToCollect);
                    collected = true;
                }
                else
                {
                    state.AddMessage("Már van nálad zsebkés, ezt itt hagyod.");
                }
            }
            else if (itemToCollect is EnergyDrink)
            {
                state.GamePlayer.TemporarySpeedBoostTurns += EnergyDrinkDuration;
                state.AddMessage($"Felvettél egy szörny energiaitalt! Gyorsabb lettél {EnergyDrinkDuration} körre.");
                state.Items.Remove(itemToCollect);
                collected = true;
            }
            else
            {
                state.AddMessage($"Felvettél egy {itemName}-t.");
                state.Items.Remove(itemToCollect);
                collected = true;
            }

            if (collected)
            {
                Renderer.FlashEffect(itemPos, itemSymbol, ConsoleColor.White, GameConstants.EffectFlashDuration);
            }
        }
    }
}