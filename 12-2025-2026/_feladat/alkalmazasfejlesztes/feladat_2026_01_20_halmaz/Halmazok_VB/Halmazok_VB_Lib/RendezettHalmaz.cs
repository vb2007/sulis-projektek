namespace Halmazok_VB_Lib;

public class RendezettHalmaz<T> : Halmaz<T> where T : IComparable<T>
{
    public RendezettHalmaz() : base() { }

    public RendezettHalmaz(IEnumerable<T> gyujtemeny) : base()
    {
        foreach (T elem in gyujtemeny)
        {
            Hozzaad(elem);
        }
    }

    public override bool Tartalmazza(T elem)
    {
        return _elemek.BinarySearch(elem) >= 0;
    }

    public override void Hozzaad(T elem)
    {
        int index = _elemek.BinarySearch(elem);

        if (index < 0)
        {
            _elemek.Insert(~index, elem);
        }
    }
}