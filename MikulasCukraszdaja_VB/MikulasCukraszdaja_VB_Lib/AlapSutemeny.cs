namespace MikulasCukraszdaja_VB_Lib
{
    public sealed class AlapSutemeny : Sutemeny
    {
        public override int ElkeszitesiIdo =>
            KeszitesiAdatok[Azonosito].ElkeszitesiIdo;

        public AlapSutemeny(string azonosito, string tipus, string megnevezes, KeszitesiAdatok keszitesiAdatok)
            : base(azonosito, tipus, megnevezes, keszitesiAdatok)
        {
            
        }
    }
}
