namespace KobolduldozokLib.UI.Simulation;

public class Statistics
{
    public int FrameCount { get; private set; }
    public int KoboldCount { get; private set; }
    public int AngelCount { get; private set; }
    public bool AngelsActive { get; private set; }
    public int CoinCount { get; private set; }
    public int CoinsCollected { get; private set; }
    public int CurrentHouseIndex { get; private set; }
    public int TotalHouses { get; private set; }

    public void Update(int frameCount, int koboldCount, int angelCount, bool angelsActive,
                      int coinCount, int coinsCollected, int currentHouseIndex, int totalHouses)
    {
        FrameCount = frameCount;
        KoboldCount = koboldCount;
        AngelCount = angelCount;
        AngelsActive = angelsActive;
        CoinCount = coinCount;
        CoinsCollected = coinsCollected;
        CurrentHouseIndex = currentHouseIndex;
        TotalHouses = totalHouses;
    }
}
