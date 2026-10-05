using System.Text;

namespace TicTacToe_VB_Lib
{
    public static class TablaMegjelenito
    {
        public static string Kirajzol(Matrix jatek)
        {
            StringBuilder szoveg = new StringBuilder();

            for (int sor = 0; sor < 3; sor++)
            {
                szoveg.AppendLine($" {jatek.Cella(sor, 0)} | {jatek.Cella(sor, 1)} | {jatek.Cella(sor, 2)} ");
                if (sor < 2)
                {
                    szoveg.AppendLine("---+---+---");
                }
            }

            return szoveg.ToString();
        }
    }
}
