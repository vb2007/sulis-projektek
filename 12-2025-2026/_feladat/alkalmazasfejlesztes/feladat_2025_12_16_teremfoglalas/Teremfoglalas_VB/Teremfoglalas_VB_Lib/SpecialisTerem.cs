namespace Teremfoglalas_VB_Lib;

public sealed class SpecialisTerem : Terem
{
    public int TakaritasiIdoPerc { get; set; }

    public SpecialisTerem(int teremAzonosito, int helyekSzama, int takaritasiIdoPerc) : base(teremAzonosito, helyekSzama)
    {
        TakaritasiIdoPerc = takaritasiIdoPerc;
    }

    public new void IdopontFoglalas(Foglalas foglalas)
    {
        if (foglalas.HelyszinAzonosito != TeremAzonosito)
        {
            throw new FoglalasException();
        }

        int idotartamPerc = (int)(foglalas.Vege - foglalas.Kezdete).TotalMinutes;

        //foglalás megvalósítható-e
        if (Orarend.FoglaltE(foglalas.Kezdete, idotartamPerc))
        {
            throw new FoglalasException();
        }

        //takarítás megvalósítható-e
        if (Orarend.FoglaltE(foglalas.Vege, TakaritasiIdoPerc))
        {
            throw new FoglalasException();
        }

        //takarítás & foglalás hozzáadása
        Orarend = Orarend + foglalas;

        Foglalas takaritas = new Foglalas(foglalas.Vege, TakaritasiIdoPerc, TeremAzonosito, -1);
        Orarend = Orarend + takaritas;
    }

    public override string ToString()
    {
        return $"Speciális terem azonosító: {TeremAzonosito}\n" +
               $"Helyek száma: {HelyekSzama}\n" +
               $"Takarítási idő: {TakaritasiIdoPerc} perc\n" +
               $"{Orarend}";
    }
}
