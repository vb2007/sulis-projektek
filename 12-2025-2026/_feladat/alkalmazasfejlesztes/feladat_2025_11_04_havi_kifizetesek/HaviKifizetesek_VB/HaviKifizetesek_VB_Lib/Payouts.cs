namespace HaviKifizetesek_VB_Lib;

public class Payouts
{
    private readonly List<Payout> _payouts = new();
    private static readonly int[] Denominations = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100 };

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

    private Dictionary<int, int> GetDenominationsForAmount(int amount)
    {
        Dictionary<int, int> result = new();
        int remaining = amount;

        foreach (int denomination in Denominations)
        {
            int count = remaining / denomination;
            if (count > 0)
            {
                result[denomination] = count;
                remaining %= denomination;
            }
        }

        return result;
    }

    public Dictionary<int, int> GetTotalDenominations() =>
        RoundedUniquePayouts
            .SelectMany(p => GetDenominationsForAmount(p.Amount))
            .GroupBy(x => x.Key)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.Value));
}
