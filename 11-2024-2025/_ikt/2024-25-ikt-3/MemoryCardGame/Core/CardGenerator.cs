namespace MemoryCardGame.Core
{
    public class CardGenerator
    {
        public static string[,] GenerateCards(int rows, int columns)
        {
            if ((rows * columns) % 2 != 0)
            {
                throw new ArgumentException("A kártyák számának párosnak kell lennie.");
            }
            List<string> cardValues = new List<string>();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
            int numPairs = (rows * columns) / 2;

            for (int i = 0; i < numPairs; i++)
            {
                string cardValue = "[" + characters[i % characters.Length] + "]";
                cardValues.Add(cardValue);
                cardValues.Add(cardValue);
            }

            Random rng = new Random();
            int n = cardValues.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = cardValues[k];
                cardValues[k] = cardValues[n];
                cardValues[n] = value;
            }

            string[,] cards = new string[rows, columns];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cards[i, j] = cardValues[index++];
                }
            }
            return cards;
        }
    }
}