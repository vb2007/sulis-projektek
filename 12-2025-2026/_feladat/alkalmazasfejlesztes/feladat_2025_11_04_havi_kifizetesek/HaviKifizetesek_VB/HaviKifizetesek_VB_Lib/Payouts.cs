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

    private int? this[string name]
    {
        get
        {
            if (_payouts.Any(x => x.Name == name))
                return _payouts.Where(x => x.Name == name).Sum(x => x.Amount);
            return null;
        }
    }

    public List<Payout> RoundedUniquePayouts =>
        _payouts
            .GroupBy(x => x.Name)
            .Select(x => new Payout(
                x.Key, 
                (int)Math.Round(this[x.Key]!.Value / 100.0) * 100))
            .OrderBy(x => x.Name)
            .ToList();
}
