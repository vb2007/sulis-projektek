namespace UtazasiCsomagok_VB_Lib;

public class HibasProgramException : Exception
{
    public HibasProgramException() : base ("A megadott programazonosító nem létezik.") { }
}
