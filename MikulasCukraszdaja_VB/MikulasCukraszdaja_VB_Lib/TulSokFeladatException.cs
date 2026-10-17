namespace MikulasCukraszdaja_VB_Lib
{
    public class TulSokFeladatException : Exception
    {
        public TulSokFeladatException() : base("Túl sok feladat, több mint 8 óra elkészíteni.") { }
    }
}
