namespace Lift_VB_Lib;

public class HibasIranyException : Exception
{
    public HibasIranyException() : base("Hibás irány!") {}
    public HibasIranyException(string message) : base(message) {}
}
