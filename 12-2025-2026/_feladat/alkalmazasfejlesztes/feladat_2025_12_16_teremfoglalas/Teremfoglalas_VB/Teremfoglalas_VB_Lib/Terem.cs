namespace Teremfoglalas_VB_Lib;

public class Terem
{
    public int TeremAzonosito { get; set; }
    public int HelyekSzama { get; set; }
    public Orarend Orarend { get; set; }

    public Terem(int teremAzonosito, int helyekSzama)
    {
        TeremAzonosito = teremAzonosito;
        HelyekSzama = helyekSzama;
        Orarend = new Orarend();
    }

    public void IdopontFoglalas(Foglalas foglalas)
    {
        
    }
}
