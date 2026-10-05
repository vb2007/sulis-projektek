namespace TicTacToe_VB_Lib
{
    public static class GyoztesCheck
    {
        public static bool VanNyertes(Tabla tabla, char jatekos)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((tabla.Cella(i, 0) == jatekos && tabla.Cella(i, 1) == jatekos && tabla.Cella(i, 2) == jatekos)
                    || (tabla.Cella(0, i) == jatekos && tabla.Cella(1, i) == jatekos && tabla.Cella(2, i) == jatekos))
                {
                    return true;
                }
            }

            return (tabla.Cella(0, 0) == jatekos && tabla.Cella(1, 1) == jatekos && tabla.Cella(2, 2) == jatekos)
                   || (tabla.Cella(0, 2) == jatekos && tabla.Cella(1, 1) == jatekos && tabla.Cella(2, 0) == jatekos);
        }
    }
}
