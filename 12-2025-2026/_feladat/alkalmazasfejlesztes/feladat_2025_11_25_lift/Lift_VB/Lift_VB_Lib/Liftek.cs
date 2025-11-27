namespace Lift_VB_Lib;

public class Liftek
{
    private readonly List<Lift> _liftek;

    public Liftek(IEnumerable<string> sorok)
    {
        
    }

    public Lift this[int sorszam]
    {
        get { return _liftek[sorszam]; }
    }
}