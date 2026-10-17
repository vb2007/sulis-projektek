namespace Teasdobozok_VB_Lib
{
    public static class DobozFactory
    {
        public static TeasDoboz? Factory(string adatsor, Filterek filterek)
        {
            if (string.IsNullOrWhiteSpace(adatsor) || adatsor.StartsWith("Darabszam;"))
            {
                return null;
            }

            string[] adatok = adatsor.Split(';');
            int darabSzam = int.Parse(adatok[0]);
            string[] filterAzonositok = adatok.Skip(1).ToArray();

            if (filterAzonositok.Length == 1)
            {
                return new EgyszeruDoboz(darabSzam, filterAzonositok[0], filterek);
            }

            ValogatasDoboz doboz = new(darabSzam, filterek);
            foreach (string filterAzonosito in filterAzonositok)
            {
                doboz += filterAzonosito;
            }

            return doboz;
        }
    }
}
