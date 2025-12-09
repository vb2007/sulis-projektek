namespace Mesterek_VB_Lib;

public sealed class Burkolo : MesterEmber
{
    public string Szakterulet { get; set; }
    
    public Burkolo(string nev, int napiDij, string szakterulet) : base(nev, napiDij)
    {
        if (szakterulet != "belső" && szakterulet != "külső")
        {
            throw new ArgumentException("A szakterület értéke csak \"belső\" vagy \"külső\" lehet!");
        }

        Szakterulet = szakterulet;
    }

    public bool MunkatVallal(int nap)
    {
        if (!this[nap])
        {
            return false;
        }
        
        if (SzabadnapokSzama < 10)
        {
            throw new TulSokElfoglaltsagException();
        }
        
        Elfoglaltsag[nap - 1] = false;
        
        return true;
    }
    
    public override string ToString()
    {
        return $"Neve: {Nev}, Szakterülete: {(Szakterulet == "belső" ? "burkoló" : "vízvezeték szerelő")} Napidíja: {NapiDij}, Szabadnapok: {string.Join(", ", FoglalhatoNapok())}";
    }
}