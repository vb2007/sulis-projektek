namespace UtazasiCsomagok_VB_Lib;

public class UtazasFactory
{
    List<EgyszeruProgram> egyszeruProgramok = new();
    List<UtazasiProgram> utazasiCsomag = new();

    public UtazasFactory(IEnumerable<string> utazasAzonositoSorok, Programok programok)
    {
        foreach (string utazasAzonositok in utazasAzonositoSorok)
        {
            if (utazasAzonositok.Contains(';'))
            {
                IEnumerable<string> azonositok = utazasAzonositok.Split(';');

                //utazasiCsomag.Add(new EgyszeruProgram(programok[azonositok[0]]));
            }
            
            egyszeruProgramok.Add(new EgyszeruProgram(programok[utazasAzonositok]!));
        }
    }
}
