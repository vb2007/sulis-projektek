namespace AktivaloKod_VB_Lib.Data
{
    public class ErrorMessages
    {
        public const string ErrorNull = "A kód nem lehet null.";
        public const string ErrorFormat = "A kód formátuma hibás (XXXX-XXXX-XXXX vagy 12 karakter kötőjel nélkül, csak betűk és számjegyek).";
        public const string ErrorMissingG = "A kód nem tartalmaz G betűt.";
        public const string ErrorMissingC = "A kód nem tartalmaz C betűt.";
        public const string ErrorJCount = "A kódnak pontosan egy J betűt kell tartalmaznia.";
        public const string ErrorMissingDigit = "A kód nem tartalmaz számjegyet.";
    }
}
