namespace PokerLib;

public class Poker
{
    public int PlayerCount => Hands.Count;
    private List<Hand.Card> _deck = new();

    public void AddPlayers(int playerCount)
    {
        for (int i = 0; i < playerCount; i++)
        {
            Hands.Add(new Hand());
        }
    }

    public List<Hand> Hands = new();

    public void Deal()
    {
        foreach (var hand in Hands)
        {
            hand.RemoveAllCards();
        }

        var deck = new List<Hand.Card>();
        foreach (var suite in Enum.GetValues(typeof(Hand.Suites)).Cast<Hand.Suites>())
        {
            foreach (var face in Enum.GetValues(typeof(Hand.Faces)).Cast<Hand.Faces>())
            {
                deck.Add(new Hand.Card() { Face = face, Suite = suite });
            }
        }

        _deck = new(deck.Shuffle());

        for (int i = 0; i < 5; i++)
        {
            _deck.RemoveAt(0);
            foreach (var hand in Hands)
            {
                var card = _deck[0];
                _deck.RemoveAt(0);
                hand.AddCard(card.Face, card.Suite);
            }
        }
    }

    public int PickWinner()
    {
        int maxIndex = 0;
        int maxRank = 0;
        for (int i = 0; i < Hands.Count; i++)
        {
            if (maxRank < Rank(i))
            {
                maxRank = Rank(i);
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    private int Rank(int playerIndex)
    {
        var hand = Hands[playerIndex];
        if (hand.IsRoyalFlush()) return 1000000;
        return 0;
    }
}