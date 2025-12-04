namespace KobolduldozokLib;

public class SimulationSettings
{
    public int Speed { get; set; } = 1;
    public bool IsManualMode { get; set; } = false;
    
    public int GetDelayMilliseconds()
    {
        return Speed switch
        {
            1 => 1000,//1mp
            2 => 800,
            3 => 600,
            4 => 500,
            5 => 400,
            6 => 300,
            7 => 200,
            8 => 150,
            9 => 100,
            10 => 50,
            _ => 1000
        };
    }

    public override string ToString()
    {
        return $"Speed: {Speed}, Manual Mode: {(IsManualMode ? "ON" : "OFF")}, Delay: {GetDelayMilliseconds()}ms";
    }
}
