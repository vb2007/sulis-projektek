using NetDiscordRpc;
using NetDiscordRpc.Core.Logger;
using NetDiscordRpc.RPC;
using RePontGame.Core;
using RePontGame.Models;

namespace RePontGame.Services;

public static class RpcService
{
    private static DiscordRPC? _client;
    private static DateTime? _startTime;

    private const string _clientId = "1355892132350525603";

    private const string _largeImageKey = "repont_logo_gif";
    private const string _largeImageText = "RePont Kalandjáték";

    private const string _smallImageKey = "repont";
    private const string _smallImageText = "RePont";

    private static bool _isInitialized = false;

    public static void Initialize()
    {
        if (_isInitialized) return;

        try
        {
            _client = new DiscordRPC(_clientId);

            _client.Logger = new NullLogger();

            _client.Initialize();

            _startTime = DateTime.UtcNow;
            _isInitialized = true;

            SetInitialPresence();
        }
        catch (Exception)
        {
            _client?.Dispose();
            _client = null;
            _isInitialized = false;
        }
    }

    private static void SetInitialPresence()
    {
        if (!_isInitialized || _client == null) return;

        try
        {
            _client.SetPresence(new RichPresence()
            {
                Details = "Indítás...",
                State = "Főmenü betöltése",
                Assets = new Assets()
                {
                    LargeImageKey = _largeImageKey,
                    LargeImageText = _largeImageText,
                    SmallImageKey = _smallImageKey,
                    SmallImageText = _smallImageText
                },
                Timestamps = new Timestamps() { Start = _startTime }
            });
        }
        catch (Exception) { }
    }

    public static void UpdateMenuPresence(PlayerData playerData)
    {
        if (!_isInitialized || _client == null) return;

        try
        {
            _client.UpdateDetails($"{playerData.Name} a főmenüben");
            _client.UpdateState($"Vagyon: {playerData.TotalMoneyEarned} Ft");
            _client.UpdateLargeAsset(_largeImageKey, _largeImageText);
            _client.UpdateSmallAsset(_smallImageKey, _smallImageText);

            if (_startTime.HasValue)
            {
                _client.UpdateStartTime(_startTime.Value);
            }
        }
        catch (Exception) { }
    }

    public static void UpdateIngamePresence(GameState gameState)
    {
        if (!_isInitialized || _client == null || gameState.IsGameOver) return;

        try
        {
            string details = $"{gameState.GamePlayer.BottlesCollected} palack gyűjtve";
            string state = $"Cél: ({gameState.TargetRePont.Position.X},{gameState.TargetRePont.Position.Y}) | Spawn: {gameState.GetCurrentEnemySpawnRate():P0}";

            if (gameState.GamePlayer.HasKnife)
            {
                details += " | Késsel";
            }
            if (gameState.GamePlayer.TemporarySpeedBoostTurns > 0)
            {
                details += $" | Energiaital ({gameState.GamePlayer.TemporarySpeedBoostTurns})";
            }

            _client.UpdateDetails(details);
            _client.UpdateState(state);
            _client.UpdateLargeAsset(_largeImageKey, _largeImageText);
            _client.UpdateSmallAsset(_smallImageKey, _smallImageText);

            if (_startTime.HasValue)
            {
                _client.UpdateStartTime(_startTime.Value);
            }
        }
        catch (Exception) { }
    }

    public static void Shutdown()
    {
        if (!_isInitialized || _client == null) return;

        try
        {
            _client.ClearPresence();
            _client.Dispose();
        }
        catch (Exception) { }
        finally
        {
            _client = null;
            _isInitialized = false;
            _startTime = null;
        }
    }
}