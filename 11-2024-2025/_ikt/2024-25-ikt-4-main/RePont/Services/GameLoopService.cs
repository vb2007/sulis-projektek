using RePontGame.Core;
using RePontGame.Handlers;
using RePontGame.Models;
using RePontGame.UI;

namespace RePontGame.Services;

public static class GameLoopService
{
    private const int MapSizeX = GameConstants.MapSizeX;
    private const int MapSizeY = GameConstants.MapSizeY;

    public static void RunGame(PlayerData playerData)
    {
        GameState gameState = new GameState(MapSizeX, MapSizeY, playerData);
        RpcService.UpdateIngamePresence(gameState);
        Renderer.DrawLayout(MapSizeX, MapSizeY);

        while (!gameState.IsGameOver)
        {
            Renderer.Render(gameState);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.H)
            {
                MenuRenderer.ShowHelpScreen();
                Renderer.DrawLayout(MapSizeX, MapSizeY);
                Renderer.Render(gameState);
                RpcService.UpdateIngamePresence(gameState);
                continue;
            }

            InputHandler.ProcessInput(gameState, keyInfo.Key);

            if (!gameState.IsGameOver)
            {
                RpcService.UpdateIngamePresence(gameState);
                Renderer.Render(gameState);
            }
        }

        Renderer.Render(gameState);
        Thread.Sleep(500);

        string finalCause = gameState.MessageLog.LastOrDefault(m => m.Contains("Vége a játéknak") || m.Contains("Kiléptél")) ?? "A játéknak vége.";

        if (gameState.PlayerWon)
        {
            long sessionEarnings = gameState.GamePlayer.BottlesCollected * GameConstants.MoneyPerBottle;
            playerData.TotalMoneyEarned += sessionEarnings;

            Renderer.DisplayTemporaryInteractionMessage("Mentés...", ConsoleColor.Cyan);
            SaveManager.SavePlayerData(playerData);
            Thread.Sleep(700);
            Renderer.ClearInteractionPanel();

            Renderer.AnimateWinScreen(gameState, sessionEarnings);
        }
        else if (finalCause.Contains("Kiléptél"))
        {
            Renderer.DisplayInteractionMessage($"Kiléptél a játékból, {playerData.Name}.", ConsoleColor.Gray);
        }
        else
        {
            string lossReason = finalCause;
            if (lossReason.Contains("legyőzött!")) lossReason = $"Legyőzött: {finalCause.Split("A(z) ")[1].Split(" legyőzött!")[0]}";
            else if (lossReason.Contains("elkapott!")) lossReason = $"Elkapott: {finalCause.Split("A(z) ")[1].Split(" elkapott!")[0]}";
            else lossReason = "Ismeretlen okból vesztettél.";

            Renderer.AnimateLossScreen(gameState, lossReason);
        }

        Console.ReadKey(true);
    }
}