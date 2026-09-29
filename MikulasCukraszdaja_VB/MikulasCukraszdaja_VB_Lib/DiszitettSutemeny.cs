namespace MikulasCukraszdaja_VB_Lib
{
    public class DiszitettSutemeny : Sutemeny
    {
        public override int ElkeszitesiIdo => throw new NotImplementedException();

        public DiszitettSutemeny(string azonosito, string tipus, string megnevezes, KeszitesAdatok keszitesAdatok)
            : base(azonosito, tipus, megnevezes, keszitesAdatok)
        {

        }
    }
}
