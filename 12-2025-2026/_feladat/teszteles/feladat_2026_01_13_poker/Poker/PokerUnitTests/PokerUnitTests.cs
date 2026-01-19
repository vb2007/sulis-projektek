using PokerLib;

namespace PokerUnitTests;

[TestFixture]
public class PokerUnitTests
{
    private Poker _poker;

    [SetUp]
    public void Setup()
    {
        _poker = new Poker();
    }

    [Test]
    public void AddPlayersShouldAddTwoPlayers()
    {
        _poker.AddPlayers(2);

        Assert.That(_poker.PlayerCount, Is.EqualTo(2));
        Assert.That(_poker.Hands.Count, Is.EqualTo(2));
    }

    [Test]
    public void DealShouldGiveFiveCardsToEachPlayer()
    {
        _poker.AddPlayers(3);

        _poker.Deal();

        foreach (Hand hand in _poker.Hands)
        {
            Assert.That(hand.Cards.Count, Is.EqualTo(5));
        }
    }

    [Test]
    public void PickWinnerShouldSelectPlayerWithRoyalFlush()
    {
        _poker.AddPlayers(2);
        
        // p0: sima kéz
        _poker.Hands[0].AddCard(Hand.Faces.Two, Hand.Suites.Hearts);
        _poker.Hands[0].AddCard(Hand.Faces.Three, Hand.Suites.Diamonds);
        _poker.Hands[0].AddCard(Hand.Faces.Four, Hand.Suites.Clubs);
        _poker.Hands[0].AddCard(Hand.Faces.Five, Hand.Suites.Spades);
        _poker.Hands[0].AddCard(Hand.Faces.Seven, Hand.Suites.Hearts);
        
        //p1: royal flush
        _poker.Hands[1].AddCard(Hand.Faces.Ten, Hand.Suites.Hearts);
        _poker.Hands[1].AddCard(Hand.Faces.Jack, Hand.Suites.Hearts);
        _poker.Hands[1].AddCard(Hand.Faces.Queen, Hand.Suites.Hearts);
        _poker.Hands[1].AddCard(Hand.Faces.King, Hand.Suites.Hearts);
        _poker.Hands[1].AddCard(Hand.Faces.Ace, Hand.Suites.Hearts);

        int winner = _poker.PickWinner();

        Assert.That(winner, Is.EqualTo(1));
    }

    [Test]
    public void PickWinnerShouldSelectCorrectWinnerWithMultiplePlayers()
    {
        _poker.AddPlayers(4);
        
        //p0: sima kéz
        _poker.Hands[0].AddCard(Hand.Faces.Two, Hand.Suites.Hearts);
        _poker.Hands[0].AddCard(Hand.Faces.Three, Hand.Suites.Diamonds);
        _poker.Hands[0].AddCard(Hand.Faces.Four, Hand.Suites.Clubs);
        _poker.Hands[0].AddCard(Hand.Faces.Five, Hand.Suites.Spades);
        _poker.Hands[0].AddCard(Hand.Faces.Seven, Hand.Suites.Hearts);
        
        //p1: sima kéz
        _poker.Hands[1].AddCard(Hand.Faces.Two, Hand.Suites.Clubs);
        _poker.Hands[1].AddCard(Hand.Faces.Three, Hand.Suites.Clubs);
        _poker.Hands[1].AddCard(Hand.Faces.Four, Hand.Suites.Hearts);
        _poker.Hands[1].AddCard(Hand.Faces.Six, Hand.Suites.Spades);
        _poker.Hands[1].AddCard(Hand.Faces.Eight, Hand.Suites.Hearts);
        
        //p2(nyertes): royal flush
        _poker.Hands[2].AddCard(Hand.Faces.Ten, Hand.Suites.Diamonds);
        _poker.Hands[2].AddCard(Hand.Faces.Jack, Hand.Suites.Diamonds);
        _poker.Hands[2].AddCard(Hand.Faces.Queen, Hand.Suites.Diamonds);
        _poker.Hands[2].AddCard(Hand.Faces.King, Hand.Suites.Diamonds);
        _poker.Hands[2].AddCard(Hand.Faces.Ace, Hand.Suites.Diamonds);
        
        //p3: sima kéz
        _poker.Hands[3].AddCard(Hand.Faces.Nine, Hand.Suites.Hearts);
        _poker.Hands[3].AddCard(Hand.Faces.Ten, Hand.Suites.Clubs);
        _poker.Hands[3].AddCard(Hand.Faces.Jack, Hand.Suites.Spades);
        _poker.Hands[3].AddCard(Hand.Faces.Queen, Hand.Suites.Clubs);
        _poker.Hands[3].AddCard(Hand.Faces.King, Hand.Suites.Spades);

        int winner = _poker.PickWinner();

        Assert.That(winner, Is.EqualTo(2));
    }
}
