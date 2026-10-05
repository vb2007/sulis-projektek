namespace TicTacToe_VB_Lib
{
    public class Matrix
    {
        private readonly Tabla _tabla = new();

        public char AktivJatekos { get; private set; } = 'X';

        public bool JatekVege { get; private set; }

        public char Nyertes { get; private set; } = ' ';

        public char Cella(int sor, int oszlop) => _tabla.Cella(sor, oszlop);

        public bool Lepes(int sor, int oszlop)
        {
            if (JatekVege)
                return false;

            if (!_tabla.Iras(sor, oszlop, AktivJatekos))
                return false;

            if (GyoztesCheck.VanNyertes(_tabla, AktivJatekos))
            {
                Nyertes = AktivJatekos;
                JatekVege = true;
                return true;
            }

            if (_tabla.TeleVan())
            {
                JatekVege = true;
                return true;
            }

            AktivJatekos = AktivJatekos == 'X' ? 'O' : 'X';
            return true;
        }
    }
}
