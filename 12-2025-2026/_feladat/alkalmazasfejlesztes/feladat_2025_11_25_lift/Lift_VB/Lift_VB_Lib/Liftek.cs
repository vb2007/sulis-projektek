namespace Lift_VB_Lib;

public class Liftek
{
    private readonly List<Lift> _liftek;

    public Liftek(IEnumerable<Lift> liftek)
    {
        _liftek = new List<Lift>(liftek);
    }

    public Lift this[int sorszam]
    {
        get
        {
            if (sorszam < 1 || sorszam > _liftek.Count)
                throw new IndexOutOfRangeException($"Nincs {sorszam}. számú lift!");
            return _liftek[sorszam - 1];
        }
    }
}
