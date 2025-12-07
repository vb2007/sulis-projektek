namespace TortOsztaly_VB_Lib;

public class Tort
{
    public int Szamlalo { get; private set; }
    public int Nevezo { get; private set; }

    public Tort()
    {
        Szamlalo = 0;
        Nevezo = 1;
    }

    public Tort(int szamlalo, int nevezo)
    {
        if (nevezo == 0)
        {
            throw new ArgumentException("A nevező nem lehet 0!");
        }

        if (nevezo < 0)
        {
            szamlalo = -szamlalo;
            nevezo = -nevezo;
        }

        int lnko = LegnagyobbKozosOszto(Math.Abs(szamlalo), Math.Abs(nevezo));
        Szamlalo = szamlalo / lnko;
        Nevezo = nevezo / lnko;
    }

    private int LegnagyobbKozosOszto(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        
        return a;
    }

    public override string ToString()
    {
        if (Nevezo == 1)
        {
            return Szamlalo.ToString();
        }
        return $"{Szamlalo}/{Nevezo}";
    }

    public double TizedesErtek => (double)Szamlalo / Nevezo;

    //tört + tört
    public static Tort operator +(Tort a, Tort b)
    {
        int ujSzamlalo = a.Szamlalo * b.Nevezo + b.Szamlalo * a.Nevezo;
        int ujNevező = a.Nevezo * b.Nevezo;
        return new Tort(ujSzamlalo, ujNevező);
    }

    //tört - tört
    public static Tort operator -(Tort a, Tort b)
    {
        int ujSzamlalo = a.Szamlalo * b.Nevezo - b.Szamlalo * a.Nevezo;
        int ujNevező = a.Nevezo * b.Nevezo;
        return new Tort(ujSzamlalo, ujNevező);
    }

    //tört * tört
    public static Tort operator *(Tort a, Tort b)
    {
        int ujSzamlalo = a.Szamlalo * b.Szamlalo;
        int ujNevező = a.Nevezo * b.Nevezo;
        return new Tort(ujSzamlalo, ujNevező);
    }

    //tört / tört
    public static Tort operator /(Tort a, Tort b)
    {
        if (b.Szamlalo == 0)
        {
            throw new DivideByZeroException("Nullával nem lehet osztani!");
        }
        int ujSzamlalo = a.Szamlalo * b.Nevezo;
        int ujNevező = a.Nevezo * b.Szamlalo;
        return new Tort(ujSzamlalo, ujNevező);
    }

    //tört + int
    public static Tort operator +(Tort a, int b)
    {
        return a + new Tort(b, 1);
    }

    //int + tört
    public static Tort operator +(int a, Tort b)
    {
        return new Tort(a, 1) + b;
    }

    //tört - int
    public static Tort operator -(Tort a, int b)
    {
        return a - new Tort(b, 1);
    }

    //int - tört
    public static Tort operator -(int a, Tort b)
    {
        return new Tort(a, 1) - b;
    }

    //tört * int
    public static Tort operator *(Tort a, int b)
    {
        return a * new Tort(b, 1);
    }

    //int * tört
    public static Tort operator *(int a, Tort b)
    {
        return new Tort(a, 1) * b;
    }

    //tört / int
    public static Tort operator /(Tort a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Nullával nem lehet osztani!");
        }
        return a / new Tort(b, 1);
    }

    //int / tört
    public static Tort operator /(int a, Tort b)
    {
        return new Tort(a, 1) / b;
    }

    //tört == tört
    public static bool operator ==(Tort a, Tort b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Szamlalo * b.Nevezo == b.Szamlalo * a.Nevezo;
    }

    //tört != tört
    public static bool operator !=(Tort a, Tort b)
    {
        return !(a == b);
    }

    //tört < tört
    public static bool operator <(Tort a, Tort b)
    {
        return a.Szamlalo * b.Nevezo < b.Szamlalo * a.Nevezo;
    }

    //tört > tört
    public static bool operator >(Tort a, Tort b)
    {
        return a.Szamlalo * b.Nevezo > b.Szamlalo * a.Nevezo;
    }

    //tört <= tört
    public static bool operator <=(Tort a, Tort b)
    {
        return a < b || a == b;
    }

    //tört >= tört
    public static bool operator >=(Tort a, Tort b)
    {
        return a > b || a == b;
    }

    //int -> tört
    public static implicit operator Tort(int ertek)
    {
        return new Tort(ertek, 1);
    }

    //double -> tört
    public static implicit operator Tort(double ertek)
    {
        // Meghatározzuk a nevezőt (pl. 0.5 -> 1/2, 0.25 -> 1/4, stb.)
        int nevező = 1000000; // Pontosság
        int szamlalo = (int)(ertek * nevező);
        return new Tort(szamlalo, nevező);
    }

    //tört -> double
    public static implicit operator double(Tort tort)
    {
        return tort.TizedesErtek;
    }

    //tört -> int (matematikai kerekítés)
    public static explicit operator int(Tort tort)
    {
        return (int)Math.Round(tort.TizedesErtek);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Tort tort)
        {
            return this == tort;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Szamlalo, Nevezo);
    }
}
