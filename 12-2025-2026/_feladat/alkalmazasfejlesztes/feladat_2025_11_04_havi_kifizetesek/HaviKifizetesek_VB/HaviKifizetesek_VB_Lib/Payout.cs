namespace HaviKifizetesek_VB_Lib;

public class Payout
{
    public string Name { get; set; }
    public int Amount { get; set; }

    public Payout(string dataLine)
    {
        string[] values = dataLine.Split(';');
        
        Name = values[0];
        Amount = int.Parse(values[1]);
    }
}