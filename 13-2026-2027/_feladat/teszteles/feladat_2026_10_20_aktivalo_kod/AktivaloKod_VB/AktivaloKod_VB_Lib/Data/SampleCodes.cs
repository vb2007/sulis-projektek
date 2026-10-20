namespace AktivaloKod_VB_Lib.Data
{
    public class SampleCodes
    {
        public static string valid1 = "KGCW-5321-JUAH";
        public static string valid2 = "AAAA-BBBB-JCG1";
        public static string valid3 = "CAJAVALA78G";
        public static string invalidMissingChars = "AAAA-BBBB-CCCC";
        public static string invalidDashPlacement = "--GGJJCCCC1234";
        public static string invalidTooManyJ = "ggjj-cccc-1234";
        public static string invalidTooManyDashes = "AA-AA-GC-GG-5J-T0";
        public static string invalidTooShort = "CAJAVA78G";
        public static string invalidTooLong = "JACA-UU1G-1MOP1";
        public static string invalidBadSplit = "JACA-UU1G1MOP1";

        public static string[] sampleCodeList =
            {
                "KGCW-5321-JUAH",
                "AAAA-BBBB-JCG1",
                "AAAA-BBBB-CCCC",
                "--GGJJCCCC1234",
                "ggjj-cccc-1234",
                "CAJAVALA78G",
                "AA-AA-GC-GG-5J-T0",
                "CAJAVA78G",
                "JACA-UU1G-1MOP1",
                "JACA-UU1G1MOP1",
            };
    }
}
