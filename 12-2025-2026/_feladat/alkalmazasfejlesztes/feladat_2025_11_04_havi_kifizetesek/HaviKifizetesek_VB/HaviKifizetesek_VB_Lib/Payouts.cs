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
}