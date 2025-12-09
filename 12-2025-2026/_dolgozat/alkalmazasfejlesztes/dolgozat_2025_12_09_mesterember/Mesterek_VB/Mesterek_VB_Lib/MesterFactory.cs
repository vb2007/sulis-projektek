namespace Mesterek_VB_Lib;

public sealed class MesterFactory
{
    public MesterEmber Factory(string adatSor)
    {
        string[] adatElemek = adatSor.Split(';');

        char mesterTipus = char.Parse(adatElemek[0]);
        string mesterNeve = adatElemek[1];
        switch (mesterTipus)
        {
            case 'b':
                int mesterNapiDija = int.Parse(adatElemek[2]);
                string mesterSzakterulete = adatElemek[4];
                return new Burkolo(mesterNeve, mesterNapiDija, mesterSzakterulete);
                break;
            case 'v':
                int mesterTapasztalatEvei = int.Parse(adatElemek[2]);
                return new VizvezetekSzerelo(mesterNeve, mesterTapasztalatEvei);
                break;
            default:
                throw new InvalidDataException("A mester adattípusát 'v' vagy 'b' értékkel lehet csak megadni.");
        }
    }
}