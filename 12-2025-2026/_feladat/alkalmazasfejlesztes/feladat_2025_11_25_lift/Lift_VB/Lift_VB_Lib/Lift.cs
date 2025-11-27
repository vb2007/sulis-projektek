namespace Lift_VB_Lib;

public class Lift : IMozog
{
    private int AktualisEmelet { get; set; }
    private int EmeletekSzama { get; set; }

    public Lift(int emeletekSzama)
    {
        EmeletekSzama = emeletekSzama;
        AktualisEmelet = Random.Shared.Next(1, emeletekSzama + 1);
    }

    private void Hibalehetoseg()
    {
        int esely = Random.Shared.Next(0, 100);
        if (esely == 0)
        {
            throw new Exception("A lift elromlott");
        }
    }

    public void Lefele()
    {
        Hibalehetoseg();

        if (AktualisEmelet == 1)
        {
            throw new HibasIranyException("Nem lehet lejjebb menni az 1. emeletről!");
        }
        AktualisEmelet--;
    }

    public void Felfele()
    {
        Hibalehetoseg();

        if (AktualisEmelet == EmeletekSzama)
        {
            throw new HibasIranyException($"Nem lehet feljebb menni a(z) {EmeletekSzama}. emeletről!");
        }
        AktualisEmelet++;
    }

    public override string ToString()
    {
        return $"Lift (Aktuális emelet: {AktualisEmelet}, Emeletek száma: {EmeletekSzama})";
    }
}
