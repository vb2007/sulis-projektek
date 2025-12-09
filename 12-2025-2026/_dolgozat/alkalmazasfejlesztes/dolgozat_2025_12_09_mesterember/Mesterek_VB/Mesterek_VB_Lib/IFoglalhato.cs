namespace Mesterek_VB_Lib;

public interface IFoglalhato
{
    IEnumerable<int> FoglalhatoNapok();
    int SzabadnapokSzama { get; }
}