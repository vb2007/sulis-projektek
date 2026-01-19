namespace PokerLib;

public class Hand
{
    public enum Suites
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public enum Faces
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public struct Card
    {
        public Suites Suite;
        public Faces Face;
    }

    public List<Card> Cards { get; set; } = new();

    public bool AddCard(Faces face, Suites suite)
    {
        if (Cards.Count >= 5) 
            return false;
        Card newCard = new() { Face = face, Suite = suite };
        if (HasInHand(newCard)) 
            return false;
        Cards.Add(newCard);
        return true;
    }

    private bool HasInHand(Card newCard)
    {
        return Cards.Any(card => 
            card.Face == newCard.Face 
            && card.Suite == newCard.Suite);
    }

    public void AddHand(string hand)
    {
        foreach (var card in hand.Split(","))
        {
            var trimmedCard = card.Trim();
            if (trimmedCard.Length < 2) return;
            Suites suite;
            switch (trimmedCard[0])
            {
                case 'H': suite = Suites.Hearts; break;
                case 'D': suite = Suites.Diamonds; break;
                case 'S': suite = Suites.Spades; break;
                case 'C': suite = Suites.Clubs; break;
                default: return;
            }

            trimmedCard = trimmedCard.Substring(1);
            Faces face;
            switch (trimmedCard)
            {
                case "A": face = Faces.Ace; break;
                case "2": face = Faces.Two; break;
                case "3": face = Faces.Three; break;
                case "4": face = Faces.Four; break;
                case "5": face = Faces.Five; break;
                case "6": face = Faces.Six; break;
                case "7": face = Faces.Seven; break;
                case "8": face = Faces.Eight; break;
                case "9": face = Faces.Nine; break;
                case "10": face = Faces.Ten; break;
                case "J": face = Faces.Jack; break;
                case "Q": face = Faces.Queen; break;
                case "K": face = Faces.King; break;
                default: return;
            }

            AddCard(face, suite);
        }
        
    }

    public void RemoveAllCards()
    {
        Cards.Clear();
    }

    public bool IsRoyalFlush()
    {
        if (Cards.Count != 5) return false;
        Suites suite = Cards[0].Suite;
        if (Cards.Any(card => card.Suite != suite))
        {
            return false;
        }

        if (!HasInHand(new Card() { Suite = suite, Face = Faces.Ace })) 
            return false;
        if (!HasInHand(new Card() { Suite = suite, Face = Faces.King })) 
            return false;
        if (!HasInHand(new Card() { Suite = suite, Face = Faces.Queen })) 
            return false;
        if (!HasInHand(new Card() { Suite = suite, Face = Faces.Jack })) 
            return false;
        if (!HasInHand(new Card() { Suite = suite, Face = Faces.Ten })) 
            return false;
        return true;
    }
}