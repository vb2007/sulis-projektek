namespace JoAlany_VB_Lib;

public class Szemely
{
    //get=később módosítható az értéke, init=beállítás után nem felülírható az értéke
    public string SzemelyNev { get; init; }
    public DateTime SzuletesiDatum { get; init; }
    public int kor;
    public int Kor => kor;
    
    public Szemely(int kor, string szemelyNev, DateTime szuletesiDatum)
    {
        SzemelyNev = szemelyNev ?? throw new ArgumentNullException(nameof(szemelyNev));
        SzuletesiDatum = szuletesiDatum;
        int korTest = DateTime.Today.Year - szuletesiDatum.Year;
        if (korTest < 14)
        {
            throw new HibasEletkorException();
        }
        else
        {
            this.kor = korTest;
        }
    }

    public override string ToString()
    {
        return $"{SzemelyNev} ({Kor} éves)";
    }
}