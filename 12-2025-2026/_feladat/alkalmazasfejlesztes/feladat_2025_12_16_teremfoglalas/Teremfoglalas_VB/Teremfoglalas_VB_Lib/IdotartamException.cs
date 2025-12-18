namespace Teremfoglalas_VB_Lib;

public class IdotartamException : Exception
{
    public IdotartamException() : base("A lefoglalt időtartam nem pozitív, vagy nem 15-tel osztható.") { }
}