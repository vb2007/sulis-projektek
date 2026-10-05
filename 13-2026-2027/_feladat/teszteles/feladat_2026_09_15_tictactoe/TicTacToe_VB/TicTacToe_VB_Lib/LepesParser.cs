namespace TicTacToe_VB_Lib
{
    public static class LepesParser
    {
        public static bool LepesFeldolgozas(string? bemenet, out int sor, out int oszlop)
        {
            sor = -1;
            oszlop = -1;

            if (string.IsNullOrWhiteSpace(bemenet))
            {
                return false;
            }

            string[] darabolt = bemenet.Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (darabolt.Length != 2
                || !int.TryParse(darabolt[0], out var oszlopInput)
                || !int.TryParse(darabolt[1], out var sorInput))
            {
                return false;
            }

            sor = sorInput - 1;
            oszlop = oszlopInput - 1;
            return sor >= 0 && sor < 3 && oszlop >= 0 && oszlop < 3;
        }
    }
}
