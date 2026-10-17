namespace MikulasCukraszdaja_VB_Lib
{
    public sealed class AlapSutemeny : Sutemeny
    {
        public override int ElkeszitesiIdo =>
            KeszitesAdatok[Azonosito].ElkeszitesiIdo;

        public AlapSutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok keszitesAdatok)
            : base(azonosito, tipus, megnevezes, keszitesAdatok)
        {
            
        }
    }
}
