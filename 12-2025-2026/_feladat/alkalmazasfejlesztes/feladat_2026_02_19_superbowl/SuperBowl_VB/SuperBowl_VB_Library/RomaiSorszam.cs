namespace SuperBowl_VB_Library;

public class RomaiSorszam
{
    public string RomaiSorszamString { get; private set; }

    public static Dictionary<char, int> RomaiMap = new Dictionary<char, int>()
    {
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
    };

    public int ArabSorszam
    {
        get
        {
            int ertek = 0;
            string romaiSzam = RomaiSorszamString.TrimEnd('.');

            for (int i = 0; i < romaiSzam.Length; i++)
            {
                if (i + 1 < romaiSzam.Length &&
                    RomaiMap[romaiSzam[i]] < RomaiMap[romaiSzam[i + 1]])
                {
                    ertek -= RomaiMap[romaiSzam[i]];
                }
                else
                {
                    ertek += RomaiMap[romaiSzam[i]];
                }
            }

            return ertek;
        }
    }

    public RomaiSorszam(string romaiSsz)
    {
        RomaiSorszamString = romaiSsz.ToUpper();
    }
}
