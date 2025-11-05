namespace HaviKifizetesek_VB_Lib;

public class Payouts
{
    public readonly List<Payout> _payouts = new();

    public Payouts(IEnumerable<string> dataLines)
    {
        foreach (string dataLine in dataLines)
        {
            _payouts.Add(new Payout(dataLine));
        }
    }

    public int? this[string name]
    {
        get
        {
            if (_payouts.Any(x => x.Name == name))
                return _payouts.Where(x => x.Name == name).Sum(x => x.Amount);
            return null;
        }
    }
}