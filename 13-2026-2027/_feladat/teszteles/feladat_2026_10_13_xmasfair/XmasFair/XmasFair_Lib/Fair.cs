using System.Globalization;

namespace XmasFair_Lib
{
    public class Fair
    {
        private const string DateFormat = "yyyy.MM.dd";

        public string Name { get; }
        public int StandCount { get; }
        public int StandPrice { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Fair(string name, int standCount, int standPrice, string startDate, string endDate)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A vásárnak kell nevet adni.", nameof(name));
            }
            
            if (standCount < 0)
            {
                throw new ArgumentException("A standok száma nem lehet negatív.", nameof(standCount));
            }
               
            if (standPrice < 0)
            {
                throw new ArgumentException("A stand ára nem lehet negatív.", nameof(standPrice));
            }

            StartDate = ParseDate(startDate, nameof(startDate));
            EndDate = ParseDate(endDate, nameof(endDate));
            if (EndDate < StartDate)
            {
                throw new ArgumentException("A végdátum nem lehet korábbi a kezdő dátumnál.", nameof(endDate));
            }

            Name = name;
            StandCount = standCount;
            StandPrice = standPrice;
        }

        private static DateTime ParseDate(string value, string paramName)
        {
            if (!DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                throw new ArgumentException($"A dátum formátuma érvénytelen (elvárt: {DateFormat}).", paramName);
            }
            
            return date;
        }
    }
}
