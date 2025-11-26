namespace Lift_VB_Lib;

public class Lift : IMozog
{
    public int AktualisEmelet { get; init; }
    
    public Lift(int emeletekSzama)
    {
        AktualisEmelet = Random.Shared.Next(1, emeletekSzama + 1);
    }
}