namespace Ajandekdoboz_VB_Lib;

public class Switch : Termek
{
    public int PortokSzama { get; set; }
    
    public Switch(string nev, int ar, int portokSzama) : base(nev, ar)
    {
        PortokSzama = portokSzama;
    }
}