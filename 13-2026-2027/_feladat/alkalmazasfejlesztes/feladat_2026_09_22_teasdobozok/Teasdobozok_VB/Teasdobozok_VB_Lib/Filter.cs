namespace Teasdobozok_VB_Lib
{
    public class Filter
    {
        public string Id { get; init; }
        public string Tipus { get; init; }
        public int Ar { get; init; }
        public bool Gyogytea => Id.StartsWith('z');

        public Filter(string id, string tipus, int ar)
        {
            Id = id;
            Tipus = tipus;
            Ar = ar;
        }

        public override string ToString()
        {
            return $"{Tipus} ({Ar} Ft)";
        }
    }
}
