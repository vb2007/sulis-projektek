namespace Teremfoglalas_VB_Lib;

public sealed class AltalanosTerem : Terem
{
    public AltalanosTerem(int teremAzonosito, int helyekSzama) : base(teremAzonosito, helyekSzama) { }

    public override void IdopontFoglalas(Foglalas foglalas)
    {
        if (foglalas.HelyszinAzonosito != TeremAzonosito)
        {
            throw new FoglalasException();
        }

        Orarend = Orarend + foglalas;
    }

    public override string ToString()
    {
        return $"Általános terem azonosító: {TeremAzonosito}\n" +
               $"Helyek száma: {HelyekSzama}\n" +
               $"{Orarend}";
    }
}
