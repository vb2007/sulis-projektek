namespace Mesterek_VB_Lib;

public class TulSokElfoglaltsagException : Exception
{
    public TulSokElfoglaltsagException() : base("A mester túl sok munkát vállalt!") { }
}