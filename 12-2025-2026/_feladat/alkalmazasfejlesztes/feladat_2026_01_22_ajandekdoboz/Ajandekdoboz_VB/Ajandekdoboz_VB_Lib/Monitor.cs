namespace Ajandekdoboz_VB_Lib;

public class Monitor : Termek
{
    public int RefreshRate { get; set; }
    
    public Monitor(string nev, int ar, int refreshRate) : base(nev, ar)
    {
        RefreshRate = refreshRate;
    }   
}