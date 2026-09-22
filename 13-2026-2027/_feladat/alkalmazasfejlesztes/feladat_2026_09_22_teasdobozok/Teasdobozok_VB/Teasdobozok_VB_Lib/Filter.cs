namespace Teasdobozok_VB_Lib
{
    internal class Filter
    {
        public string Id { get; set; }
        public string Tipus { get; set; }
        public int Ar { get; set; }

        public Filter(string id, string tipus, int ar)
        {
            Id = id;
            Tipus = tipus;
            Ar = ar;
        }

        //public bool Gyogytea
        //{
        //    get
        //    {
        //        return Tipus.StartsWith('z') ? true : false;
        //    }
        //}

        public bool Gogytea =>
            Tipus.StartsWith('z') ? true : false;

        public override string ToString()
        {
            return $"{Tipus} ({Ar} Ft)";
        }
    }
}
