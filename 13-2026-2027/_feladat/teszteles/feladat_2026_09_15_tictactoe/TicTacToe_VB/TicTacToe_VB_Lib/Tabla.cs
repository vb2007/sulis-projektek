namespace TicTacToe_VB_Lib
{
    internal class Tabla
    {
        private readonly char[,] _cellak =
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        public char Cella(int sor, int oszlop)
        {
            if (!TablanBelul(sor, oszlop))
            {
                return ' ';
            }

            return _cellak[sor, oszlop];
        }

        public bool Iras(int sor, int oszlop, char jel)
        {
            if (!TablanBelul(sor, oszlop))
            {
                return false;
            }

            if (_cellak[sor, oszlop] != ' ')
            {
                return false;
            }

            _cellak[sor, oszlop] = jel;
            return true;
        }

        public bool TeleVan()
        {
            for (int sor = 0; sor < 3; sor++)
            {
                for (int oszlop = 0; oszlop < 3; oszlop++)
                {
                    if (_cellak[sor, oszlop] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool TablanBelul(int sor, int oszlop)
        {
            return sor >= 0 && sor < 3 && oszlop >= 0 && oszlop < 3;
        }
    }
}
