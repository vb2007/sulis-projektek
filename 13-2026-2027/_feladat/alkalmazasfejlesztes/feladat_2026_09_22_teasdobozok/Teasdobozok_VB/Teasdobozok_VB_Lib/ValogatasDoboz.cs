namespace Teasdobozok_VB_Lib
{
    public sealed class ValogatasDoboz : TeasDoboz
    {
        private readonly Filterek _filterek;
        private readonly List<string> _filterAzonositok;

        public override int Ar => _filterAzonositok.Sum(filterAzonosito => _filterek[filterAzonosito].Ar) + 100;

        public string FilterTipusokString => string.Join(", ",
            _filterAzonositok
                .Select(filterAzonosito => _filterek[filterAzonosito].Tipus)
                .Distinct());

        public override string Nev =>
            string.IsNullOrWhiteSpace(FilterTipusokString)
                ? "Válogatás tea"
                : $"Válogatás tea - {FilterTipusokString}";

        public ValogatasDoboz(int darabSzam, Filterek filterek)
            : this(darabSzam, filterek, Enumerable.Empty<string>())
        {
        }

        private ValogatasDoboz(int darabSzam, Filterek filterek, IEnumerable<string> filterAzonositok)
            : base(darabSzam)
        {
            _filterek = filterek;
            _filterAzonositok = new List<string>();

            foreach (string filterAzonosito in filterAzonositok)
            {
                _ = filterek[filterAzonosito];
                _filterAzonositok.Add(filterAzonosito);
            }
        }

        public static ValogatasDoboz operator +(ValogatasDoboz doboz, string filterAzonosito)
        {
            List<string> ujFilterAzonositok = new(doboz._filterAzonositok)
            {
                filterAzonosito
            };

            return new ValogatasDoboz(doboz.DarabSzam, doboz._filterek, ujFilterAzonositok);
        }
    }
}
