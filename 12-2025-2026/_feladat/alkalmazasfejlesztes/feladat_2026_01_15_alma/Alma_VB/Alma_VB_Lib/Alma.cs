namespace Alma_VB_Lib;

public class Alma
{
    private const int KEZDO_MERET = 5; //mm
    private const int NOVEKEDES_LEPES_IDO = 2; //sec
    private readonly (int, int) NOVEKEDES_MERET = (1, 3); //mm
    private const int ERESHATAR_MERET = 80; //mm
    private const int ERES_LEPES_IDO = 5; //sec
    private readonly (int, int) ERES_SZAZALEK = (5, 10); //%
    private const int PERC = 60;
    private readonly (int, int) ROHADAS_IDO = (2 * PERC, 5 * PERC);
    private const int HALAL_IDO = 5 * PERC;
}