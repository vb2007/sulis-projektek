namespace Teremfoglalas_VB_Lib;

public class Foglalas : IFoglalas
{
    public int HelyszinAzonosito { get; }
    public DateTime Kezdete { get; }
    public DateTime Vege { get; }
    public int TanarAzonosito { get; }

    public Foglalas(DateTime kezdet, int idotartamPerc, int teremAzonosito, int tanarAzonosito)
    {
        if (idotartamPerc <= 0 || idotartamPerc % 15 != 0)
        {
            throw new IdotartamException();
        }

        Kezdete = kezdet;
        Vege = kezdet.AddMinutes(idotartamPerc);
        HelyszinAzonosito = teremAzonosito;
        TanarAzonosito = tanarAzonosito;
    }

    public override string ToString()
    {
        return $"Kezdet: {Kezdete:yyyy.MM.dd HH:mm}, Vég: {Vege:yyyy.MM.dd HH:mm}, Tanár azonosító: {TanarAzonosito}";
    }
}
