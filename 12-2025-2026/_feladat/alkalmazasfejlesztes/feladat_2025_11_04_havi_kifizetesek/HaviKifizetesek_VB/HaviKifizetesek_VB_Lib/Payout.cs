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

    public Payout(string name, int amount)
    {
        Name = name;
        Amount = amount;
    }
    
    public string Monogram
    {
        get
        {
            string[] nameParts = Name.Split(' ');
            return $"{nameParts[0][0]} {nameParts[1][0]}";
        }
    }
}
