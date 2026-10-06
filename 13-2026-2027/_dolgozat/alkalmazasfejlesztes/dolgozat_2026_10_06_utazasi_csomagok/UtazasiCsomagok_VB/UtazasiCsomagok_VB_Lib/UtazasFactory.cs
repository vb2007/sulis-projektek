namespace UtazasiCsomagok_VB_Lib;

public static class UtazasFactory
{
    public static ProgramElem Factory(string utazasAzonositoSor, Programok programok)
    {
        string[] azonositok = utazasAzonositoSor.Split(';');

        if (azonositok.Length == 1)
        {
            return new EgyszeruProgram(programok[azonositok[0]]);
        }

        UtazasiCsomag utazasiCsomag = new([]);
        foreach (string azonosito in azonositok)
        {
            utazasiCsomag += programok[azonosito];
        }

        return utazasiCsomag;
    }
}
