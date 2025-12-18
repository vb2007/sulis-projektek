namespace Teremfoglalas_VB_Lib;

public class FoglalasException : Exception
{
    public FoglalasException() : base("A kért időpontban a terem nem foglalható.") { }
}
