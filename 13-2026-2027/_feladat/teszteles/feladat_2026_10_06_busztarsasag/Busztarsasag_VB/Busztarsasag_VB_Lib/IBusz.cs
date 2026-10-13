namespace Busztarsasag_VB_Lib;

public interface IBusz
{
    string Rendszam { get; }
    int Ferohely { get; }
    int Utasok { get; }
    int OsszesSzallitott { get; }

    void Leszall(int db);

    int Felszall(int db); //visszaadja hányan szálltak fel ténylegesen

    void NapVege();
}
