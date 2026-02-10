namespace Konyvtar_VB
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public override string ToString() => $"{Title} - {Author}";
    }
}
