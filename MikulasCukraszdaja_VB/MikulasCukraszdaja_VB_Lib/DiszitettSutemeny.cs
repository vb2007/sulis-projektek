namespace MikulasCukraszdaja_VB_Lib
{
    public sealed class DiszitettSutemeny : Sutemeny
    {
        private readonly IEnumerable<string> _osszetevoAzonositok;

        public override int ElkeszitesiIdo =>
            _osszetevoAzonositok
                .Select(TipusMeghatarozas)
                .Sum(x => KeszitesAdatok[x].ElkeszitesiIdo);

        public DiszitettSutemeny(
            string azonosito,
            string tipus,
            string megnevezes,
            KeszitesAdatok keszitesAdatok,
            IEnumerable<string> osszetevoAzonositok)
            : base(azonosito, tipus, megnevezes, keszitesAdatok)
        {
            _osszetevoAzonositok = osszetevoAzonositok;
        }

        public string TipusMeghatarozas(string osszetevoAzonosito)
        {
            if (osszetevoAzonosito.StartsWith('d'))
            {
                return osszetevoAzonosito;
            }

            return osszetevoAzonosito[0].ToString();
        }
    }
}
