namespace Alapfilmek_VB_Lib.Tables
{
    internal class Munkakor
    {
        public int MunkakorAzonosito { get; init; }
        public string MunkakorNev {  get; init; }

        internal Munkakor(string dataLine)
        {
            string[] split = dataLine.Split('\t');

            MunkakorAzonosito = int.Parse(split[0]);
            MunkakorNev = split[1];
        }
    }
}
