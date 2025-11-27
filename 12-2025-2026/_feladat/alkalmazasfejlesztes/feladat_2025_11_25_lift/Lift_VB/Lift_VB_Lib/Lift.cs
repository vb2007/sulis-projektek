namespace Lift_VB_Lib;

public class Lift : IMozog
{
    private int AktualisEmelet { get; set; }

    public Lift(int emeletekSzama)
    {
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
            throw new HibasIranyException();
        }
        AktualisEmelet--;
    }

    public void Felfele()
    {
        Hibalehetoseg();
        
        //nem tudom mennyi a legfelső emelet, a legnagyobb bementre tippeltem a példából
        if (AktualisEmelet == 9)
        {
            throw new HibasIranyException();
        }
        AktualisEmelet++;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
