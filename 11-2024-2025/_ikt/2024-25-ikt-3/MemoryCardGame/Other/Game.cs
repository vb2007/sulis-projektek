using MemoryCardGame.Other;

namespace MemoryCardGame.Core
{
    public class Game
    {
        private int _rows;
        private int _columns;
        private string[,] _cards;
        private string[,] _displayCards;
        private bool[,] _revealedCards;
        private int _score = 0;
        private int _pairsFound = 0;

        public void Start()
        {
            Console.WriteLine(Draw.DrawStart());

            (_rows, _columns) = Handle.GetUserInputs();

            int requiredWidth = _columns * 7 + 2;
            int requiredHeight = _rows * 4 + 5;
            if (Console.WindowWidth < requiredWidth || Console.WindowHeight < requiredHeight)
            {

                try
                {
                    Console.WindowWidth = requiredWidth;
                    Console.WindowHeight = requiredHeight;
                }
                catch (Exception)
                {
                    Console.WriteLine("Hiba: A konzol ablak mérete nem állítható be automatikusan. Kérlek, manuálisan növeld a méretet.");
                    Console.ReadKey();
                    return;
                }
            }

            _cards = CardGenerator.GenerateCards(_rows, _columns);
            _displayCards = new string[_rows, _columns];
            _revealedCards = new bool[_rows, _columns];
            InitializeDisplayCards();
            Console.Clear();
            Draw.DrawCards(_displayCards, true, _rows, _columns, _score);
            Thread.Sleep(3000);

            PlayGame();

            Console.WriteLine(Draw.DrawEnd(_pairsFound == (_rows * _columns) / 2));
            if (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Start();
            }
        }

        private void InitializeDisplayCards()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _displayCards[i, j] = "[ ]";
                }
            }
        }
        private void PlayGame()
        {
            while (_pairsFound < (_rows * _columns) / 2)
            {
                Draw.DrawCards(_displayCards, false, _rows, _columns, _score);

                int[] firstCardCoords = GetCardSelection("Első kártya:");
                int row1 = firstCardCoords[0];
                int col1 = firstCardCoords[1];

                if (_revealedCards[row1, col1])
                {
                    string msg = "Ez a kártya már felfedve. Válassz másikat.";
                    Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
                    Console.WriteLine(msg);
                    Thread.Sleep(1500);
                    continue;
                }

                _displayCards[row1, col1] = _cards[row1, col1];
                Draw.DrawCards(_displayCards, false, _rows, _columns, _score);

                int[] secondCardCoords = GetCardSelection("Második kártya:");
                int row2 = secondCardCoords[0];
                int col2 = secondCardCoords[1];

                if (_revealedCards[row2, col2] || (row1 == row2 && col1 == col2))
                {
                    string msg = "Érvénytelen választás. Válassz másik kártyát.";
                    Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
                    Console.WriteLine(msg);
                    _displayCards[row1, col1] = "[ ]";
                    Thread.Sleep(1500);
                    continue;
                }

                _displayCards[row2, col2] = _cards[row2, col2];
                Draw.DrawCards(_displayCards, false, _rows, _columns, _score);


                if (_cards[row1, col1] == _cards[row2, col2])
                {
                    string msg = "Egyezés!";
                    Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
                    Console.WriteLine(msg);
                    _revealedCards[row1, col1] = true;
                    _revealedCards[row2, col2] = true;
                    _pairsFound++;
                    Thread.Sleep(1500);
                }
                else
                {
                    string msg = "Nincs egyezés.";
                    Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
                    Console.WriteLine(msg);
                    Thread.Sleep(1500);
                    _displayCards[row1, col1] = "[ ]";
                    _displayCards[row2, col2] = "[ ]";
                }
                _score++;
            }
        }

        private int[] GetCardSelection(string prompt)
        {
            while (true)
            {
                Console.SetCursorPosition((Console.WindowWidth - prompt.Length) / 2, Console.CursorTop);
                Console.WriteLine(prompt);
                int row = Handle.GetCoordinateInput("Sor (0-" + (_rows - 1) + "): ", _rows);
                int col = Handle.GetCoordinateInput("Oszlop (0-" + (_columns - 1) + "): ", _columns);

                return new int[] { row, col };
            }
        }
    }
}